using static System.Windows.Forms.Design.AxImporter;

namespace homework
{
    public partial class Form1 :Form {
        public Form1() {
            InitializeComponent();

            button5.Text = button6.Text = button7.Text = button8.Text = button9.Text = null;

            Image resizedImage = new Bitmap(Image.FromFile("time.png"), new Size(20, 20));
            button5.Image = resizedImage;

            resizedImage = new Bitmap(Image.FromFile("phone.png"), new Size(20, 20));
            button6.Image = resizedImage;

            resizedImage = new Bitmap(Image.FromFile("people.png"), new Size(20, 20));
            button7.Image = resizedImage;

            resizedImage = new Bitmap(Image.FromFile("flag.png"), new Size(20, 20));
            button8.Image = resizedImage;

            resizedImage = new Bitmap(Image.FromFile("exit.png"), new Size(20, 20));
            button9.Image = resizedImage;

            int[] prize = { 100, 200, 300, 500, 1000, 2000, 4000, 8000, 16000, 32000, 64000, 125000, 250000, 500000, 1000000 };
            for (int i = 0; i < prize.Length; i++) {
                listBox1.Items.Add($"{prize.Length - i} - {prize[prize.Length - 1 - i]}");
            }
        }

        private void Form1_Load(object sender, EventArgs e) {
            Button[] buttons = [button1, button2, button3, button4];

            Dictionary<string, string[]> questionAndAnswerOptions = new Dictionary<string, string[]>();

            FileStream fs = new FileStream("question.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs);

            int i = 0;
            string tempQuestion = string.Empty;
            List<string> AnswerOptions = new List<string>();

            while (!sr.EndOfStream) {
                string line = sr.ReadLine()?.Trim()??"";
                if (string.IsNullOrEmpty(line)) { continue; }

                if (i == 0) {
                    tempQuestion = line;
                    i++;
                } else if (i <= 4) {
                    AnswerOptions.Add(line);
                    i++;
                } 
                
                if (i == 5) {
                    questionAndAnswerOptions.Add(tempQuestion, AnswerOptions.ToArray());
                    AnswerOptions.Clear();
                    i = 0;
                }
            }

            sr.Close();
            fs.Close();

            foreach (var item in questionAndAnswerOptions) {
                label1.Text = item.Key;
                for (int j = 0; j < item.Value.Length; j++) {
                    buttons[j].Text = item.Value[j];
                }
            }
        }
    }
}
