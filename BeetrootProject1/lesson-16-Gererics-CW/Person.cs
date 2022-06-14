using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lesson_16_Gererics_CW
{
    public class Person
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Age { get; set; }

        public Person (string firstName, string lastName, string age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        //возвращать отсортированній масив с персонами
      


    }
}
