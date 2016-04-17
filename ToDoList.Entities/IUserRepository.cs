using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Entities
{
    public interface IUserRepository
    {
        void AddUser(User user);
        void Save();
        IEnumerable<User> GetUsers();
    }
}
