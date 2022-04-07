// See https://aka.ms/new-console-template for more information

using Class01.Exersice01.Entities;

Console.WriteLine("=========== Student Info ============");
Student student1 = new Student()
{
    Name = "John D",
    Username = "student1",
    Password = "P@ssw0rd",
    Grades = new List<int> { 8, 9, 7, 7, 6 }
};
student1.PrintGrades();
student1.PrintUser();

Console.WriteLine("=========== Teacher Info ============");
Teacher teacher1 = new Teacher()
{
    Name = "Scoth A",
    Username = "teacher1",
    Password = "P@ssw0rd",
    Subjects = new List<string>() { "Math", "Calculus", "Linear Algebra", "Discret Math"}
};
teacher1.PrintSubjects();
teacher1.PrintUser();
