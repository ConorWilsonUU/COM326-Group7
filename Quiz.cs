using System;

public class Quiz
{
	public Quiz()
	{
		private int QuizID;
		private string QuizTitle;
		private	string QuizDescription;
		private DateTime QuizDate;

			public int QuizID
			{
					get { return QuizID; }
					set { QuizID = value; }
			}
			public string QuizTitle
			{
					get { return QuizTitle; }
					set { QuizTitle = value; }
			}
			public string QuizDescription
			{
					get { return QuizDescription; }
					set { QuizDescription = value; }
			}
			public DateTime QuizDate
			{
					get { return QuizDate; }
					set { QuizDate = value; }
			}
			// Constructor
			public Quiz(int quizID, string quizTitle, string quizDescription, DateTime quizDate)
			{
					this.QuizID = quizID;
					this.QuizTitle = quizTitle;
					this.QuizDescription = quizDescription;
					this.QuizDate = quizDate;
			}
}
}
