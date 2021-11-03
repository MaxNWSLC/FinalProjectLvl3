namespace SaleMyStuffApp
{
    public class ItemsClass
    {
        int id;
        string name;
        decimal price;
        string info;//short description
        string image;
        string state;//the state of the item for User like: forSale, sold
        int owner;//the owner of the Item
        decimal tempPrice;

        public ItemsClass(int id, string name, decimal price, string info, string image, string state, int owner, decimal tempPrice)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.info = info;
            this.image = image;
            this.state = state;
            this.owner = owner;
            this.tempPrice = tempPrice;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public decimal Price { get => price; set => price = value; }
        public string Info { get => info; set => info = value; }
        public string Image { get => image; set => image = value; }
        public string State { get => state; set => state = value; }
        public int Owner { get => owner; set => owner = value; }
        public decimal TempPrice { get => tempPrice; set => tempPrice = value; }
    }
}
