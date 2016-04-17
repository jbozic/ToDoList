using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Entities
{
    public class User
    {
        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public IList<Todo> Todos { get; private set; }

        public User(string fName, string lName)
        {
            FirstName = fName;
            LastName = lName;
            Todos = new List<Todo>();
        }
    }
}
