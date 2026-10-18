using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public static class EnumerableExtensions
    {
        // R1: Page
        public static IEnumerable<T> Page<T>(this IEnumerable<T> source, int pageNumber, int pageSize)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            // (R1) Invalid numbers throw
            if (pageNumber < 1) throw new ArgumentOutOfRangeException(nameof(pageNumber), "Page number must be 1 or greater.");
            if (pageSize < 1) throw new ArgumentOutOfRangeException(nameof(pageSize), "Page size must be 1 or greater.");

            int startIndex = (pageNumber - 1) * pageSize;
            int endIndex = startIndex + pageSize;
            int currentIndex = 0;

            foreach (var item in source)
            {
                if (currentIndex >= startIndex && currentIndex < endIndex)
                {
                    yield return item; // (R1) yield return where it fits
                }

                currentIndex++;

                // Early exit: فرامل الطوارئ عشان منكملش اللوب على الفاضي
                if (currentIndex >= endIndex)
                {
                    yield break;
                }
            }
        }

        // R2: FindById
        public static T? FindById<T>(this IEnumerable<T> source, int id) where T : IHasId
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            foreach (var item in source)
            {
                if (item.Id == id)
                {
                    return item; // (R2) Returns the item with that id
                }
            }

            return default; // (R2) Returns default if not found
        }

        // R3: ToIdDictionary
        public static IReadOnlyDictionary<int, T> ToIdDictionary<T>(this IEnumerable<T> source) where T : IHasId
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            var dictionary = new Dictionary<int, T>();

            foreach (var item in source)
            {
                // بنضيف الـ Id كـ Key والعنصر كـ Value
                // الـ .Add بترمي Exception لوحدها لو الـ Id متكرر (وده السلوك القياسي)
                dictionary.Add(item.Id, item);
            }

            // (R3) الـ Dictionary العادي بيطبق الـ IReadOnlyDictionary بطبيعته، فبنقدر نرجعه مباشرة
            return dictionary;
        }
    }
}