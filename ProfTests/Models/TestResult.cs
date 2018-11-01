using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfTests.Models
{
    public class TestResult
    {
        public TestResult(string header, string description)
        {
            Header = header;
            Description = description;
        }

        public string Header { get; set; }
        public string Description { get; set; }
    }
}
