namespace RIS
{
    // menuItem include name, type, description and price
    public class menuItem
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Desc { get; set; }
        public int Price { get; set; }

        public menuItem(string name, string type, string desc, int price)
        {
            Name = name;
            Type = type;
            Desc = desc;
            Price = price;
        }
    }
}
