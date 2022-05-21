// See https://aka.ms/new-console-template for more information

//var url1 = "https://az764295.vo.msecnd.net/stable/c3511e6c69bb39013c4a4b7b9566ec1ca73fc4d5/VSCodeUserSetup-x64-1.67.2.exe";
//var url2 = "https://altushost-swe.dl.sourceforge.net/project/graphicsmagick/graphicsmagick/1.3.38/GraphicsMagick-1.3.38-windows.7z";

//Console.WriteLine("Hello, World!");

//var hc = new HttpClient();

//var data = await hc.GetByteArrayAsync(url1);
//var data2 = await hc.GetByteArrayAsync(url2);

//Console.WriteLine(data.Length);
//Console.WriteLine(data2.Length);


var nums = Enumerable.Range(1, 200);

//foreach (var num in nums)
//{
//    await Task.Delay(1000);
//    Console.WriteLine(num);
//}

Parallel.ForEachAsync(nums, async (num, _) =>
{
    Console.WriteLine($"{num} - {Environment.CurrentManagedThreadId}");
    await Task.Delay(1000);
});


Console.WriteLine("BEFORE PARALLEL FOR-EACH");

await Task.Delay(5000);