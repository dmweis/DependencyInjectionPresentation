using System.Collections.Generic;
using Insero.DependencyInjection.RandomUsers.Data;
using RestSharp;

namespace Insero.DependencyInjection.RandomUsers
{
    class RandomUserWebProvider : IRandomUserProvider
    {
        public IEnumerable<Person> GetUsers(int number)
        {
            var client = new RestClient("https://randomuser.me/");
            var request = new RestRequest($"/api/?results={number}", Method.GET);
            var response = client.Execute<RandomUserResult>(request);
            if (response.IsSuccessful)
            {
                return response.Data.Results;
            }
            // In case of a failure return empty list because in this case we don't care. 
            // THIS IS NOT CORRECT ERROR HANDLING!!!
            return new List<Person>();
        }
    }
}
