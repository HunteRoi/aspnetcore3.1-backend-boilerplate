using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.V1
{
    public class Person
    {
        private Person() { }

        public Person(string firstname, string lastname, string email, string phone) : this()
        {
            FirstName = firstname;
            LastName = lastname;
            Email = email;
            Phone = phone;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; private set; }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string Email { get; private set; }

        public string Phone { get; private set; }

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