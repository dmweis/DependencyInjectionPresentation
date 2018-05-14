using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Insero.DependencyInjection.RandomUsers.Data;

namespace Insero.DependencyInjection.RandomUsers
{
    public class UserDisplayViewModel : ViewModelBase
    {
        private readonly IRandomUserProvider _userProvider;

        public ObservableCollection<UserViewModel> Users { get; } = new ObservableCollection<UserViewModel>();
        public RelayCommand ReloadUsersCommand { get; }

        public UserDisplayViewModel(IRandomUserProvider userProvider)
        {
            _userProvider = userProvider;
            ReloadUsersCommand = new RelayCommand(ReloadUsers);
            ReloadUsers();
        }

        private void ReloadUsers()
        {
            var users = _userProvider.GetUsers(5);
            Users.Clear();
            foreach (var person in users)
            {
                Users.Add(new UserViewModel(person));
            }
        }
    }
}
