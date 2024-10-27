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
            panel1 = new Panel();
            btnStart = new Button();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)pbBackground).BeginInit();
            panel1.SuspendLayout();
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
            // panel1
            // 
            panel1.Controls.Add(btnStart);
            panel1.Controls.Add(label2);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 330);
            panel1.Name = "panel1";
            panel1.Size = new Size(584, 31);
            panel1.TabIndex = 3;
            // 
            // btnStart
            // 
            btnStart.Cursor = Cursors.Hand;
            btnStart.Location = new Point(381, 3);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(200, 23);
            btnStart.TabIndex = 1;
            btnStart.Text = "Iniciar";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.SteelBlue;
            label2.Location = new Point(12, 7);
            label2.Name = "label2";
            label2.Size = new Size(215, 15);
            label2.TabIndex = 0;
            label2.Text = "https://github.com/lthiagovs/PokeUnit";
            // 
            // LauncherForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 361);
            Controls.Add(panel1);
            Controls.Add(label1);
            Controls.Add(pbBackground);
            Name = "LauncherForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LauncherForm";
            ((System.ComponentModel.ISupportInitialize)pbBackground).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private PictureBox pbBackground;
        private Panel panel1;
        private Label label2;
        private Button btnStart;
    }
}