using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public interface IHasId
    {
        int Id { get; } 
    }
    public class Store<T> where T : IHasId
    {
        // 1. استبدال الـ List بـ Dictionary (الـ Key هو الـ Id، والـ Value هو الـ Item نفسه)
        private readonly Dictionary<int, T> _items = new Dictionary<int, T>();

        public void Add(T item)
        {
            if (item == null) return;

            // 2. رمي Exception برسالة واضحة لو الـ Id متسجل قبل كده
            if (_items.ContainsKey(item.Id))
            {
                throw new InvalidOperationException($"Cannot add item: An item with Id {item.Id} already exists in the store.");
            }

            _items.Add(item.Id, item);
        }

        public T? GetById(int id)
        {
            // 3. البحث بقى O(1) بدون أي لوب نهائياً!
            // TryGetValue أسرع طريقة عشان تدور في الديكشنري وترجع القيمة لو موجودة
            if (_items.TryGetValue(id, out T? item))
            {
                return item;
            }

            return default; // هترجع null لو العنصر مش موجود
        }

        // 4. اختيار الـ Return Type: استخدمنا IEnumerable<T>
        // ده بيجبر الـ Caller إنه يقرأ الداتا أو يعمل foreach بس، ومستحيل يقدر يعمل .Add() أو .Remove()
        public IEnumerable<T> GetAll()
        {
            return _items.Values; // بنرجع القيم (Values) بس من غير الـ Keys
        }

        public void Remove(int id)
        {
            // الـ Remove كمان بقى سريع جداً O(1)
            _items.Remove(id);
        }
    }
}
