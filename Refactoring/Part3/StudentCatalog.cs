namespace RefactoringLab.Part03.Students;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
}

public static class StudentCatalog
{
    // غيرنا الـ Return type لـ IEnumerable
    public static IEnumerable<Student> GetAllStudents()
    {
        for (var i = 1; i <= 1_000_000; i++)
        {
            // بناء العنصر وقت الطلب فقط (Lazy Evaluation)
            yield return new Student { Id = i, Name = $"Student {i}" };
        }
    }
}
