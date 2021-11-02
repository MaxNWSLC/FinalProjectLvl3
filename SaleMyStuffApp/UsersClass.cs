namespace SaleMyStuffApp
{
    public class UsersClass
    {
        int id;
        string login;
        string pass;
        string dob;//date of birth
        string firstName;
        string lastName;
        string inventory;//items in the users inventory that he is not selling atm
        string selling;//items user is selling
        string saved;//items user may have saved for later to buy
        string lastLogin;
        decimal money;

        public UsersClass(int id, string login, string pass, string dob, string firstName, string lastName, string inventory, string selling, string saved, string lastLogin, decimal money)
        {
            this.id = id;
            this.login = login;
            this.pass = pass;
            this.dob = dob;
            this.firstName = firstName;
            this.lastName = lastName;
            this.inventory = inventory;
            this.selling = selling;
            this.saved = saved;
            this.lastLogin = lastLogin;
            this.money = money;
        }
        public UsersClass(int id, string firstName, string inventory, string selling, string saved, string lastLogin, decimal money)
        {
            this.id = id;
            this.firstName = firstName;
            this.inventory = inventory;
            this.selling = selling;
            this.saved = saved;
            this.lastLogin = lastLogin;
            this.money = money;
        }
        public UsersClass(int id, string login, string pass)
        {
            this.id = id;
            this.login = login;
            this.pass = pass;
        }

        public int Id { get => id; set => id = value; }
        public string Login { get => login; set => login = value; }
        public string Pass { get => pass; set => pass = value; }
        public string Dob { get => dob; set => dob = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Inventory { get => inventory; set => inventory = value; }
        public string Selling { get => selling; set => selling = value; }
        public string Saved { get => saved; set => saved = value; }
        public string LastLogin { get => lastLogin; set => lastLogin = value; }
        public decimal Money { get => money; set => money = value; }

        /// <summary>
        /// Ads int N(itemId) in the Saved string
        /// </summary>
        /// <param name="n"></param>
        /// <returns>String of the saved items</returns>
        public string SaveIn(string old, int n)
        {
            if (old.Length == 0)
                return Saved = $"{n}";
            return Saved = $"{old},{n}";
        }
        /// <summary>
        /// Removes int N(itemId) from the Saved string
        /// </summary>
        /// <param name="n"></param>
        /// <returns>String of the remained items</returns>
        public string SaveOut(string old, int n)
        {
            if (old.Length == 1)
                return Saved = "";
            string takeOut = $"{n},";
            string str = old.Replace(takeOut, "");
            if (str[0] == ',')
                str.Remove(0);
            if (str[str.Length - 1] == ',')
                str.Remove(str.Length - 1);
            return Saved = str;
        }
        /// <summary>
        /// Ads int N(itemId) in the Inventory string
        /// </summary>
        /// <param name="n"></param>
        /// <returns>Inventory items as string</returns>
        public string SetInventoryIn(string old, int n)
        {
            if (old.Length == 0)
                return Inventory = $"{n}";
            return Inventory = $"{old},{n}";
        }
        /// <summary>
        /// Ads int N(itemId) in the Inventory string
        /// </summary>
        /// <param name="n"></param>
        /// <returns>Inventory items as string</returns>
        public string SetSellingOut(string old, int n)
        {
            if (old.Length == 1)
                return Selling = "";
            string takeOut = $"{n},";
            string str = old.Replace(takeOut, "");
            if (str[0] == ',')
                str.Remove(0);
            if (str[str.Length - 1] == ',')
                str.Remove(str.Length - 1);
            return Selling = str;
        }
    }
}
