namespace ClassLibrary
{
    public class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Manufacturer { get; set; }

        public override string? ToString()
        {
             return $"Name: {Name} \nPrice: {Price} \nManufacturer: {Manufacturer}";
        }
    }
}
