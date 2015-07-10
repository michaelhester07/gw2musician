namespace midiKeyboarder
{
    partial class sectionPanel
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
            this.renderPlane = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.renderPlane)).BeginInit();
            this.SuspendLayout();
            // 
            // renderPlane
            // 
            this.renderPlane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.renderPlane.Location = new System.Drawing.Point(0, 0);
            this.renderPlane.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.renderPlane.Name = "renderPlane";
            this.renderPlane.Size = new System.Drawing.Size(1045, 265);
            this.renderPlane.TabIndex = 0;
            this.renderPlane.TabStop = false;
            this.renderPlane.Click += new System.EventHandler(this.renderPlane_Click);
            // 
            // sectionPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.renderPlane);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "sectionPanel";
            this.Size = new System.Drawing.Size(1045, 265);
            ((System.ComponentModel.ISupportInitialize)(this.renderPlane)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox renderPlane;
    }
}
