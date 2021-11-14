using System.Collections.Generic;

namespace EF_SQLite
{
    public class Order
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
    }
}