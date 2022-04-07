// See https://aka.ms/new-console-template for more information


using BoxingUnboxing.Entities;

// Boxing an integer in to a more universal type, object
// All value types derive from object
// That is why we can box any value type in to object
int number = 5000; //int
Console.WriteLine(number.GetType());
object objectNum = number; //boxing
Console.WriteLine(objectNum);
Console.WriteLine(objectNum.GetType());

// Note: Casting changes the type, but does not change the object value
// It is different than converting since converting tries to change the value to match another type
// Casting just changes the type if the value is eligable to exist in that type as well
// A good example is unboxing since object and int can both hold the number 8000
// There is no need to change the number since it can exist in both of the types
object secondNumber = 8000;
//object secondNumber = "8000"; //Exception
int secondNum = (int)secondNumber; //casting
Console.WriteLine(secondNumber);
Console.WriteLine(secondNum);
Console.WriteLine(secondNumber.GetType());
Console.WriteLine(secondNum.GetType());

//IMPOSSIBLE - the value is of type Employee, which is not a developer
Employee employee = new Employee { Company = "IT-Labs", FullName = "Petre Arsovski" };
//Developer developer = (Developer)employee;
//developer.GetInfo();

//The value is of type Developer, so it can be held by a variable of type Employee, Employee is upper 
//in the hierarchy. Can be casted to developer.
Employee devEmp = new Developer { Company = "IT-Labs", FullName = "Petre Arsovski", Project = "Emergenetics" };
Console.WriteLine(devEmp.GetType());
Console.WriteLine(devEmp.GetInfo());
//Console.WriteLine(devEmp.Code());
Developer d2 = (Developer)devEmp;
d2.Code();

object obj = d2;
((Developer)obj).Code();


//Employee employee1 = employee;
//((Developer)employee1).Code(); //Exception
Employee employee1 = d2;
((Developer)employee1).Code();

List<Employee> employees = new List<Employee>();
employees.Add(new Developer { Company = "IT-Labs", FullName = "Petre Arsovski", Project = "Emergenetics" });
employees.Add(new Tester { Company = "IT-Labs", FullName = "Petre Arsovski", NumOfBugs = 23 });
foreach(Employee emp in employees)
{
    Console.WriteLine(emp.GetType());
}
((Developer)employees.First()).Code();
//((Developer)employees.Last()).Code(); //Exception
((Tester)employees.Last()).Test();

Console.ReadLine();
