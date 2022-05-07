using CSharpAdvanced_G2_L10_Disposables;

for (int i = 0; i < 100000; i++)
{
    using CustomReader reader = new CustomReader("file.txt");

    string value = reader.GetFileContent();

    Console.WriteLine(value);

    Thread.Sleep(TimeSpan.FromSeconds(0.5));
}
