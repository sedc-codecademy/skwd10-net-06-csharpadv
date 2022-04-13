namespace GoThroughExample
{
    /// <summary>
    /// A way to avoid specifying the generic parameter
    /// of the <see cref="GenericListHelper{T}"/> base class.
    /// </summary>
    internal class IntListHelper : GenericListHelper<int>
    {
        /// <summary>
        /// Int-specific method not related to <see cref="GenericListHelper{T}"/>.
        /// </summary>
        /// <param name="ints">List of ints.</param>
        /// <returns>The sum of the provided ints.</returns>
        public int Sum(List<int> ints) { return ints.Sum(); }
    }
}
