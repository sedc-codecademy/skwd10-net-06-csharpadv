namespace Humans
{
    /// <summary>
    /// General-purpose interface for modelling humans
    /// </summary>
    internal interface IHuman
    {
        /// <summary>
        /// Gets info for human
        /// </summary>
        string GetInfo();

        /// <summary>
        /// Invokes greeting for human
        /// </summary>
        void Greet(string name);
    }
}
