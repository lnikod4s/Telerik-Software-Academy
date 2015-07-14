using System;
using System.Collections.Generic;
using System.Linq;

internal class Student
{
	private string firstName;
	private string lastName;
	private IList<Exam> exams;

	internal Student(string firstName, string lastName, IList<Exam> exams = null)
	{
		this.firstName = firstName;
		this.lastName = lastName;
		this.exams = exams;
	}

	internal string FirstName
	{
		get { return this.firstName; }
		set
		{
			if (value == null)
			{
				throw new NullReferenceException("First name value is null.");
			}

			this.firstName = value;
		}
	}

	internal string LastName
	{
		get { return this.lastName; }
		set
		{
			if (value == null)
			{
				throw new NullReferenceException("Last name value is null.");
			}

			this.lastName = value;
		}
	}

	internal IList<Exam> Exams
	{
		get { return new List<Exam>(this.exams); }
		private set
		{
			if (this.Exams == null)
			{
				throw new NullReferenceException("Set of exams is null.");
			}

			if (this.Exams.Count == 0)
			{
				throw new ArgumentException("Set of exams is empty.");
			}

			this.exams = value;
		}
	}

	internal IList<ExamResult> CheckExams()
	{
		return this.Exams.Select(t => t.Check()).ToList();
	}

	internal double CalcAverageExamResultInPercents()
	{
		var examScore = new double[this.Exams.Count];
		var examResults = this.CheckExams();
		for (int i = 0; i < examResults.Count; i++)
		{
			examScore[i] =
				((double)examResults[i].Grade - examResults[i].MinGrade) /
				(examResults[i].MaxGrade - examResults[i].MinGrade);
		}

		return examScore.Average();
	}
}
