namespace midiKeyboarder
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
            ((System.ComponentModel.ISupportInitialize)(this.nudPort)).BeginInit();
            this.SuspendLayout();
            // 
            // cbxType
            // 
            this.cbxType.FormattingEnabled = true;
            this.cbxType.Location = new System.Drawing.Point(4, 3);
            this.cbxType.Name = "cbxType";
            this.cbxType.Size = new System.Drawing.Size(144, 24);
            this.cbxType.TabIndex = 0;
            // 
            // tbIp
            // 
            this.tbIp.Location = new System.Drawing.Point(3, 84);
            this.tbIp.Name = "tbIp";
            this.tbIp.Size = new System.Drawing.Size(144, 22);
            this.tbIp.TabIndex = 1;
            // 
            // nudPort
            // 
            this.nudPort.Location = new System.Drawing.Point(4, 113);
            this.nudPort.Name = "nudPort";
            this.nudPort.Size = new System.Drawing.Size(143, 22);
            this.nudPort.TabIndex = 2;
            // 
            // cbPlay
            // 
            this.cbPlay.AutoSize = true;
            this.cbPlay.Location = new System.Drawing.Point(4, 34);
            this.cbPlay.Name = "cbPlay";
            this.cbPlay.Size = new System.Drawing.Size(57, 21);
            this.cbPlay.TabIndex = 3;
            this.cbPlay.Text = "Play";
            this.cbPlay.UseVisualStyleBackColor = true;
            // 
            // cbRemote
            // 
            this.cbRemote.AutoSize = true;
            this.cbRemote.Location = new System.Drawing.Point(3, 61);
            this.cbRemote.Name = "cbRemote";
            this.cbRemote.Size = new System.Drawing.Size(135, 21);
            this.cbRemote.TabIndex = 4;
            this.cbRemote.Text = "Connect Remote";
            this.cbRemote.UseVisualStyleBackColor = true;
            // 
            // instrumentPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbRemote);
            this.Controls.Add(this.cbPlay);
            this.Controls.Add(this.nudPort);
            this.Controls.Add(this.tbIp);
            this.Controls.Add(this.cbxType);
            this.Name = "instrumentPanel";
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

    }
}
