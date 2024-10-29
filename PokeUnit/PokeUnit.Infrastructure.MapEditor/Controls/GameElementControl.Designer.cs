namespace PokeUnit.Infrastructure.MapEditor.Controls
{
    partial class GameElementControl
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
            pbSprite.Dock = DockStyle.Left;
            pbSprite.Location = new Point(0, 0);
            pbSprite.Name = "pbSprite";
            pbSprite.Size = new Size(60, 58);
            pbSprite.TabIndex = 0;
            pbSprite.TabStop = false;
            pbSprite.Click += pbSprite_Click;
            pbSprite.MouseEnter += pbSprite_MouseEnter;
            pbSprite.MouseLeave += pbSprite_MouseLeave;
            // 
            // GameElementControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(pbSprite);
            Cursor = Cursors.Hand;
            Name = "GameElementControl";
            Size = new Size(58, 58);
            ((System.ComponentModel.ISupportInitialize)pbSprite).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pbSprite;
    }
}
