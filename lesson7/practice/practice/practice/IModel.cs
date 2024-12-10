using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice {
    internal interface IModel {
        TextBox[] TextBoxes { get; set; }
        Label[] Labels { get; set; }

        void SaveToFile();
        void DeleteFromFile();
        void DeleteAllFromFile();
        string GetFirstBook();

        string[] LoadFromFile();
    }
}
