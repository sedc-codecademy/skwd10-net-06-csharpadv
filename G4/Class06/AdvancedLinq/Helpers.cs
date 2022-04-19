// Copied from README.md
namespace AdvancedLinq
{
    using System.Collections.Generic;

    public abstract class BaseEntity
    {
        public int Id { get; set; }
    }

    public class Person : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        /// <summary>
        /// Adding human-readable text representation when printing objects.
        /// </summary>
        /// <returns>Text representation of <see cref="Person"/> objects.</returns>
        public override string ToString()
        {
            return $"Id: {Id}; FirstName: {FirstName}; LastName: {LastName}; Age: {Age}";
        }
    }

    public class Student : Person
    {
        public bool IsPartTime { get; set; }
        public List<Subject> Subjects { get; set; }
        public Student()
        {

        }
        public Student(int id, string first, string last, int age, bool partTime)
        {
            Id = id;
            FirstName = first;
            LastName = last;
            Age = age;
            IsPartTime = partTime;
        }

        /// <summary>
        /// Adding human-readable text representation when printing objects.
        /// </summary>
        /// <returns>Text representation of <see cref="Student"/> objects.</returns>
        public override string ToString()
        {
            return $"Id: {Id}; FirstName: {FirstName}; LastName: {LastName}; Age: {Age}; IsPartTime: {IsPartTime}";
        }
    }

    public class Subject : BaseEntity
    {
        public string Title { get; set; }
        public int Modules { get; set; }
        public int StudentsAttending { get; set; }
        public Academy Type { get; set; }

        public Subject(int id, string title, int modules, int students, Academy type)
        {
            Id = id;
            Title = title;
            Modules = modules;
            StudentsAttending = students;
            Type = type;
        }

        /// <summary>
        /// Adding human-readable text representation when printing objects.
        /// </summary>
        /// <returns>Text representation of <see cref="Subject"/> objects.</returns>
        public override string ToString()
        {
            return
                $"Id: {Id}; Title: {Title}; Modules: {Modules}; StudentsAttending: {StudentsAttending}; AcademyType: {Type}";
        }
    }

    public enum Academy
    {
        Programming,
        Design,
        Networks
    }

    public static class SEDC
    {
        public static List<Student> Students = new List<Student>()
        {
            new Student(12, "Bob", "Bobsky", 29, false),
            new Student(22, "Jill", "Wayne", 36, true),
            new Student(27, "Greg", "Gregsky", 45, false),
            new Student(29, "Anne", "Willson", 31, true),
            new Student(30, "Liana", "Wurtz", 25, false),
            new Student(41, "Bill", "Zu", 38, false)
        };

        public static List<Subject> Subjects = new List<Subject>()
        {
            new Subject(15, "C# Basic", 10, 24, Academy.Programming),
            new Subject(16, "C# Advanced", 15, 26, Academy.Programming),
            new Subject(44, "JavaScript", 25, 22, Academy.Programming),
            new Subject(67, "Photoshop", 12, 18, Academy.Design),
            new Subject(88, "Illustrator", 12, 18, Academy.Design),
            new Subject(97, "Networks Basic", 8, 12, Academy.Networks),
            new Subject(98, "Networks Advanced", 16, 10, Academy.Networks)
        };

        static SEDC()
        {
            Students[0].Subjects = new List<Subject>() {Subjects[0], Subjects[2], Subjects[3], Subjects[4]};
            Students[1].Subjects = new List<Subject>() {Subjects[3], Subjects[4], Subjects[5], Subjects[1]};
            Students[2].Subjects = new List<Subject>() {Subjects[5], Subjects[6]};
            Students[3].Subjects = new List<Subject>() {Subjects[3], Subjects[4]};
            Students[4].Subjects = new List<Subject>() {Subjects[1], Subjects[2], Subjects[3], Subjects[5]};
            Students[5].Subjects = new List<Subject>() {Subjects[2]};
        }
    }
}
