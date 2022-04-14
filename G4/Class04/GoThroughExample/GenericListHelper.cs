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
                // Console.WriteLine just invokes the ToString method
                // for the object being sent as a parameter. For simple
                // types, it's a string representation of the value,
                // while for complex objects you need to override
                // object.ToString() to make the output meaningful - 
                // otherwise it's just some info regarding the type
                // of object
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
