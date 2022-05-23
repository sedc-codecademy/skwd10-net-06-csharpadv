namespace GoodPractices
{
    using System;

    // class names should be in PascalCase
    // use properties for modelling class state, especially
    // if that state should be publicly accessible
    // don't use fields instead
    class ExampleClass
    {
        // private field names should be in underscore camelCase
        // use (private) fields for state exclusively accessible for the
        // declaring class and hidden for others
        private string _propertyOneBackingField;

        // property names should be in PascalCase
        public string PropertyOne
        {
            get
            {
                return _propertyOneBackingField;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new PropertyOneEmptyException();

                _propertyOneBackingField = value;
            }
        }

        public int PropertyTwo { get; set; }

        // boolean property names should be phrased so they
        // can be answered by a yes/no question
        public bool IsPropertyTwoZero
        {
            get
            {
                return PropertyTwo == 0;
            }
        }

        // constructors are methods, so constructor names are
        // also in PascalCase
        // method parameters should be in camelCase
        public ExampleClass(string propertyOne, int propertyTwo)
        {
            PropertyOne = propertyOne;
            PropertyTwo = propertyTwo;
        }

        // methods names should be in PascalCase
        public string GetProperties()
        {
            return $"{PropertyOne} {PropertyTwo}";
        }
    }

    // custom exceptions should have "Exception" suffix
    public class PropertyOneEmptyException : Exception
    {
        public PropertyOneEmptyException() : base("PropertyOne cannot be empty")
        {
            
        }
    }
}
