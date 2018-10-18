using ProfTests.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfTests.Data
{
    public static class Input
    {
        public static Methodic PrimaryMethodic()
        {
            List<Question> Questions = new List<Question>
            {
                new Question("Можно ли прожить всю жизнь, не трудясь? Как ты к этому относишься?", "")
                {
                    Answers = new List<AnswerChoice>()
                    {
                        new AnswerChoice("не знаю, не задумывался", 2),
                        new AnswerChoice("можно, но это неинтересно", 3),
                        new AnswerChoice("можно, и это интересно, можно делать все что хочешь", 1)
                    }
                },
                new Question("Зачем люди трудятся?", "")
                {
                    Answers = new List<AnswerChoice>()
                    {
                        new AnswerChoice("чтобы получать деньги", 2),
                        new AnswerChoice("труд приносит радость, делает человека уважаемым в обществе", 1),
                        new AnswerChoice("не знаю", 1)
                    }
                },
                new Question("Ты хотел бы, чтобы твоя работа была…", "")
                {
                    Answers = new List<AnswerChoice>()
                    {
                        new AnswerChoice("интересной и полезной людям ", 3),
                        new AnswerChoice("не обязательно интересной, но высокооплачиваемой", 2),
                        new AnswerChoice("я об этом еще не думал", 1)
                    }
                },
                new Question("Кого можно назвать трудолюбивым человеком?", "")
                {
                    Answers = new List<AnswerChoice>()
                    {
                        new AnswerChoice("того, кто трудится честно, выполняет качественно свою работу", 2),
                        new AnswerChoice("того, кто трудится с любовью ", 3),
                        new AnswerChoice("не знаю", 1)
                    }
                },

            };

            int i = 1;
            Questions.ForEach(x => x.Number = i++);

            return new Methodic()
            {
                Questions = Questions,
                CalcResult = (questions) =>
                {
                    int scores = 0;
                    foreach(var quest in questions)
                    {
                        foreach(var answer in quest.Answers)
                        {
                            if (answer.IsSelected == true)
                                scores += answer.ScoreCount;
                        }
                    }

                    Dictionary<int, string> levels = new Dictionary<int, string>()
                    {
                        [12] = "Высокий",
                        [8] = "Средний",
                        [0] = "Низкий"
                    };

                    var result = new TestResult();
                    result.Items.Add("Уровень", levels.First(x => scores >= x.Key).Value);
                    return result;
                }
            };
        }
    }
}
