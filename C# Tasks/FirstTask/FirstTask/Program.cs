using System.Reflection.Metadata;

namespace FirstTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var product01 = new Product("Chips", -100, Category.Food);
            var product02 = new Product("Chips", 100, Category.Food);
            var location = new Location
            {
                X = 10,
                Y = 10
            };
            product01.Location = location;
            product02.Location = location;
            Console.WriteLine(product01); // Price 0
            Console.WriteLine(product02); // Price 100
        }
    }

    internal class Product
    {
        public Product(string name, decimal price, Category category)
        {
            Name = name;
            Price = price;
            Category = category;
        }
        public string Name { get; set; }
        private decimal price;
        public decimal Price
        {
            get => price;

            set
            {
                price = (value < 0) ? 0 : value;
            }
        }
        public Category Category { get; set; }
        private Location location;
        public Location Location { get; set; }
        public override string ToString()
        {
            return $"Name : {Name} , Price : {Price}, Category : {Category} , {Location}";
        }

    }
    enum Category
    {
        Food = 1,
        Clothing,
        Electronics
    }
    struct Location
    {
        public int X { get; set; }
        public int Y { get; set; }
        public override string ToString()
        {
            return $"X : {X} , Y : {Y}";
        }
    }
}
