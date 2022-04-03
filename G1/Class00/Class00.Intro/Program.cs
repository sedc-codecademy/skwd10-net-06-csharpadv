// See https://aka.ms/new-console-template for more information
using Class00.Intro.Entities;
using Class00.Intro.Enums;

Console.WriteLine("Zdravo na site, dobredojdovte na kursot C# Advanced!");
Console.Write("Sega kje povtorime shto se ");
Console.WriteLine("uceshe vo prethodniot kurs.");

Console.WriteLine("=========================================");

#region Input, parsing and operators
Console.WriteLine("Primer za vnes na podatoci i parsiranje");

Console.Write("Vnesete ime: ");
string ime = Console.ReadLine();

Console.Write("Vnesete prezime: ");
string prezime = Console.ReadLine();

Console.Write("Vnesete broj: ");
int broj1 = int.Parse(Console.ReadLine());

Console.Write("Vnesete broj2: ");
int broj2 = int.Parse(Console.ReadLine());

//formatiranje na string
Console.WriteLine("Blagodaram " + ime + " " + prezime + " za vnesenite brevi " + broj1 + " i " + broj2);
Console.WriteLine(String.Format("Blagodaram {0} {1} za vnesenite brevi {2} i {3} ", ime, prezime, broj1, broj2));
Console.WriteLine($"Blagodaram {ime} {prezime} za vnesenite brevi {broj1} i {broj2}");

//operatori
Console.WriteLine($"Zbirot na {broj1} i {broj2} e {broj1 + broj2}");
Console.WriteLine($"Razlikata na {broj1} i {broj2} e {broj1 - broj2}");
Console.WriteLine($"Pomnozeni {broj1} i {broj2} davat {broj1 * broj2}");
Console.WriteLine($"{broj1} pomnozen so 10 i podelen so 2 e {(broj1 * 10) / 2}");
#endregion Input and parsing

#region DateTime
//DateTime currentDateTime = DateTime.Now;

//// Adding or removing days to a DateTime date
//DateTime addedDays = currentDateTime.AddDays(2);
//Console.WriteLine(addedDays);
//DateTime removedDays = currentDateTime.AddDays(-5);
//Console.WriteLine(removedDays);

//// Adding months to a DateTime date
//DateTime addedMonths = currentDateTime.AddMonths(2);
//Console.WriteLine(addedMonths);

//// Adding years to a DateTime date
//DateTime addedYears = currentDateTime.AddYears(2);
//Console.WriteLine(addedYears);

//// Adding hours to a DateTime date
//DateTime addedHours = currentDateTime.AddHours(3);
//Console.WriteLine(addedHours);

//// Get the number of the month from a DateTime
//int month = currentDateTime.Month;
//Console.WriteLine(month);

//// Get the number of the day from a DateTime
//int day = currentDateTime.Day;
//Console.WriteLine(day);

//// Get the number of the year from a DateTime
//int year = currentDateTime.Year;
//Console.WriteLine(year);

#endregion DateTime

Console.WriteLine("=========================================");

#region Conditions
//Console.WriteLine("Primer za If uslov");
//Console.Write("Vnesete broj: ");
//int prvBroj = int.Parse(Console.ReadLine());
//Console.Write("Vnesete ushte eden broj: ");
//int vtorBroj = int.Parse(Console.ReadLine());

//if (prvBroj > vtorBroj)
//{
//    Console.WriteLine(prvBroj + " e pogolem od " + vtorBroj);
//}
//else if (prvBroj < vtorBroj)
//{
//    Console.WriteLine(prvBroj + " e pomal od " + vtorBroj);
//}
//else
//{
//    Console.WriteLine("Broevite se isti");
//}

//Console.WriteLine("=========================================");

//Console.WriteLine("Primer za swith");
//Console.Write("Vnesete nesete ja pozicijata na natprevaruvacot so bukvi: ");
//string pozicija = Console.ReadLine();

//switch (pozicija)
//{
//    case "prv":
//        Console.WriteLine("Cestitam pobedivte na natprevarot!");
//        break;
//    case "vtor":
//        Console.WriteLine("Cestitam osvoivte srebren medal!");
//        break;
//    case "tret":
//        Console.WriteLine("Cestitam osvoivte bronzen medal!");
//        break;
//    case "cetvrti":
//        Console.WriteLine("Mnogu blisku do osvojuvanje na medal, uteshna nagrada!");
//        break;
//    default:
//        Console.WriteLine("Ne vleguvate vo konkurencija za medal");
//        break;
//}
//Console.WriteLine("Pritisnete enter za da prodolzite");
//Console.ReadLine();
#endregion Conditions

Console.WriteLine("=========================================");

#region Loops, Arrays, Method

//Console.WriteLine("Printanje na vekje vnesenite ime i prezime 5 pati");
//for (int i = 0; i < 5; i++)
//{
//    Console.WriteLine(GetFullName(ime, prezime));
//}

////deklaracija i inicijalizacija na listi
//int[] listaBroevi = new int[5] { 12, 13, 441, 17, 2 };
//int pozicijaLista = 1;

//Console.WriteLine("Printanje na listata so koristenje na foreach");
//foreach (int i in listaBroevi)
//{
//    Console.WriteLine($"na pozicija {pozicijaLista} vo listata se naogja {i}");
//    pozicijaLista++;
//}
//pozicijaLista--;

//Console.WriteLine("Printanje na lista pocnuvajki od posledniot element si koristenje na while");
//while (pozicijaLista > 0)
//{
//    Console.WriteLine($"na pozicija {pozicijaLista} vo listata se naogja {listaBroevi[pozicijaLista - 1]}");
//    pozicijaLista--;
//}
#endregion Loops and Arrays

Console.WriteLine("=========================================");

#region Classes, Objects, Enums, Inheritance and Exceptions
//Console.WriteLine("Kreiraj student");
//var student = new Student();

//Console.WriteLine("Vnesi ime: ");
//student.Name = Console.ReadLine();

//Console.WriteLine("Vnesi prezime: ");
//student.Surname = Console.ReadLine();

//student.Gender = GenderEnum.Male.ToString().ToLower();

//try
//{
//    Console.WriteLine("Vnesi vozrast: ");
//    student.Age = int.Parse(Console.ReadLine());
//}
//catch (Exception)
//{
//    Console.WriteLine("Treba da vnesete broj od 1 do 100: ");
//    student.Age = int.Parse(Console.ReadLine());
//}
//finally
//{
//    Console.WriteLine("Vozrasta na studentot e vnesena");
//}

//string procitanaVrednot = string.Empty;
//List<string> predmeti = new List<string>();
//Console.WriteLine("Vnesuvaj predmeti koi gi sledi studentotse dodeka ne vnesete kraj: ");
//while (procitanaVrednot != "kraj")
//{
//    procitanaVrednot = Console.ReadLine();
//    if (procitanaVrednot != "kraj")
//        predmeti.Add(procitanaVrednot);
//}
//student.FollowCourses = predmeti;

//Console.WriteLine($"Studentot {student.Name} {student.Surname} na vozrast od {student.Age} godini pol {student.Gender} gi sledi slednive predmeti:");
//foreach (string predmet in student.FollowCourses)
//{
//    Console.WriteLine(predmet);
//}

////koristenje na linq za filtriranje na kursevi
//Console.WriteLine("Kursevi so ime podolgo od 5 karakteri se slednive");
//foreach (string kurs in student.FollowCourses.Where(x => x.Length > 5))
//{
//    Console.WriteLine(kurs);
//}
#endregion Classes, Objects, Enums and Inheritance

#region Method
static string GetFullName(string firstName, string lastName)
{
    return firstName + " " + lastName;

}
#endregion metod