using ProfTests.Other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfTests.Models
{
    public class AnswerChoice : BaseViewModel
    {
        public AnswerChoice(string text, int score)
        {
            Text = text;
            ScoreCount = score;
        }

        public string Text { get; set; }
        private bool? _IsSelected = false;
        private int scoreCount;

        public bool? IsSelected
        {
            get => _IsSelected;
            set
            {
                _IsSelected = value;
                OnPropertyChanged("IsSelected");
            }
        }

        public int ScoreCount
        {
            get => scoreCount;
            set
            {
                scoreCount = value;
                OnPropertyChanged("ScoreCount");
            }
        }
    }
}
