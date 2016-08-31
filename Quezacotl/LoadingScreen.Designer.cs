namespace Quezacotl
{
    partial class LoadingScreen
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
            this.progressBarLoad = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // progressBarLoad
            // 
            this.progressBarLoad.Location = new System.Drawing.Point(254, 309);
            this.progressBarLoad.Name = "progressBarLoad";
            this.progressBarLoad.Size = new System.Drawing.Size(278, 23);
            this.progressBarLoad.Step = 1;
            this.progressBarLoad.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBarLoad.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Action Comics", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(322, 275);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Loading...";
            // 
            // LoadingScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Quezacotl.Properties.Resources.loading;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(544, 344);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBarLoad);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(546, 346);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(546, 346);
            this.Name = "LoadingScreen";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.LoadingScreen_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ProgressBar progressBarLoad;
    }
}