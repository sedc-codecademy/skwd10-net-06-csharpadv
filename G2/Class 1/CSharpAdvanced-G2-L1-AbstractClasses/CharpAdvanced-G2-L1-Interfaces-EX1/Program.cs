
using CharpAdvanced_G2_L1_Interfaces_EX1.Entities;

Teacher teacherOne = new Teacher(1, "Mihajlo", "mikid996", "admin", "C# Advanced");
Teacher teacherTwo = new Teacher(2, "Bojan", "bokid998", "teacher", "C# Advanced");

Student studentOne = new Student(3, "David", "davidd999", "student", new List<int>() { 5, 5, 5 });
Student studentTwo = new Student(4, "David", "davidd9991", "student", new List<int>() { 5, 5, 5 });

teacherOne.PrintUser();
teacherTwo.PrintUser();
studentOne.PrintUser();
studentTwo.PrintUser();