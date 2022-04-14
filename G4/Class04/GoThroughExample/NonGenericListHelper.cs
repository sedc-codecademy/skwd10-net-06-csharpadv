namespace GoThroughExample
{
    /// <summary>
    /// Small sample to show how a non-generic class can
    /// exist with generic methods inside. This gives more
    /// flexibility about the generic type parameters in
    /// the methods, especially because of the fact that each
    /// method would have its own set of generic type parameters
    /// and constraints, but might break the "single-responsibility"
    /// principle of the class being able to do "too many things".
    /// </summary>
    internal class NonGenericListHelper
    {
        public void GoThrough<T>(List<T> items)
        {
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }
    }
}
