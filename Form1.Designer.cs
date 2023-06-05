namespace NSI_AD24_Digitizer_Tool
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            StatusLabel = new Label();
            label1 = new Label();
            DisconnectBtn = new Button();
            ConnectBtn = new Button();
            BaudSelect = new ComboBox();
            label6 = new Label();
            ParitySelect = new ComboBox();
            label5 = new Label();
            COMText = new TextBox();
            label4 = new Label();
            PortText = new TextBox();
            label3 = new Label();
            HostText = new TextBox();
            label2 = new Label();
            SerialSelect = new CheckBox();
            TCPSelect = new CheckBox();
            LogText = new RichTextBox();
            MsgReader = new System.ComponentModel.BackgroundWorker();
            label7 = new Label();
            groupBox2 = new GroupBox();
            ModelLabel = new Label();
            HWLabel = new Label();
            FWLabel = new Label();
            label11 = new Label();
            WriteDataBtn = new Button();
            MAC5Text = new TextBox();
            MAC4Text = new TextBox();
            MAC3Text = new TextBox();
            MAC2Text = new TextBox();
            MAC1Text = new TextBox();
            label10 = new Label();
            MAC0Text = new TextBox();
            label9 = new Label();
            RebootBtn = new Button();
            ClearEEPROMBtn = new Button();
            ResetBtn = new Button();
            label8 = new Label();
            button1 = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(StatusLabel);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(DisconnectBtn);
            groupBox1.Controls.Add(ConnectBtn);
            groupBox1.Controls.Add(BaudSelect);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(ParitySelect);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(COMText);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(PortText);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(HostText);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(SerialSelect);
            groupBox1.Controls.Add(TCPSelect);
            groupBox1.Location = new Point(12, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(474, 208);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // StatusLabel
            // 
            StatusLabel.AutoSize = true;
            StatusLabel.BackColor = Color.Yellow;
            StatusLabel.Location = new Point(66, 134);
            StatusLabel.Name = "StatusLabel";
            StatusLabel.Size = new Size(26, 15);
            StatusLabel.TabIndex = 17;
            StatusLabel.Text = "Idle";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(16, 134);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 16;
            label1.Text = "Status";
            // 
            // DisconnectBtn
            // 
            DisconnectBtn.AutoSize = true;
            DisconnectBtn.Enabled = false;
            DisconnectBtn.Location = new Point(97, 163);
            DisconnectBtn.Name = "DisconnectBtn";
            DisconnectBtn.Size = new Size(76, 25);
            DisconnectBtn.TabIndex = 15;
            DisconnectBtn.Text = "Disconnect";
            DisconnectBtn.UseVisualStyleBackColor = true;
            DisconnectBtn.Click += DisconnectBtn_Click;
            // 
            // ConnectBtn
            // 
            ConnectBtn.AutoSize = true;
            ConnectBtn.Location = new Point(16, 163);
            ConnectBtn.Name = "ConnectBtn";
            ConnectBtn.Size = new Size(75, 25);
            ConnectBtn.TabIndex = 14;
            ConnectBtn.Text = "Connect";
            ConnectBtn.UseVisualStyleBackColor = true;
            ConnectBtn.Click += button1_Click;
            // 
            // BaudSelect
            // 
            BaudSelect.AllowDrop = true;
            BaudSelect.DropDownStyle = ComboBoxStyle.DropDownList;
            BaudSelect.Enabled = false;
            BaudSelect.FormattingEnabled = true;
            BaudSelect.Items.AddRange(new object[] { "9600", "19200", "38400", "57600", "115200" });
            BaudSelect.Location = new Point(364, 98);
            BaudSelect.Name = "BaudSelect";
            BaudSelect.Size = new Size(95, 23);
            BaudSelect.TabIndex = 12;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(300, 101);
            label6.Name = "label6";
            label6.Size = new Size(58, 15);
            label6.TabIndex = 11;
            label6.Text = "Baudrate";
            // 
            // ParitySelect
            // 
            ParitySelect.AllowDrop = true;
            ParitySelect.DropDownStyle = ComboBoxStyle.DropDownList;
            ParitySelect.Enabled = false;
            ParitySelect.FormattingEnabled = true;
            ParitySelect.Items.AddRange(new object[] { "Parity None", "Parity Odd", "Parity Even" });
            ParitySelect.Location = new Point(206, 98);
            ParitySelect.Name = "ParitySelect";
            ParitySelect.Size = new Size(79, 23);
            ParitySelect.TabIndex = 10;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(161, 101);
            label5.Name = "label5";
            label5.Size = new Size(39, 15);
            label5.TabIndex = 9;
            label5.Text = "Parity";
            // 
            // COMText
            // 
            COMText.Enabled = false;
            COMText.Location = new Point(66, 98);
            COMText.Name = "COMText";
            COMText.Size = new Size(88, 23);
            COMText.TabIndex = 8;
            COMText.Text = "COM3";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(16, 101);
            label4.Name = "label4";
            label4.Size = new Size(34, 15);
            label4.TabIndex = 7;
            label4.Text = "COM";
            // 
            // PortText
            // 
            PortText.Location = new Point(206, 43);
            PortText.Name = "PortText";
            PortText.Size = new Size(79, 23);
            PortText.TabIndex = 6;
            PortText.Text = "15024";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(161, 48);
            label3.Name = "label3";
            label3.Size = new Size(31, 15);
            label3.TabIndex = 5;
            label3.Text = "Port";
            // 
            // HostText
            // 
            HostText.Location = new Point(66, 43);
            HostText.Name = "HostText";
            HostText.Size = new Size(88, 23);
            HostText.TabIndex = 4;
            HostText.Text = "192.168.1.254";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(16, 46);
            label2.Name = "label2";
            label2.Size = new Size(33, 15);
            label2.TabIndex = 3;
            label2.Text = "Host";
            // 
            // SerialSelect
            // 
            SerialSelect.AutoSize = true;
            SerialSelect.Location = new Point(16, 73);
            SerialSelect.Name = "SerialSelect";
            SerialSelect.Size = new Size(79, 19);
            SerialSelect.TabIndex = 2;
            SerialSelect.Text = "Serial Port";
            SerialSelect.UseVisualStyleBackColor = true;
            SerialSelect.CheckedChanged += SerialSelect_CheckedChanged;
            // 
            // TCPSelect
            // 
            TCPSelect.AutoSize = true;
            TCPSelect.Checked = true;
            TCPSelect.CheckState = CheckState.Checked;
            TCPSelect.Location = new Point(16, 18);
            TCPSelect.Name = "TCPSelect";
            TCPSelect.Size = new Size(61, 19);
            TCPSelect.TabIndex = 1;
            TCPSelect.Text = "TCP/IP";
            TCPSelect.UseVisualStyleBackColor = true;
            TCPSelect.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // LogText
            // 
            LogText.Location = new Point(12, 441);
            LogText.Name = "LogText";
            LogText.ReadOnly = true;
            LogText.Size = new Size(474, 179);
            LogText.TabIndex = 1;
            LogText.Text = "";
            // 
            // MsgReader
            // 
            MsgReader.DoWork += MsgReader_DoWork;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(12, 419);
            label7.Name = "label7";
            label7.Size = new Size(30, 15);
            label7.TabIndex = 8;
            label7.Text = "Log:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(ModelLabel);
            groupBox2.Controls.Add(HWLabel);
            groupBox2.Controls.Add(FWLabel);
            groupBox2.Controls.Add(label11);
            groupBox2.Controls.Add(WriteDataBtn);
            groupBox2.Controls.Add(MAC5Text);
            groupBox2.Controls.Add(MAC4Text);
            groupBox2.Controls.Add(MAC3Text);
            groupBox2.Controls.Add(MAC2Text);
            groupBox2.Controls.Add(MAC1Text);
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(MAC0Text);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(RebootBtn);
            groupBox2.Controls.Add(ClearEEPROMBtn);
            groupBox2.Controls.Add(ResetBtn);
            groupBox2.Controls.Add(label8);
            groupBox2.Location = new Point(12, 217);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(474, 192);
            groupBox2.TabIndex = 9;
            groupBox2.TabStop = false;
            // 
            // ModelLabel
            // 
            ModelLabel.AutoSize = true;
            ModelLabel.Location = new Point(86, 34);
            ModelLabel.Name = "ModelLabel";
            ModelLabel.Size = new Size(98, 15);
            ModelLabel.TabIndex = 27;
            ModelLabel.Text = "Model: Unknown";
            // 
            // HWLabel
            // 
            HWLabel.AutoSize = true;
            HWLabel.Location = new Point(86, 19);
            HWLabel.Name = "HWLabel";
            HWLabel.Size = new Size(84, 15);
            HWLabel.TabIndex = 26;
            HWLabel.Text = "Board ver.0.0.0";
            // 
            // FWLabel
            // 
            FWLabel.AutoSize = true;
            FWLabel.Location = new Point(189, 19);
            FWLabel.Name = "FWLabel";
            FWLabel.Size = new Size(93, 15);
            FWLabel.TabIndex = 25;
            FWLabel.Text = "FW ver.0.0.0DBG";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label11.Location = new Point(17, 19);
            label11.Name = "label11";
            label11.Size = new Size(62, 15);
            label11.TabIndex = 24;
            label11.Text = "Device ID";
            // 
            // WriteDataBtn
            // 
            WriteDataBtn.AutoSize = true;
            WriteDataBtn.Enabled = false;
            WriteDataBtn.Location = new Point(20, 161);
            WriteDataBtn.Name = "WriteDataBtn";
            WriteDataBtn.Size = new Size(114, 25);
            WriteDataBtn.TabIndex = 23;
            WriteDataBtn.Text = "Write Factory Data";
            WriteDataBtn.UseVisualStyleBackColor = true;
            WriteDataBtn.Click += WriteDataBtn_Click;
            // 
            // MAC5Text
            // 
            MAC5Text.CharacterCasing = CharacterCasing.Upper;
            MAC5Text.Location = new Point(315, 132);
            MAC5Text.MaxLength = 2;
            MAC5Text.Name = "MAC5Text";
            MAC5Text.Size = new Size(36, 23);
            MAC5Text.TabIndex = 22;
            MAC5Text.KeyPress += MAC5Text_KeyPress;
            // 
            // MAC4Text
            // 
            MAC4Text.CharacterCasing = CharacterCasing.Upper;
            MAC4Text.Location = new Point(273, 132);
            MAC4Text.MaxLength = 2;
            MAC4Text.Name = "MAC4Text";
            MAC4Text.Size = new Size(36, 23);
            MAC4Text.TabIndex = 21;
            MAC4Text.KeyPress += MAC4Text_KeyPress;
            // 
            // MAC3Text
            // 
            MAC3Text.CharacterCasing = CharacterCasing.Upper;
            MAC3Text.Location = new Point(231, 132);
            MAC3Text.MaxLength = 2;
            MAC3Text.Name = "MAC3Text";
            MAC3Text.Size = new Size(36, 23);
            MAC3Text.TabIndex = 20;
            MAC3Text.KeyPress += MAC3Text_KeyPress;
            // 
            // MAC2Text
            // 
            MAC2Text.CharacterCasing = CharacterCasing.Upper;
            MAC2Text.Location = new Point(189, 132);
            MAC2Text.MaxLength = 2;
            MAC2Text.Name = "MAC2Text";
            MAC2Text.ReadOnly = true;
            MAC2Text.Size = new Size(36, 23);
            MAC2Text.TabIndex = 19;
            MAC2Text.Text = "DC";
            // 
            // MAC1Text
            // 
            MAC1Text.CharacterCasing = CharacterCasing.Upper;
            MAC1Text.Location = new Point(147, 132);
            MAC1Text.MaxLength = 2;
            MAC1Text.Name = "MAC1Text";
            MAC1Text.ReadOnly = true;
            MAC1Text.Size = new Size(36, 23);
            MAC1Text.TabIndex = 18;
            MAC1Text.Text = "08";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(20, 135);
            label10.Name = "label10";
            label10.Size = new Size(79, 15);
            label10.TabIndex = 17;
            label10.Text = "MAC Address";
            // 
            // MAC0Text
            // 
            MAC0Text.CharacterCasing = CharacterCasing.Upper;
            MAC0Text.Location = new Point(105, 132);
            MAC0Text.MaxLength = 2;
            MAC0Text.Name = "MAC0Text";
            MAC0Text.ReadOnly = true;
            MAC0Text.Size = new Size(36, 23);
            MAC0Text.TabIndex = 13;
            MAC0Text.Text = "00";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label9.Location = new Point(16, 110);
            label9.Name = "label9";
            label9.Size = new Size(77, 15);
            label9.TabIndex = 12;
            label9.Text = "Factory Data";
            // 
            // RebootBtn
            // 
            RebootBtn.AutoSize = true;
            RebootBtn.Enabled = false;
            RebootBtn.Location = new Point(277, 77);
            RebootBtn.Name = "RebootBtn";
            RebootBtn.Size = new Size(75, 25);
            RebootBtn.TabIndex = 11;
            RebootBtn.Text = "Reboot";
            RebootBtn.UseVisualStyleBackColor = true;
            RebootBtn.Click += button3_Click;
            // 
            // ClearEEPROMBtn
            // 
            ClearEEPROMBtn.AutoSize = true;
            ClearEEPROMBtn.Enabled = false;
            ClearEEPROMBtn.Location = new Point(176, 77);
            ClearEEPROMBtn.Name = "ClearEEPROMBtn";
            ClearEEPROMBtn.Size = new Size(95, 25);
            ClearEEPROMBtn.TabIndex = 10;
            ClearEEPROMBtn.Text = "Clear EEPROM";
            ClearEEPROMBtn.UseVisualStyleBackColor = true;
            ClearEEPROMBtn.Click += button2_Click;
            // 
            // ResetBtn
            // 
            ResetBtn.AutoSize = true;
            ResetBtn.Enabled = false;
            ResetBtn.Location = new Point(20, 77);
            ResetBtn.Name = "ResetBtn";
            ResetBtn.Size = new Size(150, 25);
            ResetBtn.TabIndex = 9;
            ResetBtn.Text = "Reset Config";
            ResetBtn.UseVisualStyleBackColor = true;
            ResetBtn.Click += button1_Click_1;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label8.Location = new Point(16, 59);
            label8.Name = "label8";
            label8.Size = new Size(63, 15);
            label8.TabIndex = 8;
            label8.Text = "Command";
            // 
            // button1
            // 
            button1.Location = new Point(48, 415);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 10;
            button1.Text = "Clear Log";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_2;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(497, 632);
            Controls.Add(button1);
            Controls.Add(groupBox2);
            Controls.Add(label7);
            Controls.Add(LogText);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "NSI-AD24 Digitizer Tool v0.0.1DBG";
            Load += MainForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private CheckBox TCPSelect;
        private TextBox PortText;
        private Label label3;
        private TextBox HostText;
        private Label label2;
        private CheckBox SerialSelect;
        private ComboBox ParitySelect;
        private Label label5;
        private TextBox COMText;
        private Label label4;
        private ComboBox BaudSelect;
        private Label label6;
        private Button DisconnectBtn;
        private Button ConnectBtn;
        private RichTextBox LogText;
        private System.ComponentModel.BackgroundWorker MsgReader;
        private Label label7;
        private GroupBox groupBox2;
        private Label StatusLabel;
        private Label label1;
        private Label label9;
        private Button ClearEEPROMBtn;
        private Button ResetBtn;
        private Label label8;
        private Button WriteDataBtn;
        private TextBox MAC5Text;
        private TextBox MAC4Text;
        private TextBox MAC3Text;
        private TextBox MAC2Text;
        private TextBox MAC1Text;
        private Label label10;
        private TextBox MAC0Text;
        private Label ModelLabel;
        private Label HWLabel;
        private Label FWLabel;
        private Label label11;
        public Button RebootBtn;
        private Button button1;
    }
}