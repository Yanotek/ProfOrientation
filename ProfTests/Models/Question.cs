using ProfTests.Other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfTests.Models
{
    public class Question : BaseViewModel
    {
        public Question(string text, string group)
        {
            Text = text;
            Group = group;
        }

        private bool _Completed = false;
        public bool Completed
        {
            get => _Completed;
            set
            {
                _Completed = value;
                OnPropertyChanged("Completed");
            }
        }
        public string Text { get; set; }
        public string Group { get; set; }
        public int Number { get; set; }

        public ICollection<AnswerChoice> Answers { get; set; }
    }
}
