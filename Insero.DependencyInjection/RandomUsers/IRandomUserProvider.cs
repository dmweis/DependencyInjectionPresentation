using System.Collections.Generic;
using Insero.DependencyInjection.RandomUsers.Data;

namespace Insero.DependencyInjection.RandomUsers
{
    public interface IRandomUserProvider
    {
        IEnumerable<Person> GetUsers(int number);
    }
}
