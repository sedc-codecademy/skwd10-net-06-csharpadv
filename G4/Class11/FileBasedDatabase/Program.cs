using System;

namespace FileBasedDatabase
{
    using System.Collections.Generic;
    using Models;

    class Program
    {
        static void Main(string[] args)
        {
            Student bob = new Student
            {
                Id = 1,
                FirstName = "Bob",
                LastName = "Bobsky",
                Age = 30,
                IsPartTime = true
            };

            Student jane = new Student
            {
                Id = 2,
                FirstName = "Jane",
                LastName = "Doe",
                Age = 25,
                IsPartTime = false
            };

            IGenericRepository<Student> repository = new FileSystemGenericRepository<Student>();

            // insert two students
            repository.Insert(bob);
            repository.Insert(jane);

            // get all studens (number will be 2x times you have run the application without deleting
            // the file)
            List<Student> currentlySavedStudents = repository.GetAll();

            // print students
            foreach (var student in currentlySavedStudents)
            {
                Console.WriteLine(
                    $"deserialized bob info: Id: {student.Id} FirstName: {student.FirstName}; LastName: {student.LastName}; Age: {student.Age}; IsPartTime: {student.IsPartTime}");
            }
        }
    }
}
