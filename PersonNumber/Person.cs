using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonNumber
{
    public class Person
    {
        /// <summary>
        /// Default constructor 
        /// </summary>
        public Person()
        {
        }

        /// <summary>
        /// Constructor with tree parameters
        /// </summary>
        /// <param name="personNumber"></param>
        /// <param name="name"></param>
        /// <param name="gender"></param>
        public Person(string personNumber, string name, string gender)
        {
            PersonNumber = personNumber;
            Name = name;
            Gender = gender;
        }

        public string PersonNumber { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }

        /// <summary>
        /// Method that validates the person number
        /// </summary>
        /// <returns></returns>
        public bool Check()
        {
            ControlPersonNumber control = new ControlPersonNumber();
            (bool Valid, string gender) = control.CheckPersonNummer(PersonNumber);
            if(Valid)
            {
                Gender = gender;
                return true;
            }
            return false;
        }

    }
}
