namespace PokeUnit.Infrastructure.MapEditor.Dialogs
{
    partial class MapNoiseDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapNoiseDialog));
            label1 = new Label();
            cbNoiseType = new ComboBox();
            label2 = new Label();
            button1 = new Button();
            button2 = new Button();
            panel1 = new Panel();
            nbFrequency = new NumericUpDown();
            nbAmplitude = new NumericUpDown();
            label3 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)nbFrequency).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nbAmplitude).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(64, 15);
            label1.TabIndex = 0;
            label1.Text = "Map Noise";
            // 
            // cbNoiseType
            // 
            cbNoiseType.FormattingEnabled = true;
            cbNoiseType.Items.AddRange(new object[] { "Simple Noise", "Smooth Noise", "Diamong Square Noise", "Perlin Noise", "Wave Noise" });
            cbNoiseType.Location = new Point(12, 87);
            cbNoiseType.Name = "cbNoiseType";
            cbNoiseType.Size = new Size(217, 23);
            cbNoiseType.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 66);
            label2.Name = "label2";
            label2.Size = new Size(67, 15);
            label2.TabIndex = 2;
            label2.Text = "Noise Type:";
            // 
            // button1
            // 
            button1.DialogResult = DialogResult.OK;
            button1.Location = new Point(157, 232);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 3;
            button1.Text = "Apply";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.DialogResult = DialogResult.Cancel;
            button2.Location = new Point(76, 232);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 4;
            button2.Text = "Cancel";
            button2.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.BackgroundImage = (Image)resources.GetObject("panel1.BackgroundImage");
            panel1.BackgroundImageLayout = ImageLayout.Stretch;
            panel1.Location = new Point(157, 9);
            panel1.Name = "panel1";
            panel1.Size = new Size(72, 72);
            panel1.TabIndex = 5;
            // 
            // nbFrequency
            // 
            nbFrequency.Location = new Point(11, 179);
            nbFrequency.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            nbFrequency.Name = "nbFrequency";
            nbFrequency.Size = new Size(88, 23);
            nbFrequency.TabIndex = 6;
            // 
            // nbAmplitude
            // 
            nbAmplitude.Location = new Point(12, 131);
            nbAmplitude.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            nbAmplitude.Name = "nbAmplitude";
            nbAmplitude.Size = new Size(88, 23);
            nbAmplitude.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(11, 161);
            label3.Name = "label3";
            label3.Size = new Size(62, 15);
            label3.TabIndex = 8;
            label3.Text = "Frequency";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(11, 113);
            label4.Name = "label4";
            label4.Size = new Size(63, 15);
            label4.TabIndex = 9;
            label4.Text = "Amplitude";
            // 
            // MapNoiseDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(244, 267);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(nbAmplitude);
            Controls.Add(nbFrequency);
            Controls.Add(panel1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(cbNoiseType);
            Controls.Add(label1);
            Name = "MapNoiseDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "MapNoiseDialog";
            ((System.ComponentModel.ISupportInitialize)nbFrequency).EndInit();
            ((System.ComponentModel.ISupportInitialize)nbAmplitude).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Button button1;
        private Button button2;
        private Panel panel1;
        public ComboBox cbNoiseType;
        private NumericUpDown numericUpDown1;
        private Label label3;
        private Label label4;
        public NumericUpDown nbFrequency;
        public NumericUpDown nbAmplitude;
    }
}