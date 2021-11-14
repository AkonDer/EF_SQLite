using System.Collections.Generic;

namespace EF_SQLite
{
    public class Castomer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public List<Product> Products { get; set; }
    }
}