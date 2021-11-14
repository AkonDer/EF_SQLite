namespace EF_SQLite
{
    public class Product
    {
        public int ProductId { get; set; }
        public string PuroductName { get; set; }
        public string Note { get; set; }
        public double Price { get; set; }
        public Castomer Castomer { get; set; }
    }
}