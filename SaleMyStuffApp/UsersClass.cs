namespace SaleMyStuffApp
{
    class UsersClass
    {
        int id;
        string login;
        string pass;
        string dob;//date of birth
        string firstName;
        string lastName;
        string inventory;//items in the users inventory that he is not selling
        string selling;//items user is selling
        string saved;//items user may have saved for later to buy
        string lastLogin;

        public UsersClass(int id, string login, string pass, string dob, string firstName, string lastName, string inventory, string selling, string saved, string lastLogin)
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
    }
}
