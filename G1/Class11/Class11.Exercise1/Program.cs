using Class11.Exercise1.DataAccess;
using Class11.Exercise1.Entities;

Console.WriteLine("================ Exercise to show how we can use JSON/CSV file as database ================");
Console.WriteLine("We have 2 entities Student and Subject and we create JSON/CSV files that will be used as");
Console.WriteLine("simulation for database. So for student we will have file students.json/csv and for subject");
Console.WriteLine("we will have subjects.json/csv. As already worked in workshop we will use generic class to");
Console.WriteLine("have one common database class and to be used for both entities.");
Console.WriteLine("===========================================================================================");

Db<Student> studentDb = new Db<Student>();
Db<Subject> subjectDb = new Db<Subject>();

void Seed()
{
    if(studentDb.GetAll().Count == 0)
    {
        Console.WriteLine("========== INSERTING DATA IN STUDENTS DATABASE ===========");
        studentDb.Insert(new Student("John", "Snow", 23));
        studentDb.Insert(new Student("Jane", "Doe", 35));
        studentDb.Insert(new Student("John", "Smith", 123));
    }


    if (subjectDb.GetAll().Count == 0)
    {
        Console.WriteLine("========== INSERTING DATA IN SBJECTS DATABASE ===========");
        subjectDb.Insert(new Subject("C# Advanced", Academy.Programming, 15));
        subjectDb.Insert(new Subject("Photoshop", Academy.Design, 20));
        subjectDb.Insert(new Subject("C# Basic", Academy.Programming, 12));
    }
}

Seed();

var students = studentDb.GetAll();
var subjects = subjectDb.GetAll();

Console.WriteLine("=========== STUDENTS LIST ===========");
foreach(var student in students)
{
    Console.WriteLine(student.Info());
}

Console.WriteLine("=========== SUBJECTS LIST ===========");
foreach (var subject in subjects)
{
    Console.WriteLine(subject.Info());
}

Console.WriteLine("=========== GET BY ID ===========");
Console.Write("Student with ID 2 is ");
Console.WriteLine(studentDb.GetById(2).Info());

Console.Write("Subject with ID 3 is ");
Console.WriteLine(subjectDb.GetById(3).Info());

Console.WriteLine("=========== ADD NEW STUDENT ===========");
Console.Write("FirstName: ");
string firstName = Console.ReadLine();
Console.Write("LastName: ");
string lastName = Console.ReadLine();
Console.Write("Age: ");
int age = int.Parse(Console.ReadLine());
Student newStudent = new Student(firstName, lastName, age);
studentDb.Insert(newStudent);
Console.WriteLine("======== STUDENT CREATED ==========");

Console.WriteLine("=========== STUDENTS LIST ===========");
students = studentDb.GetAll();
foreach (var student in students)
{
    Console.WriteLine(student.Info());
}

Console.WriteLine("=========== CLEAR DATABASE ===========");
Console.Write("Do you want to clear both databases? (y/n) ");
string answer = Console.ReadLine();
if (answer == "y")
{
    studentDb.ClearDb();
    subjectDb.ClearDb();
}
else
{
    Console.WriteLine("Not sure a?");
}
