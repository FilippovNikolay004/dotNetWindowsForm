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

            listBox1.Enabled = false;

            int[] prize = { 100, 200, 300, 500, 1000, 2000, 4000, 8000, 16000, 32000, 64000, 125000, 250000, 500000, 1000000 };
            for (int i = 0; i < prize.Length; i++) {
                listBox1.Items.Add($"{prize.Length - i} - {prize[prize.Length - 1 - i]}");
            }
        }

        private void Form1_Load(object sender, EventArgs e) {
            List<Question> questions = new List<Question>();

            Button[] buttons = [button1, button2, button3, button4];

            Dictionary<string, string[]> questionAndAnswerOptions = new Dictionary<string, string[]>();

            FileStream fs = new FileStream("question.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs);

            int i = 0;
            string tempQuestion = string.Empty;
            List<string> AnswerOptions = new List<string>();
            int indexCorrectAnswer = 0;

            while (!sr.EndOfStream) {
                string line = sr.ReadLine()?.Trim()??"";
                if (string.IsNullOrEmpty(line)) { continue; }

                if (i == 0) {
                    tempQuestion = line;
                    i++;
                } else if (i <= 4) {
                    if (line.IndexOf("true") != -1)
                        indexCorrectAnswer = i - 1;

                    AnswerOptions.Add(line);
                    i++;
                } 
                
                if (i == 5) {
                    questions.Add(new Question(tempQuestion, AnswerOptions, "t"));
                    //AnswerOptions.Clear();
                    i = 0;
                }
            }

            sr.Close();
            fs.Close();

            foreach (var item in questions) {
                label1.Text = item.Text;
                for (int j = 0; j < item.Options.Count; j++) {
                    buttons[j].Text = $"{(j == 0 ? "A" : j == 1 ? "B" : j == 2 ? "C" : "D")}: {item.Options[j]}";
                }
            }
        }
    }
}
