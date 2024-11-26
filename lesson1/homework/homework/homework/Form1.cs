namespace homework {
    public partial class Form1 :Form {
        public Form1() {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e) {
        }

        private void Form1_Load(object sender, EventArgs e) {
            // TASK 1
            /*
            Вывести на экран свое(краткое !!! ) резюме с помощью последовательности 
               MessageBox'ов (числом не менее трех). Причем на заголовке последнего 
               должно отобразиться среднее число символов на странице
               (общее количество символов в резюме / количество MessageBox'OB).
            */

            string[] resume = { "ABOUT ME",
                                "I am non-conflict team player with strong time management skills",
                                "I have a solid understanding of Object-Oriented Programming (OOP)",
                                "software design patterns, and the SOLID principles." };
            int sum = 0;

            for (int i = 0; i < resume.Length; i++) {
                sum += resume[i].Length;
                if (i != resume.Length - 1)
                    MessageBox.Show(resume[i], $"Resume. Part: {i + 1}");
                else {
                    MessageBox.Show(resume[i], $"Resume. average number of characters: {sum / resume.Length}");
                }
            }


            // TASK 2
            /*
            Написать функцию, которая "угадывает" задуманное пользователем
            число от 1 до 2000. Для запроса к пользователю использовать
            MessageBox. После того, как число отгадано, необходимо вывести
            количество запросов, потребовавшихся для этого, и предоставить
            пользователю возможность сыграть еще раз, не выходя из программы. 
            (MessageBox'ы оформляются кнопками и значками соответственно ситуации).
            */

            int number = 202;
            int tempNumber = 0;
            int Count = 0;
            bool isNext = false;

            int min = 1;
            int max = 2000;
            int mid = 0;

            do {
                isNext = number < 1 || number > 2000;

                if (isNext) { MessageBox.Show("Вы ввели неверный диапозон!"); }
            } while (isNext);

            while (number != mid) {
                mid = (min + max) / 2;

                if (mid == number) {
                    MessageBox.Show($"Ваше число: {mid}\nКол-во попыток: {Count}", "Результаты");
                    break;
                }

                DialogResult res = MessageBox.Show($"Ваше число больше\n: {mid}",
                    "Больше/меньше", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (res == DialogResult.Yes) { min = mid + 1; } 
                else if (res == DialogResult.No) { max = mid - 1; }

                Count++;
            }
        }
    }
}
