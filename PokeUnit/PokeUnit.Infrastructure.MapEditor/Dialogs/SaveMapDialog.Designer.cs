namespace PokeUnit.Infrastructure.MapEditor.Dialogs
{
    partial class SaveMapDialog
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
            btnSave = new Button();
            btnCancel = new Button();
            label1 = new Label();
            txtName = new TextBox();
            label2 = new Label();
            label3 = new Label();
            txtDescription = new TextBox();
            SuspendLayout();
            // 
            // btnSave
            // 
            btnSave.DialogResult = DialogResult.OK;
            btnSave.Location = new Point(123, 183);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 0;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(16, 183);
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
            label1.Size = new Size(63, 15);
            label1.TabIndex = 2;
            label1.Text = "Save map?";
            // 
            // txtName
            // 
            txtName.Location = new Point(16, 56);
            txtName.Name = "txtName";
            txtName.Size = new Size(182, 23);
            txtName.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 38);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 4;
            label2.Text = "Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(16, 100);
            label3.Name = "label3";
            label3.Size = new Size(39, 15);
            label3.TabIndex = 5;
            label3.Text = "Name";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(16, 118);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.Size = new Size(182, 59);
            txtDescription.TabIndex = 6;
            // 
            // SaveMapDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(211, 217);
            Controls.Add(txtDescription);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(txtName);
            Controls.Add(label1);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Name = "SaveMapDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Save Map";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSave;
        private Button btnCancel;
        private Label label1;
        public TextBox txtName;
        private Label label2;
        private Label label3;
        public TextBox txtDescription;
    }
}