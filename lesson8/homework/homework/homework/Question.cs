using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework {
    internal class Question {
        public string Text { get; set; }
        public List<string> Options { get; set; }
        public string CorrectAnswer { get; set; }

        public Question() : this (null, null, null) { }
        public Question(string text, List<string> options, string correctAnswer) {
            Text = text;
            Options = options;
            CorrectAnswer = correctAnswer;
        }
    }
}
