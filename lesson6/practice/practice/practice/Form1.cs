namespace practice
{
    public partial class Form1 :Form, ILibraryView {

        #region ILibraryView Implementation
        public TextBox[] TextBoxes { get; set; }
        public Label[] Labels { get; set; }
        public Label Output { get; set; }

        public event EventHandler<EventArgs> Save;
        public event EventHandler<EventArgs> Delete;
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
    }
}