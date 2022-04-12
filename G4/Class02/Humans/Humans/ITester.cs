namespace Humans
{
    /// <summary>
    /// An interface to model testers
    /// </summary>
    internal interface ITester
    {
        /// <summary>
        /// How many bugs has a tester found so far
        /// </summary>
        int NumberOfBugsFound { get; }

        /// <summary>
        /// Instructs tester to test a feature
        /// </summary>
        void TestFeature(string feature);
    }
}
