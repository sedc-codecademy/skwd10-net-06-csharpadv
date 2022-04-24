using AdvancedLinq.Entities;
using AdvancedLinq.Enums;
using AdvancedLinq.Helpers;



List<Subject> Subjects = new List<Subject>()
{
    new Subject(1,"C# Basic",Academy.Programming),
    new Subject(2,"C# Advanced",Academy.Programming),
    new Subject(3,"MVC",Academy.Programming),
    new Subject(4,"Unit Testing",Academy.Testing),
    new Subject(5,"End-to-end Testing",Academy.Testing),
    new Subject(6,"Manual Testing",Academy.Testing),
    new Subject(7,"ISO/OSI",Academy.Networks),
    new Subject(8,"Network Security",Academy.Networks),
    new Subject(9,"Netwroking Interfaces",Academy.Networks),
    new Subject(10,"Netwroking Interfaces",Academy.Networks),
};


List<Student> Students = new List<Student>()
{
    new Student(3,"Bob","Bobsky", new List<Subject>(){ Subjects[1], Subjects[2] } ),
    new Student(1,"Miki","Miksi", new List<Subject>(){ Subjects[1], Subjects[2],Subjects[3] }),
    new Student(2,"Miki","Miksi", new List<Subject>(){ Subjects[4],Subjects[5],Subjects[6] }),
    new Student(1,"Nikola","Nikolski", new List<Subject>(){ Subjects[6],Subjects[7],Subjects[8] }),
    new Student(1,"Cvetan","Miksi", new List<Subject>(){ Subjects[8],Subjects[3],Subjects[1], Subjects[9] })
};


List<Student> studentsWithSameLastName = Students.Where(x => x.LastName == "Miksi").ToList();

//studentsWithSameLastName.Print();

//Students.Select(x => $"{x.FirstName} {x.LastName}").ToList().ForEach(x => Console.WriteLine(x));

//Students.Where(x => x.Subjects.Any(x => x.AcademyType == Academy.Networks)).ToList().Print();

Student studentNamedMiki = Students.FirstOrDefault(x => x.FirstName == "Mik");

Subject someSubject = Subjects.LastOrDefault(x => x.Id == 10);

Student sameLastName = Students.Single(x => x.LastName == "Nikolski");

//Subject singleTypeProgrammingSubject = Subjects.SingleOrDefault(x => x.AcademyType == Academy.Programming);

//Students.SelectMany(x => x.Subjects).Distinct().ToList().Print();

bool hasBob = Students.Any(x => x.FirstName == "Bob");
//Console.WriteLine(hasBob);

bool allAreBob = Students.All(x => x.FirstName == "Bob");
//Console.WriteLine(allAreBob);

bool sameIds = Students.All(x => x.Id == 1);
//Console.WriteLine(sameIds);

//Subjects.Except(new List<Subject>() { someSubject }).ToList().Print();

//Students.OrderBy(x => x.FirstName).ThenBy(x=>x.Id).ToList().Print();

//Subjects.OrderByDescending(x => x.Id).ToList().Print();

Subjects.OrderBy(x => x.Name).ToList().Print();