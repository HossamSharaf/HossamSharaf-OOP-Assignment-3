using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Store<T>
    {
        private readonly List<T> _items = new List<T>();

        public void Add(T item)
        {
            if (item != null)
            {
                _items.Add(item);
            }
        }

        // هنا الكومبايلر هيعترض ويرفض يعمل Compile
        public T? GetById(int id)
        {
            return _items.FirstOrDefault(x => x.Id == id); // ERROR!
        }

        public IEnumerable<T> GetAll()
        {
            return _items;
        }

        // وهنا كمان هيعترض لنفس السبب
        public void Remove(int id)
        {
            _items.RemoveAll(x => x.Id == id); // ERROR!
        }
    }
}
