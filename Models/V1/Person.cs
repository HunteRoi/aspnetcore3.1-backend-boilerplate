using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace Models.V1
{
    public class Person
    {
        private Person() { }

        public Person(string firstname, string lastname, string email, string phone) : this()
        {
            SetFirstName(firstname);
            SetLastName(lastname);
            SetEmail(email);
            SetPhone(phone);
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string Email { get; private set; }

        public string Phone { get; private set; }

        public Person SetFirstName(string firstname) {
            if (string.IsNullOrWhiteSpace(firstname)) throw new ArgumentNullException(nameof(firstname));
            FirstName = firstname;
            return this;
        }

        public Person SetLastName(string lastname) {
            if (string.IsNullOrWhiteSpace(lastname)) throw new ArgumentNullException(nameof(lastname));
            LastName = lastname;
            return this;
        }
        
        public Person SetEmail(string email) {
            if (string.IsNullOrWhiteSpace(email)) throw new ArgumentNullException(nameof(email));
            Email = email;
            return this;
        }
        
        public Person SetPhone(string phone) {
            if (string.IsNullOrWhiteSpace(phone)) throw new ArgumentNullException(nameof(phone));
            Phone = phone;
            return this;
        }

        public Person Update(Person person)
        {
            FirstName = person.FirstName;
            LastName = person.LastName;
            Email = person.Email;
            Phone = person.Phone;

            return this;
        }
    }
}