Console.WriteLine("=============== Disposable ===============");

#region Preparation data
string AppPath = @"..\..\..\Text";
string FilePath = AppPath + @"\text.txt";

void CreateFolder(string path)
{
	if (!Directory.Exists(path))
	{
		Directory.CreateDirectory(path);
	}
}
void CreateFile(string path)
{
	if (!File.Exists(path))
	{
		File.Create(path).Close();
	}
}
#endregion

#region Manual Disposal
//stream writer dispose method

//stream reader dispose method

//method call code
#endregion

#region Disposal with Using
//stream writer dispose method

//stream reader dispose method

//method call code
#endregion

#region Dispose with our own class
//stream writer dispose method

//stream reader dispose method

//method call code
#endregion