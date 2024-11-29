using System;
using System.Collections.Generic;

namespace homework
{
    public partial class Form1 :Form {
        private Button[] buttons;
        private Image buttonImageX = Image.FromFile("x.jpg");
        private Image buttonImageO = Image.FromFile("o.jpg");
        private int[] cellStates = { -1, -1, -1, -1, -1, -1, -1, -1, -1 };
        /*
         * -1 - Свободная клетка
         * 0 - Занято компьютером
         * 1 - Занято пользователем
         */
        int indexStep = 0;

        public Form1() {
            InitializeComponent();

            // Инициализация массива кнопок
            buttons = new Button[] {
                button1, button2, button3,
                button4, button5, button6,
                button7, button8, button9
            };

            foreach (var button in buttons) {
                button.Click += Button_Click;
                button.Enabled = false;
            }

            buttonImageX = new Bitmap(buttonImageX, new Size(button1.Width, button1.Height));
            buttonImageO = new Bitmap(buttonImageO, new Size(button1.Width, button1.Height));

            radioButton1.Checked = true;
        }

        private void Form1_Load(object sender, EventArgs e) {
        }
        private void button10_Click(object sender, EventArgs e) {
            // Старт

            button10.Text = "Игра началась!";
            button10.Enabled = false;
            GameReset();

            if (checkBox1.Checked) { MakeBotMove(); }

            checkBox1.Enabled = false;
            radioButton1.Enabled = false;
            radioButton2.Enabled = false;
        }
        private void Button_Click(object sender, EventArgs e) {
            // Определяем кнопку, которая вызвала событие
            Button clickedButton = (Button)sender;

            if (clickedButton != null) {
                MakePlayerMove(clickedButton); // Ход игрока
                if (CheckWin()) { GameOver(); }
                else {
                    MakeBotMove(); // Ход компьютера
                    if (CheckWin()) { GameOver(); }
                }
            }
        }

        private int GetIndexFromName(string nameButton) {
            return int.Parse(nameButton.Replace("button", "")) - 1;
        }
        private bool IsCellStates(int index) {
            if (cellStates[index] == -1) { return true; }
            return false;
        }
        private void MakeBotMove() {
            for (int i = 0; i < cellStates.Length; i++) {
                if (IsCellStates(i)) break;
                else if (cellStates.Length == i + 1) return;
            }

            indexStep++;

            Random r = new Random();
            int index = 0;

            if (radioButton2.Checked && indexStep < 4) {
                if (cellStates[4] == 1 && indexStep == 1) {
                    do {
                        index = r.Next(0, 9);
                    } while (!(index == 0 || index == 2 || index == 6 || index == 8) || !IsCellStates(index));
                } else if ((cellStates[0] == 1 || cellStates[2] == 1 || cellStates[6] == 1 || cellStates[8] == 1) && indexStep == 2) {
                    do {
                        index = r.Next(0, 9);
                    } while (!(index == 0 || index == 2 || index == 6 || index == 8) || !IsCellStates(index));
                } else if (indexStep == 3) {
                    bool step = true;

                    for (int i = 0; i < cellStates.Length; i++) {
                        if (IsCellStates(index))
                            continue;

                        if (cellStates[i] == 0 && cellStates[i + 1] == -1 && cellStates[i + 2] == 0) {
                            index = i + 1;
                            step = false;
                            break;
                        }
                    }

                    if (step) {
                        for (int i = 0; i < cellStates.Length - 6; i++) {
                            if (cellStates[i] == 0 && cellStates[i + 3] == -1 && cellStates[i + 6] == 0) {
                                index = i + 3;
                                step = false;
                                break;
                            }
                        }
                    } 

                    if (step) {
                        do {
                            index = r.Next(0, 9);
                        } while (!IsCellStates(index));
                    }
                }
            } else {
                do {
                    index = r.Next(0, 9);
                } while (!IsCellStates(index));
            }

            cellStates[index] = 0;
            buttons[index].Enabled = false;
            buttons[index].Image = buttonImageO;
        }
        private void MakePlayerMove(Button clickedButton) {
            int index = GetIndexFromName(clickedButton.Name);

            if (IsCellStates(index)) {
                cellStates[index] = 1;
                buttons[index].Enabled = false;
                buttons[index].Image = buttonImageX;
                buttons[index].ImageAlign = ContentAlignment.MiddleCenter;
            }
        }

        public bool CheckWin() {
            int result = WhoIsWin();
            string caption = "Результат";

            if (result == 1) {
                MessageBox.Show("Игрок выиграл!", caption);
                return true;
            } else if (result == 0) {
                MessageBox.Show("Компьютер выиграл!", caption);
                return true;
            } else if (result == 3) {
                MessageBox.Show("Ничья!", caption);
                return true;
            }

            return false;
        }

        private void GameOver() {
            AllButtonDisabled();
            button10.Text = "Новая игра";
            button10.Enabled = true;
            checkBox1.Enabled = true;
            radioButton1.Enabled = true;
            radioButton2.Enabled = true;
        }
        private void AllButtonDisabled() {
            for (int i = 0; i < cellStates.Length; i++) {
                if (cellStates[i] == -1) { buttons[i].Enabled = false; }
            }
        }
        private void GameReset() {
            for (int i = 0; i < cellStates.Length; i++) {
                buttons[i].Enabled = true;
                buttons[i].Image = null;
                cellStates[i] = -1;
                indexStep = 0;
            }
        }

        private int WhoIsWin() {
            // Првоерки по горизонтали
            for (int i = 0; i < cellStates.Length - 2; i += 3) {
                if (cellStates[i] == 1 && cellStates[i + 1] == 1 && cellStates[i + 2] == 1) {
                    return 1;
                } else if (cellStates[i] == 0 && cellStates[i + 1] == 0 && cellStates[i + 2] == 0) {
                    return 0;
                }
            }

            // Проверки по вертикали
            for (int i = 0; i < cellStates.Length - 6; i++) {
                if (cellStates[i] == 1 && cellStates[i + 3] == 1 && cellStates[i + 6] == 1) {
                    return 1;
                } else if (cellStates[i] == 0 && cellStates[i + 3] == 0 && cellStates[i + 6] == 0) {
                    return 0;
                }
            }

            // Проверки по диагонали
            if (cellStates[0] == 1 && cellStates[4] == 1 && cellStates[8] == 1 ||
                    cellStates[2] == 1 && cellStates[4] == 1 && cellStates[6] == 1) {
                return 1;
            } else if (cellStates[0] == 0 && cellStates[4] == 0 && cellStates[8] == 0 ||
                    cellStates[2] == 0 && cellStates[4] == 0 && cellStates[6] == 0) {
                return 0;
            }

            // Все поля заполнены
            for (int i = 0; i < cellStates.Length; i++) {
                if (IsCellStates(i)) break;
                else if (cellStates.Length == i + 1) return 3;
            }

            return -1;
        }
    }
}
