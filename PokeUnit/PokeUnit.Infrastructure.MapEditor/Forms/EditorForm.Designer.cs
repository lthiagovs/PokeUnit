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
            panel6 = new Panel();
            btnNoise = new Button();
            btnAlien = new Button();
            panel5 = new Panel();
            btnEvent = new Button();
            panel4 = new Panel();
            btnZoomOut = new Button();
            btnZoomIn = new Button();
            panel3 = new Panel();
            btnSaveMap = new Button();
            btnOpenMap = new Button();
            btnNewMap = new Button();
            panel2 = new Panel();
            pnMap = new Panel();
            pnElements = new Panel();
            pnContent = new Panel();
            menuStrip1.SuspendLayout();
            panel1.SuspendLayout();
            panel6.SuspendLayout();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
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
            panel1.Controls.Add(panel6);
            panel1.Controls.Add(panel5);
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(panel3);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 24);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 36);
            panel1.TabIndex = 1;
            // 
            // panel6
            // 
            panel6.Controls.Add(btnNoise);
            panel6.Controls.Add(btnAlien);
            panel6.Location = new Point(275, 0);
            panel6.Margin = new Padding(15, 3, 3, 3);
            panel6.Name = "panel6";
            panel6.Size = new Size(74, 36);
            panel6.TabIndex = 7;
            // 
            // btnNoise
            // 
            btnNoise.BackgroundImage = (Image)resources.GetObject("btnNoise.BackgroundImage");
            btnNoise.BackgroundImageLayout = ImageLayout.Stretch;
            btnNoise.Cursor = Cursors.Hand;
            btnNoise.Location = new Point(39, 3);
            btnNoise.Name = "btnNoise";
            btnNoise.Size = new Size(30, 30);
            btnNoise.TabIndex = 4;
            btnNoise.TabStop = false;
            btnNoise.UseVisualStyleBackColor = true;
            btnNoise.Click += btnNoise_Click;
            // 
            // btnAlien
            // 
            btnAlien.BackgroundImage = (Image)resources.GetObject("btnAlien.BackgroundImage");
            btnAlien.BackgroundImageLayout = ImageLayout.Stretch;
            btnAlien.Cursor = Cursors.Hand;
            btnAlien.Location = new Point(3, 3);
            btnAlien.Name = "btnAlien";
            btnAlien.Size = new Size(30, 30);
            btnAlien.TabIndex = 3;
            btnAlien.TabStop = false;
            btnAlien.UseVisualStyleBackColor = true;
            btnAlien.Click += btnAlien_Click;
            // 
            // panel5
            // 
            panel5.Controls.Add(btnEvent);
            panel5.Location = new Point(224, 0);
            panel5.Margin = new Padding(15, 3, 3, 3);
            panel5.Name = "panel5";
            panel5.Size = new Size(37, 36);
            panel5.TabIndex = 6;
            // 
            // btnEvent
            // 
            btnEvent.BackgroundImage = (Image)resources.GetObject("btnEvent.BackgroundImage");
            btnEvent.BackgroundImageLayout = ImageLayout.Stretch;
            btnEvent.Cursor = Cursors.Hand;
            btnEvent.Location = new Point(3, 3);
            btnEvent.Name = "btnEvent";
            btnEvent.Size = new Size(30, 30);
            btnEvent.TabIndex = 3;
            btnEvent.TabStop = false;
            btnEvent.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            panel4.Controls.Add(btnZoomOut);
            panel4.Controls.Add(btnZoomIn);
            panel4.Location = new Point(132, 0);
            panel4.Margin = new Padding(15, 3, 3, 3);
            panel4.Name = "panel4";
            panel4.Size = new Size(74, 36);
            panel4.TabIndex = 5;
            // 
            // btnZoomOut
            // 
            btnZoomOut.BackgroundImage = (Image)resources.GetObject("btnZoomOut.BackgroundImage");
            btnZoomOut.BackgroundImageLayout = ImageLayout.Stretch;
            btnZoomOut.Location = new Point(39, 3);
            btnZoomOut.Name = "btnZoomOut";
            btnZoomOut.Size = new Size(30, 30);
            btnZoomOut.TabIndex = 5;
            btnZoomOut.TabStop = false;
            btnZoomOut.UseVisualStyleBackColor = true;
            btnZoomOut.Click += btnZoomOut_Click;
            // 
            // btnZoomIn
            // 
            btnZoomIn.BackgroundImage = (Image)resources.GetObject("btnZoomIn.BackgroundImage");
            btnZoomIn.BackgroundImageLayout = ImageLayout.Stretch;
            btnZoomIn.Cursor = Cursors.Hand;
            btnZoomIn.Location = new Point(3, 3);
            btnZoomIn.Name = "btnZoomIn";
            btnZoomIn.Size = new Size(30, 30);
            btnZoomIn.TabIndex = 3;
            btnZoomIn.TabStop = false;
            btnZoomIn.UseVisualStyleBackColor = true;
            btnZoomIn.Click += btnZoomIn_Click;
            // 
            // panel3
            // 
            panel3.Controls.Add(btnSaveMap);
            panel3.Controls.Add(btnOpenMap);
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
            btnSaveMap.TabStop = false;
            btnSaveMap.UseVisualStyleBackColor = true;
            btnSaveMap.Click += btnSaveMap_Click;
            // 
            // btnOpenMap
            // 
            btnOpenMap.BackgroundImage = (Image)resources.GetObject("btnOpenMap.BackgroundImage");
            btnOpenMap.BackgroundImageLayout = ImageLayout.Stretch;
            btnOpenMap.Location = new Point(39, 3);
            btnOpenMap.Name = "btnOpenMap";
            btnOpenMap.Size = new Size(30, 30);
            btnOpenMap.TabIndex = 5;
            btnOpenMap.TabStop = false;
            btnOpenMap.UseVisualStyleBackColor = true;
            btnOpenMap.Click += btnOpenMap_Click;
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
            btnNewMap.TabStop = false;
            btnNewMap.UseVisualStyleBackColor = true;
            btnNewMap.Click += btnNewMap_Click;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ButtonFace;
            panel2.Controls.Add(pnMap);
            panel2.Controls.Add(pnElements);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 60);
            panel2.Name = "panel2";
            panel2.Size = new Size(200, 390);
            panel2.TabIndex = 2;
            // 
            // pnMap
            // 
            pnMap.BackColor = SystemColors.ActiveCaptionText;
            pnMap.Location = new Point(12, 6);
            pnMap.Name = "pnMap";
            pnMap.Size = new Size(174, 174);
            pnMap.TabIndex = 2;
            pnMap.Paint += pnMap_Paint;
            // 
            // pnElements
            // 
            pnElements.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnElements.AutoScroll = true;
            pnElements.BackColor = SystemColors.ActiveBorder;
            pnElements.Location = new Point(12, 186);
            pnElements.Name = "pnElements";
            pnElements.Size = new Size(174, 201);
            pnElements.TabIndex = 1;
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
            pnContent.Resize += pnContent_Resize;
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
            panel6.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel2.ResumeLayout(false);
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
        private Button btnOpenMap;
        private Button btnNewMap;
        private Panel panel2;
        private Panel pnContent;
        private Panel pnElements;
        private Panel panel4;
        private Button btnZoomOut;
        private Button btnZoomIn;
        private Panel pnMap;
        private Panel panel5;
        private Button btnEvent;
        private Panel panel6;
        private Button btnAlien;
        private Button btnNoise;
    }
}