using ProfTests.Other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfTests.Models
{
    public class Methodic : BaseViewModel
    {
        public List<Question> Questions { get; set; }
        public Action<Methodic> CalcResult { get; set; }
        public List<TestResult> TestResult { get; set; }
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
    }
}
