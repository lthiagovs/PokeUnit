namespace PokeUnit.Infrastructure.MapEditor.Forms
{
    partial class EditorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditorForm));
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            viewToolStripMenuItem = new ToolStripMenuItem();
            layerToolStripMenuItem = new ToolStripMenuItem();
            scenarioToolStripMenuItem = new ToolStripMenuItem();
            toolsToolStripMenuItem = new ToolStripMenuItem();
            advancedToolStripMenuItem = new ToolStripMenuItem();
            moduleToolStripMenuItem = new ToolStripMenuItem();
            windowToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            panel1 = new Panel();
            panel3 = new Panel();
            btnSaveMap = new Button();
            button2 = new Button();
            btnNewMap = new Button();
            panel2 = new Panel();
            pnElements = new Panel();
            pictureBox1 = new PictureBox();
            pnContent = new Panel();
            menuStrip1.SuspendLayout();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, editToolStripMenuItem, viewToolStripMenuItem, layerToolStripMenuItem, scenarioToolStripMenuItem, toolsToolStripMenuItem, advancedToolStripMenuItem, moduleToolStripMenuItem, windowToolStripMenuItem, helpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(39, 20);
            editToolStripMenuItem.Text = "Edit";
            // 
            // viewToolStripMenuItem
            // 
            viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            viewToolStripMenuItem.Size = new Size(44, 20);
            viewToolStripMenuItem.Text = "View";
            // 
            // layerToolStripMenuItem
            // 
            layerToolStripMenuItem.Name = "layerToolStripMenuItem";
            layerToolStripMenuItem.Size = new Size(47, 20);
            layerToolStripMenuItem.Text = "Layer";
            // 
            // scenarioToolStripMenuItem
            // 
            scenarioToolStripMenuItem.Name = "scenarioToolStripMenuItem";
            scenarioToolStripMenuItem.Size = new Size(64, 20);
            scenarioToolStripMenuItem.Text = "Scenario";
            // 
            // toolsToolStripMenuItem
            // 
            toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            toolsToolStripMenuItem.Size = new Size(46, 20);
            toolsToolStripMenuItem.Text = "Tools";
            // 
            // advancedToolStripMenuItem
            // 
            advancedToolStripMenuItem.Name = "advancedToolStripMenuItem";
            advancedToolStripMenuItem.Size = new Size(72, 20);
            advancedToolStripMenuItem.Text = "Advanced";
            // 
            // moduleToolStripMenuItem
            // 
            moduleToolStripMenuItem.Name = "moduleToolStripMenuItem";
            moduleToolStripMenuItem.Size = new Size(60, 20);
            moduleToolStripMenuItem.Text = "Module";
            // 
            // windowToolStripMenuItem
            // 
            windowToolStripMenuItem.Name = "windowToolStripMenuItem";
            windowToolStripMenuItem.Size = new Size(63, 20);
            windowToolStripMenuItem.Text = "Window";
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(44, 20);
            helpToolStripMenuItem.Text = "Help";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ButtonFace;
            panel1.Controls.Add(panel3);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 24);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 36);
            panel1.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.Controls.Add(btnSaveMap);
            panel3.Controls.Add(button2);
            panel3.Controls.Add(btnNewMap);
            panel3.Location = new Point(3, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(111, 36);
            panel3.TabIndex = 4;
            // 
            // btnSaveMap
            // 
            btnSaveMap.BackgroundImage = (Image)resources.GetObject("btnSaveMap.BackgroundImage");
            btnSaveMap.BackgroundImageLayout = ImageLayout.Stretch;
            btnSaveMap.Location = new Point(75, 3);
            btnSaveMap.Name = "btnSaveMap";
            btnSaveMap.Size = new Size(30, 30);
            btnSaveMap.TabIndex = 6;
            btnSaveMap.UseVisualStyleBackColor = true;
            btnSaveMap.Click += btnSaveMap_Click;
            // 
            // button2
            // 
            button2.BackgroundImage = (Image)resources.GetObject("button2.BackgroundImage");
            button2.BackgroundImageLayout = ImageLayout.Stretch;
            button2.Location = new Point(39, 3);
            button2.Name = "button2";
            button2.Size = new Size(30, 30);
            button2.TabIndex = 5;
            button2.UseVisualStyleBackColor = true;
            // 
            // btnNewMap
            // 
            btnNewMap.BackgroundImage = (Image)resources.GetObject("btnNewMap.BackgroundImage");
            btnNewMap.BackgroundImageLayout = ImageLayout.Stretch;
            btnNewMap.Cursor = Cursors.Hand;
            btnNewMap.Location = new Point(3, 3);
            btnNewMap.Name = "btnNewMap";
            btnNewMap.Size = new Size(30, 30);
            btnNewMap.TabIndex = 3;
            btnNewMap.UseVisualStyleBackColor = true;
            btnNewMap.Click += btnNewMap_Click;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ButtonFace;
            panel2.Controls.Add(pnElements);
            panel2.Controls.Add(pictureBox1);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 60);
            panel2.Name = "panel2";
            panel2.Size = new Size(200, 390);
            panel2.TabIndex = 2;
            // 
            // pnElements
            // 
            pnElements.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnElements.BackColor = SystemColors.ActiveBorder;
            pnElements.Location = new Point(12, 186);
            pnElements.Name = "pnElements";
            pnElements.Size = new Size(174, 201);
            pnElements.TabIndex = 1;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.ActiveCaptionText;
            pictureBox1.Location = new Point(12, 6);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(174, 174);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // pnContent
            // 
            pnContent.BorderStyle = BorderStyle.FixedSingle;
            pnContent.Dock = DockStyle.Fill;
            pnContent.Location = new Point(200, 60);
            pnContent.Name = "pnContent";
            pnContent.Size = new Size(600, 390);
            pnContent.TabIndex = 3;
            pnContent.Paint += pnContent_Paint;
            pnContent.MouseDown += pnContent_MouseDown;
            pnContent.MouseMove += pnContent_MouseMove;
            pnContent.MouseUp += pnContent_MouseUp;
            // 
            // EditorForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pnContent);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "EditorForm";
            Text = "PokeUnit Map Editor 1.0";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStripMenuItem layerToolStripMenuItem;
        private ToolStripMenuItem scenarioToolStripMenuItem;
        private ToolStripMenuItem toolsToolStripMenuItem;
        private ToolStripMenuItem advancedToolStripMenuItem;
        private ToolStripMenuItem moduleToolStripMenuItem;
        private ToolStripMenuItem windowToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private Panel panel1;
        private Panel panel3;
        private Button btnSaveMap;
        private Button button2;
        private Button btnNewMap;
        private Panel panel2;
        private Panel pnContent;
        private PictureBox pictureBox1;
        private Panel pnElements;
    }
}