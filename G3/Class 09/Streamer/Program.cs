
using System.Diagnostics;

var sw = Stopwatch.StartNew();
//var lines1Task = File.ReadAllLinesAsync($@"D:\Source\MPD\ExportData\2020-12-05.xml");
////var lines2Task = File.ReadAllLinesAsync($@"D:\Source\MPD\ExportData\2020-12-01.xml");
//Console.WriteLine(sw.ElapsedMilliseconds);
//var lines1 = await lines1Task;
////Console.WriteLine(sw.ElapsedMilliseconds);
////var lines2 = await lines2Task;
//Console.WriteLine(sw.ElapsedMilliseconds);
//Console.WriteLine(lines1[0]);
////Console.WriteLine(lines2[0]);
//sw.Stop();

//Console.WriteLine(sw.ElapsedMilliseconds);

sw.Restart();
using (var sr = File.OpenText($@"D:\Source\MPD\ExportData\2020-12-03.xml"))
{
    var firstLine = await sr.ReadLineAsync();
    Console.WriteLine(firstLine);
    var secondLine = await sr.ReadLineAsync();
    Console.WriteLine(secondLine);
}
//sr.Close();

var fs = File.Open($@"D:\Source\MPD\ExportData\2020-12-03.xml", FileMode.Open, FileAccess.Read);
fs.Seek(100_000_000, SeekOrigin.Begin);
var b = fs.ReadByte();
Console.WriteLine(b);
fs.Close();

sw.Stop();
Console.WriteLine(sw.ElapsedMilliseconds);


