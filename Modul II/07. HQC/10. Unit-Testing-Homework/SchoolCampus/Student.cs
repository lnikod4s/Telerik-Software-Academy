using System;

namespace SchoolCampus
{
    public class Student
    {
        private const int MIN_ID_VALUE = 10000;
        private const int MAX_ID_VALUE = 99999;

        private static int uniqueNumber = MIN_ID_VALUE;
        private readonly int id;
        private string name;

        public Student(string name)
        {
            this.id = uniqueNumber++;
            this.Name = name;
        }

        public int Id
        {
            get
            {
                if (this.id > MAX_ID_VALUE)
                {
                    throw new ArgumentOutOfRangeException(
                        string.Format("Student's ID must be a integer value in the range[{0}...{1}].", MIN_ID_VALUE, MAX_ID_VALUE));
                }

                return this.id;
            }
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Student's name cannot be null or emtpy string.");
                }

                this.name = value;
            }
        }
    }
}