// See https://aka.ms/new-console-template for more information
using Enteties;
using Enteties.Interfaces;


IUser user = new User(4);
Console.WriteLine(user.GetID());


IThingsThatCanWriteANote pen = new Pen();
IThingsThatCanWriteANote computer = new Computer();
IThingsThatCanWriteANote phone = new Phone();

//LoginUser(pen);
//LoginUser(computer);
//LoginUser(phone);

//pen.WriteNote();
//computer.WriteNote();
//phone.WriteNote();

IDeveloper developer = new Developer();
ITester tester = new Tester();
IQAEng qAEng = new QAEng();

developer.Code();
tester.TestCode();
qAEng.TestCode();
qAEng.Code();

void LoginUser(IThingsThatCanWriteANote noteWtiter)
{
    Console.WriteLine("Enter username: ");
    string username = Console.ReadLine();

    Console.WriteLine("Enter password");
    string password = Console.ReadLine();

    noteWtiter.WriteNote();
}

