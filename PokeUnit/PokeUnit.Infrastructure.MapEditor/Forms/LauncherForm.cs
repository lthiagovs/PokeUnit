namespace PokeUnit.Infrastructure.MapEditor.Forms
{
    public partial class LauncherForm : Form
    {

        private Thread? editorThread { get; set; }

        private void LoadEditor()
        {
            this.editorThread = new Thread(() =>
            {
                Application.Run(new EditorForm());
                this.editorThread!.SetApartmentState(ApartmentState.STA);
            });
        }

        private void StartEditor()
        {
            if (this.editorThread != null)
            {
                this.editorThread.Start();
                this.Close();
            }
            else
            {
                MessageBox.Show("Erro ao inicializar editor...");
                this.Close();
            }
        }

        public LauncherForm()
        {
            InitializeComponent();
            this.pbBackground.SizeMode = PictureBoxSizeMode.StretchImage;
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            this.StartEditor();
        }

        private void LauncherForm_Shown(object sender, EventArgs e)
        {
            this.LoadEditor();
        }
    }
}
