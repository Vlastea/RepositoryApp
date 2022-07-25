using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RepositoryApp
{
    public struct Employee
    {
        /// <summary>
        /// Employee ID
        /// </summary>
        private int iD;


        /// <summary>
        /// Entry date
        /// </summary>
        private DateTime vdateTime;

        /// <summary>
        /// Last name and First name
        /// </summary>
        private string name;

        /// <summary>
        /// Age
        /// </summary>
        private int age;

        /// <summary>
        /// Height
        /// </summary>
        private int height;

        /// <summary>
        /// Birth date
        /// </summary>
        private string birthDate;

        /// <summary>
        /// Place of birth
        /// </summary>
        private string place;

        public int ID { get { return this.iD; } set { this.iD = value; } }
        public DateTime VDateTime { get { return this.vdateTime; } set { this.vdateTime = value; } }
        public string Name { get { return this.name; } set { this.name = value; } }
        public int Age { get { return this.age; } set { this.age = value; } }
        public int Height { get { return this.height; } set { this.height = value; } }
        public string BirthDate { get { return this.birthDate; } set { this.birthDate = value; } }
        public string Place { get { return this.place; } set { this.place = value; } }

        public Employee(int ID, DateTime VDateTime, string Name, int Age, int Height, string BirthDate, string Place)
        {
            this.iD = ID;
            this.vdateTime = VDateTime;
            this.name = Name;
            this.age = Age;
            this.height = Height;
            this.birthDate = BirthDate;
            this.place = Place;

        }

        public string Print()
        {
            return $"{this.vdateTime.ToString("g"),18}    ID: {this.iD}  Name:{this.name,10}   Age: {this.age,3}   Height: {this.height,4}   Birth date: {this.birthDate,11}   Birth place: {this.place}";
        }

    }
}
