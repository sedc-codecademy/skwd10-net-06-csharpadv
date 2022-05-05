if (args.Length < 2)
{
    Console.WriteLine("Invalid usage");
    return;
}

var filename = args[0];
var extension = args[1];

if (!File.Exists(filename))
{
    Console.WriteLine("Cannot change extension on non-existant file");
    return;
}

try
{
    var newName = $"{Path.GetFileNameWithoutExtension(filename)}.{extension}";
    var oldPath = Path.GetDirectoryName(filename);
    var newPath = Path.Combine(oldPath, newName);

    if (File.Exists(newPath))
    {
        Console.WriteLine("File with the same new extension already exists");
        return;
    }
    File.Copy(filename, newPath);
    Console.WriteLine("Done");
}
catch (IOException iex)
{
    Console.WriteLine(iex.Message);
}
