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

        public UsersClass(string login)
        {
            this.login = login;
        }

        public UsersClass(int id)
        {
            this.id = id;
        }

        public UsersClass(string login, string pass, string dob, string firstName, string lastName)
        {
            this.login = login;
            this.pass = pass;
            this.dob = dob;
            this.firstName = firstName;
            this.lastName = lastName;
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

        #region Methods
        /// <summary>
        /// Ads int N(itemId) in the Saved string
        /// </summary>
        /// <param name="n"></param>
        /// <returns>String of the saved items</returns>
        public string Save(int n)
        {
            if (Saved.Length == 0)
                return Saved = $"{n}";
            return Saved = $"{Saved},{n}";
        }
        /// <summary>
        /// Make sure there are not too many comas
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private string StringCheck(string str)
        {
            if (str.Contains(",,"))
                str = str.Replace(",,", ",");
            if (str[0] == ',')
                str = str.Remove(0, 1);
            if (str.Length > 1 && str[str.Length - 1] == ',')
                str = str.Remove(str.Length - 1, 1);
            return str;
        }
        /// <summary>
        /// Removes int N(itemId) from the Saved string
        /// </summary>
        /// <param name="n"></param>
        /// <returns>String of the remained items</returns>
        public string UnSave(int n)
        {
            if (Saved.Length <= 2)
                return Saved = "";
            string str = Saved.Replace($"{n}", "");
            return Saved = StringCheck(str);
        }
        /// <summary>
        /// Removes int N(itemId) from Inventory
        /// </summary>
        /// <param name="n">Id of the Item to take out</param>
        /// <param name="old">String of the inventory</param>
        /// <returns>String of the remained items</returns>
        public string InventoryOut(int n)
        {
            if (Inventory.Length <= 2)
                return Inventory = "";
            string str = Inventory.Replace($"{n}", "");
            return Inventory = StringCheck(str);
        }
        /// <summary>
        /// Ads int N(itemId) in the Inventory string
        /// </summary>
        /// <param name="n"></param>
        /// <returns>Inventory items as string</returns>
        public string InventoryIn(int n)
        {
            if (Inventory.Length == 0)
                return Inventory = $"{n}";
            return Inventory = $"{Inventory},{n}";
        }
        /// <summary>
        /// Remove item from selling
        /// </summary>
        /// <param name="n"></param>
        /// <returns>Inventory items as string</returns>
        public string CancelSelling(int n)
        {
            if (Selling.Length <= 2)
                return Selling = "";
            string str = Selling.Replace($"{n}", "");
            return Selling = StringCheck(str);
        }
        /// <summary>
        /// Ads int N(itemId) in the Inventory string
        /// </summary>
        /// <param name="n"></param>
        /// <returns>Inventory items as string</returns>
        public string AddSelling(int n)
        {
            if (Selling.Length == 0)
                return Selling = $"{n}";
            return Selling = $"{Selling},{n}";
        }
        #endregion
    }
}
