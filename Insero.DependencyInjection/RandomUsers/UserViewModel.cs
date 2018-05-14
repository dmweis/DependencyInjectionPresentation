using GalaSoft.MvvmLight;
using Insero.DependencyInjection.RandomUsers.Data;

namespace Insero.DependencyInjection.RandomUsers
{
    public class UserViewModel
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string Nationality { get; }
        public string Email { get; }

        public UserViewModel(Person person)
        {
            FirstName = person.Name.First;
            LastName = person.Name.Last;
            Nationality = person.Nat;
            Email = person.Email;
        }

    }
}
