using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Course : IHasId
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
    