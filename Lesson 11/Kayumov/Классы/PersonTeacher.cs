using Exams.Интерфейсы;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exams.Классы
{
    public class PersonTeacher : IEntity
    {
        public int Id { get; set; }        
        public string Name { get; set; }        
        public string Password { get; set; }
        public int DisciplineId { get; set; }

        public PersonTeacher(int id, string name, string password, int disciplineId)
        {
            Id = id;           
            Name = name;
            Password = password;
            DisciplineId = disciplineId;
        }

    }
}
