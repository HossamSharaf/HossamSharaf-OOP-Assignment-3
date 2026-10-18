using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }

    public class CourseStore
    {
        private readonly List<Course> _courses = new List<Course>();

        public void Add(Course course)
        {
            if (course != null)
            {
                _courses.Add(course);
            }
        }

        public Course? GetById(int id)
        {
            return _courses.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Course> GetAll()
        {
            return _courses;
        }

        public void Remove(int id)
        {
            _courses.RemoveAll(c => c.Id == id);
        }
    }
}
