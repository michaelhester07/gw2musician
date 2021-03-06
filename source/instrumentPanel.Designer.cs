﻿namespace midiKeyboarder
{
    partial class instrumentPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbxType = new System.Windows.Forms.ComboBox();
            this.tbIp = new System.Windows.Forms.TextBox();
            this.nudPort = new System.Windows.Forms.NumericUpDown();
            this.cbPlay = new System.Windows.Forms.CheckBox();
            this.cbRemote = new System.Windows.Forms.CheckBox();
            this.cbMboxServer = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.nudPort)).BeginInit();
            this.SuspendLayout();
            // 
            // cbxType
            // 
            this.cbxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxType.FormattingEnabled = true;
            this.cbxType.Items.AddRange(new object[] {
            "standard",
            "flute",
            "bass",
            "drum"});
            this.cbxType.Location = new System.Drawing.Point(3, 2);
            this.cbxType.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbxType.Name = "cbxType";
            this.cbxType.Size = new System.Drawing.Size(109, 21);
            this.cbxType.TabIndex = 0;
            this.cbxType.SelectedIndexChanged += new System.EventHandler(this.cbxType_SelectedIndexChanged);
            // 
            // tbIp
            // 
            this.tbIp.Location = new System.Drawing.Point(2, 68);
            this.tbIp.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbIp.Name = "tbIp";
            this.tbIp.Size = new System.Drawing.Size(109, 20);
            this.tbIp.TabIndex = 1;
            this.tbIp.TextChanged += new System.EventHandler(this.tbIp_TextChanged);
            // 
            // nudPort
            // 
            this.nudPort.Location = new System.Drawing.Point(3, 92);
            this.nudPort.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nudPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.nudPort.Name = "nudPort";
            this.nudPort.Size = new System.Drawing.Size(107, 20);
            this.nudPort.TabIndex = 2;
            this.nudPort.Value = new decimal(new int[] {
            55555,
            0,
            0,
            0});
            this.nudPort.ValueChanged += new System.EventHandler(this.nudPort_ValueChanged);
            // 
            // cbPlay
            // 
            this.cbPlay.AutoSize = true;
            this.cbPlay.Location = new System.Drawing.Point(3, 28);
            this.cbPlay.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbPlay.Name = "cbPlay";
            this.cbPlay.Size = new System.Drawing.Size(46, 17);
            this.cbPlay.TabIndex = 3;
            this.cbPlay.Text = "Play";
            this.cbPlay.UseVisualStyleBackColor = true;
            this.cbPlay.CheckedChanged += new System.EventHandler(this.cbPlay_CheckedChanged);
            // 
            // cbRemote
            // 
            this.cbRemote.AutoSize = true;
            this.cbRemote.Location = new System.Drawing.Point(2, 50);
            this.cbRemote.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbRemote.Name = "cbRemote";
            this.cbRemote.Size = new System.Drawing.Size(106, 17);
            this.cbRemote.TabIndex = 4;
            this.cbRemote.Text = "Connect Remote";
            this.cbRemote.UseVisualStyleBackColor = true;
            this.cbRemote.CheckedChanged += new System.EventHandler(this.cbRemote_CheckedChanged);
            // 
            // cbMboxServer
            // 
            this.cbMboxServer.AutoSize = true;
            this.cbMboxServer.Location = new System.Drawing.Point(3, 124);
            this.cbMboxServer.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbMboxServer.Name = "cbMboxServer";
            this.cbMboxServer.Size = new System.Drawing.Size(82, 17);
            this.cbMboxServer.TabIndex = 5;
            this.cbMboxServer.Text = "Start Server";
            this.cbMboxServer.UseVisualStyleBackColor = true;
            this.cbMboxServer.CheckedChanged += new System.EventHandler(this.cbMboxServer_CheckedChanged);
            // 
            // instrumentPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.cbMboxServer);
            this.Controls.Add(this.cbRemote);
            this.Controls.Add(this.cbPlay);
            this.Controls.Add(this.nudPort);
            this.Controls.Add(this.tbIp);
            this.Controls.Add(this.cbxType);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "instrumentPanel";
            this.Size = new System.Drawing.Size(110, 144);
            this.Load += new System.EventHandler(this.instrumentPanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudPort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ComboBox cbxType;
        private System.Windows.Forms.TextBox tbIp;
        private System.Windows.Forms.NumericUpDown nudPort;
        private System.Windows.Forms.CheckBox cbPlay;
        private System.Windows.Forms.CheckBox cbRemote;
        private System.Windows.Forms.CheckBox cbMboxServer;

    }
}
