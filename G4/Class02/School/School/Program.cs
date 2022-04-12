namespace School // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var student1 = new Student();
            student1.Id = "1";
            student1.Name = "Pero";
            student1.UserName = "pero69";
            student1.Password = "123123";
            student1.Grades = new List<int> { 1, 2, 2, 1, 3 };

            var student2 = new Student();
            student2.Id = "2";
            student2.Name = "Stanko";
            student2.UserName = "st4nk0";
            student2.Password = "verystrongpasswordthatcannotbebroken";
            student2.Grades = new List<int> { 5, 5, 4, 5, 5 };

            var teacher1 = new Teacher();
            teacher1.Id = "3";
            teacher1.Name = "Desanka";
            teacher1.UserName = "levanka";
            teacher1.Password = "mnogusumubava";
            teacher1.Subject = "Matematika";

            var teacher2 = new Teacher();
            teacher2.Id = "4";
            teacher2.Name = "Petra";
            teacher2.UserName = "strongGirl99";
            teacher2.Password = "asdfgh";
            teacher2.Subject = "Biologija";

            student1.PrintUser();
            student2.PrintUser();

            teacher1.PrintUser();
            teacher2.PrintUser();
        }
    }
}