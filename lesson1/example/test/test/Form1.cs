namespace test {
    public partial class Form1 :Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {

        }

        private void button1_Click(object sender, EventArgs e) {
            //MessageBox.Show("Hello world", "Привет мир", MessageBoxButtons. YesNo, MessageBoxIcon. Question);// this.Close();

            //button1.Text = button1.Text == "OK" ? "NO" : "OK";

            DialogResult rez = MessageBox.Show("Hello world", "Привет мир", MessageBoxButtons. YesNo, MessageBoxIcon.Question);

            if (rez == DialogResult.Yes)
                label1.Text = "Yes";

            else
                label1.Text = "No";
        }
    }
}
