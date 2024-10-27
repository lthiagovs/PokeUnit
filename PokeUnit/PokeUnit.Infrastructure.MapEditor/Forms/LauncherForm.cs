namespace PokeUnit.Infrastructure.MapEditor.Forms
{
    public partial class LauncherForm : Form
    {

        private Thread? editorThread { get; set; }

        private void StartEditor()
        {
            this.editorThread = new Thread(() =>
            {
                Application.Run(new EditorForm());
            });
            this.editorThread.SetApartmentState(ApartmentState.STA);
            this.editorThread.Start();
            this.Close();
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
    }
}
