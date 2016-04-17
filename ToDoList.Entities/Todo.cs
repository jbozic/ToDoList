using System;

namespace ToDoList.Entities
{
    public class Todo
    {
        public string Message { get; private set; }
        public Status Status { get; private set; }
        public DateTime DateCreated { get; private set; }
        public DateTime? DateStarted { get; private set; }
        public DateTime? DateFinished { get; private set; }


        public Todo(string message)
        {
            Message = message;
            Status = Status.Created;
            DateCreated = DateTime.UtcNow;
        }

        public void Update()
        {
            switch (Status)
            {
                case Status.Created:
                    Status = Status.Started;
                    DateStarted = DateTime.UtcNow;
                    break;

                case Status.Started:
                    Status = Status.Finished;
                    DateFinished = DateTime.UtcNow;
                    break;

                case Status.Finished:
                    break;
                default:
                    break;
            }
        }
    }
}