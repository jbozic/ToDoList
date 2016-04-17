using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Entities;

namespace ToDoList
{
    class InMemoryUserRepository : IUserRepository
    {
        private List<User> users = new List<User>();

        public void AddUser(User user)
        {
            users.Add(user);
        }
        

        public IEnumerable<User> GetUsers()
        {
            return users;
        }

        public void Save()
        {

        }
    }
}
