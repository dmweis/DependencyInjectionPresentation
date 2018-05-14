using System.Collections.Generic;
using Insero.DependencyInjection.RandomUsers.Data;

namespace Insero.DependencyInjection.RandomUsers
{
    interface IRandomUserProvider
    {
        IEnumerable<Person> GetUsers(int number);
    }
}
