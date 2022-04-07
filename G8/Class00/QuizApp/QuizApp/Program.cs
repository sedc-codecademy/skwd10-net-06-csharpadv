// See https://aka.ms/new-console-template for more information

using QuizApp.Domain.Classes;
using QuizApp.Services;

UserService userService = new UserService();
QuizService quizService = new QuizService();


while (true)
{
    try
    {
        Console.WriteLine("Enter username");
        string username = Console.ReadLine();
        if (string.IsNullOrEmpty(username))
        {
            throw new Exception("You must enter username");
        }

        Teacher teacher = userService.GetTeacherByUserName(username);
        if(teacher != null)
        {
            bool passwordMatch = userService.PasswordMatch(teacher.Password);
            if (!passwordMatch)
            {
                throw new Exception("Password did not match 3 times. Try again after 30 minutes");
            }

            Console.ForegroundColor = ConsoleColor.Green;
            foreach(Student student in userService.GetStudentsThatDidTheQuiz())
            {
                Console.WriteLine($"{student.FirstName} {student.LastName} {student.CorrectAnswer}");
            }

            Console.ForegroundColor = ConsoleColor.Red;
            foreach (Student student in userService.GetStudentsThatDidNotFinisheTheQuiz())
            {
                Console.WriteLine($"{student.FirstName} {student.LastName}");
            }

            Console.ResetColor();
        }
        else
        {
            Student student = userService.GetStudentByUserName(username);
            if(student == null)
            {
                throw new Exception("The user does not exist");
            }
            bool passwordMatch = userService.PasswordMatch(student.Password);
            if (!passwordMatch)
            {
                throw new Exception("Password did not match 3 times. Try again after 30 minutes");
            }
            if (student.HasFinishedQuiz)
            {
                throw new Exception("You already did the quiz");
            }
            quizService.TakeQuiz(student);
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("An error occured");
        Console.WriteLine(ex.Message);
    }
}


Console.ReadLine();
