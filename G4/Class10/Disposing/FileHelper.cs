namespace Disposing
{
    using System;
    using System.IO;

    /// <summary>
    /// Custom helper for writing to files.
    /// </summary>
    static class FileHelper
    {
        /// <summary>
        /// Append to file implementation using explicit <see cref="IDisposable.Dispose"/>
        /// invocation.
        /// </summary>
        /// <param name="path">Path to the file to write to.</param>
        /// <param name="content">Text that should be written to file.</param>
        public static void AppendTextInFile(string path, string content)
        {
            StreamWriter streamWriter = new StreamWriter(path, true);
            if (content == "break") throw new Exception("Something broke unexpectedly");
            streamWriter.WriteLine(content);

            // invoke Dispose() manually; useful when you need
            // more control over reserved unmanaged resources'
            // lifecycle
            streamWriter.Dispose();
        }

        /// <summary>
        /// Append to file implementation using the 'using' keyword.
        /// invocation.
        /// </summary>
        /// <param name="path">Path to the file to write to.</param>
        /// <param name="content">Text that should be written to file.</param>
        public static void AppendTextInFileSafe(string path, string content)
        {
            // the using method implies invoking IDisposable.Dispose method
            // automatically after its code block terminates
            using (StreamWriter streamWriter = new StreamWriter(path, true))
            {
                if (content == "break") throw new Exception("Something broke unexpectedly");
                streamWriter.WriteLine(content);
            }
        }
    }
}
