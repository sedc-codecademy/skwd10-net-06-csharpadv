using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equality
{
    class Person : IEquatable<Person>
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }

        public override bool Equals(object? obj)
        {
            if (obj == null)
            {
                return base.Equals(obj);
            }
            if (obj is Person other)
            {
                return Equals(other);
            }
            else
            {
                return base.Equals(obj);
            }
        }

        public bool Equals(Person? other)
        {
            if (other == null)
            {
                return false;
            }
            if (other.FirstName != this.FirstName)
            {
                return false;
            }
            if (other.LastName != this.LastName)
            {
                return false;
            }
            return true;

        }

        //public override string ToString()
        //{
        //    return this.ToString();
        //}
    }

    struct PersonStruct
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
    }

    record PersonRecord(string FirstName, string LastName);
}
