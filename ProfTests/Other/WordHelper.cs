using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Word = Microsoft.Office.Interop.Word;

namespace ProfTests.Other
{
    public static class WordHelper
    {
        public static void InWord(IEnumerable<Tuple<string, string>> res, string relativeSource)
        {
            try
            {
                Word.Application app = new Word.Application();
                string source = AppDomain.CurrentDomain.BaseDirectory + relativeSource;
                Word.Document doc = app.Documents.Add(source);
                doc.Activate();
                Word.Bookmarks bookmarks = doc.Bookmarks;

                StringBuilder result = new StringBuilder();

                foreach (var b in res)
                {
                    result.AppendLine(b.Item1);
                    result.AppendLine(b.Item2);
                }

                bookmarks["Results"].Range.Text = result.ToString();
                bookmarks["Name"].Range.Text = StaticParameters.User.Name;
                bookmarks["SecondName"].Range.Text = StaticParameters.User.SecondName;

                app.PrintOut(Range: Word.WdPrintOutRange.wdPrintAllDocument);
            }
            catch
            {
                MessageBox.Show("Произошла ошибка с печатью документа");
            }
        }
    }
}
