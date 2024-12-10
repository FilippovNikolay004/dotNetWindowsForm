namespace practice
{
    public partial class Form1 :Form, ILibraryView {

        #region ILibraryView Implementation
        public TextBox[] TextBoxes { get; set; }
        public Label[] Labels { get; set; }
        public Label Output { get; set; }

        public event EventHandler<EventArgs> Save;
        public event EventHandler<EventArgs> Delete;
        public event EventHandler<EventArgs> DeleteAll;
        public event EventHandler<EventArgs> GetFirstBook;
        #endregion

        public Form1() {
            InitializeComponent();

            TextBoxes = [
                textBox1, textBox2,
                textBox3, textBox4
            ];
            Labels = [
                label1, label2,
                label3, label4
            ];
            Output = label5;
            Output.Text = "";
            Output.Enabled = false;

            for (int i = 0; i < TextBoxes.Length; i++) {
                TextBoxes[i].TextChanged += textBoxes_TextChanged;
            }

            button1.Enabled = button2.Enabled = false;

            ContextMenuStrip = contextMenuStrip1;

            MenuToolStripMenuItem1.Image = Image.FromFile("Menu.png");
            ExitToolStripMenuItem1.Image = Image.FromFile("Close.png");
        }

        private void textBoxes_TextChanged(object? sender, EventArgs e) {
            if (sender == null || TextBoxes.Any(tb => tb.Text.Length == 0)) {
                button1.Enabled = button2.Enabled = false;
            } else {
                button1.Enabled = button2.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            Save?.Invoke(this, EventArgs.Empty);
        }

        private void button2_Click(object sender, EventArgs e) {
            Delete?.Invoke(this, EventArgs.Empty);
        }

        private void Û‰‡ÎËËÚ¸¬ÒÂ«‡ÔËÒËToolStripMenuItem_Click(object sender, EventArgs e) {
            DeleteAll?.Invoke(this, EventArgs.Empty);
        }

        private void Û‰‡ÎËÚ¸¬ÒÂ«‡ÔËÒËToolStripMenuItem_Click(object sender, EventArgs e) {
            DeleteAll?.Invoke(this, EventArgs.Empty);
        }

        private void ‚˚ıÓ‰ToolStripMenuItem1_Click(object sender, EventArgs e) {
            Close();
        }

        private void ‚˚ıÓ‰ToolStripMenuItem_Click(object sender, EventArgs e) {
            Close();
        }

        private void Form1_Load(object sender, EventArgs e) {

        }

        private void GetFirstBookContextMenuToolStripMenuItem_Click(object sender, EventArgs e) {
            GetFirstBook?.Invoke(this, EventArgs.Empty);
        }
        private void GetFirstBookToolStripMenuItem_Click(object sender, EventArgs e) {
            GetFirstBook?.Invoke(this, EventArgs.Empty);
        }
    }
}