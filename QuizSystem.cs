using System;

public class QuizSystem
{
    List<string> AdminUsers = new List<string>()
    {

    };
    List<string> StudentUsers = new List<string>()
    {

    };
    List<string> Quiz = new List<string>()
    {

    };
    List<string> Categories = new List<string>()
    {

    };

    private static List<Question> QuestionLists = new List<Question>();
    static string destinationFilePath;

    // Starting point for the application
    public static void Main()
    {
        string folder = "Data";
        string filename = "Question.csv";

        // Copy CSV into working directory
        string filePath = CopyDataToWorkingDir(folder, filename);
        QuestionLists.LoadQuestion(filePath);

        MainMenu();
    }

    public static void MainMenu()
    {
        while (true)
        {
            Console.WriteLine("Main Menu:");
            Console.WriteLine("1. Edit Question");
            Console.WriteLine("2. Show Correct Answer for Chosen Question");
            Console.WriteLine("3. Exit");

            Console.Write("Select an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    // Call method to edit question
                    EditQuestion();
                    break;
                case "2":
                    // Call method to show correct answer
                    ShowAnswer();
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
    public void EditQuestionMenu()
    {
        Console.WriteLine("Enter Question ID to edit:");
        int id = int.Parse(Console.ReadLine());

        // Get the question list from Question class
        List<Question> questions = Question.GetAllQuestions();
        Question q = questions.FirstOrDefault(x => x.QuestionID == id);

        if (q == null)
        {
            Console.WriteLine("Question not found.");
            return;
        }

        Console.WriteLine("Enter new question text:");
        string newText = Console.ReadLine();

        Console.WriteLine("Enter new options:");
        string newOptions = Console.ReadLine();

        Console.WriteLine("Enter new correct answer:");
        string newAnswer = Console.ReadLine();

        Console.WriteLine("Enter new difficulty:");
        string newDifficulty = Console.ReadLine();

        // Call the Question class update method
        q.Update(newText, newOptions, newAnswer, newDifficulty); 

        Console.WriteLine("Question updated successfully.");
    }

    public static void ShowAnswer()
    {
        Console.WriteLine("Enter Question ID:");
        int id = int.Parse(Console.ReadLine());

        Question q = Question.GetAllQuestions().FirstOrDefault(x => x.QuestionID == id);

        if (q == null)
        {
            Console.WriteLine("Question not found.");
            return;
        }

        Console.WriteLine($"Correct Answer: {q.QuestionCorrectAnswer}");

    }
}
