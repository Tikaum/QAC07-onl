using Exams.Интерфейсы;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exams.Классы
{
    public class EducationalEntity : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateOnly ExamDate { get; set; }
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int Attempt { get; set; }
        public int Score { get; set; }


        public EducationalEntity(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public EducationalEntity(int id, string name, DateOnly examdate)
        {
            Id = id;
            Name = name;
            ExamDate = examdate;
        }

        public EducationalEntity(int id, string disciplinename, DateOnly examdate, int studentID, string studentname, int attempt, int score)
        {
            Id = id;
            Name = disciplinename;
            ExamDate = examdate;
            StudentID = studentID;
            StudentName = studentname;
            Attempt = attempt;
            Score = score;
        }
    }
}
