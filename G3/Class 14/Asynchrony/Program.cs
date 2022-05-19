// See https://aka.ms/new-console-template for more information
using System.Net;

Console.WriteLine("Hello, World!");

WebClient wc = new WebClient();

Console.WriteLine("Started download one");
var dataTask = wc.DownloadDataTaskAsync("https://az764295.vo.msecnd.net/stable/c3511e6c69bb39013c4a4b7b9566ec1ca73fc4d5/VSCodeUserSetup-x64-1.67.2.exe");
//Console.WriteLine("Finished download one");

WebClient wc2 = new WebClient();
Console.WriteLine("Started download two");
var data2Task = wc2.DownloadDataTaskAsync("https://altushost-swe.dl.sourceforge.net/project/graphicsmagick/graphicsmagick/1.3.38/GraphicsMagick-1.3.38-windows.7z");
//Console.WriteLine("Finished download two");

// busy waiting
// var data = dataTask.Result;
// asynchronous waiting
var data = await dataTask; 
Console.WriteLine("Finished download one");
//var data2 = data2Task.Result;
var data2 = await data2Task;
Console.WriteLine("Finished download two");

Console.WriteLine(data.Length);
Console.WriteLine(data2.Length);
