using System.Collections.Generic;
using WebProject.RandomUsers.Data;

namespace WebProject.RandomUsers
{
    public interface IRandomUserProvider
    {
        IEnumerable<Person> Users { get; }
    }
}
