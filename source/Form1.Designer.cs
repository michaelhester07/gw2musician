﻿namespace midiKeyboarder
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.instrumentList = new System.Windows.Forms.FlowLayoutPanel();
            this.instrumentSectionList = new System.Windows.Forms.FlowLayoutPanel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnAddInstrument = new System.Windows.Forms.ToolStripButton();
            this.btnRemoveInstrument = new System.Windows.Forms.ToolStripButton();
            this.btnLoad = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.btnSeekStart = new System.Windows.Forms.ToolStripButton();
            this.btnRecord = new System.Windows.Forms.ToolStripButton();
            this.btnPlay = new System.Windows.Forms.ToolStripButton();
            this.btnDeleteSection = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tbBPM = new System.Windows.Forms.ToolStripTextBox();
            this.tickLabel = new System.Windows.Forms.ToolStripLabel();
            this.cbConnectOutput = new System.Windows.Forms.CheckBox();
            this.cbxOutputDevices = new System.Windows.Forms.ComboBox();
            this.cbConnectInput = new System.Windows.Forms.CheckBox();
            this.cbxInputDevices = new System.Windows.Forms.ComboBox();
            this.playTimer = new System.Windows.Forms.Timer(this.components);
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
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.67589F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 86.32411F));
            this.tableLayoutPanel1.Controls.Add(this.instrumentList, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.instrumentSectionList, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.toolStrip1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.41048F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85.58952F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1043, 549);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // instrumentList
            // 
            this.instrumentList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.instrumentList.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.instrumentList.Location = new System.Drawing.Point(4, 84);
            this.instrumentList.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.instrumentList.Name = "instrumentList";
            this.instrumentList.Size = new System.Drawing.Size(137, 461);
            this.instrumentList.TabIndex = 0;
            // 
            // instrumentSectionList
            // 
            this.instrumentSectionList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.instrumentSectionList.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.instrumentSectionList.Location = new System.Drawing.Point(147, 84);
            this.instrumentSectionList.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.instrumentSectionList.Name = "instrumentSectionList";
            this.instrumentSectionList.Size = new System.Drawing.Size(892, 461);
            this.instrumentSectionList.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddInstrument,
            this.btnRemoveInstrument,
            this.btnLoad,
            this.btnSave});
            this.toolStrip1.Location = new System.Drawing.Point(2, 53);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(141, 27);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnAddInstrument
            // 
            this.btnAddInstrument.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddInstrument.Image = global::midiKeyboarder.Properties.Resources.plus;
            this.btnAddInstrument.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddInstrument.Name = "btnAddInstrument";
            this.btnAddInstrument.Size = new System.Drawing.Size(24, 24);
            this.btnAddInstrument.Text = "toolStripButton1";
            this.btnAddInstrument.Click += new System.EventHandler(this.btnAddInstrument_Click);
            // 
            // btnRemoveInstrument
            // 
            this.btnRemoveInstrument.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRemoveInstrument.Image = global::midiKeyboarder.Properties.Resources.delete;
            this.btnRemoveInstrument.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRemoveInstrument.Name = "btnRemoveInstrument";
            this.btnRemoveInstrument.Size = new System.Drawing.Size(24, 24);
            this.btnRemoveInstrument.Text = "toolStripButton2";
            this.btnRemoveInstrument.Click += new System.EventHandler(this.btnRemoveInstrument_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnLoad.Image = global::midiKeyboarder.Properties.Resources.load;
            this.btnLoad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(24, 24);
            this.btnLoad.Text = "toolStripButton3";
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnSave
            // 
            this.btnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSave.Image = global::midiKeyboarder.Properties.Resources.save;
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(24, 24);
            this.btnSave.Text = "toolStripButton1";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.toolStrip2);
            this.panel1.Controls.Add(this.cbConnectOutput);
            this.panel1.Controls.Add(this.cbxOutputDevices);
            this.panel1.Controls.Add(this.cbConnectInput);
            this.panel1.Controls.Add(this.cbxInputDevices);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(147, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(892, 74);
            this.panel1.TabIndex = 3;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSeekStart,
            this.btnRecord,
            this.btnPlay,
            this.btnDeleteSection,
            this.toolStripLabel1,
            this.tbBPM,
            this.tickLabel});
            this.toolStrip2.Location = new System.Drawing.Point(0, 47);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(892, 27);
            this.toolStrip2.TabIndex = 3;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // btnSeekStart
            // 
            this.btnSeekStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSeekStart.Image = global::midiKeyboarder.Properties.Resources.seek;
            this.btnSeekStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSeekStart.Name = "btnSeekStart";
            this.btnSeekStart.Size = new System.Drawing.Size(24, 24);
            this.btnSeekStart.Text = "SeekBegin";
            this.btnSeekStart.Click += new System.EventHandler(this.btnSeekStart_Click);
            // 
            // btnRecord
            // 
            this.btnRecord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRecord.Image = global::midiKeyboarder.Properties.Resources.record;
            this.btnRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRecord.Name = "btnRecord";
            this.btnRecord.Size = new System.Drawing.Size(24, 24);
            this.btnRecord.Text = "toolStripButton2";
            this.btnRecord.Click += new System.EventHandler(this.btnRecord_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPlay.Image = global::midiKeyboarder.Properties.Resources.play;
            this.btnPlay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(24, 24);
            this.btnPlay.Text = "toolStripButton4";
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnDeleteSection
            // 
            this.btnDeleteSection.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDeleteSection.Image = global::midiKeyboarder.Properties.Resources.delete;
            this.btnDeleteSection.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeleteSection.Name = "btnDeleteSection";
            this.btnDeleteSection.Size = new System.Drawing.Size(24, 24);
            this.btnDeleteSection.Text = "toolStripButton1";
            this.btnDeleteSection.Click += new System.EventHandler(this.btnDeleteSection_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(96, 24);
            this.toolStripLabel1.Text = "Beats Per Minute";
            // 
            // tbBPM
            // 
            this.tbBPM.Name = "tbBPM";
            this.tbBPM.Size = new System.Drawing.Size(76, 27);
            this.tbBPM.Text = "120";
            // 
            // tickLabel
            // 
            this.tickLabel.Name = "tickLabel";
            this.tickLabel.Size = new System.Drawing.Size(86, 24);
            this.tickLabel.Text = "toolStripLabel2";
            // 
            // cbConnectOutput
            // 
            this.cbConnectOutput.AutoSize = true;
            this.cbConnectOutput.Location = new System.Drawing.Point(285, 3);
            this.cbConnectOutput.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbConnectOutput.Name = "cbConnectOutput";
            this.cbConnectOutput.Size = new System.Drawing.Size(101, 17);
            this.cbConnectOutput.TabIndex = 1;
            this.cbConnectOutput.Text = "Connect Output";
            this.cbConnectOutput.UseVisualStyleBackColor = true;
            this.cbConnectOutput.CheckedChanged += new System.EventHandler(this.cbConnectOutput_CheckedChanged_1);
            // 
            // cbxOutputDevices
            // 
            this.cbxOutputDevices.FormattingEnabled = true;
            this.cbxOutputDevices.Location = new System.Drawing.Point(190, 2);
            this.cbxOutputDevices.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbxOutputDevices.Name = "cbxOutputDevices";
            this.cbxOutputDevices.Size = new System.Drawing.Size(92, 21);
            this.cbxOutputDevices.TabIndex = 2;
            // 
            // cbConnectInput
            // 
            this.cbConnectInput.AutoSize = true;
            this.cbConnectInput.Location = new System.Drawing.Point(98, 4);
            this.cbConnectInput.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbConnectInput.Name = "cbConnectInput";
            this.cbConnectInput.Size = new System.Drawing.Size(92, 17);
            this.cbConnectInput.TabIndex = 0;
            this.cbConnectInput.Text = "Connect input";
            this.cbConnectInput.UseVisualStyleBackColor = true;
            this.cbConnectInput.CheckedChanged += new System.EventHandler(this.cbConnectInput_CheckedChanged);
            // 
            // cbxInputDevices
            // 
            this.cbxInputDevices.FormattingEnabled = true;
            this.cbxInputDevices.Location = new System.Drawing.Point(2, 2);
            this.cbxInputDevices.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbxInputDevices.Name = "cbxInputDevices";
            this.cbxInputDevices.Size = new System.Drawing.Size(92, 21);
            this.cbxInputDevices.TabIndex = 0;
            // 
            // playTimer
            // 
            this.playTimer.Interval = 10;
            this.playTimer.Tick += new System.EventHandler(this.playTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1043, 549);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
        private System.Windows.Forms.ToolStripButton btnLoad;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox cbConnectOutput;
        private System.Windows.Forms.ComboBox cbxOutputDevices;
        private System.Windows.Forms.CheckBox cbConnectInput;
        private System.Windows.Forms.ComboBox cbxInputDevices;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton btnSeekStart;
        private System.Windows.Forms.ToolStripButton btnRecord;
        private System.Windows.Forms.ToolStripButton btnPlay;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox tbBPM;
        private System.Windows.Forms.ToolStripButton btnSave;
        private System.Windows.Forms.Timer playTimer;
        private System.Windows.Forms.ToolStripLabel tickLabel;
        private System.Windows.Forms.ToolStripButton btnDeleteSection;
    }
}

