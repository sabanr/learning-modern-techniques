using System;

namespace modern_tech
{
    public class Person {

        public string FirstName { get; }

        public string LastName { get; }

        public Person(string firstName, string lastName) {
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName), "Cannot set name to null");
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName), "Cannot set name to null");
        }

        // OLD WAY

        //public string HyphenateForPartner(Person partner) {
        //    if (partner != null) {
        //        return $"{partner.LastName} - {LastName}";
        //    }
        //    throw new ArgumentNullException(nameof(partner), "partner should not be null");
        //}

        // NEW WAY (use discard) more compact than checking for null with an if

        public string HyphenateForPartner(Person partner) {
            _ = partner ?? throw new ArgumentNullException(nameof(partner), "partner should not be null");
            return $"{partner.LastName} - {LastName}";
        }
    }
}
