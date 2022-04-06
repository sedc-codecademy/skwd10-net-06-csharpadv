using Class00.Excercise2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class00.Excercise2.Services
{
    public  class Services
    {
        public Student GetStudentByUserName(string username)
        {
            return UsernameAndPasswordDB.Students.FirstOrDefault(x => x.Username.ToLower() == username.ToLower());
        }

        public bool PasswordCheck(string password)
        {
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Enter password");
                string passwordInput = Console.ReadLine();
                if (password == passwordInput)
                {
                    return true;
                }
            }
            return false;
        }
        public Teacher GetTeacherByUserName(string username)
        {
            return UsernameAndPasswordDB.Teachers.FirstOrDefault(x => x.Username.ToLower() == username.ToLower());
        }


        public List<Student> GetStudentsThatStartTheQuiz()
        {
            return UsernameAndPasswordDB.Students.Where(x => x.isQuizzFinished).ToList();
        }


        public List<Student> GetStudentsThatNotStartTheQuiz()
        {
            return UsernameAndPasswordDB.Students.Where(x => !x.isQuizzFinished).ToList();
        }


       

        public void StartQuiz(Student student)
        {
            foreach (Questions question in QuestionsAndAnswersDB.Questions)
            {
                Console.WriteLine(question.Question);
                for (int i = 1; i <= question.Answers.Count; i++)
                {
                    Console.WriteLine($"{question.Answers[i - 1]}");
                }

                bool isAnswered = false;
                while (!isAnswered)
                {
                    Console.WriteLine("Enter answer: 1 is a:, 2 is b:, 3 is c and 4 is d");
                    bool isInputCorrect = int.TryParse(Console.ReadLine(), out int selectedAnswer);
                    if (!isInputCorrect)
                    {
                        Console.WriteLine("You must enter a number");
                        continue;
                    }
                    if (selectedAnswer < 1 || selectedAnswer > 4)
                    {
                        Console.WriteLine("Invalid selection, please select 1-4");
                        continue;
                    }
                    if (question.CorrectAnswer == selectedAnswer)
                    {
                        student.CorrectAnswers++;
                    }
                    isAnswered = true;
                }
            }
            student.isQuizzFinished = true;
            Console.WriteLine("Thank you for finishing the quiz");
        }
    }
}
