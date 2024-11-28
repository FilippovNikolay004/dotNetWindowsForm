namespace homework
{
    public partial class Form1 :Form {
        public Form1() {
            InitializeComponent();

            this.Width = 500;
            this.Height = 400;
        }

        private void Form1_Load(object sender, EventArgs e) {
            label1.Width = this.ClientSize.Width - 20;
            label1.Height = this.ClientSize.Height - 20;

            label1.Location = new Point(10, 10);
        }

        private void label1_Click(object sender, EventArgs e) {

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e) {
            Text = $"X = {e.Location.X}, Y = {e.Location.Y}";
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Right) {
                Text = $"{this.Width} X {this.Height}";
            } else if (e.Button == MouseButtons.Left) {
                MessageBox.Show("Вы нажали снаружи прямоугольник");
            }
        }

        private void label1_MouseDown(object sender, MouseEventArgs e) {
            if (e.Button == MouseButtons.Left && 
                (e.Location.X == 1 && e.Location.Y <= label1.Height) || // Лево
                (e.Location.Y + 1 == label1.Height && e.Location.X <= label1.Width) || // Низ
                (e.Location.Y == 1 && e.Location.X <= label1.Width) || // Верх
                (e.Location.X == label1.Width - 1 && e.Location.Y <= label1.Height + 1) // Право
                ) {
                MessageBox.Show("Вы нажали на границу прямоугольник");
            } else if (e.Button == MouseButtons.Left) {
                MessageBox.Show("Вы нажали внутри прямоугольника" + $" Mouse: X: {e.Location.X}, Y: {e.Location.Y}\n" +
                    $"Square: W: {label1.Width} H: {label1.Height}");
            }
        }
    }
}
