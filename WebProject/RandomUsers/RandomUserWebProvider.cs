using System.Collections.Generic;
using System.Linq;
using RestSharp;
using WebProject.RandomUsers.Data;

namespace WebProject.RandomUsers
{
    class RandomUserWebProvider : IRandomUserProvider
    {
        private IList<Person> _users;

        public IEnumerable<Person> Users => _users.ToList();

        public RandomUserWebProvider()
        {
            var client = new RestClient("https://randomuser.me/");
            var request = new RestRequest($"/api/?results={10}", Method.GET);
            var response = client.Execute<RandomUserResult>(request);
            if (response.IsSuccessful)
            {
                _users = response.Data.Results;
            }
        }

    }
}
