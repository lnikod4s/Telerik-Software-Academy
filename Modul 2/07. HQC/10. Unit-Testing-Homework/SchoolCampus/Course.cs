using System;
using System.Collections.Generic;

namespace SchoolCampus
{
    public class Course
    {
        private const int MAX_STUDENTS_COUNT = 30;

        private ICollection<Student> students;

        public Course(ICollection<Student> students)
        {
            this.Students = new List<Student>(students);
        }

        public ICollection<Student> Students
        {
            get { return this.students; }
            set
            {
                if (value.Count > MAX_STUDENTS_COUNT)
                {
                    throw new ArgumentOutOfRangeException(
                        string.Format("Count of students in each course should be less than {0}", MAX_STUDENTS_COUNT));
                }

                this.students = value;
            }
        }

        public void AddStudent(Student student)
        {
            this.Students.Add(student);
        }

        public void RemoveStudent(Student student)
        {
            this.Students.Remove(student);
        }
    }
}
