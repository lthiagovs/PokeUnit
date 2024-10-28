namespace PokeUnit.Infrastructure.MapEditor.Dialogs
{
    partial class NewMapDialog
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
            btnCreate = new Button();
            btnCancel = new Button();
            label1 = new Label();
            nSizeX = new NumericUpDown();
            nSizeY = new NumericUpDown();
            label4 = new Label();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)nSizeX).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nSizeY).BeginInit();
            SuspendLayout();
            // 
            // btnCreate
            // 
            btnCreate.DialogResult = DialogResult.OK;
            btnCreate.Location = new Point(93, 132);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(75, 23);
            btnCreate.TabIndex = 0;
            btnCreate.Text = "Create";
            btnCreate.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(12, 132);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 1;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(107, 15);
            label1.TabIndex = 2;
            label1.Text = "Create a new map?";
            // 
            // nSizeX
            // 
            nSizeX.Location = new Point(16, 61);
            nSizeX.Maximum = new decimal(new int[] { 173, 0, 0, 0 });
            nSizeX.Name = "nSizeX";
            nSizeX.Size = new Size(71, 23);
            nSizeX.TabIndex = 7;
            // 
            // nSizeY
            // 
            nSizeY.Location = new Point(92, 61);
            nSizeY.Maximum = new decimal(new int[] { 173, 0, 0, 0 });
            nSizeY.Name = "nSizeY";
            nSizeY.Size = new Size(71, 23);
            nSizeY.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(16, 43);
            label4.Name = "label4";
            label4.Size = new Size(33, 15);
            label4.TabIndex = 9;
            label4.Text = "PosX";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(93, 43);
            label5.Name = "label5";
            label5.Size = new Size(33, 15);
            label5.TabIndex = 10;
            label5.Text = "PosY";
            // 
            // NewMapDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(175, 167);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(nSizeY);
            Controls.Add(nSizeX);
            Controls.Add(label1);
            Controls.Add(btnCancel);
            Controls.Add(btnCreate);
            Name = "NewMapDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "New Map";
            ((System.ComponentModel.ISupportInitialize)nSizeX).EndInit();
            ((System.ComponentModel.ISupportInitialize)nSizeY).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCreate;
        private Button btnCancel;
        private Label label1;
        public NumericUpDown nSizeX;
        public NumericUpDown nSizeY;
        private Label label4;
        private Label label5;
    }
}