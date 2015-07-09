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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.instrumentList = new System.Windows.Forms.FlowLayoutPanel();
            this.instrumentSectionList = new System.Windows.Forms.FlowLayoutPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAddInstrument = new System.Windows.Forms.ToolStripButton();
            this.btnRemoveInstrument = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.cbConnectInput = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbxInputDevices = new System.Windows.Forms.ComboBox();
            this.cbConnectOutput = new System.Windows.Forms.CheckBox();
            this.cbxOutputDevices = new System.Windows.Forms.ComboBox();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btnSeekStart = new System.Windows.Forms.ToolStripButton();
            this.btnRecord = new System.Windows.Forms.ToolStripButton();
            this.btnPlay = new System.Windows.Forms.ToolStripButton();
            this.btnStop = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tbBPM = new System.Windows.Forms.ToolStripTextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 300;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.67589F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 86.32411F));
            this.tableLayoutPanel1.Controls.Add(this.instrumentList, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.instrumentSectionList, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.toolStrip1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.41048F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85.58952F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1265, 458);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // instrumentList
            // 
            this.instrumentList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.instrumentList.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.instrumentList.Location = new System.Drawing.Point(3, 69);
            this.instrumentList.Name = "instrumentList";
            this.instrumentList.Size = new System.Drawing.Size(166, 386);
            this.instrumentList.TabIndex = 0;
            // 
            // instrumentSectionList
            // 
            this.instrumentSectionList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.instrumentSectionList.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.instrumentSectionList.Location = new System.Drawing.Point(175, 69);
            this.instrumentSectionList.Name = "instrumentSectionList";
            this.instrumentSectionList.Size = new System.Drawing.Size(1087, 386);
            this.instrumentSectionList.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddInstrument,
            this.btnRemoveInstrument,
            this.toolStripButton3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 39);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(172, 27);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnAddInstrument
            // 
            this.btnAddInstrument.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddInstrument.Image = ((System.Drawing.Image)(resources.GetObject("btnAddInstrument.Image")));
            this.btnAddInstrument.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddInstrument.Name = "btnAddInstrument";
            this.btnAddInstrument.Size = new System.Drawing.Size(24, 24);
            this.btnAddInstrument.Text = "toolStripButton1";
            // 
            // btnRemoveInstrument
            // 
            this.btnRemoveInstrument.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRemoveInstrument.Image = ((System.Drawing.Image)(resources.GetObject("btnRemoveInstrument.Image")));
            this.btnRemoveInstrument.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRemoveInstrument.Name = "btnRemoveInstrument";
            this.btnRemoveInstrument.Size = new System.Drawing.Size(24, 24);
            this.btnRemoveInstrument.Text = "toolStripButton2";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(24, 24);
            this.toolStripButton3.Text = "toolStripButton3";
            // 
            // cbConnectInput
            // 
            this.cbConnectInput.AutoSize = true;
            this.cbConnectInput.Location = new System.Drawing.Point(130, 5);
            this.cbConnectInput.Name = "cbConnectInput";
            this.cbConnectInput.Size = new System.Drawing.Size(117, 21);
            this.cbConnectInput.TabIndex = 0;
            this.cbConnectInput.Text = "Connect input";
            this.cbConnectInput.UseVisualStyleBackColor = true;
            this.cbConnectInput.CheckedChanged += new System.EventHandler(this.cbConnectInput_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.toolStrip2);
            this.panel1.Controls.Add(this.cbConnectOutput);
            this.panel1.Controls.Add(this.cbxOutputDevices);
            this.panel1.Controls.Add(this.cbConnectInput);
            this.panel1.Controls.Add(this.cbxInputDevices);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(175, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1087, 60);
            this.panel1.TabIndex = 3;
            // 
            // cbxInputDevices
            // 
            this.cbxInputDevices.FormattingEnabled = true;
            this.cbxInputDevices.Location = new System.Drawing.Point(3, 3);
            this.cbxInputDevices.Name = "cbxInputDevices";
            this.cbxInputDevices.Size = new System.Drawing.Size(121, 24);
            this.cbxInputDevices.TabIndex = 0;
            // 
            // cbConnectOutput
            // 
            this.cbConnectOutput.AutoSize = true;
            this.cbConnectOutput.Location = new System.Drawing.Point(380, 4);
            this.cbConnectOutput.Name = "cbConnectOutput";
            this.cbConnectOutput.Size = new System.Drawing.Size(129, 21);
            this.cbConnectOutput.TabIndex = 1;
            this.cbConnectOutput.Text = "Connect Output";
            this.cbConnectOutput.UseVisualStyleBackColor = true;
            this.cbConnectOutput.CheckedChanged += new System.EventHandler(this.cbConnectOutput_CheckedChanged_1);
            // 
            // cbxOutputDevices
            // 
            this.cbxOutputDevices.FormattingEnabled = true;
            this.cbxOutputDevices.Location = new System.Drawing.Point(253, 2);
            this.cbxOutputDevices.Name = "cbxOutputDevices";
            this.cbxOutputDevices.Size = new System.Drawing.Size(121, 24);
            this.cbxOutputDevices.TabIndex = 2;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSeekStart,
            this.btnRecord,
            this.btnPlay,
            this.btnStop,
            this.toolStripLabel1,
            this.tbBPM});
            this.toolStrip2.Location = new System.Drawing.Point(0, 33);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1087, 27);
            this.toolStrip2.TabIndex = 3;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // btnSeekStart
            // 
            this.btnSeekStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSeekStart.Image = ((System.Drawing.Image)(resources.GetObject("btnSeekStart.Image")));
            this.btnSeekStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSeekStart.Name = "btnSeekStart";
            this.btnSeekStart.Size = new System.Drawing.Size(24, 24);
            this.btnSeekStart.Text = "SeekBegin";
            // 
            // btnRecord
            // 
            this.btnRecord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRecord.Image = ((System.Drawing.Image)(resources.GetObject("btnRecord.Image")));
            this.btnRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRecord.Name = "btnRecord";
            this.btnRecord.Size = new System.Drawing.Size(24, 24);
            this.btnRecord.Text = "toolStripButton2";
            // 
            // btnPlay
            // 
            this.btnPlay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPlay.Image = ((System.Drawing.Image)(resources.GetObject("btnPlay.Image")));
            this.btnPlay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(24, 24);
            this.btnPlay.Text = "toolStripButton4";
            // 
            // btnStop
            // 
            this.btnStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnStop.Image = ((System.Drawing.Image)(resources.GetObject("btnStop.Image")));
            this.btnStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(24, 24);
            this.btnStop.Text = "toolStripButton5";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(120, 24);
            this.toolStripLabel1.Text = "Beats Per Minute";
            // 
            // tbBPM
            // 
            this.tbBPM.Name = "tbBPM";
            this.tbBPM.Size = new System.Drawing.Size(100, 27);
            this.tbBPM.Text = "120";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1265, 458);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Midi Keyboarder";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel instrumentList;
        private System.Windows.Forms.FlowLayoutPanel instrumentSectionList;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAddInstrument;
        private System.Windows.Forms.ToolStripButton btnRemoveInstrument;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox cbConnectOutput;
        private System.Windows.Forms.ComboBox cbxOutputDevices;
        private System.Windows.Forms.CheckBox cbConnectInput;
        private System.Windows.Forms.ComboBox cbxInputDevices;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton btnSeekStart;
        private System.Windows.Forms.ToolStripButton btnRecord;
        private System.Windows.Forms.ToolStripButton btnPlay;
        private System.Windows.Forms.ToolStripButton btnStop;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox tbBPM;
    }
}

