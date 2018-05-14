using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Insero.DependencyInjection.RandomUsers.Data;

namespace Insero.DependencyInjection.RandomUsers
{
    class HardcodedUserProvider : IRandomUserProvider
    {
        public IEnumerable<Person> GetUsers(int number)
        {
            return new[]
            {
                new Person
                {
                    Name = new Name {First = "David", Last = "Weis"},
                    Nat = "SK",
                    Email = "dmw@insero.com"
                },
                new Person
                {
                    Name = new Name{First = "Kris", Last = "Carta"},
                    Nat = "US",
                    Email = "kjc@insero.com"
                },
                new Person
                {
                    Name = new Name{First = "John", Last = "Doe"},
                    Nat = "BR",
                    Email = "someone@someplace.br"
                },
                new Person
                {
                    Name = new Name{First = "Rick", Last = "Sanchez"},
                    Nat = "Yes",
                    Email = "someone@someplace.br"
                },
                new Person
                {
                    Name = new Name{First = "Foo", Last = "Bar"},
                    Nat = "DK",
                    Email = "someone@someplace.br"
                }
            }.Take(number);
        }
    }
}
