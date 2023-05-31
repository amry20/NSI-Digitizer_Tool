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
            button4 = new Button();
            textBox6 = new TextBox();
            textBox5 = new TextBox();
            textBox4 = new TextBox();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            label10 = new Label();
            textBox1 = new TextBox();
            label9 = new Label();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            label8 = new Label();
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
            groupBox1.Size = new Size(499, 199);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // StatusLabel
            // 
            StatusLabel.AutoSize = true;
            StatusLabel.BackColor = Color.Yellow;
            StatusLabel.Location = new Point(64, 134);
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
            DisconnectBtn.Location = new Point(147, 162);
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
            ConnectBtn.Location = new Point(66, 162);
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
            LogText.Location = new Point(12, 430);
            LogText.Name = "LogText";
            LogText.ReadOnly = true;
            LogText.Size = new Size(499, 190);
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
            label7.Location = new Point(12, 412);
            label7.Name = "label7";
            label7.Size = new Size(30, 15);
            label7.TabIndex = 8;
            label7.Text = "Log:";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(button4);
            groupBox2.Controls.Add(textBox6);
            groupBox2.Controls.Add(textBox5);
            groupBox2.Controls.Add(textBox4);
            groupBox2.Controls.Add(textBox3);
            groupBox2.Controls.Add(textBox2);
            groupBox2.Controls.Add(label10);
            groupBox2.Controls.Add(textBox1);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(button3);
            groupBox2.Controls.Add(button2);
            groupBox2.Controls.Add(button1);
            groupBox2.Controls.Add(label8);
            groupBox2.Location = new Point(12, 217);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(499, 192);
            groupBox2.TabIndex = 9;
            groupBox2.TabStop = false;
            // 
            // button4
            // 
            button4.AutoSize = true;
            button4.Location = new Point(20, 128);
            button4.Name = "button4";
            button4.Size = new Size(114, 25);
            button4.TabIndex = 23;
            button4.Text = "Write Factory Data";
            button4.UseVisualStyleBackColor = true;
            // 
            // textBox6
            // 
            textBox6.CharacterCasing = CharacterCasing.Upper;
            textBox6.Location = new Point(315, 99);
            textBox6.MaxLength = 2;
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(36, 23);
            textBox6.TabIndex = 22;
            // 
            // textBox5
            // 
            textBox5.CharacterCasing = CharacterCasing.Upper;
            textBox5.Location = new Point(273, 99);
            textBox5.MaxLength = 2;
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(36, 23);
            textBox5.TabIndex = 21;
            // 
            // textBox4
            // 
            textBox4.CharacterCasing = CharacterCasing.Upper;
            textBox4.Location = new Point(231, 99);
            textBox4.MaxLength = 2;
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(36, 23);
            textBox4.TabIndex = 20;
            // 
            // textBox3
            // 
            textBox3.CharacterCasing = CharacterCasing.Upper;
            textBox3.Location = new Point(189, 99);
            textBox3.MaxLength = 2;
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(36, 23);
            textBox3.TabIndex = 19;
            // 
            // textBox2
            // 
            textBox2.CharacterCasing = CharacterCasing.Upper;
            textBox2.Location = new Point(147, 99);
            textBox2.MaxLength = 2;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(36, 23);
            textBox2.TabIndex = 18;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label10.Location = new Point(20, 102);
            label10.Name = "label10";
            label10.Size = new Size(79, 15);
            label10.TabIndex = 17;
            label10.Text = "MAC Address";
            // 
            // textBox1
            // 
            textBox1.CharacterCasing = CharacterCasing.Upper;
            textBox1.Location = new Point(105, 99);
            textBox1.MaxLength = 2;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(36, 23);
            textBox1.TabIndex = 13;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label9.Location = new Point(16, 77);
            label9.Name = "label9";
            label9.Size = new Size(77, 15);
            label9.TabIndex = 12;
            label9.Text = "Factory Data";
            // 
            // button3
            // 
            button3.AutoSize = true;
            button3.Location = new Point(277, 37);
            button3.Name = "button3";
            button3.Size = new Size(75, 25);
            button3.TabIndex = 11;
            button3.Text = "Reboot";
            button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.AutoSize = true;
            button2.Location = new Point(176, 37);
            button2.Name = "button2";
            button2.Size = new Size(95, 25);
            button2.TabIndex = 10;
            button2.Text = "Clear EEPROM";
            button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.AutoSize = true;
            button1.Location = new Point(20, 37);
            button1.Name = "button1";
            button1.Size = new Size(150, 25);
            button1.TabIndex = 9;
            button1.Text = "Reset Config";
            button1.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label8.Location = new Point(16, 19);
            label8.Name = "label8";
            label8.Size = new Size(63, 15);
            label8.TabIndex = 8;
            label8.Text = "Command";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(523, 632);
            Controls.Add(groupBox2);
            Controls.Add(label7);
            Controls.Add(LogText);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "MainForm";
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
        private Button button3;
        private Button button2;
        private Button button1;
        private Label label8;
        private Button button4;
        private TextBox textBox6;
        private TextBox textBox5;
        private TextBox textBox4;
        private TextBox textBox3;
        private TextBox textBox2;
        private Label label10;
        private TextBox textBox1;
    }
}