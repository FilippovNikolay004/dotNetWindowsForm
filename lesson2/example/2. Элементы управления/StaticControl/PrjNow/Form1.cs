namespace PrjNow {
    public partial class Form1 :Form {
        public Form1() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e) {
            label1.BackColor = Color.FromArgb(new Random().Next(0, 255), new Random().Next(0, 255), new Random().Next(0, 255));
        }

        private void button2_Click(object sender, EventArgs e) {
            timer1.Stop();
        }

        private void label1_Click(object sender, EventArgs e) {
            timer1.Stop();
        }

        private void label1_MouseDoubleClick(object sender, MouseEventArgs e) {
            timer1.Start();
        }
    }
}
