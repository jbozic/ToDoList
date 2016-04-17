using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    class Program
    {
        static void Main(string[] args)
        {
            var repo = new InMemoryUserRepository();
            var ui = new UserInterface(repo);

            repo.AddUser(new Entities.User("A", "B"));

            while (true)
            {
                try
                {
                    ui.Draw();

                } catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    break;
                }
                
            }

        }
    }
}
