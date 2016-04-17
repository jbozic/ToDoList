using System;
using System.Collections.Generic;
using System.Linq;
using ToDoList.Entities;

namespace ToDoList
{
    internal class UserInterface
    {
        private IUserRepository userRepository;
        private IEnumerable<User> users;
        private int? selectedUserIndex = null;
       
        public UserInterface(IUserRepository inMemoryUserRepository)
        {
            userRepository = inMemoryUserRepository;
            users = userRepository.GetUsers();
        }

        public void Draw()
        {
            Console.Clear();

            ListUsers(users);

            if(selectedUserIndex.HasValue)
            {
                AddOrUpdateToDo();
            }else
            {
                AddOrSelectUser();
            }
        }

        private void AddOrSelectUser()
        {
            Console.WriteLine("Add (a) or select user (inbox)");
            var key = Console.ReadKey();

            switch(key.Key)
            {
                case ConsoleKey.A:
                    AddUser();
                    break;
                default:
                    var userIndex = int.Parse(key.KeyChar.ToString());
                    selectedUserIndex = userIndex;
                    break;
            }
        }

        private void AddUser()
        {
            Console.WriteLine("First name:");
            var fname = Console.ReadLine();
            Console.WriteLine("Last name:");
            var lname = Console.ReadLine();

            userRepository.AddUser(new User(fname, lname));
        }

        private void AddOrUpdateToDo()
        {
            Console.WriteLine("Add (a) or update todo (index)");
            var users = userRepository.GetUsers().ToList();
            var selectedUser = users[selectedUserIndex.Value];

            var key = Console.ReadKey();

            switch(key.Key)
            {
                case ConsoleKey.A:
                    AddTodo(selectedUser);
                    break;
                case ConsoleKey.Escape:
                    selectedUserIndex = null;
                    break;
                default:
                    var index = int.Parse(key.KeyChar.ToString());
                    selectedUser.Todos[index].Update();
                    break;
            }
        }

        private void AddTodo(User selectedUser)
        {
            Console.WriteLine("Message:");
            var message = Console.ReadLine();
            selectedUser.Todos.Add(new Todo(message));

        }

        private void ListUsers(IEnumerable<User> users)
        {
            var index = 0;
            foreach (var u in users)
            {
                Console.WriteLine(
                    string.Format(
                        "{0} {1} {2}",
                        index,
                        u.FirstName,
                        u.LastName)
                        );
                if(selectedUserIndex.HasValue && selectedUserIndex.Value == index)
                {
                    var todoIndex = 0;
                    foreach(var td in u.Todos)
                    {
                        Console.WriteLine(
                            string.Format(
                                "\t{0} m:{1} s:{2} dc:{3} ds:{4} df:{5}\n",
                                todoIndex,
                                td.Message,
                                td.Status,
                                td.DateCreated,
                                td.DateStarted,
                                td.DateFinished
                            )
                            );
                        todoIndex++;
                    }
                }
            }
        }
    }
}