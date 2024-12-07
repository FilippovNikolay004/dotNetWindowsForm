using System;
using System.Collections.Generic;

namespace homework {
    public partial class Form1 :Form, IGameView {
        #region IGameView Implementation
        public Button[] buttons { get; set; }
        public Button StartBtn { get; set; }
        public Image buttonImageX { get; set; }
        public Image buttonImageO { get; set; }
        public int[] cellStates { get; set; }
        public int indexStep { get; set; }
        public GroupBox LevelGroup { get; set; }
        public CheckBox WhoFirst { get; set; }
        public RadioButton isHardLevel { get; set; }


        public event EventHandler<EventArgs> Start;
        public event EventHandler<EventArgs> CellClicked;
        #endregion


        public Form1() {
            InitializeComponent();

            // Инициализация массива кнопок
            buttons = [
                button1, button2, button3,
                button4, button5, button6,
                button7, button8, button9
            ];
            foreach (var button in buttons) {
                button.Click += buttons_Click;
                button.Enabled = false; 
            }

            StartBtn = button10;
            LevelGroup = groupBox1;
            WhoFirst = checkBox1;

            cellStates = [
                -1, -1, -1,
                -1, -1, -1,
                -1, -1, -1
            ];

            buttonImageX = Image.FromFile("x.jpg");
            buttonImageO = Image.FromFile("o.jpg");

            buttonImageX = new Bitmap(buttonImageX, new Size(button1.Width, button1.Height));
            buttonImageO = new Bitmap(buttonImageO, new Size(button1.Width, button1.Height));

            radioButton1.Checked = true;
            isHardLevel = radioButton2;
        }

        private void button10_Click(object sender, EventArgs e) {
            Start?.Invoke(this, EventArgs.Empty);
        }
        private void buttons_Click(object? sender, EventArgs e) {
            if (sender == null) return;

            CellClicked?.Invoke((Button)sender, EventArgs.Empty);
        }
    }
}
