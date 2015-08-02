using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SchoolCampus.Tests
{
    [TestClass]
    public class SchoolCampusTests
    {
        // Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
        }

        // Use ClassCleanup to run code after all tests in a class have run
        [ClassCleanup]
        public static void ClassCleanup()
        {
        }

        // Use TestInitialize to run code before running each test
        [TestInitialize]
        public void TestInitialize()
        {
        }

        // Use TestCleanup to run code after each test has run
        [TestCleanup]
        public void TestCleanup()
        {
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
        public void TestStudentCtorWithEmptyNameShouldThrowException()
        {
            var student = new Student(string.Empty);
        }

        [TestMethod]
        public void TestStudentCtorShouldProduceValidId()
        {
            const string NAME = "Bruce";
            var student = new Student(NAME);
            Assert.AreEqual(10001, student.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
        public void TestStudentIdGetter()
        {
            for (int i = 0; i < 90001; i++)
            {
                var student = new Student("A#" + i);
                var currId = student.Id;
            }
        }

        [TestMethod]
        public void TestStudentNameGetterAndSetter()
        {
            const string NAME = "David";
            var student = new Student(NAME);
            Assert.AreEqual(NAME, student.Name);
        }

        [TestMethod]
        public void TestSchoolCtor()
        {
            var student1 = new Student("Mel");
            var student2 = new Student("Chuck");
            var student3 = new Student("Bil");
            var student4 = new Student("Steve");

            var studentsSet = new List<Student> { student1, student2, student3, student4 };
            var studentsSet2 = new List<Student> { student3, student4 };
            var studentsSet3 = new List<Student> { student1, student3 };
            var studentsSet4 = new List<Student> { student2, student4 };

            var course = new Course(studentsSet);
            var course2 = new Course(studentsSet2);
            var course3 = new Course(studentsSet3);
            var course4 = new Course(studentsSet4);

            var courseSet = new List<Course> { course, course2, course3, course4 };

            var newSchool = new School(studentsSet, courseSet);
            Assert.AreEqual(studentsSet.Count, newSchool.Students.Count);
            Assert.AreEqual(courseSet.Count, newSchool.Courses.Count);
        }

        [TestMethod]
        public void TestCourseCtor()
        {
            var student1 = new Student("Bruce");
            var student2 = new Student("Lawrence");
            var student3 = new Student("Ernest");
            var student4 = new Student("Robert");

            var studentsSet = new List<Student> { student1, student2, student3, student4 };

            var course = new Course(studentsSet);
            Assert.AreEqual(studentsSet.Count, course.Students.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), AllowDerivedTypes = true)]
        public void TestCourseStudentsSetter()
        {
            var students = new List<Student>();
            for (int i = 0; i < 31; i++)
            {
                var student = new Student("B#" + i);
                students.Add(student);
            }

            var course = new Course(students);
        }

        [TestMethod]
        public void TestCourseAddStudent()
        {
            var students = new List<Student>();
            var course = new Course(students);

            var anotherStudent = new Student("Adam");
            course.AddStudent(anotherStudent);
            Assert.AreEqual(students.Count + 1, course.Students.Count);
        }

        [TestMethod]
        public void TestCourseRemoveStudent()
        {
            var students = new List<Student>();
            var course = new Course(students);

            var student = new Student("Adam");
            course.AddStudent(student);
            course.AddStudent(student);
            course.RemoveStudent(student);
            Assert.AreEqual(students.Count + 1, course.Students.Count);
        }
    }
}
