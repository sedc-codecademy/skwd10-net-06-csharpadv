// See https://aka.ms/new-console-template for more information
using CSharpAdvanced_G2_L1_Interfaces.Entities;
using CSharpAdvanced_G2_L1_Interfaces.Interfaces;
using CSharpAdvanced_G2_L1_Interfaces.Services;

//Console.WriteLine("Hello, World!");


//Employee employee = new Employee("Mihajlo", 32);

//employee.DoWork();

//IWork employeeTwo = new Employee("Mihajlo", 32);

//employeeTwo.DoWork();

User user = new Student("Dragan", "C# Advanced");

IUserService userService = new StudentService();

userService.LogIn(user);
userService.PrintInformation(user);

userService = new TeacherService();

userService.LogIn(user);
userService.PrintInformation(user);
