namespace FileSystem
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            #region commented-out code

            //string currentDirectory = Directory.GetCurrentDirectory();
            //Console.WriteLine(currentDirectory);

            //string relativeAppPath = @"..\..\..\";
            //string absoluteAppPath = @"C:\Users\AU000MC5\source\repos\skwd10-net-06-csharpadv\G4\Class09\FileSystem\FileSystem\";

            //bool relativePathFolderExists = Directory.Exists(relativeAppPath + "nonexistingfolder");

            //Console.WriteLine($"relativePathFolderExists: {relativePathFolderExists}");

            //bool absolutePathFolderExists = Directory.Exists(absoluteAppPath + "nonexistingfolder");

            //Console.WriteLine($"absolutePathFolderExists: {absolutePathFolderExists}");

            //string newFolderRelativePath = relativeAppPath + "newFolderRelativePath";

            //if (!Directory.Exists(newFolderRelativePath))
            //{
            //    Directory.CreateDirectory(newFolderRelativePath);
            //}

            //string newFolderAbsolutePath = absoluteAppPath + "newFolderAbsolutePath";

            //if (!Directory.Exists(newFolderAbsolutePath))
            //{
            //    Directory.CreateDirectory(newFolderAbsolutePath);
            //}

            //if (Directory.Exists(newFolderRelativePath))
            //{
            //    Directory.Delete(newFolderRelativePath, true);
            //}

            //string appPath = @"..\..\..\";
            //string filesPath = appPath + @"myFolder\";

            //string filePath = filesPath + @"test.txt";

            //bool testTxtFileExists = File.Exists(filePath);

            //Console.WriteLine($"testTxtFileExists: {testTxtFileExists}");

            //if (!Directory.Exists(filesPath))
            //{
            //    Directory.CreateDirectory(filesPath);
            //}

            //if (!File.Exists(filePath))
            //{
            //    File.Create(filePath).Close();
            //    File.WriteAllText(filePath, "Hello SEDC! We are writing in a file");
            //}

            //string readTextFromFile = File.ReadAllText(filePath);

            //Console.WriteLine($"readTextFromFile: {readTextFromFile}");

            //if (File.Exists(filePath))
            //{
            //    File.Delete(filePath);
            //}

            //string appPath = @"..\..\..\";
            //string folderPath = appPath + @"myFolder\";
            //string filePath = folderPath + @"test";

            //if (!Directory.Exists(folderPath))
            //{
            //    Directory.CreateDirectory(folderPath);
            //    Console.WriteLine("New directory was created!");
            //}

            //using (StreamWriter sw = new StreamWriter(filePath))
            //{
            //    sw.WriteLine("Hello SEDC!");
            //    sw.WriteLine("We are writing text from StreamWriter!");
            //    Console.WriteLine("Writing is complete!");
            //}

            //using (StreamWriter sw = new StreamWriter(filePath, true))
            //{
            //    sw.WriteLine("Hello AGAIN!");
            //    sw.WriteLine("This is written on top of previous one");
            //    Console.WriteLine("Writing again");
            //}

            //using (StreamReader sr = new StreamReader(filePath))
            //{
            //    string firstLine = sr.ReadLine();
            //    string secondLine = sr.ReadLine();
            //    string restContent = sr.ReadToEnd();

            //    Console.WriteLine($"First line: {firstLine}");
            //    Console.WriteLine($"Second line: {secondLine}");
            //    Console.WriteLine($"Rest of content: {restContent}");
            //}

            //using (StreamReader sr = new StreamReader(filePath))
            //{
            //    string allContent = sr.ReadToEnd();

            //    Console.WriteLine($"All content: {allContent}");
            //}

            //using (StreamReader sr = new StreamReader(filePath))
            //{
            //    for (int i = 0; i < 2; i++)
            //    {
            //        sr.ReadLine();
            //    }

            //    string thirdLine = sr.ReadLine();

            //    Console.WriteLine($"Third line: {thirdLine}");
            //}
            //string[] fileContentLines = File.ReadAllLines(filePath);
            //string thirdLine = fileContentLines[2];

            //Console.WriteLine($"Third line: {thirdLine}");

            #endregion
            /*****************************
             * File System
             *****************************
             * - The file system is the permanence medium of your computer. It's a hierarchical structure with multiple branching nodes
             *      starting with a single root node - the drive, usually named by a single letter (e.g. C:).
             * - Each node after the root can be either a file or a folder; files are the so-called edge nodes (or leafs) and the hierarchy
             *      does not branch further after them. Folders can contain other folders and files so they can produce additional branching.
             *      Folders are just a logical construct that groups other files/folders and does not contain data in itself (other than the
             *      name of the folder) - reading and writing (text) data only makes sense over files.
             * - Each file and folder has an associated path for them - it's the address unique of the file or folder that describes the navigation
             *      steps through the hierarchy to get to the desired file or folder. There are two types of paths - absolute and relative.
             */

            /****************
             * Absolute Paths
             ****************
             * - Absolute paths always start from the root node (the drive letter itself) and this paths navigate down the hierarchy to get to
             *      the lower levels to the desired file/folder. Having a constant starting point for navigating through the hierarchy make the
             *      absolute paths constant and unique for each file or folder in the file system
             */

            // example of absolute path that has 6 levels of folder hierarchy from root (5 after SEDC folder)
            string absolutePath = @"C:\SEDC\CSharpAdv\FileSystem\bin\Debug\net5.0\file.txt";
            // example of absolute path that has 1 level of folder hierarchy from root (0 after SEDC folder)
            string absoluteSedcPath = @"C:\SEDC\file.txt";

            /****************
             * Relative Paths
             ****************
             * - Relative paths are paths that don't start from the root node - they start from the node in the current context and change depending
             *      on what is our starting point. For example, our current context 
             */
            // example of relative path - assumption is that we are in the C:\SEDC\CSharpAdv\FileSystem\FileSystem\bin\Debug\net5.0\ folder
            string relativePath = "file.txt";
            // example of relative path to reach the C:\SEDC\file.txt file
            string relativeSedcPath = "../../../../../file.txt";


            /**************************
             * Working With Directories
             **************************
             * .NET has a built-in static class for working with directories named Directory
             * that resides in the System.IO namespace. If you include this namespace into your
             * application (using System.IO), you are ready to invoke its built-in methods
             */

            /* IMPORTANT: CHANGE THIS TO YOUR SETUP SO ABSOLUTE PATHS WILL BE VALID */
            var solutionFolderAbsolutePath = @"C:\Users\AU000MC5\source\repos\skwd10-net-06-csharpadv\G4\Class09\";

            if (string.IsNullOrWhiteSpace(solutionFolderAbsolutePath))
            {
                throw new Exception("CHANGE THIS TO YOUR SETUP SO ABSOLUTE PATHS WILL BE VALID");
            }

            // get current directory from context; in .NET applications this is usually the binary executable output folder
            // (in our case e.g. [solution_path]\FileSystem\bin\Debug\net5.0)
            string currentDirectory = Directory.GetCurrentDirectory();
            
            PrintValue(nameof(currentDirectory), currentDirectory);

            // assuming that we are starting from exe folder ([solution_path]\FileSystem\bin\Debug\net5.0),
            // we need to get exactly 3 levels back to get to the project folder (..\ = one level up in the
            // hierarchy)
            string appRelativePath = @"..\..\..\";

            PrintValue(nameof(appRelativePath), appRelativePath);

            // Absolute path to our project folder
            string appAbsolutePath = @$"{solutionFolderAbsolutePath}FileSystem\";

            PrintValue(nameof(appAbsolutePath), appAbsolutePath);

            // Using a variable to store the main app path for future use
            var myFolderPath = appRelativePath + @"myFolder\";

            PrintValue(nameof(myFolderPath), myFolderPath);

            // check if folder exists
            bool myFolderExists = Directory.Exists(myFolderPath);

            PrintValue(nameof(myFolderExists), myFolderExists);

            // check if folder exists through absolute path
            bool myFolderExistsString = Directory.Exists(@$"{solutionFolderAbsolutePath}FileSystem\myFolder");

            PrintValue(nameof(myFolderExistsString), myFolderExistsString);

            // practical use of Directory.Exists
            string newFolder = appRelativePath + @"newFolder\";
            // We first check if it exists. If it does, we don't want to call the CreateDirectory method
            if (!Directory.Exists(newFolder))
            {
                Print($"Folder {newFolder} does not exist. Creating folder...");

                // We create the new folder
                Directory.CreateDirectory(newFolder);

                Print($"Folder {newFolder} created");
            }

            // We check if the folder exists. If it does, we don't want to call the Delete method
            if (Directory.Exists(newFolder))
            {
                Print($"Folder {newFolder} does exists. Deleting folder...");

                // We delete the new folder
                Directory.Delete(newFolder);
            
                Print($"Folder {newFolder} deleted");
            }

            /********************
             * Working With Files
             ********************
             * Similarly to the Directory class, there's a static class named
             * File that has methods for file creating, writing, checking if
             * a file exist, deleting etc
             */
            string filesPath = appRelativePath + @"myFolder\";

            PrintValue(nameof(filesPath), filesPath);

            string testTxtPath = filesPath + @"test.txt";

            PrintValue(nameof(testTxtPath), testTxtPath);

            bool testTxtExists = File.Exists(testTxtPath);

            PrintValue(nameof(testTxtExists), testTxtExists);

            // creating container where we will use File methods
            if (!Directory.Exists(filesPath))
            {
                Print($"Folder {filesPath} does not exist. Creating folder...");

                Directory.CreateDirectory(filesPath);
                
                Print($"Folder {filesPath} created");
            }

            // practical usage of File.Exists
            // we don't want to create a file if it already exists
            if (!File.Exists(testTxtPath))
            {
                Print($"File {testTxtPath} does not exist. Creating file...");

                // File.Create returns a FileStream object and is
                // one of the methods in the File class that leaves
                // the file locked until we explicitly call File.Close()
                // or File.Dispose() to unlock the file
                File.Create(testTxtPath).Close();

                Print($"File {testTxtPath} created");
            }

            // we don't want to delete the file if it doesn't exist
            // because it will throw an error (cannot delete a non-existing file)
            // NOTE: if you comment out this part, the below example for writing
            // to file won't be executed because the file will be deleted, and
            // the File.Exists condition in the if statement will be false, therefore
            // writing to the file will be skipped
            //if (File.Exists(testTxtPath))
            //{
            //    Print($"File {testTxtPath} exists. Deleting file...");
                
            //    // File.Delete expects the file to be unlocked for usage
            //    // before invocation; if we don't close the returned stream
            //    // from File.Create() above, this will fail. File.Delete
            //    // returns nothing (void), so no stream returned to be closed
            //    File.Delete(testTxtPath);

            //    Print($"File {testTxtPath} deleted");
            //}

            // writing to file
            // we want to write to the file only if it exists
            // this will not happen if we uncomment the File.Delete block
            if (File.Exists(testTxtPath))
            {
                Print($"File {testTxtPath} exists. Writing to file...");

                // File.WriteAllText writes to a file, overwriting all the existing contents
                // in it. It automatically opens and closes the file stream, so the file is
                // ready for accessing after text has been written
                File.WriteAllText(testTxtPath, "Hello SEDC! We are writing in a file");

                Print($"Text has been written to file {testTxtPath}");

                // File.AppendAllText, as opposed to File.WriteAllText, preserves the previous
                // content in the file, and adds any string that we put in the contents parameter
                // at the end of the file. Similarly, it manages file stream closing on its own
                // NOTE: AppendAllText won't add a new line before appending, so content will
                // be concatenated with previous
                
                // uncomment this if you want a new line between old and new content
                // (\n = newline)
                //File.AppendAllText(testTxtPath, "\n");
                
                File.AppendAllText(testTxtPath, "Hello again! We are appending to a file");

                Print($"Text has been appended to file {testTxtPath}");
            }

            // reading from file
            // we don't want to read from the file in case it does not exist, because this
            // would throw an error
            if (File.Exists(testTxtPath))
            {
                Print($"File {testTxtPath} exists. Reading from file...");

                // File.ReadAllText reads all lines in the file and returns them as a
                // single string. Compare this to File.ReadAllLines() that returns all
                // separate lines in a string array
                string content = File.ReadAllText(testTxtPath);

                PrintValue($"{testTxtPath} content", content);
            }


            /********************************************
             * Working With StreamWriter and StreamReader
             ********************************************
             * StreamWriter and StreamReader are both low-level alternatives to using
             * the static File class. The static File class uses StreamWriter and StreamReader
             * to expose methods for writing and reading to file, and contains convenience methods
             * for when we don't need the added control that StreamWriter and StreamReader provide
             */

            // Writing with StreamWriter
            // StreamWriter treats files that it works with as unmanaged resources. Therefore,
            // similarly to File.Create, we need to close the writer once we are done with writing
            // of the file so the file is again available for access. StreamWriter implements the
            // IDisposable interface that contains a method called Dispose that frees up the
            // unmanaged memory the writer works with. Implementing IDisposable on a class
            // allows usage of the keyword using that, when used, will automatically invoke the
            // Dispose method at the end of the code block.
            // StreamWriter has a Close() method that is similar to the one in the File.Create().Close()
            // example, but internally it calls the IDisposable.Dispose method. In practical sense,
            // it doesn't make much difference which method you would call (Close or Dispose), but
            // when in doubt, just use Close()
            using (StreamWriter sw = new StreamWriter(testTxtPath))
            {
                Print($"Writing with {nameof(StreamWriter)}...!");
                
                // WriteLine puts the provided string in a temporary memory (aka buffer)
                // that gets written (aka flushed) to the file once StreamWriter.Flush
                // method is invoked. StreamWriter.Flush is automatically invoked if 
                // IDisposable.Dispose method is invoked explicitly, or you are using the
                // using keyword - as mentioned, Dispose/Close will be called at the end of the
                // code block
                sw.WriteLine("Hello SEDC!");

                // invoke sw.Flush if you don't want to wait with writing to the file until
                // IDisposable.Dispose is invoked after the using code block is finished
                // sw.Flush();


                sw.WriteLine("We are writing text from StreamWriter!");
                
                Print($"Writing with {nameof(StreamWriter)} is complete!");
            }

            // Writing without rewriting the document with StreamWriter
            // StreamWriter has another constructor that takes a bool value
            // after the file path that dictates whether the written content
            // would overwrite the existing content (false), or it would append
            // the content at the end of the file (true)
            using (StreamWriter sw = new StreamWriter(testTxtPath, true))
            {
                Print($"Appending with {nameof(StreamWriter)}...");
                
                sw.WriteLine("Hello AGAIN!");
                sw.WriteLine("This is written on top of the previous one!");
                
                Print($"Appending with {nameof(StreamWriter)} is complete!");
            }

            // alternative of previous two blocks that do not use the using keyword
            //StreamWriter swWithoutUsing = new StreamWriter(testTxtPath);
            //Print($"Writing with {nameof(StreamWriter)}...!");
            //swWithoutUsing.WriteLine("Hello SEDC!");
            //swWithoutUsing.WriteLine("We are writing text from StreamWriter!");
            //Print($"Writing with {nameof(StreamWriter)} is complete!");
            //swWithoutUsing.Close();

            //swWithoutUsing = new StreamWriter(testTxtPath, true);
            //Print($"Appending with {nameof(StreamWriter)}...");
            //swWithoutUsing.WriteLine("Hello AGAIN!");
            //swWithoutUsing.WriteLine("This is written on top of the previous one!");
            //Print($"Appending with {nameof(StreamWriter)} is complete!");
            //swWithoutUsing.Close();

            // Reading with StreamReader
            // Similarly to StreamWriter, StreamReader treats files that it works with as
            // unmanaged resources. Therefore, all the existing details about releasing
            // unmanaged resources and unlocking the file stand here as well. When reading
            // content from files with StreamReader, the way the reader navigates the file
            // when reading it is moving from one line to the other when invoking the
            // StreamReader.ReadLine method. With each invocation of StreamReader.ReadLine,
            // the pointer for the current line that is about to be read moves by one
            // position. StreamReader.ReadToEnd reads the rest of the file content relative
            // to the current line position - i.e. if you haven't invoked StreamReader.ReadLine,
            // it will read the whole file at once, otherwise it will start from the current
            // line position and read the rest of the content
            using (StreamReader sr = new StreamReader(testTxtPath))
            {
                // this moves line position [0] -> [1] (zero-based index of second line)
                // after reading
                string firstLine = sr.ReadLine();
                // this moves line position [1] -> [2] (zero-based index of third line)
                // after reading
                string secondLine = sr.ReadLine();
                // read the rest of the file
                string restContent = sr.ReadToEnd();
                PrintValue("First Line", firstLine);
                PrintValue("Second Line", secondLine);
                PrintValue("Rest of content", restContent);
            }

            /*********************
             * Additional examples
             *********************/
            // read all content with StreamReader
            using (StreamReader sr = new StreamReader(testTxtPath))
            {
                string allContent = sr.ReadToEnd();

                PrintValue("All content", allContent);
            }

            // read exactly the third line with StreamReader
            using (StreamReader sr = new StreamReader(testTxtPath))
            {
                for (int i = 0; i < 2; i++)
                {
                    sr.ReadLine();
                }

                string thirdLine = sr.ReadLine();

                PrintValue("Third line", thirdLine);
            }

            // read exactly the third line with File.ReadAllLines shortcut
            string[] fileContentLines = File.ReadAllLines(testTxtPath);
            string thirdLineShortcut = fileContentLines[2];

            PrintValue("Third line (via File.ReadAllLines shortcut)", thirdLineShortcut);
        }

        private static void PrintValue(string label, object value, bool newLine = true)
        {
            string output = $"{label}: {value}";

            Print(output, newLine);
        }

        private static void Print(string text, bool newLine = true)
        {
            Console.WriteLine(text);

            if (newLine)
            {
                Console.WriteLine();
            }
        }
    }
}
