using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Insero.DependencyInjection.RandomUsers.Data;
using Moq;

namespace Insero.DependencyInjection.RandomUsers.Tests
{
    [TestClass()]
    public class UserDisplayViewModelTests
    {
        private IEnumerable<Person> _users;

        [TestInitialize]
        public void CreateUsers()
        {
            _users = new[]
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
            };
        }

        [TestMethod()]
        public void ViewModelLoadsUsersOnConstruction()
        {
            // Arrange
            var userProviderMock = new Mock<IRandomUserProvider>();
            userProviderMock
                .Setup(provider => provider.GetUsers(It.IsAny<int>()))
                .Returns((int number) => _users.Take(number));
            // Act
            var vm = new UserDisplayViewModel(userProviderMock.Object);
            // Assert
            vm.Users.Should().BeEquivalentTo(_users.Select(user => new UserViewModel(user)));
        }

        [TestMethod()]
        public void ViewModelReloadsUsersOnReloadUserCommand()
        {
            // Arrange
            var userProviderMock = new Mock<IRandomUserProvider>();
            userProviderMock
                .Setup(provider => provider.GetUsers(It.IsAny<int>()))
                .Returns((int number) => _users.Take(number));
            // Act
            var vm = new UserDisplayViewModel(userProviderMock.Object); // 1 on creation
            // 4 times for each command call
            vm.ReloadUsersCommand.Execute(null);
            vm.ReloadUsersCommand.Execute(null);
            vm.ReloadUsersCommand.Execute(null);
            vm.ReloadUsersCommand.Execute(null);
            // Assert
            userProviderMock.Verify(mock => mock.GetUsers(It.IsAny<int>()), Times.Exactly(5));
        }
    }
}