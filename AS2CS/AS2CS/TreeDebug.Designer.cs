namespace AS2CS
{
    partial class TreeDebug
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
            this.tvw_display = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // tvw_display
            // 
            this.tvw_display.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvw_display.Location = new System.Drawing.Point(0, 0);
            this.tvw_display.Name = "tvw_display";
            this.tvw_display.Size = new System.Drawing.Size(789, 697);
            this.tvw_display.TabIndex = 0;
            // 
            // TreeDebug
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 697);
            this.Controls.Add(this.tvw_display);
            this.Name = "TreeDebug";
            this.Text = "TreeDebug";
            this.Load += new System.EventHandler(this.TreeDebug_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tvw_display;
    }
}