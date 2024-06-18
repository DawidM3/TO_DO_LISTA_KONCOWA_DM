using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.DataModel;

namespace ToDoList.Services
{
    public class ToDoListService
    {
        public IEnumerable<ToDoItem> GetItems() => new[]
        {
            new ToDoItem { Description = "Kolokwium Programowanie" },
            new ToDoItem { Description = "Zapłać za internet" },
            new ToDoItem { Description = "kup jabłka" },
        };
    }
}
