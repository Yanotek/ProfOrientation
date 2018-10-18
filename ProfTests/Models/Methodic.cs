using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfTests.Models
{
    public class Methodic
    {
        public List<Question> Questions { get; set; }
        public Func<List<Question>, TestResult> CalcResult { get; set; }
    }
}
