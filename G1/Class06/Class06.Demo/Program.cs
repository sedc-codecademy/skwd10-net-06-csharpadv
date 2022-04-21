
using Class06.DataAccess;
using Classo6.Domain.Entities;
using Classo6.Domain.enums;

#region Where
//Console.WriteLine("==== SLQ LIKE ========");
////Filters all records by where condition and returns IEnumerable of the object
////that you are selecting
//IEnumerable<Student> findStudentBob = from x in SEDC.Students
//                                      where x.FirstName == "Bob" && x.LastName == "Show"
//                                      select x;
//foreach (Student student in findStudentBob)
//{
//    Console.WriteLine(student.Info());
//}

//Console.WriteLine("==== LAMBDA EXP ========");
//IEnumerable<Student> findStudentBob2 = SEDC.Students.Where(x => x.FirstName == "Bob" && x.LastName == "Show");
//foreach (Student student in findStudentBob2)
//{
//    Console.WriteLine(student.Info());
//}
#endregion

#region Select
////SELECT returns IEnumerable of strings and if you need to return several properties
////then use string formating to include all properties
//Console.WriteLine("==== SLQ LIKE ========");
//IEnumerable<string> studentsNamesList = from x in SEDC.Students
//                                    select x.FirstName;

//foreach (string name in studentsNamesList)
//{
//    Console.WriteLine(name);
//}

//studentsNamesList = from x in SEDC.Students
//                    select $"{x.FirstName} {x.LastName} - {x.Age}";

//foreach (string name in studentsNamesList)
//{
//    Console.WriteLine(name);
//}

//Console.WriteLine("==== LAMBDA EXP ========");
//IEnumerable<string> studentsNamesList2 = SEDC.Students.Select(x => x.FirstName);
//foreach (string name in studentsNamesList2)
//{
//    Console.WriteLine(name);
//}

//studentsNamesList2 = SEDC.Students.Select(x => $"{x.FirstName} {x.LastName} - {x.Age}");
//foreach (string name in studentsNamesList2)
//{
//    Console.WriteLine(name);
//}
#endregion

#region Complex Queries
////Complex queries ar queries that are contained of several nested queries
//Console.WriteLine("==== SLQ LIKE ========");
//List<Student> findStudent1 = (from x in SEDC.Students
//                                       where x.IsPartTime == true
//                                       where ( from y in x.Subjects
//                                               where y.Type == Academy.Programming
//                                               select y).ToList().Count > 0
//                                       select x).ToList();
//findStudent1.PrintEntities();

//Console.WriteLine("==== LAMBDA EXP ========");
//List<Student> findStudent2 = SEDC.Students.Where(x => x.IsPartTime)
//                             .Where(x => x.Subjects
//                                    .Where(y => y.Type == Academy.Programming)
//                                    .ToList().Count > 0).ToList();
//findStudent2.PrintEntities();

#endregion

#region First, Single, Last / OrDefailt
////First
//Console.WriteLine("========== First ===========================");
//List<string> strings = new List<string>();
//strings.FirstOrDefault();

//Student student1 = SEDC.Students.First();
//Console.WriteLine(student1.Info());
//Student student2 = SEDC.Students.FirstOrDefault();
//Console.WriteLine(student2.Info());
//Student student3 = SEDC.Students.First(x => x.FirstName == "Anne");
//Console.WriteLine(student3.Info());
//Student student4 = SEDC.Students.FirstOrDefault(x => x.FirstName == "Anne1");
//if (student4 != null)
//{
//    Console.WriteLine(student4.Info());
//}

////Single
//Console.WriteLine("========== Single ===========================");
//student3 = SEDC.Students.Single(x => x.FirstName == "Anne");
//Console.WriteLine(student3.Info());
//student4 = SEDC.Students.SingleOrDefault(x => x.FirstName == "Anne1");
//if (student4 != null)
//{
//    Console.WriteLine(student4.Info());
//}

////Last
//Console.WriteLine("============ LAST =========================");
//student1 = SEDC.Students.Last();
//Console.WriteLine(student1.Info());
//student2 = SEDC.Students.LastOrDefault();
//Console.WriteLine(student2.Info());
//student3 = SEDC.Students.Last(x => x.FirstName == "Bob");
//Console.WriteLine(student3.Info());
//student4 = SEDC.Students.LastOrDefault(x => x.FirstName == "Anne");
//if (student4 != null)
//{
//    Console.WriteLine(student4.Info());
//}
#endregion

#region SelectMany
//List<List<Subject>> partTimeSubjectsSelect = SEDC.Students
//                                                .Where(x => x.IsPartTime)
//                                                .Select(x => x.Subjects).ToList();
//foreach (var subjectList in partTimeSubjectsSelect)
//{
//    Console.WriteLine("========================================");
//    subjectList.PrintEntities();
//}

//Console.WriteLine("======== SELECT MANY ================================");
//List<Subject> partTimeSubjectsSelect2 = SEDC.Students
//                                                .Where(x => x.IsPartTime)
//                                                .SelectMany(x => x.Subjects).ToList();

//partTimeSubjectsSelect2.PrintEntities();

#endregion

#region Distinct
//Console.WriteLine("======== DISTINCT ================================"); 
//List<Subject> distinctSubjects = partTimeSubjectsSelect2.Distinct().ToList();
//distinctSubjects.PrintEntities();
#endregion

#region Any
//bool isBob = SEDC.Students.Any(x => x.FirstName == "Bob");
//if (isBob)
//{
//    Console.WriteLine("There is Bob!");
//}
//else
//{
//    Console.WriteLine("There is NO Bob!");
//}
#endregion

#region All
//bool areThereShortNames = SEDC.Students.All(x => x.FirstName.Length > 3);
//if (areThereShortNames)
//{
//    Console.WriteLine("No!");
//}
//else
//{
//    Console.WriteLine("Yes!");
//}
#endregion

#region ORDERBY / ORDERBYDESCENDING / THENBY / THENBYDESCENDING
//List<Student> studentsOrdered = SEDC.Students.OrderBy(x => x.FirstName).ThenByDescending(x => x.LastName).ToList();
//studentsOrdered.PrintEntities();
#endregion
