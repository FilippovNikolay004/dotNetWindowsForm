﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework {
    internal interface IModel {
        Button[] buttons { get; set; }
        Button StartBtn { get; set; }
        Image buttonImageX { get; set; }
        Image buttonImageO { get; set; }
        int[] cellStates { get; set; }
        int indexStep { get; set; } /* * -1 - Свободная клетка * 0 - Занято компьютером * 1 - Занято пользователем */
        CheckBox WhoFirst { get; set; }
        GroupBox LevelGroup { get; set; }
        RadioButton isHardLevel { get; set; }

        void StartGame();
        void ResetGame();
        public void ChoiceCell(Button button);
    }
}
