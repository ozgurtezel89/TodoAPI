using System;
using System.Collections.Generic;
using TodoApi.Models;

namespace TodoApi.Models
{
    public interface IDailyTasksRepository
    {
        IEnumerable<TodoItem> GetMyDailyTasksPlease();
    }

    public class DailyTasksRepositoryMock : IDailyTasksRepository
    {
        public IEnumerable<TodoItem> GetMyDailyTasksPlease()
        {
            List<TodoItem> DailyTask = new List<TodoItem>{
                new TodoItem(1, null, "Polish your shoes with a polisher.", "Shoe Care"),
                new TodoItem(2, null, "Check your car tires, oil and water.", "Car safety check"),
                new TodoItem(3, null, "Lock your front door and set the alarm.", "House safety")
            };

            return  DailyTask;
        }
    }
}