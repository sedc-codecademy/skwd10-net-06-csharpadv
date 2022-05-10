namespace Disposing
{
    using System;
    using System.IO;

    /// <summary>
    /// Custom writer implementation that implements
    /// <see cref="IDisposable"/>, that acts as a wrapper
    /// over a <see cref="StreamWriter"/>. It allows invoking
    /// the method <see cref="IDisposable.Dispose"/> that in
    /// turn, disposes of the internal <see cref="StreamWriter"/>
    /// instance and removes all locks from files that have been
    /// written to.
    /// </summary>
    class OutWriter : IDisposable
    {
        /// <summary>
        /// The internal <see cref="StreamWriter"/> instance.
        /// It's set to private so it cannot be invoked directly
        /// from the outside, but <see cref="OutWriter"/>'s implementation
        /// uses <see cref="StreamWriter"/>'s methods for its
        /// own method(s) implementation.
        /// </summary>
        private StreamWriter _streamWriter;
        private bool _isDisposed;

        /// <summary>
        /// Private constructor for setting default value for
        /// <see cref="_isDisposed"/> value.
        /// </summary>
        private OutWriter()
        {
            _isDisposed = false;
        }

        /// <summary>
        /// Constructor that instantiates the <see cref="OutWriter"/>
        /// instance. It contains an optional parameter <paramref name="append"/>
        /// that takes <c>true</c> as default value if no value is specified
        /// for it. Note that optional parameters always come last in the signature
        /// (you cannot have a non-optional parameter after an optional parameter).
        /// You can also have multiple optional parameters.
        /// </summary>
        /// <param name="path">Path to the file to write to.</param>
        /// <param name="append">If <c>true</c>, sets the internal <see cref="StreamWriter"/>
        /// to append to files; otherwise, mode is set to write, and this will overwrite
        /// all of the file's contents when attempting to write something new.</param>
        public OutWriter(string path, bool append = true) : this()
        {
            _streamWriter = new StreamWriter(path, append);
        }

        /// <summary>
        /// Writes content to the file. Note that it doesn't immediately close the internal
        /// <see cref="StreamWriter"/> instance - you need to either call <see cref="IDisposable.Dispose"/>
        /// explicitly, or use the 'using' keyword so the file you are writing to is released.
        /// </summary>
        /// <param name="content"></param>
        public void Write(string content)
        {
            if (content == "break") throw new Exception("Something broke unexpectedly");
            _streamWriter.WriteLine(content);
        }

        /// <summary>
        /// The only method in the <see cref="IDisposable"/>. Very useful when implementing
        /// so-called "facade" classes over some low-level C# constructs that use unmanaged
        /// resources. It should be used to dispose all of the other <see cref="IDisposable"/>
        /// fields/properties in the class.
        /// </summary>
        public void Dispose()
        {
            // to prevent disposing an already disposed object,
            // only call dispose while _isDisposed == false; after that,
            // it is set to true, and any subsequent Dispose() invocation
            // will skip re-disposing the already disposed StreamWriter
            if (!_isDisposed)
            {
                _streamWriter.Dispose();
                _isDisposed = true;
            }
        }
    }
}
