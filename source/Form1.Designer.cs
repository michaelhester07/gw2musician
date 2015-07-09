namespace midiKeyboarder
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.cbFlat = new System.Windows.Forms.CheckBox();
            this.cbBass = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.cbConnect = new System.Windows.Forms.CheckBox();
            this.cbInputDevice = new System.Windows.Forms.ComboBox();
            this.cbOutputDevice = new System.Windows.Forms.ComboBox();
            this.cbConnectOutput = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.tbIpAddress = new System.Windows.Forms.TextBox();
            this.cbFlute = new System.Windows.Forms.CheckBox();
            this.nudPort = new System.Windows.Forms.NumericUpDown();
            this.cbRunServer = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudPort)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "C",
            "D",
            "E",
            "F",
            "G",
            "A",
            "B"});
            this.comboBox1.Location = new System.Drawing.Point(114, 66);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(92, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // cbFlat
            // 
            this.cbFlat.AutoSize = true;
            this.cbFlat.Location = new System.Drawing.Point(18, 179);
            this.cbFlat.Margin = new System.Windows.Forms.Padding(2);
            this.cbFlat.Name = "cbFlat";
            this.cbFlat.Size = new System.Drawing.Size(43, 17);
            this.cbFlat.TabIndex = 2;
            this.cbFlat.Text = "Flat";
            this.cbFlat.UseVisualStyleBackColor = true;
            this.cbFlat.CheckedChanged += new System.EventHandler(this.cbFlat_CheckedChanged);
            // 
            // cbBass
            // 
            this.cbBass.AutoSize = true;
            this.cbBass.Location = new System.Drawing.Point(142, 179);
            this.cbBass.Margin = new System.Windows.Forms.Padding(2);
            this.cbBass.Name = "cbBass";
            this.cbBass.Size = new System.Drawing.Size(49, 17);
            this.cbBass.TabIndex = 4;
            this.cbBass.Text = "Bass";
            this.cbBass.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Interval = 300;
            // 
            // cbConnect
            // 
            this.cbConnect.AutoSize = true;
            this.cbConnect.Location = new System.Drawing.Point(114, 10);
            this.cbConnect.Margin = new System.Windows.Forms.Padding(2);
            this.cbConnect.Name = "cbConnect";
            this.cbConnect.Size = new System.Drawing.Size(93, 17);
            this.cbConnect.TabIndex = 9;
            this.cbConnect.Text = "Connect Input";
            this.cbConnect.UseVisualStyleBackColor = true;
            this.cbConnect.CheckedChanged += new System.EventHandler(this.cbConnect_CheckedChanged);
            // 
            // cbInputDevice
            // 
            this.cbInputDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbInputDevice.FormattingEnabled = true;
            this.cbInputDevice.Location = new System.Drawing.Point(9, 8);
            this.cbInputDevice.Margin = new System.Windows.Forms.Padding(2);
            this.cbInputDevice.Name = "cbInputDevice";
            this.cbInputDevice.Size = new System.Drawing.Size(92, 21);
            this.cbInputDevice.TabIndex = 10;
            // 
            // cbOutputDevice
            // 
            this.cbOutputDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOutputDevice.FormattingEnabled = true;
            this.cbOutputDevice.Location = new System.Drawing.Point(9, 32);
            this.cbOutputDevice.Margin = new System.Windows.Forms.Padding(2);
            this.cbOutputDevice.Name = "cbOutputDevice";
            this.cbOutputDevice.Size = new System.Drawing.Size(92, 21);
            this.cbOutputDevice.TabIndex = 11;
            // 
            // cbConnectOutput
            // 
            this.cbConnectOutput.AutoSize = true;
            this.cbConnectOutput.Location = new System.Drawing.Point(114, 34);
            this.cbConnectOutput.Margin = new System.Windows.Forms.Padding(2);
            this.cbConnectOutput.Name = "cbConnectOutput";
            this.cbConnectOutput.Size = new System.Drawing.Size(101, 17);
            this.cbConnectOutput.TabIndex = 12;
            this.cbConnectOutput.Text = "Connect Output";
            this.cbConnectOutput.UseVisualStyleBackColor = true;
            this.cbConnectOutput.CheckedChanged += new System.EventHandler(this.cbConnectOutput_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 68);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Auto Transpose";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(115, 102);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(95, 17);
            this.checkBox1.TabIndex = 14;
            this.checkBox1.Text = "Connect Client";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // tbIpAddress
            // 
            this.tbIpAddress.Location = new System.Drawing.Point(18, 101);
            this.tbIpAddress.Margin = new System.Windows.Forms.Padding(2);
            this.tbIpAddress.Name = "tbIpAddress";
            this.tbIpAddress.Size = new System.Drawing.Size(76, 20);
            this.tbIpAddress.TabIndex = 15;
            this.tbIpAddress.Text = "192.168.1.4";
            // 
            // cbFlute
            // 
            this.cbFlute.AutoSize = true;
            this.cbFlute.Location = new System.Drawing.Point(78, 179);
            this.cbFlute.Margin = new System.Windows.Forms.Padding(2);
            this.cbFlute.Name = "cbFlute";
            this.cbFlute.Size = new System.Drawing.Size(49, 17);
            this.cbFlute.TabIndex = 3;
            this.cbFlute.Text = "Flute";
            this.cbFlute.UseVisualStyleBackColor = true;
            // 
            // nudPort
            // 
            this.nudPort.Location = new System.Drawing.Point(17, 135);
            this.nudPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudPort.Name = "nudPort";
            this.nudPort.Size = new System.Drawing.Size(77, 20);
            this.nudPort.TabIndex = 16;
            this.nudPort.Value = new decimal(new int[] {
            1337,
            0,
            0,
            0});
            // 
            // cbRunServer
            // 
            this.cbRunServer.AutoSize = true;
            this.cbRunServer.Location = new System.Drawing.Point(114, 136);
            this.cbRunServer.Margin = new System.Windows.Forms.Padding(2);
            this.cbRunServer.Name = "cbRunServer";
            this.cbRunServer.Size = new System.Drawing.Size(122, 17);
            this.cbRunServer.TabIndex = 17;
            this.cbRunServer.Text = "Run Multibox Server";
            this.cbRunServer.UseVisualStyleBackColor = true;
            this.cbRunServer.CheckedChanged += new System.EventHandler(this.cbRunServer_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(253, 206);
            this.Controls.Add(this.cbRunServer);
            this.Controls.Add(this.nudPort);
            this.Controls.Add(this.tbIpAddress);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbConnectOutput);
            this.Controls.Add(this.cbOutputDevice);
            this.Controls.Add(this.cbInputDevice);
            this.Controls.Add(this.cbConnect);
            this.Controls.Add(this.cbBass);
            this.Controls.Add(this.cbFlute);
            this.Controls.Add(this.cbFlat);
            this.Controls.Add(this.comboBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Midi Keyboarder";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudPort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.CheckBox cbFlat;
        private System.Windows.Forms.CheckBox cbBass;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox cbConnect;
        private System.Windows.Forms.ComboBox cbInputDevice;
        private System.Windows.Forms.ComboBox cbOutputDevice;
        private System.Windows.Forms.CheckBox cbConnectOutput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox tbIpAddress;
        private System.Windows.Forms.CheckBox cbFlute;
        private System.Windows.Forms.NumericUpDown nudPort;
        private System.Windows.Forms.CheckBox cbRunServer;
    }
}

