using System;

public class Question
{ 


//public Question()
//*****************************************************
// NEED TO DO
//*****************************************************
// Save questions into the list  <----!!! DONE
// Edit Question <----
// Show correct answer for chosen question <---- DONE



	private int questionID;
	private string questionText;
	private string questionCorrectAnswer;
	private string questionDifficulty;
	private string questionOptions;

	private static List<Question> QuestionList = new List<Question>();
	static string destinationFilePath;

	public static void Main()
	{
		string folder = "Data";
		string filename = "Question.csv";

		destinationFilePath = CopyDataToWorkingDir(folder, filename);
		LoadQuestionsOptions(destinationFilePath);
		MainMenu();
	}

	public static string CopyDataToWorkingDir(string folder, string filename)
	{
		string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.Fullname;
		string sourceFilePath = Path.Combine(projectDirectory,folder, filename);
		string destinationFilePath = Path.Combine(Environment.CurrentDirectory,filename);

		if (File.Exists(sourceFilePath))
		{
			File.Copy(sourceFilePath, destinationFilePath, true);
		}
		else
		{
			Console.WriteLine("Source file not found: " + sourceFilePath);
		}
		return destinationFilePath;
	}

	public static void LoadQuestionOptions(string destinationFilePath)
	{
		using (var reader = new StreamReader(destinationFilePath))
		{
			reader.ReadLine();
			while(!reader.EndOfStream)
			{
				var line = reader.ReadLine();
				var values = line.Split(',');
				int QuestionId = int.Parse(values[0]);
				string QuestionTxt = values[1];
				string Options = values[2];
				string CorrectAnswer = values[3];
				string DifficultyLevel = values[4];

                Question q = new Question(QuestionId, QuestionTxt, CorrectAnswer, DifficultyLevel, Options);
                QuestionList.Add(q);
            }
		}
	}

	public static void MainMenu()
	{
		while (true)
		{
			Console.WriteLine("Pick An Option:");
            Console.WriteLine("1: Edit Question");
            Console.WriteLine("2: Show Answer");
            int choice = Convert.To.Int32(Console.ReadLine());

			if (choice == 1)
			{
				EditQuestion();
			}
			else if(choice == 2)
			{
				Answer();
			}
			else
			{
				Console.WriteLine("Please try again");
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

	public static void EditQuestion()
	{
		//do this next time
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