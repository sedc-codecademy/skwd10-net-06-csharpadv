using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class00.Excercise2.Entities
{
    public static class QuestionsAndAnswersDB
    {
        public static List<Questions> Questions = new List<Questions>()
        {
            new Questions()
            {
                Question = "What is the capital of Tasmania?",
                 Answers  = new List<string>
                {
                    "a: Dodoma",
                    "b: Hobart",
                    "c: Launceston",
                    "d: Wellington"
                },
                CorrectAnswer = 2
            },
            new Questions()
            {
                Question = "What is the tallest building in the Republic of the Congo?",
                Answers  = new List<string>
                {
                    "a: Kinshasa Democratic Republic of the Congo Temple",
                    "b: Palais de la Nation",
                    "c: Kongo Trade Centre",
                    "d: Nabemba Tower"
                },
                CorrectAnswer = 4
            },
            new Questions()
            {
                Question = "Which of these is not one of Pluto's moons?",
                Answers  = new List<string>
                {
                    "a: Styx",
                    "b: Hydra",
                    "c: Nix",
                    "d: Lugia"
                },
                CorrectAnswer = 3
            },
            new Questions()
            {
                Question = "What is the smallest lake in the world?",
                Answers  = new List<string>
                {
                    "a: Onega Lake",
                    "b: Benxi Lake",
                    "c: Kivu Lake",
                    "d: Wakatipu Lake"
                },
                CorrectAnswer = 2
            },
            new Questions()
            {
                Question = "What country has the largest population of alpacas?",
                Answers  = new List<string>
                {
                    "a: Chad",
                    "b: Peru",
                    "c: Australia",
                    "d: Niger"
                },
                CorrectAnswer = 2
            },
        };
    }
}
