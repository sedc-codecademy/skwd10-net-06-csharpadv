namespace TextHelper
{
    /// <summary>
    /// A class for modelling a simple Order entity.
    /// 
    /// Contains a regular "instance" method Print() that shows
    /// order info, and a static method IsOrderValid(Order order)
    /// for sharing common validation logic for Order instances.
    /// </summary>
    internal class Order
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description {get; set; }

        public string Print()
        {
            return $"{TextHelper.CapitalFirstLetter(Title)} - {Description}";
        }

        /// <summary>
        /// Static method that validates an order. Note that accessing properties
        /// in a non-static context (e.g. this.Id) is NOT possible, even though
        /// the method is defined in the same class. The static context is global
        /// for the whole application, and to do mutation over an instance of
        /// Order, we need to supply it through a parameter.
        /// 
        /// If this was a regular method (e.g. Print()), we can access instance
        /// properties/members normally.
        /// </summary>
        public static bool IsOrderValid(Order order)
        {
            // if Id is less or equal than 0, and Title is not assigned (empty string)...
            if(order.Id <= 0 || order.Title == "")
            {
                // ... then the order is invalid, i.e. return false
                return false;
            }

            // otherwise, return true.
            // Conditions for an object's validity can vary in other cases, but if the
            // ID field is a number (int), most database engines won't allow a value
            // less than or equal to 0 for this field.
            return true;
        }
    }
}
