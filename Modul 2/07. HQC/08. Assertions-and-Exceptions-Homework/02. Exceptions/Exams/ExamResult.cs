using System;

internal class ExamResult
{
	private int grade;
	private int minGrade;
	private int maxGrade;
	private string comments;

	internal ExamResult(int grade, int minGrade, int maxGrade, string comments)
	{
		this.grade = grade;
		this.minGrade = minGrade;
		this.maxGrade = maxGrade;
		this.comments = comments;
	}

	internal int Grade
	{
		get { return this.grade; }
		private set
		{
			if (value < 0)
			{
				throw new ArgumentException("Grade value must be at least zero.");
			}

			this.grade = value;
		}
	}

	internal int MinGrade
	{
		get { return this.minGrade; }
		private set
		{
			if (value < 0)
			{
				throw new ArgumentException("MinGrade value must be at least zero.");
			}

			this.minGrade = value;
		}
	}

	internal int MaxGrade
	{
		get { return this.maxGrade; }
		private set
		{
			if (value < 0)
			{
				throw new ArgumentException("MaxGrade value must be at least zero.");
			}

			this.maxGrade = value;
		}
	}

	internal string Comments
	{
		get { return this.comments; }
		private set
		{
			if (string.IsNullOrEmpty(value))
			{
				throw new NullReferenceException("Comments value should be a non-empty string.");
			}

			this.comments = value;
		}
	}
}
