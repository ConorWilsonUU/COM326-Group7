using System;

public class Question
{
	public Question()
	{
		private int questionID;
		private string questionText;
		private string questionCorrectAnswer;
		private string questionDifficulty;

		List<string> QuestionOptions = new List<string>()
		{

		};

			public int QuestionID
			{
					get { return questionID; }
					set { questionID = value; }
			}
			public string QuestionText
			{
					get { return questionText; }
					set { questionText = value; }
			}
			public string QuestionCorrectAnswer
			{
					get { return questionCorrectAnswer; }
					set { questionCorrectAnswer = value; }
			}
			public string QuestionDifficulty
			{
					get { return questionDifficulty; }
					set { questionDifficulty = value; }
			}
			// Constructor
			public Question(int questionID, string questionText, string questionCorrectAnswer, string questionDifficulty)
			{
					this.questionID = questionID;
					this.questionText = questionText;
					this.questionCorrectAnswer = questionCorrectAnswer;
					this.questionDifficulty = questionDifficulty;
			}
}
}
