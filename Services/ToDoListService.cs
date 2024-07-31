using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using ToDoList.DataModel;

namespace ToDoList.Services
{
    public class ToDoListService
    {
        private const string FilePath = "todoitems.json";

        public IEnumerable<ToDoItem> GetItems()
        {
            if (File.Exists(FilePath))
            {
                var json = File.ReadAllText(FilePath);
                return JsonConvert.DeserializeObject<List<ToDoItem>>(json);
            }
            return new List<ToDoItem>();
        }

        public void SaveItems(IEnumerable<ToDoItem> items)
        {
            var json = JsonConvert.SerializeObject(items, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(FilePath, json);
        }
    }
}
