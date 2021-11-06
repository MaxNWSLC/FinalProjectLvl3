namespace SaleMyStuffApp
{
    public class History
    {
        int id;
        int buyer;
        int seller;
        int item;
        decimal price;
        string date;

        public History(int id, int buyer, int seller, int item, decimal price, string date)
        {
            this.id = id;
            this.buyer = buyer;
            this.seller = seller;
            this.item = item;
            this.price = price;
            this.date = date;
        }

        public int Id { get => id; set => id = value; }
        public int Buyer { get => buyer; set => buyer = value; }
        public int Seller { get => seller; set => seller = value; }
        public int Item { get => item; set => item = value; }
        public decimal Price { get => price; set => price = value; }
        public string Date { get => date; set => date = value; }
    }
}
