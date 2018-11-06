using ProfTests.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ProfTests.Interfaces
{
    public interface IEvaluation
    {
        TestPageViewModel Model { get; set; }
    }
}
