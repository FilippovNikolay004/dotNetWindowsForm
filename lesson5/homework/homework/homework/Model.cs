using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace homework {
    internal class Model: IModel {
        public Button[] buttons { get; set; }
        public Button StartBtn { get; set; }
        public int[] cellStates { get; set; }
        public int indexStep { get; set; } /* * -1 - Свободная клетка * 0 - Занято компьютером * 1 - Занято пользователем */
        public CheckBox WhoFirst { get; set; }
        public GroupBox LevelGroup { get; set; }
        public RadioButton isHardLevel { get; set; }
        public System.Drawing.Image buttonImageX { get; set; }
        public System.Drawing.Image buttonImageO { get; set; }


        public void StartGame() {
            GameReset();
            ChangeBtnStart();
            ChangeCheckBox();
            ChangeLevelGroup();
            ChangeCellStates();
            WhoGoesFirst();
        }
        public void ResetGame() {
            ChangeBtnStart();
            ChangeCheckBox();
            ChangeLevelGroup();
            AllButtonDisabled();
        }



        public void WhoGoesFirst() {
            if (WhoFirst.Checked) { MakeBotMove(); }
        }
        public void ChoiceCell(Button button) {
            button.Enabled = false;

            int index = GetIndexFromName(button.Name);
            cellStates[index] = 1;
            buttons[index].Image = buttonImageX;
            buttons[index].ImageAlign = ContentAlignment.MiddleCenter;

            if (!CheckWin()) { MakeBotMove(); }
            else { ResetGame(); }
        }

        public void MakeBotMove() {
            for (int i = 0; i < cellStates.Length; i++) {
                if (IsCellStates(i)) break;
                else if (cellStates.Length == i + 1) return;
            }

            if (isHardLevel.Checked) {
                
            }

            Random r = new Random();
            int index = 0;
            do {
                index = r.Next(0, 9);
            } while (!IsCellStates(index));

            cellStates[index] = 0;
            buttons[index].Enabled = false;
            buttons[index].Image = buttonImageO;
            buttons[index].ImageAlign = ContentAlignment.MiddleCenter;

            if (CheckWin()) { ResetGame(); }
        }


        // Изменение вида и текста
        public void ChangeBtnStart() {
            StartBtn.Enabled = !StartBtn.Enabled;
            StartBtn.Text = !StartBtn.Enabled ? 
                StartBtn.Text = "Игра началась!" : StartBtn.Text = "Начать игру";
        }
        public void ChangeCellStates() {
            for (int i = 0; i < buttons.Length; i++) {
                buttons[i].Enabled = !buttons[i].Enabled;
            }
        }
        public void ChangeCheckBox() {
            WhoFirst.Enabled = !WhoFirst.Enabled;
        }
        public void ChangeLevelGroup() {
            LevelGroup.Enabled = !LevelGroup.Enabled;
        }


        private int GetIndexFromName(string nameButton) {
            return int.Parse(nameButton.Replace("button", "")) - 1;
        }
        private bool IsCellStates(int index) {
            return cellStates[index] == -1;
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
        private int WhoIsWin() {
            // Проверка по горизонтали
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
        private void GameReset() {
            for (int i = 0; i < cellStates.Length; i++) {
                buttons[i].Image = null;
                cellStates[i] = -1;
                indexStep = 0;
            }
        }
        private void AllButtonDisabled() {
            for (int i = 0; i < cellStates.Length; i++) {
                if (cellStates[i] == -1) { buttons[i].Enabled = false; }
            }
        }
    }
}