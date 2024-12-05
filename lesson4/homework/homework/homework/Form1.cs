using System.Collections.Generic;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace homework {
    public partial class Form1 :Form {
        Dictionary<string, double> gasoline;
        List<(TextBox price, TextBox count, double sum)> menu;
        private double RefuelingSum { get; set; }
        private double CoffeeSum { get; set; }
        private double TotalSum { get; set; }


        public Form1() {
            InitializeComponent();

            TextBox[] textBoxes = { textBox1, textBox2, textBox3, textBox8, textBox9, textBox10, textBox11 };
            for (int i = 0; i < textBoxes.Length; i++) {
                textBoxes[i].Enabled = false;
                textBoxes[i].Text = "0";
            }

            TextBox[] textBoxesEvents = { textBox8, textBox9, textBox11, textBox10 };
            for (int i = 0; i < textBoxesEvents.Length; i++) {
                textBoxesEvents[i].EnabledChanged += AllTextBoxCoffe_TextChanged;
                textBoxesEvents[i].TextChanged += AllTextBoxCoffe_TextChanged;
            }

            checkBox1.CheckedChanged += checkBox_CheckedChanged;
            checkBox2.CheckedChanged += checkBox_CheckedChanged;
            checkBox3.CheckedChanged += checkBox_CheckedChanged;
            checkBox4.CheckedChanged += checkBox_CheckedChanged;

            textBox2.TextChanged += gasStation_TextChanged;
            textBox3.TextChanged += gasStation_TextChanged;

            radioButton1.CheckedChanged += AllRadioBatton_CheckedChanged;
            radioButton2.CheckedChanged += AllRadioBatton_CheckedChanged;


            // <Price (Key), Count (Value)>
            menu = new List<(TextBox, TextBox, double)> {
                ( textBox7, textBox8, 0 ),
                ( textBox6, textBox9, 0 ),
                ( textBox4, textBox11, 0 ),
                ( textBox5, textBox10, 0 ),
            };

            gasoline = new Dictionary<string, double> {
                {"Regular", 1.25 },
                {"Midgrade", 5.25 },
                {"Premium", 10.55 },
                {"Diesel", 7.65 },
                {"E85", 7.46 }
            };

            foreach (var item in gasoline) { comboBox1.Items.Add(item.Key); }
            comboBox1.Text = comboBox1.Items[0]?.ToString() ?? "Default Value";

            textBox1.Enabled = false;
            textBox2.Enabled = true;

            textBox4.Text = "7,20";
            textBox5.Text = "4,40";
            textBox6.Text = "5,40";
            textBox7.Text = "4,00";

            label9.Text = "0 грн";
        }


        private void SumTotalLabel() {
            TotalSum = 0;
            TotalSum += CoffeeSum;
            TotalSum += RefuelingSum;
            label10.Text = $"{TotalSum.ToString("F2")} грн";
        }
        private void CalculateLitersForMoney() {
            double sum = double.Parse(textBox3.Text);
            double fuelPrice = double.Parse(textBox1.Text);

            RefuelingSum = sum;
            textBox2.Text = (sum / fuelPrice).ToString("F3");
        }
        private void CalculatePriceForLiters() {
            RefuelingSum = double.Parse(textBox1.Text) * double.Parse(textBox2.Text);
            label6.Text = $"{RefuelingSum.ToString("F2")} грн";
        }
        private void CalculateCafeOrderTotal() {
            CoffeeSum = 0;
            for (int i = 0; i < menu.Count; i++) {
                if (menu[i].count.Enabled) {
                    double count = double.Parse(menu[i].price.Text);
                    double price = double.Parse(menu[i].count.Text);

                    // Обновляем элемент
                    menu[i] = (menu[i].price, menu[i].count, (menu[i].sum * 0) + price * count);
                    CoffeeSum += menu[i].sum;
                }
            }

            label9.Text = $"{CoffeeSum.ToString("F2")} грн";
        }

        
        // Автозаправка
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
            if (comboBox1.SelectedItem == null) { return; }

            string selectedItem = comboBox1.SelectedItem.ToString() ?? string.Empty;
            textBox1.Text = gasoline[selectedItem].ToString();

            if (radioButton1.Checked) { CalculatePriceForLiters(); }
            else if (radioButton2.Checked) { CalculateLitersForMoney(); }

            SumTotalLabel();
        }
        private void AllRadioBatton_CheckedChanged(object? sender, EventArgs e) {
            if (sender == null) { return; }
            RadioButton radioButton = (RadioButton)sender;

            if(radioButton.Checked) {
                textBox2.Enabled = !textBox2.Enabled;
                textBox3.Enabled = !textBox3.Enabled;

                if (!string.IsNullOrEmpty(textBox2.Text) && textBox2.Enabled) { 
                    if (textBox3.Text.Length == 0) { textBox3.Text = "0";  }
                    CalculatePriceForLiters(); 
                }
                else if (!string.IsNullOrEmpty(textBox3.Text) && textBox3.Enabled) { CalculateLitersForMoney(); }
                else { label6.Text = $"0 грн"; label10.Text = $"0 грн"; }

                SumTotalLabel();
            }
        }
        private void gasStation_TextChanged(object? sender, EventArgs e) {
            if (sender == null) { return; }
            TextBox textBox = (TextBox)sender;
            if (!string.IsNullOrEmpty(textBox.Text)) {
                if (textBox.Name == "textBox2") { CalculatePriceForLiters(); }
                else { CalculateLitersForMoney(); }

                SumTotalLabel();
            } else { label6.Text = $"0 грн"; label10.Text = $"0 грн"; }
        }
        

        // Кофе
        private void checkBox_CheckedChanged(object? sender, EventArgs e) {
            if (sender == null) { return; }
            
            CheckBox[] checkBoxes = { checkBox1, checkBox2, checkBox3, checkBox4 };
            TextBox[] textBoxes = { textBox8, textBox9, textBox11, textBox10 };

            if (checkBoxes.Length != textBoxes.Length) { return; }

            for (int i = 0; i < checkBoxes.Length; i++)
                textBoxes[i].Enabled = checkBoxes[i].Checked;

            label9.Text = $"{CoffeeSum.ToString()} грн";
        }
        private void AllTextBoxCoffe_TextChanged(object? sender, EventArgs e) {
            if (sender == null) { return; }
            TextBox textBox = (TextBox)sender;

            if (string.IsNullOrEmpty(textBox.Text) || !double.TryParse(textBox.Text, out double result )) {
                CoffeeSum = 0;
                label9.Text = $"0 грн";
                
                SumTotalLabel();
                return;
            }

            CalculateCafeOrderTotal();
            SumTotalLabel();
        }
    }
}