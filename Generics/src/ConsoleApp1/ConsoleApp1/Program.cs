namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== 1. Setup Stores ===");

            // Put 5 students in a Store
            var studentStore = new Store<Student>();
            studentStore.Add(new Student { Id = 1, Name = "Ahmed" });
            studentStore.Add(new Student { Id = 2, Name = "Mona" });
            studentStore.Add(new Student { Id = 3, Name = "Ziad" });
            studentStore.Add(new Student { Id = 4, Name = "Sara" });
            studentStore.Add(new Student { Id = 5, Name = "Omar" });

            // Put 3 courses in a Store
            var courseStore = new Store<Course>();
            courseStore.Add(new Course { Id = 101, Title = "C# Basics", Price = 1000m });
            courseStore.Add(new Course { Id = 102, Title = "OOP in C#", Price = 1500m });
            courseStore.Add(new Course { Id = 103, Title = "Data Structures", Price = 2000m });

            Console.WriteLine("\n=== 2. Get one of each by id ===");
            var student = studentStore.GetById(3);
            Console.WriteLine($"Found Student: {student?.Name} (Id: {student?.Id})");

            var course = courseStore.GetById(102);
            Console.WriteLine($"Found Course: {course?.Title} (Id: {course?.Id})");

            Console.WriteLine("\n=== 3. Add a student with an existing id ===");
            try
            {
                studentStore.Add(new Student { Id = 1, Name = "Ahmed Copy" }); // Id 1 already exists
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"[Exception Caught]: {ex.Message}");
            }

            Console.WriteLine("\n=== 4. Print page 2 (size 2) of the students ===");
            // Page 1 should be (Ahmed, Mona). Page 2 should be (Ziad, Sara).
            var page2Students = studentStore.GetAll().Page(pageNumber: 2, pageSize: 2);
            foreach (var s in page2Students)
            {
                Console.WriteLine($"Page 2 Student: {s.Name}");
            }

            Console.WriteLine("\n=== 5. Call FindById on a plain List ===");
            // بنثبت هنا إن الـ Extension Method شغالة على أي IEnumerable مش بس الـ Store
            var plainList = new List<Student>
        {
            new Student { Id = 99, Name = "External Student" }
        };
            var foundInList = plainList.FindById(99);
            Console.WriteLine($"Found in plain list: {foundInList?.Name}");

            // === 6. Compile Error Test ===
            // new Store<int>(); // must NOT compile
        }
    }

}
