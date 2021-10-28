namespace SaleMyStuffApp
{
    class ItemsClass
    {
        int id;
        string name;
        string price;
        string info;//short description
        string image;
        string state;//the state of the item for User like: forSale, sold, inventory    ??? not sure about this one

        public ItemsClass(int id, string name, string price, string info, string image, string state)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.info = info;
            this.image = image;
            this.state = state;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Price { get => price; set => price = value; }
        public string Info { get => info; set => info = value; }
        public string Image { get => image; set => image = value; }
        public string State { get => state; set => state = value; }
    }
}
