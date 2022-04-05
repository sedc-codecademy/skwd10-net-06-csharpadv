// See https://aka.ms/new-console-template for more information


using Class00.Excercise2.Entities;
using Class00.Excercise2.Services;


Services services = new Services();


Console.WriteLine("Hello and welcome to our quiz app !!!!");

while (true)
{
    try
    {

        Console.WriteLine("Please enter username");
        string username = Console.ReadLine();
        if (string.IsNullOrEmpty(username))
        {
            throw new Exception("Please enter username, it's mandatory field");
        }


        Student student = services.GetStudentByUserName(username);

        if (student != null)
        {

            if (student == null)
            {
                throw new Exception("The user does not exist");
            }
            bool isPasswordCorrect = services.PasswordCheck(student.Password);
            if (!isPasswordCorrect)
            {
                throw new Exception("Password did not match 3 times. Try again after 30 minutes");
            }
            if (student.isQuizzFinished)
            {
                throw new Exception("You already did the quiz");
            }


            services.StartQuiz(student);

        }
        else
        {
            Teacher teacher = services.GetTeacherByUserName(username);

            if (teacher == null)
            {
                throw new Exception("The user does not exist");
            }
            bool isPasswordCorrect = services.PasswordCheck(teacher.Password);
            if (!isPasswordCorrect)
            {
                Console.WriteLine("You have entered incorrect password three times! The application will close!");
                //Console.ReadLine();
                Environment.Exit(0);
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("The students that take the quiz are: ");
            foreach (Student students in services.GetStudentsThatStartTheQuiz())
            {
                Console.WriteLine($"{students.FirstName} {students.LastName} with {students.CorrectAnswers} correct answers");
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("The students that dont take the quiz are: ");
            foreach (Student students in services.GetStudentsThatNotStartTheQuiz())
            {
                Console.WriteLine($"{students.FirstName} {students.LastName}");
            }

            Console.ResetColor();


        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("An error occured");
        Console.WriteLine(ex.Message);
    }
}








 
