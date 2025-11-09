using TodoApi.Models;

namespace TodoApi.Services
{
    public class TodoRepository
    {
        private readonly List<TodoItem> _items = new();
        private int _nextId = 1;

        public IEnumerable<TodoItem> GetAll()
        {
            return _items;
        }

        public TodoItem? GetById(int id)
        {
            return _items.FirstOrDefault(x => x.Id == id);
        }

        public TodoItem Add(string title)
        {
            var item = new TodoItem
            {
                Id = _nextId++,
                Title = title,
                IsDone = false
            };
            _items.Add(item);
            return item;
        }

        public bool Delete(int id)
        {
            var item = GetById(id);
            if (item == null) return false;
            _items.Remove(item);
            return true;
        }

        public TodoItem? ToggleDone(int id)
        {
            var item = GetById(id);
            if (item == null) return null;
            item.IsDone = !item.IsDone;
            return item;
        }
    }
}
