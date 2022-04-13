namespace GoThroughExample
{
    /// <summary>
    /// Generic list implementation. Note that the generic type parameter
    /// has no constraints, so we won't get any context of the type being
    /// printed (i.e. they are treated like object instances). For classes
    /// the output will boil down to the specific object.ToString() implementation
    /// of the class.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class GenericListHelper<T>
    {
        public void GoThrough(List<T> items)
        {
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }

        public void GetInfo(List<T> items)
        {
            // could be var as well
            T first = items[0];

            Console.WriteLine($"This list has {items.Count} members and is of type {items.GetType().Name}! The first element is {first.ToString()}!");
        }
    }
}
