using SimpleTCP;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Reflection.PortableExecutable;
using System.Runtime.Intrinsics.X86;
using System.ComponentModel;
using System;
using System.Runtime.InteropServices;

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
        public bool UseTCPConn = true, DoConnection = true;
        public System.Net.Sockets.TcpClient clientSocket;
        public NetworkStream SocketStream;
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
                    Logit("Waiting to connect...");
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
                }
                catch (Exception ex)
                {
                    Logit("Unable to connect, error: " + ex.Message);
                    StatusLabel.Text = "Error!";
                    StatusLabel.BackColor = Color.Red;
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
            if (UseTCPConn)
            {
                bool DoHandhsake = true;
                while (clientSocket.Connected)
                {
                    if (DoConnection)
                    {
                        if (DoHandhsake)
                        {
                            String SoftwareDesc = "Digitizer Tool";
                            char[] str = new char[32];
                            str = SoftwareDesc.ToCharArray();
                            UInt16 DataLength = 0;
                            byte[] strb = new byte[32];
                            for (int i = 0; i < str.Length; i++)
                            {
                                strb[i] = (byte)str[i];
                            }
                            DataFrame[0] = (byte)Opcode.Handshake;
                            DataFrame[1] = 100; // Code for digitizer software
                            DataLength += 2;
                            Array.Copy(strb, 0, DataFrame, 2, strb.Length);
                            DataLength += (UInt16)strb.Length;
                            Logit("Sending handshake command...");
                            if (send_msg(SocketStream, (byte)FrameID.HandshakeFrameID, DataFrame, DataLength) > 0)
                            {
                                byte[] inStream = new byte[512];
                                bool IsDataAvailable = false;
                                SocketStream.ReadTimeout = 1000;
                                long WaitTimeout = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                                while (!IsDataAvailable)
                                {
                                    if (DateTimeOffset.Now.ToUnixTimeMilliseconds() - WaitTimeout > 1000)
                                    {
                                        Logit("Unable to get response, timeout raised!");
                                        break;
                                    }
                                    if (SocketStream.DataAvailable)
                                    {
                                        IsDataAvailable = true;
                                    }
                                    Thread.Sleep(1);
                                }
                                if (IsDataAvailable)
                                {
                                    if (SocketStream.Read(inStream, 0, (int)inStream.Length) > 0)
                                    {
                                        string msg = System.Text.Encoding.UTF8.GetString(inStream) + Environment.NewLine;
                                        Logit("Message from server: " + msg);
                                        DoHandhsake = false;
                                    }
                                }
                            }

                        }
                    }
                    Thread.Sleep(500);
                }
            }
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

        private void Logit(string msg)
        {
            LogText.AppendText(DateTime.Now.ToString("HH:MM:ss.fff") + " " + msg + Environment.NewLine);
            LogText.ScrollToCaret();
        }

        private void DisconnectBtn_Click(object sender, EventArgs e)
        {
            if (clientSocket.Connected)
            {
                clientSocket.Close();
                SocketStream.Close();
                SocketStream.Flush();
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

        private int send_msg(NetworkStream n, byte Nextframe, byte[] data, UInt16 len)
        {
            byte[] GuardFrame = new byte[6];
            byte[] DataByte = new byte[512];
            UInt16 DataLength = 0;
            GuardFrameData GuardFrame_Data = new GuardFrameData();

            GuardFrame_Data.StartMessage = (byte)FrameID.StartMessage;
            GuardFrame_Data.GuardFrame_ID = (byte)FrameID.GuardFrameID;
            GuardFrame_Data.NextFrame_ID = Nextframe;
            GuardFrame_Data.NextFrameLength = len;

            GuardFrame = StructureToByteArray(GuardFrame_Data);
            GuardFrame_Data.checksum = calculate_sum(GuardFrame, GuardFrame.Length - 1);
            GuardFrame = StructureToByteArray(GuardFrame_Data);
            DataByte[0] = (byte)FrameID.StartMessage;
            DataByte[1] = Nextframe;
            DataLength += 2;
            Array.Copy(data, 0, DataByte, 2, len);
            DataLength += len;
            DataByte[DataLength] = calculate_sum(DataByte, DataLength);
            DataLength += 1;
            try
            {
                n.Write(GuardFrame, 0, GuardFrame.Length);
                n.Write(DataByte, 0, DataLength);
            }
            catch (Exception e)
            {
                return -1;
            }
            return 1;
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
    }

}