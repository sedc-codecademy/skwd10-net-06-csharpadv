// See https://aka.ms/new-console-template for more information
using CSharp_Advanced_G3_L1_EX1.Enteties;
using CSharp_Advanced_G3_L1_EX1.Interfaces;

IUser teacher1 = new Teacher
{
    Id = 1,
    Name = "Ivan",
    Username = "ivan",
    Password = "ivan123",
    Subject ="C# Advanced"
};

IUser teacher2 = new Teacher
{
    Id = 2,
    Name = "Vlatko",
    Username = "vlatko",
    Password = "vlatko123",
    Subject = "C# Advanced"
};

IUser student1 = new Student
{
    Id = 3,
    Name = "Petko",
    Username = "petko",
    Password = "petko123",
    Grades = new List<int> { 1, 2, 3 },
};

IUser student2 = new Student
{
    Id = 4,
    Name = "Trajko",
    Username = "trajko",
    Password = "trajko123",
    Grades = new List<int> { 4, 5, 6 },
};

teacher1.PrintUser();
teacher2.PrintUser();
student1.PrintUser();
student2.PrintUser();
