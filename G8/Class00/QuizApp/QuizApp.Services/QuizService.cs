using QuizApp.Domain;
using QuizApp.Domain.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Services
{
    public class QuizService
    {
        public void TakeQuiz(Student student)
        {
            foreach(Question question in InMemoryDb.Questions)
            {
                Console.WriteLine(question.Description); 
                for(int i = 1; i <= question.Answers.Count; i++)
                {
                    Console.WriteLine($"{i} - {question.Answers[i - 1]}");
                }

                bool isAnswered = false;
                while (!isAnswered)
                {
                    Console.WriteLine("Enter answer");
                    bool success = int.TryParse(Console.ReadLine(), out int selection);
                    if (!success)
                    {
                        Console.WriteLine("You must enter a number");
                        continue;
                    }
                    if(selection < 1 || selection > 4)
                    {
                        Console.WriteLine("Invalid selection");
                        continue;
                    }
                    if(question.CorrectAnswer == selection)
                    {
                        student.CorrectAnswer++;
                    }
                    isAnswered = true;
                }
            }
            student.HasFinishedQuiz = true;
            Console.WriteLine("Thank you!");
        }
    }
}
