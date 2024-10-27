namespace PokeUnit.Infrastructure.MapEditor.Controls
{
    partial class MapTileControl
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            pbSprite = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pbSprite).BeginInit();
            SuspendLayout();
            // 
            // pbSprite
            // 
            pbSprite.Dock = DockStyle.Fill;
            pbSprite.Location = new Point(0, 0);
            pbSprite.Name = "pbSprite";
            pbSprite.Size = new Size(24, 24);
            pbSprite.TabIndex = 0;
            pbSprite.TabStop = false;
            // 
            // MapTileControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(pbSprite);
            Cursor = Cursors.Hand;
            Name = "MapTileControl";
            Size = new Size(24, 24);
            ((System.ComponentModel.ISupportInitialize)pbSprite).EndInit();
            ResumeLayout(false);
        }

        #endregion

        public PictureBox pbSprite;
    }
}
