namespace GenericDatabase
{
    /// <summary>
    /// In case you need to go specific for some type,
    /// you can always create new class that inherits
    /// GenericDb<[class_name]> to omit specifying the 
    /// generic type parameter while at the same time, 
    /// define specific members for the database/repository
    /// of that particular entity.
    /// </summary>
    internal class ChildGenericDb : GenericDb<Order>
    {
    }
}
