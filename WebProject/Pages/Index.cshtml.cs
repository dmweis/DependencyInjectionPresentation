using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebProject.RandomUsers;
using WebProject.RandomUsers.Data;

namespace WebProject.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IRandomUserProvider _userProvider;

        public IEnumerable<Person> Users { get; set; }

        public IndexModel(IRandomUserProvider userProvider)
        {
            _userProvider = userProvider;
        }

        public void OnGet()
        {
            Users = _userProvider.Users;
        }
    }
}
