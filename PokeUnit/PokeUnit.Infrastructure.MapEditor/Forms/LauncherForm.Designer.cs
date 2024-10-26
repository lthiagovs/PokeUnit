namespace PokeUnit.Infrastructure.MapEditor.Forms
{
    partial class LauncherForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LauncherForm));
            label1 = new Label();
            pbBackground = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pbBackground).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.BorderStyle = BorderStyle.Fixed3D;
            label1.FlatStyle = FlatStyle.Flat;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(165, 24);
            label1.TabIndex = 0;
            label1.Text = "PUnit Map Editor v1.0";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pbBackground
            // 
            pbBackground.Dock = DockStyle.Fill;
            pbBackground.Image = (Image)resources.GetObject("pbBackground.Image");
            pbBackground.Location = new Point(0, 0);
            pbBackground.Name = "pbBackground";
            pbBackground.Size = new Size(584, 361);
            pbBackground.TabIndex = 2;
            pbBackground.TabStop = false;
            // 
            // LauncherForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 361);
            Controls.Add(label1);
            Controls.Add(pbBackground);
            Name = "LauncherForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LauncherForm";
            ((System.ComponentModel.ISupportInitialize)pbBackground).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private PictureBox pbBackground;
    }
}