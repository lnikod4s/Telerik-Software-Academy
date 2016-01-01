using System;

internal class CSharpExam : Exam
{
	private int score;

	internal CSharpExam(int score)
	{
		this.score = score;
	}

	internal int Score
	{
		get { return this.score; }
		private set
		{
			if (value < 0 || value > 100)
			{
				throw new ArgumentException("Score value must be in the range [0...100].");
			}

			this.score = value;
		}
	}

	internal override ExamResult Check()
	{
		return new ExamResult(this.Score, 0, 100, "Exam results calculated by score.");
	}
}
