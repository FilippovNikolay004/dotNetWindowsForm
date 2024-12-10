using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.LinkLabel;

namespace practice {
    internal class Model: IModel {
        public TextBox[] TextBoxes { get; set; } = new TextBox[0];
        public Label[] Labels { get; set; } = new Label[0];
        Label Output { get; set; } = new Label();
        
        public void SaveToFile() {
            FileStream fs = new FileStream("Lib.txt", FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            string line = string.Empty;

            for (int i = 0; i < TextBoxes.Length; i++) {
                line += $"{Labels[i].Text} {TextBoxes[i].Text}=";
            }
            sw.WriteLine(line);

            sw.Close();
            fs.Close();
        }
        public void DeleteFromFile() {
            FileStream fs = new FileStream("Lib.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

            string line = string.Empty;
            for (int i = 0; i < TextBoxes.Length; i++) {
                line += $"{Labels[i].Text} {TextBoxes[i].Text}=";
            }

            while (!sr.EndOfStream) {
                FileStream fsWrite = new FileStream("LibTemp.txt", FileMode.Append, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fsWrite);

                string t = sr.ReadLine();
                if (line != t) { sw.WriteLine(t); }

                sw.Close();
                fsWrite.Close();
            }

            sr.Close();
            fs.Close();

            File.Delete("Lib.txt");
            File.Move("LibTemp.txt", "Lib.txt");
        }
        public void DeleteAllFromFile() {
            FileStream fs = new FileStream("Lib.txt", FileMode.Create);
            fs.Close();
        }
        public string GetFirstBook() {
            FileStream fs = new FileStream("Lib.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

            string line = string.Empty;
            while (!sr.EndOfStream) {
                line = $"{sr.ReadLine()?.Replace("=", "\n") ?? ""}\n";
                break;
            }

            sr.Close();
            fs.Close();

            if (line.Length == 0) {
                return "В списке ещё нет книг";
            }

            return line;
        }

        public string[] LoadFromFile() {
            List<string> lines = new List<string>();
            FileStream fs = new FileStream("Lib.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

            while (!sr.EndOfStream) {
                lines.Add($"{sr.ReadLine()?.Replace("=", "\n") ?? ""}\n");
            }

            sr.Close();
            fs.Close();

            return lines.ToArray();
        }
    }
}
