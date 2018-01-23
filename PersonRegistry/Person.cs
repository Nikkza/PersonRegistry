
using System;
namespace PersonRegistry
{
    public abstract class Person : IComparable<Person>
    {
        public string _prefix;
        public string Prefix
        {
            get { return _prefix; }
            set { _prefix = value; }
        }

        private string _firstname;
        public string Firstname
        {
            get { return _firstname; }
            set { _firstname = value; }
        }

        private string _lastName;
        public string Lastname
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public Person(string prefix, string firstname, string lastname)
        {
            this._prefix = prefix;
            this._firstname = firstname;
            this._lastName = lastname;
        }

        public virtual string GetPersonInfo()
        {
            return _prefix + "\t" + _firstname.ToLower() + " " + _lastName.ToLower();
        }

        int IComparable<Person>.CompareTo(Person other)
        {
            if (this._lastName == other._lastName)
            {
                return this._firstname.CompareTo(other._firstname);
            }
            return this._lastName.CompareTo(other._lastName);
        }

        public static Person operator +(Person x, Person y)
        {
            if (y.Prefix == "Miss" && x.Prefix == "Mr")
            {
                return new Child("Child", y.Firstname, x.Lastname);
            }
            else if (y.Prefix == "Mr" && x.Prefix == "Miss")
            {
                return new Child("Child", x.Firstname, y.Lastname);
            }

            else if (x.Prefix == "Mr" && y.Prefix == "Mr" || y.Prefix == "Miss" && x.Prefix == "Miss")
            {
                return null;
            }
            else
                return null;
        }
    }
}
