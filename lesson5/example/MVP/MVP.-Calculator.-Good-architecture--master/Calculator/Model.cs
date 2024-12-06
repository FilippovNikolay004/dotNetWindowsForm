using System;
using System.IO;
using System.Text;

namespace Calculator
{
    public class Model : IModel
    {
        public string Result { get; set; }

        // Потенциально в коде методов происходит обращение к базе данных 
        public void Save()
        {
            StreamWriter sw = new StreamWriter("Database.txt", false);
            sw.WriteLine(Result);
            sw.Close();
        }
        public void Load()
        {
            try
            {
                StreamReader sr = new StreamReader("Database.txt", Encoding.UTF8);
                if (sr != null)
                    Result = sr.ReadLine();
                sr.Close();
            }
            catch (Exception)
            {

            }
        }
    }
}
