using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfGid.Model
{
    public class Profession
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class Question
    {
        public string Text { get; set; }
        public List<Answer> Answers { get; set; }
    }

    public class Answer
    {
        public string Text { get; set; }
        public string ProfessionName { get; set; }
        public bool IsSelected { get; set; }
    }
}
