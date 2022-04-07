using QuizApp.Domain.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Domain
{
    public static class InMemoryDb
    {

        public static List<Question> Questions = new List<Question>
        {
            new Question()
            {
                Description = "What is the capital of Tasmania?",
                Answers  = new List<string>
                {
                    "Dodoma",
                    "Hobart",
                    "Launceston",
                    "Wellington"
                },
                CorrectAnswer = 2                
            },
            new Question()
            {
                Description = "What is the tallest building in the Republic of the Congo?",
                Answers  = new List<string>
                {
                    "Kinshasa Democratic Republic of the Congo Temple",
                    "Palais de la Nation",
                    "Kongo Trade Centre",
                    "Nabemba Tower"
                },
                CorrectAnswer = 4
            },
            new Question()
            {
                Description = "Which of these is not one of Pluto's moons?",
                Answers  = new List<string>
                {
                    "Styx",
                    "Hydra",
                    "Nix",
                    "Lugia"
                },
                CorrectAnswer = 3
            },
            new Question()
            {
                Description = "What is the smallest lake in the world?",
                Answers  = new List<string>
                {
                    "Onega Lake",
                    "Benxi Lake",
                    "Kivu Lake",
                    "Wakatipu Lake"
                },
                CorrectAnswer = 2
            },
            new Question()
            {
                Description = "What country has the largest population of alpacas?",
                Answers  = new List<string>
                {
                    "Chad",
                    "Peru",
                    "Australia",
                    "Niger"
                },
                CorrectAnswer = 2
            },
        };

        public static List<Student> Students = new List<Student>
        {
            new Student() { Username = "student2", Password = "123", FirstName = "student2", LastName = "student2LastName" },
            new Student() { Username = "student3", Password = "123", FirstName = "student3", LastName = "student3LastName" },
            new Student() { Username = "student1", Password = "123", FirstName = "student1", LastName = "student1LastName" },
            new Student() { Username = "student4", Password = "123", FirstName = "student4", LastName = "student4LastName" },
            new Student() { Username = "student5", Password = "123", FirstName = "student5", LastName = "student5LastName" },
            new Student() { Username = "student6", Password = "123", FirstName = "student6", LastName = "student6LastName" },
            new Student() { Username = "student7", Password = "123", FirstName = "student7", LastName = "student7LastName" }
        };

        public static List<Teacher> Teachers = new List<Teacher>
        {
            new Teacher() { Username = "Trainer", Password = "123", FirstName = "trainer" ,  LastName ="Trainer" },
            new Teacher() { Username = "Assistant", Password = "123", FirstName = "assistant" , LastName = "Assistant"},
        };
    }
}
