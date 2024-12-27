using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace KeyboardTrainer {
    internal sealed partial class MainWindow : Window {
        string[] symbols = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m",
                           "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
        
        string wordsLine;
        int indexSymbols = 0;
        int mistakeCount = 0;

        bool isUpperCase { get; set; } = false;
        bool isShiftPress { get; set; } = false;
        bool isCapsPress { get; set; } = Keyboard.IsKeyToggled(Key.CapsLock);

        Random r = new Random();
        Stopwatch stopwatch = new Stopwatch();


        public MainWindow() {
            InitializeComponent();

            stop.IsEnabled = false;
            start.IsEnabled = true;

            ToggleCase();
        }

        private void Button_Click_Start(object sender, RoutedEventArgs e) {
            stopwatch.Start();

            stop.IsEnabled = true;
            start.IsEnabled = false;

            wordsLine = "";
            indexSymbols = 0;

            correctWords.Text = "";
            words.Text = "";

            coorectInput.Text = "";
            input.Text = "";

            speed.Text = "0";

            // Создать генерацию слов
            for (int i = 0; i < 5; i++) {
                wordsLine += GenerateWord(int.Parse(level.Value.ToString()), (bool)isCaseSensitive.IsChecked);
                wordsLine += (i + 1 != 5 ? " " : "");
            }
            words.Text = wordsLine;
        }
        private void Button_Click_Stop(object sender, RoutedEventArgs e) {
            stop.IsEnabled = !stop.IsEnabled;
            start.IsEnabled = !start.IsEnabled;
        }

        private void SomeKeyReleased(object sender, KeyEventArgs e) {
            string key = e.Key.ToString().ToLower();

            if (key == "leftshift") {
                isShiftPress = false;
                ToggleCase();
            }
        }

        private void SomeKeyPressed(object sender, KeyEventArgs e) {
            string key = e.Key.ToString().ToLower();

            if (key == "leftshift") {
                isShiftPress = true;
            }
            if (key == "capital") {
                isCapsPress = !isCapsPress;
            }

            ToggleCase();

            if (start.IsEnabled || indexSymbols == wordsLine.Length) {
                return;
            }

            if (key == "space") {
                key = " ";
            }

            if (key == "back") {
                if (input.Text.Length == 0) {
                    return;
                }

                input.Text = input.Text.Remove(input.Text.Length - 1);
                return;
            }
            
            if (key.ToLower() != "leftshift" && key.ToLower() != "capital") {
                key = isUpperCase ? key.ToUpper() : key;

                // Отправить в метод нажатую клавишу и правильную клавишу 
                if (!IsCorrectButton(key, wordsLine[indexSymbols])) {
                    mistakeCount++;
                    fails.Text = mistakeCount.ToString();
                    return;
                }

                coorectInput.Text += key;

                /*
                 * Взять символ по indexSymbols из wordsLine и поместить в correctWords
                 * Из words удалить первый символ и поместить в words
                 */                

                correctWords.Text += wordsLine[indexSymbols].ToString();
                words.Text = words.Text.Substring(1).ToString();
                
                indexSymbols++;

                // Вызвать метод, эффекта нажатия на кнопку
                KeyPressEffect(key);
            }

            if (indexSymbols == wordsLine.Length) {
                stopwatch.Stop();

                speed.Text = (wordsLine.Length / stopwatch.Elapsed.TotalSeconds * 60).ToString("F2");
            }
        }

        private void ToggleCase() {
            isUpperCase = isCapsPress && isShiftPress ? false : isCapsPress ? true : isShiftPress ? true : false;
            
            if (isUpperCase) {
                upperCase.Visibility = Visibility.Visible;
                lowerCase.Visibility = Visibility.Collapsed;
                
                return;
            }

            upperCase.Visibility = Visibility.Collapsed;
            lowerCase.Visibility = Visibility.Visible;
        }
        private string GenerateWord(int numberCharacters = 5, bool isUpperCaseSymbol = false) {
            string word = string.Empty;
            bool isUpper = false;

            for (int i = 0; i < numberCharacters; i++) {
                if (isUpperCaseSymbol) {
                    isUpper = r.Next(0, 2) == 1 ? true : false;
                }

                string temp = symbols[r.Next(0, symbols.Length - 1)];
                temp = isUpper ? temp.ToUpper() : temp;

                word += temp;
            }
            
            return word;
        }
        private void KeyPressEffect(string keyPress) {
            
        }
        private bool IsCorrectButton(string pressButton, char correctButton) {
            if (pressButton == correctButton.ToString())
                return true;

            return false;
        }
    }
}