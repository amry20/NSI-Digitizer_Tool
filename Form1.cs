using SimpleTCP;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Reflection.PortableExecutable;
using System.Runtime.Intrinsics.X86;
using System.ComponentModel;
using System;
using System.Runtime.InteropServices;
using System.IO;
using System.IO.Ports;

namespace NSI_AD24_Digitizer_Tool
{
    public partial class MainForm : Form
    {
        enum Opcode
        {
            IlegalOpcode = 0,
            Handshake = 3,
            Reboot = 6,
            GetVersion = 9,
            GetComSetting = 12,
            GetAdcSetting = 15,
            GetLoggerSetting = 18,
            GetUtilitiesSetting = 21,
            ReadyToStream = 24,
            ClearEEPROMData = 27,
            StopReceiveStream = 30,
            DisconnectFromClient = 33, // not used
            ResetDefault = 36,
            WriteFactoryData = 39,
            TurnAlarm = 42,
            SaveNetworkSetting = 45,
            SaveADCSetting = 48,
            SaveLoggerSetting = 51,
            SaveUtilitiesSetting = 54,
            Heartbeat = 57,
            FormatCard = 60,
            EjectCard = 63,
            TurnOnSiren = 66,
            TurnOffSiren = 69,
            SaveEventSetting = 72,
            TurnOnTrigger = 75,
            TurnOffTrigger = 78,
            HoldAutoTrigger = 81,
            ReadyReceiveEWSMsg = 84,
            SaveEWSSetting = 87,
            HoldReleaseEWSAlarm = 90
        };
        enum FrameID
        {
            NoMessage = 0,
            StartMessage = 2,
            GuardFrameID = 4,
            HandshakeFrameID = 6,
            VersionFrameID = 8,
            ComSettingFrameID = 10,
            AdcSettingFrameID = 12,
            GPSDataFrameID = 14,
            DeviceStatusFrameID = 16,
            ReadyToStreamFrameID = 18,
            ClearedEEPROMFrameID = 20,
            SampleDataFrameID = 22,
            SamplePerChannelFrameID = 24,
            UtilitiesFrameID = 26,
            DataLoggerSettingFrameID = 28,
            EWSBroadcastFrameID = 30,
            TextFrameID = 255
        };
        struct GuardFrameData
        {
            public byte StartMessage;
            public byte GuardFrame_ID;
            public byte NextFrame_ID;
            public UInt16 NextFrameLength;
            public byte checksum;
        };
        public MainForm()
        {
            InitializeComponent();
        }
        public class DeviceData
        {
            public UInt32 TokenID;
            public bool IsHandshaked;
            public byte[] HWVersion = new byte[3], FWVersion = new byte[3];
            public String VersionRelease, DeviceModel;
        };
        public static DeviceData NSIDigitizer = new DeviceData();
        public static bool UseTCPConn = true, DoConnection = true;
        public System.Net.Sockets.TcpClient clientSocket;
        public NetworkStream SocketStream;
        public System.IO.Ports.SerialPort serialPort;
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (TCPSelect.Checked)
            {
                SerialSelect.Checked = false;
                COMText.Enabled = false;
                ParitySelect.Enabled = false;
                BaudSelect.Enabled = false;

                HostText.Enabled = true;
                PortText.Enabled = true;

                UseTCPConn = true;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ParitySelect.SelectedIndex = 0;
            BaudSelect.SelectedIndex = 0;
            MAC0Text.TextAlign = HorizontalAlignment.Center;
            MAC1Text.TextAlign = HorizontalAlignment.Center;
            MAC2Text.TextAlign = HorizontalAlignment.Center;
            MAC3Text.TextAlign = HorizontalAlignment.Center;
            MAC4Text.TextAlign = HorizontalAlignment.Center;
            MAC5Text.TextAlign = HorizontalAlignment.Center;

        }

        private void SerialSelect_CheckedChanged(object sender, EventArgs e)
        {
            if (SerialSelect.Checked)
            {
                TCPSelect.Checked = false;
                HostText.Enabled = false;
                PortText.Enabled = false;

                BaudSelect.Enabled = true;
                COMText.Enabled = true;
                ParitySelect.Enabled = true;

                UseTCPConn = false;
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (UseTCPConn)
            {
                clientSocket = new System.Net.Sockets.TcpClient();
                clientSocket.ReceiveBufferSize = 1024;
                try
                {
                    Logit("Connectiong to the server...Please wait!");
                    ConnectBtn.Enabled = false;
                    StatusLabel.BackColor = Color.Yellow;
                    StatusLabel.Text = "Connecting";
                    await clientSocket.ConnectAsync(HostText.Text, Convert.ToInt32(PortText.Text));
                    if (clientSocket.Connected)
                    {
                        SocketStream = clientSocket.GetStream();
                        DisconnectBtn.Enabled = true;
                        ConnectBtn.Enabled = false;
                        Logit("Connected to the server.");
                        StatusLabel.Text = "Success";
                        StatusLabel.BackColor = Color.LimeGreen;
                        DoConnection = true;
                        MsgReader.RunWorkerAsync(1);
                    }
                    else
                    {
                        ConnectBtn.Enabled = true;
                    }
                }
                catch (Exception ex)
                {
                    Logit("Unable to connect, error: " + ex.Message);
                    StatusLabel.Text = "Error!";
                    StatusLabel.BackColor = Color.Red;
                    ConnectBtn.Enabled = true;
                }
            }
            else
            {
                int BaudSpeed = 115200;
                System.IO.Ports.Parity Par;
                try
                {
                    if (BaudSelect.SelectedIndex == 0)
                    {
                        BaudSpeed = 9600;
                    }
                    else if (BaudSelect.SelectedIndex == 1)
                    {
                        BaudSpeed = 19200;
                    }
                    else if (BaudSelect.SelectedIndex == 2)
                    {
                        BaudSpeed = 38400;
                    }
                    else if (BaudSelect.SelectedIndex == 3)
                    {
                        BaudSpeed = 57600;
                    }
                    else
                    {
                        BaudSpeed = 115200;
                    }
                    if (ParitySelect.SelectedIndex == 0)
                        Par = System.IO.Ports.Parity.None;
                    else if (ParitySelect.SelectedIndex == 1)
                    {
                        Par = System.IO.Ports.Parity.Odd;
                    }
                    else
                    {
                       Par = System.IO.Ports.Parity.Even;
                    }
                    serialPort = new System.IO.Ports.SerialPort(COMText.Text,BaudSpeed,Par);
                    Logit("Connectiong to the server...Please wait!");
                    ConnectBtn.Enabled = false;
                    StatusLabel.BackColor = Color.Yellow;
                    StatusLabel.Text = "Connecting";
                    serialPort.Open();
                    if (serialPort.IsOpen)
                    {
                        DisconnectBtn.Enabled = true;
                        ConnectBtn.Enabled = false;
                        Logit("Connected to the server.");
                        StatusLabel.Text = "Success";
                        StatusLabel.BackColor = Color.LimeGreen;
                        DoConnection = true;
                        MsgReader.RunWorkerAsync(1);
                    }
                    else
                    {
                        ConnectBtn.Enabled = true;
                    }
                }
                catch (Exception ex)
                {
                    Logit("Error: " + ex.Message);
                }
            }
        }

        private void process1_Exited(object sender, EventArgs e)
        {

        }
        private int BackgroundProcessLogicMethod(BackgroundWorker bw, int a)
        {
            int result = 0;
            byte[] DataFrame = new byte[512];
            UInt16 DataLength = 0;
            UInt32 Token = 0;
            bool DoHandhsake = true;
            bool DoGetVersion = false;
            while (true)
            {
                if (DoConnection)
                {
                    if (DoHandhsake && !NSIDigitizer.IsHandshaked)
                    {
                        string SoftwareDesc = "NSI-AD24 Digitizer Tool\0";
                        byte[] strb = new byte[SoftwareDesc.Length];
                        for (int i = 0; i < SoftwareDesc.Length; i++)
                        {
                            strb[i] = (byte)SoftwareDesc[i];
                        }
                        Array.Clear(DataFrame, 0, DataFrame.Length);
                        DataFrame[0] = 100; // Code for digitizer software
                        DataLength += 1;
                        Array.Copy(strb, 0, DataFrame, DataLength, strb.Length);
                        DataLength += (UInt16)(strb.Length);
                        Logit("Sending handshake command...");
                        if (send_command(SocketStream,serialPort, (byte)Opcode.Handshake, DataFrame, DataLength, Token) > 0)
                        {
                            byte[] inStream = new byte[512];
                            UInt16 BytesReceived = 0;
                            byte fr = read_data(inStream, ref BytesReceived);
                            if (fr == (byte)FrameID.HandshakeFrameID)
                            {
                                Token = BitConverter.ToUInt32(inStream, 0);
                                Logit("Received handshaking response. Data size = " + BytesReceived + " Token ID = " + Token);
                                DoHandhsake = false;
                                DoGetVersion = true;
                                NSIDigitizer.IsHandshaked = true;
                            }
                            else if (fr == (byte)FrameID.TextFrameID)
                            {
                                DoHandhsake = true;
                                char[] inText = new char[512];
                                Array.Copy(inStream, 0, inText, 0, inStream.Length);
                                string msg = new string(inText);
                                Logit("Message from device: " + msg);
                                blank_line();
                            }
                        }

                    }
                    else if (DoGetVersion && NSIDigitizer.IsHandshaked)
                    {
                        Array.Clear(DataFrame, 0, DataFrame.Length);
                        DataLength = 0;
                        Logit("Sending get version command...");
                        if (send_command(SocketStream, serialPort, (byte)Opcode.GetVersion, DataFrame, DataLength, Token) > 0)
                        {
                            byte[] inStream = new byte[512];
                            UInt16 BytesReceived = 0;
                            UInt16 LastCharPos = 0;
                            NSIDigitizer.HWVersion = new byte[3];
                            NSIDigitizer.FWVersion = new byte[3];
                            NSIDigitizer.VersionRelease = "";
                            NSIDigitizer.DeviceModel = "";
                            byte fr = read_data(inStream, ref BytesReceived);
                            if (fr == (byte)FrameID.VersionFrameID)
                            {
                                NSIDigitizer.TokenID = BitConverter.ToUInt32(inStream, 0);
                                Logit("Received get version response. Data size = " + BytesReceived);
                                Array.Copy(inStream, 0, NSIDigitizer.HWVersion, 0, NSIDigitizer.HWVersion.Length);
                                Array.Copy(inStream, 3, NSIDigitizer.FWVersion, 0, NSIDigitizer.FWVersion.Length);

                                for (UInt16 i = 6; i < BytesReceived; i++)
                                {
                                    if (inStream[i] != 0x00)
                                    {
                                        NSIDigitizer.VersionRelease += (char)(inStream[i]);
                                    }
                                    else
                                    {
                                        LastCharPos = (UInt16)(i + 1);
                                        break;
                                    }
                                }
                                for (UInt16 i = LastCharPos; i < BytesReceived; i++)
                                {
                                    if (inStream[i] != 0x00)
                                    {
                                        NSIDigitizer.DeviceModel += (char)(inStream[i]);
                                    }
                                    else
                                    {
                                        LastCharPos = 0;
                                        break;
                                    }
                                }
                                HWLabel.Text = "Board ver." + NSIDigitizer.HWVersion[0].ToString() + '.' + NSIDigitizer.HWVersion[1].ToString() + '.' + NSIDigitizer.HWVersion[2].ToString();
                                FWLabel.Text = "FW ver." + NSIDigitizer.FWVersion[0].ToString() + '.' + NSIDigitizer.FWVersion[1].ToString() + '.' + NSIDigitizer.FWVersion[2].ToString() + '_' + NSIDigitizer.VersionRelease;
                                ModelLabel.Text = "Model: " + NSIDigitizer.DeviceModel;
                                DoGetVersion = false;
                                DoConnection = false;
                                break;
                            }
                            else if (fr == (byte)FrameID.TextFrameID)
                            {
                                DoGetVersion = true;
                                char[] inText = new char[512];
                                Array.Copy(inStream, 0, inText, 0, inStream.Length);
                                string msg = new string(inText);
                                Logit("Message from device: " + msg);
                                blank_line();
                            }
                        }
                    }
                }
                Thread.Sleep(500);
            }
            Logit("Successfully connected to the device.");
            ResetBtn.Enabled = true;
            ClearEEPROMBtn.Enabled = true;
            RebootBtn.Enabled = true;
            WriteDataBtn.Enabled = true;
            NSIDigitizer.TokenID = Token;
            bw.CancelAsync();
            return result;
        }
        private void MsgReader_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            BackgroundWorker helperBW = sender as BackgroundWorker;
            int arg = (int)e.Argument;
            e.Result = BackgroundProcessLogicMethod(helperBW, arg);
            if (helperBW.CancellationPending)
            {
                e.Cancel = true;
            }
        }
        private void blank_line()
        {
            LogText.AppendText(Environment.NewLine);
            LogText.ScrollToCaret();

        }
        private void Logit(string msg)
        {
            if (LogText.Lines.Count() >= 200)
            {
                LogText.Clear();
            }
            LogText.AppendText(DateTime.Now.ToString("HH:MM:ss.fff") + " " + msg + Environment.NewLine);
            LogText.ScrollToCaret();
        }

        private void DisconnectBtn_Click(object sender, EventArgs e)
        {
            if (UseTCPConn)
            {
                if (clientSocket.Connected)
                {
                    clientSocket.Close();
                    SocketStream.Close();
                    SocketStream.Flush();
                    NSIDigitizer.IsHandshaked = false;
                    HWLabel.Text = "Board ver.0.0.0";
                    FWLabel.Text = "FW ver.0.0.0DBG";
                    ModelLabel.Text = "Model: Unknown";
                    ResetBtn.Enabled = false;
                    ClearEEPROMBtn.Enabled = false;
                    RebootBtn.Enabled = false;
                    WriteDataBtn.Enabled = false;
                    if (!clientSocket.Connected)
                    {
                        StatusLabel.Text = "Idle";
                        StatusLabel.BackColor = Color.Yellow;
                        DisconnectBtn.Enabled = false;
                        ConnectBtn.Enabled = true;
                        DoConnection = false;
                        Logit("Disconnected from server.");
                    }
                }
            }
            else
            {
                if (serialPort.IsOpen)
                {
                    serialPort.Close();
                    Thread.Sleep(100);
                    NSIDigitizer.IsHandshaked = false;
                    HWLabel.Text = "Board ver.0.0.0";
                    FWLabel.Text = "FW ver.0.0.0DBG";
                    ModelLabel.Text = "Model: Unknown";
                    ResetBtn.Enabled = false;
                    ClearEEPROMBtn.Enabled = false;
                    RebootBtn.Enabled = false;
                    WriteDataBtn.Enabled = false;
                    if (!serialPort.IsOpen)
                    {
                        StatusLabel.Text = "Idle";
                        StatusLabel.BackColor = Color.Yellow;
                        DisconnectBtn.Enabled = false;
                        ConnectBtn.Enabled = true;
                        DoConnection = false;
                        Logit("Disconnected from server.");
                    }
                }
            }
           
        }

        private byte calculate_sum(byte[] bytes, int len)
        {
            UInt16 i;
            byte checksum = 0x00;
            for (i = 0; i < len; i++)
            {
                checksum += bytes[i];
            }

            checksum ^= 0xFF;
            checksum += (byte)(checksum + 1);
            return checksum;
        }

        private int send_command(NetworkStream n,SerialPort sp, byte CMD_Opcode, byte[] data, UInt16 len, UInt32 TokenData)
        {
            byte[] GuardFrame = new byte[6];
            byte[] DataByte = new byte[512];
            byte[] TokenBytes = new byte[4];
            byte checksum = 0;
            UInt16 DataLength = 0;
            Array.Clear(DataByte, 0, DataByte.Length);
            Array.Clear(GuardFrame, 0, GuardFrame.Length);
            if (CMD_Opcode == (byte)Opcode.Handshake)
            {
                DataByte[0] = (byte)FrameID.StartMessage;
                DataByte[1] = CMD_Opcode;
                DataLength += 2;
                Array.Copy(data, 0, DataByte, DataLength, len);
                DataLength += (UInt16)(len);
                checksum = calculate_sum(DataByte, DataLength);
                DataByte[DataLength] = checksum;
                DataLength += 1;
            }
            else
            {
                TokenBytes = BitConverter.GetBytes(TokenData);
                DataByte[0] = (byte)FrameID.StartMessage;
                DataByte[1] = CMD_Opcode;
                DataLength += 2;
                Array.Copy(TokenBytes, 0, DataByte, 2, TokenBytes.Length);
                DataLength += (UInt16)TokenBytes.Length;
                Array.Copy(data, 0, DataByte, DataLength, len);
                DataLength += (UInt16)len;
                checksum = calculate_sum(DataByte, DataLength);
                DataByte[DataLength] = checksum;
                DataLength += 1;

            }

            GuardFrame[0] = (byte)FrameID.StartMessage;
            GuardFrame[1] = (byte)FrameID.GuardFrameID;
            GuardFrame[2] = CMD_Opcode;
            GuardFrame[3] = (byte)(DataLength & 0xFF);
            GuardFrame[4] = (byte)(DataLength >> 8);
            checksum = calculate_sum(GuardFrame, 5);
            GuardFrame[5] = checksum;
            try
            {
                Logit("Sending command, Opcode: " + CMD_Opcode.ToString() + " ,Token ID: " + TokenData.ToString() + " ,Data length = " + DataLength.ToString());
                Logit("Data frame checksum = " + checksum.ToString() + " Data frame length = " + DataLength);
                if (UseTCPConn)
                {
                    n.Write(GuardFrame, 0, GuardFrame.Length);
                    n.Write(DataByte, 0, DataLength);
                }
                else
                {
                    sp.Write(GuardFrame,0,GuardFrame.Length);
                    sp.Write(DataByte, 0, DataLength);
                }

            }
            catch (Exception e)
            {
                return -1;
            }
            return 1;
        }
        private byte read_data(byte[] data_out, ref UInt16 RecvLength)
        {
            bool IsDataAvailable = false;
            bool ReadGuardFrame = true;
            UInt16 DataFrameLength = 0;
            byte[] RecvData = new byte[512];
            byte NextFrameID = 0;
            Array.Clear(RecvData, 0, RecvData.Length);
            if (ReadGuardFrame)
            {
                if (UseTCPConn)
                {
                    SocketStream.ReadTimeout = 1000;
                }
                else
                {

                }
                long WaitTimeout = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                while (!IsDataAvailable)
                {
                    if (DateTimeOffset.Now.ToUnixTimeMilliseconds() - WaitTimeout > 1000)
                    {
                        Logit("Unable to get response, timeout raised!");
                        return (byte)FrameID.NoMessage;
                    }
                    if (UseTCPConn)
                    {
                        if (SocketStream.DataAvailable)
                        {
                            IsDataAvailable = true;
                            break;
                        }
                    }
                    else
                    {
                        if (serialPort.BytesToRead > 0)
                        {
                            IsDataAvailable = true;
                            break;
                        }
                    }

                    Thread.Sleep(1);
                }
                if (IsDataAvailable)
                {
                    int rd = 0;
                    if (UseTCPConn)
                    {
                        rd = SocketStream.Read(RecvData, 0, 6);
                    }
                    else
                    { 
                        rd = serialPort.Read(RecvData, 0, 6);
                    }
                    if (rd > 0)
                    {
                        byte checksum = calculate_sum(RecvData, 5);
                        if ((RecvData[0] == (byte)FrameID.StartMessage) && (RecvData[1] == (byte)FrameID.GuardFrameID) && (checksum == RecvData[5]))
                        {
                            NextFrameID = RecvData[2];
                            DataFrameLength = BitConverter.ToUInt16(RecvData, 3);
                            Logit("Received guard frame. Next frame ID = " + RecvData[2].ToString() + " Next frame length = " + DataFrameLength);
                            ReadGuardFrame = false;
                        }
                    }
                }
            }
            if (ReadGuardFrame == false)
            {
                IsDataAvailable = false;
                Array.Clear(RecvData, 0, RecvData.Length);
                if (UseTCPConn)
                {
                    SocketStream.ReadTimeout = 1000;
                }
                else
                {

                }
                long WaitTimeout = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                while (!IsDataAvailable)
                {
                    if (DateTimeOffset.Now.ToUnixTimeMilliseconds() - WaitTimeout > 1000)
                    {
                        Logit("Unable to get response, timeout raised!");
                        return (byte)FrameID.NoMessage;
                    }
                    if (UseTCPConn)
                    {
                        if (SocketStream.DataAvailable)
                        {
                            IsDataAvailable = true;
                            break;
                        }
                    }
                    else
                    {
                        if (serialPort.BytesToRead > 0)
                        {
                            IsDataAvailable = true;
                            break;
                        }
                    }

                    Thread.Sleep(1);
                }
                if (IsDataAvailable)
                {
                    int rd = 0;
                    if (UseTCPConn)
                    {
                        rd = SocketStream.Read(RecvData, 0, DataFrameLength);
                    }
                    else
                    {
                        rd = serialPort.Read(RecvData, 0, DataFrameLength);
                    }
                    if (rd > 0)
                    {
                        byte checksum = calculate_sum(RecvData, DataFrameLength - 1);
                        if ((RecvData[0] == (byte)FrameID.StartMessage) && (RecvData[DataFrameLength - 1] == checksum))
                        {
                            RecvLength = DataFrameLength;
                            Array.Clear(data_out, 0, data_out.Length);
                            Array.Copy(RecvData, 2, data_out, 0, DataFrameLength - 3);
                            return RecvData[1];
                        }
                        else
                        {
                            Logit("Data validty check failed!. Calculated checksum = " + checksum.ToString() + " Data checksum = " + data_out[DataFrameLength - 1].ToString());
                        }
                    }
                    else
                    {
                        Logit("Unable to receive data frame!");
                    }
                }
            }

            return (byte)FrameID.NoMessage;
        }
        byte[] StructureToByteArray(object obj)
        {
            int len = Marshal.SizeOf(obj);

            byte[] arr = new byte[len];

            IntPtr ptr = Marshal.AllocHGlobal(len);

            Marshal.StructureToPtr(obj, ptr, true);

            Marshal.Copy(ptr, arr, 0, len);

            Marshal.FreeHGlobal(ptr);

            return arr;
        }
        void ByteArrayToStructure(byte[] bytearray, ref object obj)
        {
            int len = Marshal.SizeOf(obj);

            IntPtr i = Marshal.AllocHGlobal(len);

            Marshal.Copy(bytearray, 0, i, len);

            obj = Marshal.PtrToStructure(i, obj.GetType());

            Marshal.FreeHGlobal(i);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (NSIDigitizer.IsHandshaked)
            {
                byte[] DataFrame = new byte[512];
                UInt16 DataLength = 0;
                try
                {
                    if ((send_command(SocketStream, serialPort, (byte)Opcode.Reboot, DataFrame, DataLength, NSIDigitizer.TokenID) < 0) || (!clientSocket.Connected))
                    {
                        Logit("Unabel to reboot device!");
                    }
                    else
                    {
                        byte[] inStream = new byte[512];
                        UInt16 BytesReceived = 0;
                        byte fr = read_data(inStream, ref BytesReceived);
                        if (fr == (byte)FrameID.TextFrameID)
                        {
                            char[] inText = new char[512];
                            Array.Copy(inStream, 0, inText, 0, inStream.Length);
                            string msg = new string(inText);
                            Logit("Message from device: " + msg);
                            blank_line();
                        }
                        else
                        {
                            Logit("Rebooting device...Please wait!");
                            Thread.Sleep(5000);
                            DisconnectBtn.PerformClick();
                        }
                    }

                }
                catch (Exception ex)
                {
                    Logit("Error: " + ex.Message);
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure want to reset all digitizer config?", "Reset digitizer config", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (NSIDigitizer.IsHandshaked)
                {
                    byte[] DataFrame = new byte[512];
                    UInt16 DataLength = 0;
                    try
                    {
                        if ((send_command(SocketStream, serialPort, (byte)Opcode.ResetDefault, DataFrame, DataLength, NSIDigitizer.TokenID) < 0) || (!clientSocket.Connected))
                        {
                            Logit("Unabel to reset the device!");
                        }
                        else
                        {
                            byte[] inStream = new byte[512];
                            UInt16 BytesReceived = 0;
                            byte fr = read_data(inStream, ref BytesReceived);
                            if (fr == (byte)FrameID.TextFrameID)
                            {
                                char[] inText = new char[512];
                                Array.Copy(inStream, 0, inText, 0, inStream.Length);
                                string msg = new string(inText);
                                Logit("Message from device: " + msg);
                                blank_line();
                            }
                            else
                            {
                                Logit("Resetting device...Please wait until reboot!");
                                
                            }
                            DisconnectBtn.PerformClick();
                        }

                    }
                    catch (Exception ex)
                    {
                        Logit("Error: " + ex.Message);
                    }
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure want to clear all EEPROM config?", "EEPROM clear", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //do something
                if (NSIDigitizer.IsHandshaked)
                {
                    byte[] DataFrame = new byte[512];
                    UInt16 DataLength = 0;
                    try
                    {
                        if ((send_command(SocketStream, serialPort, (byte)Opcode.ClearEEPROMData, DataFrame, DataLength, NSIDigitizer.TokenID) < 0) || (!clientSocket.Connected))
                        {
                            Logit("Unabel to clear EEPROM data!");
                        }
                        else
                        {
                            byte[] inStream = new byte[512];
                            UInt16 BytesReceived = 0;
                            byte fr = read_data(inStream, ref BytesReceived);
                            if (fr == (byte)FrameID.TextFrameID)
                            {
                                char[] inText = new char[512];
                                Array.Copy(inStream, 0, inText, 0, inStream.Length);
                                string msg = new string(inText);
                                Logit("Message from device: " + msg);
                                blank_line();
                            }
                            else
                            {
                                Logit("Clearing EEPROM data...Please wait!");
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        Logit("Error: " + ex.Message);
                    }
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            LogText.Clear();
        }

        private void MAC3Text_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;

            if (c != '\b' && !((c <= 0x66 && c >= 61) || (c <= 0x46 && c >= 0x41) || (c >= 0x30 && c <= 0x39)))
            {
                e.Handled = true;
            }
        }

        private void MAC4Text_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;

            if (c != '\b' && !((c <= 0x66 && c >= 61) || (c <= 0x46 && c >= 0x41) || (c >= 0x30 && c <= 0x39)))
            {
                e.Handled = true;
            }
        }

        private void MAC5Text_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;

            if (c != '\b' && !((c <= 0x66 && c >= 61) || (c <= 0x46 && c >= 0x41) || (c >= 0x30 && c <= 0x39)))
            {
                e.Handled = true;
            }
        }

        private async void WriteDataBtn_Click(object sender, EventArgs e)
        {
            byte[] MACAddress = new byte[6];
            String hex = "";
            try
            {
                hex = MAC0Text.Text.ToString();
                MACAddress[0] = Convert.ToByte(hex, 16);
                hex = "";
                hex = MAC1Text.Text.ToString();
                MACAddress[1] = Convert.ToByte(hex, 16);
                hex = "";
                hex = MAC2Text.Text.ToString();
                MACAddress[2] = Convert.ToByte(hex, 16);
                hex = "";
                hex = MAC3Text.Text.ToString();
                MACAddress[3] = Convert.ToByte(hex, 16);
                hex = "";
                hex = MAC4Text.Text.ToString();
                MACAddress[4] = Convert.ToByte(hex, 16);
                hex = "";
                hex = MAC5Text.Text.ToString();
                MACAddress[5] = Convert.ToByte(hex, 16);
                if ((send_command(SocketStream, serialPort, (byte)Opcode.WriteFactoryData, MACAddress, 6, NSIDigitizer.TokenID) < 0))
                {
                    Logit("Unabel to write factory data!");
                }
                else
                {
                    byte[] inStream = new byte[512];
                    UInt16 BytesReceived = 0;
                    Logit("writing factory data...Please wait!");
                    while (read_data(inStream, ref BytesReceived) == (byte)FrameID.NoMessage)
                    {
                        Thread.Sleep(1);
                    }
                    char[] inText = new char[512];
                    Array.Copy(inStream, 0, inText, 0, inStream.Length);
                    string msg = new string(inText);
                    Logit("Message from device: " + msg);
                    blank_line();
                }
            }
            catch (Exception ex)
            {
                Logit("Error: " + ex.Message);
            }
        }
    }

}