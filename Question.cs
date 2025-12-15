using System;

public class Question
{
    private int questionID;
	private string questionText;
	private string questionCorrectAnswer;
	private string questionDifficulty;
	private string questionOptions;

    private static List<Question> QuestionLists = new List<Question>();

    public static List<Question> GetAllQuestions()
    {
               return QuestionLists;
    }

    public static void LoadQuestion(string destinationFilePath)
    {
        using (var reader = new StreamReader(destinationFilePath))
        {
            // Skip the heqader line
            reader.ReadLine();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');

                // Read each value into the relevant variable
                int QuestionID = int.Parse(values[0]);
                string QuestionText = values[1];
                string QuestionOptions = values[2];
                string CorrectAnswer = values[3];
                string DifficultyLevel = values[4];

                // Create a question
                Question q = new Question(QuestionID, QuestionText, CorrectAnswer, DifficultyLevel, QuestionOptions);
                QuestionLists.Add(q);
            }
        }
    }

    public static void Answer()
	{
		Console.WriteLine("Enter QuestionID: ");
		string input = Console.ReadLine();
		try
		{
			int id = Convert.ToInt32(input);

			Question found = null;
			foreach (Question q in QuestionList)
			{
                if (q.QuestionID == id)
				{
					found = q;
					break;
				}
			}
			if (found != null)
			{
                Console.WriteLine($"Question: {found.QuestionText}");
                Console.WriteLine($"Correct Answer: {found.QuestionCorrectAnswer}");
            } 
            else
            {
                Console.WriteLine("Question not found.");
            }
        }
        catch (FormatException)
		{
			Console.WriteLine("Invalid ID. Please try again");
		}
	}

    public void Update(string newText, string newOptions, string newAnswer, string newDifficulty)
    {
        QuestionText = newText;
        QuestionOptions = newOptions;
        QuestionCorrectAnswer = newAnswer;
        QuestionDifficulty = newDifficulty;
    }

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

    public string QuestionOptions 
	{ 
		get { return questionOptions; } 
		set { questionOptions = value; } 
	}

    // Constructor
    public Question(int questionID, string questionText, string questionCorrectAnswer, string questionDifficulty, string questionOptions)
	{
		this.questionID = questionID;
		this.questionText = questionText;
		this.questionCorrectAnswer = questionCorrectAnswer;
		this.questionDifficulty = questionDifficulty;
        this.questionOptions = questionOptions;
    }

}