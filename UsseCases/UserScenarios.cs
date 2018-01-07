using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MsSqlStorage;
using Domain;

namespace UseCases
{
    public class UserScenarios
    {
        UserRepository _userRepository = new UserRepository();

        public List<User>GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public void CreateUser(User user)
        {
             _userRepository.CreateUser(user);
        }

        public void DeleteUser(int Id)
        {
           //TODO: Call User repository method when done.
        }

    }
}
