using System;
using System.Linq;

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

    // File path where CSV is stored
    static string destinationFilePath;

    // Loads questions from CSV and starts the menu
    public static void Main()
    {
        string folder = "Data";
        string filename = "Question.csv";

        // Copy CSV into working directory
        string filePath = CopyDataToWorkingDir(folder, filename);
        destinationFilePath = filePath;

        // Load all questions into memory
        Question.LoadQuestion(filePath);

        // Start the main menu
        MainMenu();
    }

    // Main menu
    public static void MainMenu()
    {
        while (true)
        {
            Console.WriteLine("Main Menu:");
            Console.WriteLine("1. Edit Question");
            Console.WriteLine("2. Show Correct Answer for Chosen Question");
            Console.WriteLine("3. Show All Questions");
            Console.WriteLine("4. Add Question");
            Console.WriteLine("5. Remove Question");
            Console.WriteLine("6. Exit");

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
                    // Call method to show all questions
                    ShowAllQuestions();
                    break;
                case "4":
                    // Call method to add question
                    AddQuestion();
                    break;
                case "5":
                    // Call method to remove question
                    RemoveQuestion();
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    // Edit a question
    // Updates object and rewrites the CSV file
    public static void EditQuestion()
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

        // Collect updated values from the user
        Console.WriteLine("Enter new question text:");
        string newText = Console.ReadLine();

        Console.WriteLine("Enter new options:");
        string newOptions = Console.ReadLine();

        Console.WriteLine("Enter new correct answer:");
        string newAnswer = Console.ReadLine();

        Console.WriteLine("Enter new difficulty:");
        string newDifficulty = Console.ReadLine();

        // Update the question object
        q.Update(newText, newOptions, newAnswer, newDifficulty);

        // Save updated list back to CSV
        Question.SaveAllQuestionsToCSV(destinationFilePath);

        Console.WriteLine("Question updated successfully.");
    }

    // Display the correct answer for a question
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

    // Show all questions
    public static void ShowAllQuestions()
    {
        List<Question> questions = Question.GetAllQuestions();
        foreach (Question q in questions)
        {
            Console.WriteLine($"ID: {q.QuestionID}");
            Console.WriteLine($"Text: {q.QuestionText}");
            Console.WriteLine($"Options: {q.QuestionOptions}");
            Console.WriteLine($"Correct Answer: {q.QuestionCorrectAnswer}");
            Console.WriteLine($"Difficulty: {q.QuestionDifficulty}");
        }
    }

    // Add a new question
    public static void AddQuestion()
    {
        Console.WriteLine("Enter Question ID:");
        int id = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter Question Text:");
        string text = Console.ReadLine();

        Console.WriteLine("Enter Question Options:");
        string options = Console.ReadLine();

        Console.WriteLine("Enter Correct Answer:");
        string answer = Console.ReadLine();

        Console.WriteLine("Enter Difficulty Level:");
        string difficulty = Console.ReadLine();

        Question newQ = new Question(id, text, options, answer, difficulty);
        Question.GetAllQuestions().Add(newQ);
        Question.SaveQuestionToCSV(destinationFilePath, newQ);
        Console.WriteLine("Question added successfully.");
    }

    // Remove a question by ID
    //Updates the list and rewrites the CSV file
    public static void RemoveQuestion()
    {
        Console.WriteLine("Enter Question ID to remove:");
        int id = int.Parse(Console.ReadLine());

        List<Question> questions = Question.GetAllQuestions();
        Question q = questions.FirstOrDefault(x => x.QuestionID == id);

        if (q == null)
        {
            Console.WriteLine("Question not found.");
            return;
        }

        // Remove from list
        questions.Remove(q);

        // Rewrite CSV without the removed question
        Question.SaveAllQuestionsToCSV(destinationFilePath);
        Console.WriteLine("Question removed successfully.");
    }
}
