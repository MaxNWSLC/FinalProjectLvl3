using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Windows.Forms;

namespace SaleMyStuffApp
{
    class CatalogAcces
    {
        private string connectionString;
        public CatalogAcces(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public string ConnectionString { get => connectionString; set => connectionString = value; }
        #region User
        /// <summary>
        /// Check if the login exist
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public bool CheckLogin(string login)
        {
            bool check = false;
            UsersClass checkUser = new UsersClass(login);
            using (var Connection = new SQLiteConnection(ConnectionString))
            {
                Connection.Open();
                var command = Connection.CreateCommand();
                command.CommandText = @"SELECT id FROM usersTable WHERE login = @login";
                command.Parameters.AddWithValue("@login", login);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        checkUser = new UsersClass(id: reader.GetInt32(0));
                    }
                }
                Connection.Close();
            }
            if (checkUser.Id != 0)
                check = true;
            return check;
        }
        /// <summary>
        /// Check wether Login and pass coincide
        /// </summary>
        /// <param name="user"></param>
        /// <param name="pass"></param>
        /// <returns>Object UsersClass</returns>
        public UsersClass UserLogin(string user, string pass)
        {
            UsersClass result = new UsersClass(0, "", "");
            using (var Connection = new SQLiteConnection(ConnectionString))
            {
                Connection.Open();
                var command = Connection.CreateCommand();
                command.CommandText = @"SELECT id, login, password FROM usersTable 
                WHERE login = @login AND password = @password";
                command.Parameters.AddWithValue("@login", user);
                command.Parameters.AddWithValue("@password", pass);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result = new UsersClass(id: reader.GetInt32(0),
                                                login: reader.GetString(1),
                                                pass: reader.GetString(2));
                    }
                }
                Connection.Close();
            }
            return result;
        }
        /// <summary>
        /// Check if pass was changed succesfuly
        /// </summary>
        /// <param name="uId"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        public bool TestLogin(int uId, string pass)
        {
            bool ses = false;
            UsersClass result = new UsersClass(0, "", "");
            using (var Connection = new SQLiteConnection(ConnectionString))
            {
                Connection.Open();
                var command = Connection.CreateCommand();
                command.CommandText = @"SELECT id, login, password FROM usersTable WHERE id = @uId";
                command.Parameters.AddWithValue("@uId", uId);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result = new UsersClass(id: reader.GetInt32(0),
                                                login: reader.GetString(1),
                                                pass: reader.GetString(2));
                    }
                }
                Connection.Close();
            }
            if (result.Pass.Equals(pass))
                ses = true;
            return ses;
        }
        /// <summary>
        /// get user from db if the dob and login are correct
        /// </summary>
        /// <param name="user"></param>
        /// <param name="dob"></param>
        /// <returns></returns>
        public UsersClass SearchUser(string user, string dob)
        {
            UsersClass result = new UsersClass(0, "", "");
            using (var Connection = new SQLiteConnection(ConnectionString))
            {
                Connection.Open();
                var command = Connection.CreateCommand();
                command.CommandText = @"SELECT id, login, password FROM usersTable 
                WHERE login = @login AND dob = @DoB";
                command.Parameters.AddWithValue("@login", user);
                command.Parameters.AddWithValue("@DoB", dob);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result = new UsersClass(id: reader.GetInt32(0),
                                                login: reader.GetString(1),
                                                pass: reader.GetString(2));
                    }
                }
                Connection.Close();
            }
            return result;
        }
        /// <summary>
        /// register new user to the DB
        /// </summary>
        /// <param name="newUser"></param>
        public void CreateUser(UsersClass newUser)
        {
            using (var Connection = new SQLiteConnection(ConnectionString))
            {
                Connection.Open();
                var command = Connection.CreateCommand();
                command.CommandText = @"INSERT INTO 
                usersTable ( login, password, dob, firstName, lastName, inventory, selling, saved, lastLogin ) 
                VALUES ( @login, @pass, @dob, @firstName, @lastName, @inventory, @selling, @saved, @lastLogin )";
                command.Parameters.AddWithValue("@login", newUser.Login);
                command.Parameters.AddWithValue("@pass", newUser.Pass);
                command.Parameters.AddWithValue("@dob", newUser.Dob);
                command.Parameters.AddWithValue("@firstName", newUser.FirstName);
                command.Parameters.AddWithValue("@lastName", newUser.LastName);

                command.Parameters.AddWithValue("@inventory", "");
                command.Parameters.AddWithValue("@selling", "");
                command.Parameters.AddWithValue("@saved", "");
                command.Parameters.AddWithValue("@lastLogin", "");

                try
                {
                    int count = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                Connection.Close();
            }
        }
        /// <summary>
        /// Set the user password
        /// </summary>
        /// <param name="newUser"></param>
        public void SetPassword(UsersClass newUser)
        {
            using (var Connection = new SQLiteConnection(ConnectionString))
            {
                Connection.Open();
                var command = Connection.CreateCommand();
                command.CommandText = @"UPDATE usersTable SET password = @newPass
                                        WHERE id = @id";
                command.Parameters.AddWithValue("@id", newUser.Id);
                command.Parameters.AddWithValue("@newPass", newUser.Pass);

                try
                {
                    int count = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                Connection.Close();
            }
        }
        /// <summary>
        /// write lastLogin to the DB
        /// </summary>
        /// <param name="cu"></param>
        public void SetLastLogin(UsersClass cu)
        {
            using (var Connection = new SQLiteConnection(ConnectionString))
            {
                Connection.Open();
                var command = Connection.CreateCommand();
                command.CommandText = @"UPDATE usersTable SET lastLogin = @lastLogin
                                        WHERE id = @id";
                command.Parameters.AddWithValue("@id", cu.Id);
                command.Parameters.AddWithValue("@lastLogin", cu.LastLogin);

                try
                {
                    int count = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                Connection.Close();
            }
        }
        /// <summary>
        /// Get the Currently loged user
        /// </summary>
        /// <param name="currentId"></param>
        /// <returns>Object UsersClass</returns>
        public UsersClass CurrentUser(int currentId)
        {
            UsersClass result = new UsersClass(0, "", "", "", "", "", 0);
            using (var Connection = new SQLiteConnection(ConnectionString))
            {
                Connection.Open();
                var command = Connection.CreateCommand();
                command.CommandText = @"SELECT * FROM usersTable WHERE id = @id";
                command.Parameters.AddWithValue("@id", currentId);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result = new UsersClass(id: reader.GetInt32(0),
                                                firstName: reader.GetString(4),
                                                inventory: reader.GetString(6),
                                                selling: reader.GetString(7),
                                                saved: reader.GetString(8),
                                                lastLogin: reader.GetString(9),
                                                money: reader.GetDecimal(10));
                    }
                }
                Connection.Close();
            }
            return result;
        }

        /// <summary>
        /// Buy the Item
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="userId"></param>
        public void SetInventory(string str, int uId)
        {
            using (var Connection = new SQLiteConnection(ConnectionString))
            {
                Connection.Open();
                var command = Connection.CreateCommand();
                command.CommandText = @"UPDATE usersTable SET inventory = @newInventory 
                                        WHERE id = @id";
                command.Parameters.AddWithValue("@id", uId);
                command.Parameters.AddWithValue("@newInventory", str);
                try
                {
                    int count = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                Connection.Close();
            }
        }
        /// <summary>
        /// Set the Money
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="userId"></param>
        public void SetMoney(decimal newMoney, int uId)
        {
            using (var Connection = new SQLiteConnection(ConnectionString))
            {
                Connection.Open();
                var command = Connection.CreateCommand();
                command.CommandText = @"UPDATE usersTable SET money = @newMoney 
                                        WHERE id = @id";
                command.Parameters.AddWithValue("@id", uId);
                command.Parameters.AddWithValue("@newMoney", newMoney);
                try
                {
                    int count = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                Connection.Close();
            }
        }
        /// <summary>
        /// Save/Unsave the Item
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="userId"></param>
        public void SetSaved(string newSave, int uId)
        {
            using (var Connection = new SQLiteConnection(ConnectionString))
            {
                Connection.Open();
                var command = Connection.CreateCommand();
                command.CommandText = @"UPDATE usersTable SET saved = @newSave 
                                        WHERE id = @id";
                command.Parameters.AddWithValue("@id", uId);
                command.Parameters.AddWithValue("@newSave", newSave);
                try
                {
                    int count = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                Connection.Close();
            }
        }
        /// <summary>
        /// Set selling field in user table
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="userId"></param>
        public void SetSelling(string newSale, int uId)
        {
            using (var Connection = new SQLiteConnection(ConnectionString))
            {
                Connection.Open();
                var command = Connection.CreateCommand();
                command.CommandText = @"UPDATE usersTable SET selling = @newSale
                                        WHERE id = @id";
                command.Parameters.AddWithValue("@id", uId);
                command.Parameters.AddWithValue("@newSale", newSale);
                try
                {
                    int count = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                Connection.Close();
            }
        }
        #endregion
        #region Items
        /// <summary>
        /// update the state of the Item to: "NotForSale" or "Selling"
        /// </summary>
        /// <param name="newState">String of new state</param>
        /// <param name="ciId">Current Item</param>
        public void SetState(string newState, int ciId)
        {
            using (var Connection = new SQLiteConnection(ConnectionString))
            {
                Connection.Open();
                var command = Connection.CreateCommand();
                command.CommandText = @"UPDATE itemsTable SET state = @newState 
                                        WHERE id = @id";
                command.Parameters.AddWithValue("@id", ciId);
                command.Parameters.AddWithValue("@newState", newState);
                try
                {
                    int count = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                Connection.Close();
            }
        }
        /// <summary>
        /// Set the new owner
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="userId"></param>
        public void SetOwner(int cuId, int ciId)
        {
            using (var Connection = new SQLiteConnection(ConnectionString))
            {
                Connection.Open();
                var command = Connection.CreateCommand();
                command.CommandText = @"UPDATE itemsTable SET owner = @newOwner 
                                        WHERE id = @id";
                command.Parameters.AddWithValue("@id", ciId);
                command.Parameters.AddWithValue("@newOwner", cuId);
                try
                {
                    int count = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                Connection.Close();
            }
        }
        /// <summary>
        /// update the tempPrice
        /// </summary>
        /// <param name="price">new temporary price in decimal</param>
        /// <param name="itemId">item to change price for</param>
        public void SetTempPrice(decimal price, int itemId)
        {
            using (var Connection = new SQLiteConnection(ConnectionString))
            {
                Connection.Open();
                var command = Connection.CreateCommand();
                command.CommandText = @"UPDATE itemsTable SET tempPrice = @newPrice 
                                        WHERE id = @id";
                command.Parameters.AddWithValue("@id", itemId);
                command.Parameters.AddWithValue("@newPrice", price);
                try
                {
                    int count = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                Connection.Close();
            }
        }
        /// <summary>
        /// Get the Items
        /// </summary>
        /// <param name="ids"></param>
        /// <returns>ItemsClass array</returns>
        public ItemsClass[] GetItems(int[] ids)
        {
            List<ItemsClass> result = new List<ItemsClass>();
            using (var Connection = new SQLiteConnection(ConnectionString))
            {
                Connection.Open();
                for (int i = 0; i < ids.Length; i++)
                {
                    var command = Connection.CreateCommand();
                    command.CommandText = @"SELECT * FROM itemsTable WHERE id = @ids";
                    command.Parameters.AddWithValue("@ids", ids[i]);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new ItemsClass(id: reader.GetInt32(0),
                                                    name: reader.GetString(1),
                                                    price: reader.GetDecimal(2),
                                                    info: reader.GetString(3),
                                                    image: reader.GetString(4),
                                                    state: reader.GetString(5),
                                                    owner: reader.GetInt32(6),
                                                    tempPrice: reader.GetDecimal(7)));
                        }
                    }
                }
                Connection.Close();
            }
            return result.ToArray();
        }
        /// <summary>
        /// Get the Items for Sale
        /// </summary>
        /// <returns>Array of ItemsClass Objects</returns>
        public ItemsClass[] GetItemsForSale(bool bot = false)
        {
            List<ItemsClass> result = new List<ItemsClass>();
            using (var Connection = new SQLiteConnection(ConnectionString))
            {
                Connection.Open();
                var command = Connection.CreateCommand();
                if (bot)
                    command.CommandText = @"SELECT * FROM itemsTable WHERE state = @str
                                        AND owner != 0";
                else
                    command.CommandText = @"SELECT * FROM itemsTable WHERE state = @str";
                command.Parameters.AddWithValue("@str", "ForSale");
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(new ItemsClass(id: reader.GetInt32(0),
                                                name: reader.GetString(1),
                                                price: reader.GetDecimal(2),
                                                info: reader.GetString(3),
                                                image: reader.GetString(4),
                                                state: reader.GetString(5),
                                                owner: reader.GetInt32(6),
                                                tempPrice: reader.GetDecimal(7)));
                    }
                }
                Connection.Close();
            }
            return result.ToArray();
        }
        public ItemsClass[] NotForSale()
        {
            List<ItemsClass> result = new List<ItemsClass>();
            using (var Connection = new SQLiteConnection(ConnectionString))
            {
                Connection.Open();
                var command = Connection.CreateCommand();
                    command.CommandText = @"SELECT * FROM itemsTable WHERE state = @str
                                        AND owner = 0";
                command.Parameters.AddWithValue("@str", "NotForSale");
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(new ItemsClass(id: reader.GetInt32(0),
                                                name: reader.GetString(1),
                                                price: reader.GetDecimal(2),
                                                info: reader.GetString(3),
                                                image: reader.GetString(4),
                                                state: reader.GetString(5),
                                                owner: reader.GetInt32(6),
                                                tempPrice: reader.GetDecimal(7)));
                    }
                }
                Connection.Close();
            }
            return result.ToArray();
        }
        #endregion
        #region History
        /// <summary>
        /// Get Seller History from DB
        /// </summary>
        /// <param name="uId">Current User ID</param>
        /// <returns></returns>
        public History[] GetSellHistory(int uId)
        {
            List<History> result = new List<History>();
            using (var Connection = new SQLiteConnection(ConnectionString))
            {
                Connection.Open();
                var command = Connection.CreateCommand();
                command.CommandText = @"SELECT * FROM history WHERE seller = @uId";
                command.Parameters.AddWithValue("@uId", uId);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(new History(id: reader.GetInt32(0),
                                                buyer: reader.GetInt32(1),
                                                seller: reader.GetInt32(2),
                                                item: reader.GetInt32(3),
                                                price: reader.GetDecimal(4),
                                                date: reader.GetString(5)
                                                ));
                    }
                }
                Connection.Close();
            }
            return result.ToArray();
        }
        /// <summary>
        /// Get Buyer History from DB
        /// </summary>
        /// <param name="uId">Current Usser ID</param>
        /// <returns></returns>
        public History[] GetBuyHistory(int uId)
        {
            List<History> result = new List<History>();
            using (var Connection = new SQLiteConnection(ConnectionString))
            {
                Connection.Open();
                var command = Connection.CreateCommand();
                command.CommandText = @"SELECT * FROM history WHERE buyer = @uId";
                command.Parameters.AddWithValue("@uId", uId);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(new History(id: reader.GetInt32(0),
                                                buyer: reader.GetInt32(1),
                                                seller: reader.GetInt32(2),
                                                item: reader.GetInt32(3),
                                                price: reader.GetDecimal(4),
                                                date: reader.GetString(5)
                                                ));
                    }
                }
                Connection.Close();
            }
            return result.ToArray();
        }
        public void WriteTransaction(History nt)
        {
            using (var Connection = new SQLiteConnection(ConnectionString))
            {
                Connection.Open();
                var command = Connection.CreateCommand();
                command.CommandText = @"INSERT INTO 
                history ( buyer, seller, item, price, time) 
                VALUES ( @buyer, @seller, @item, @price, @date)";
                command.Parameters.AddWithValue("@buyer", nt.Buyer);
                command.Parameters.AddWithValue("@seller", nt.Seller);
                command.Parameters.AddWithValue("@item", nt.Item);
                command.Parameters.AddWithValue("@price", nt.Price);
                command.Parameters.AddWithValue("@date", nt.Date);
                try
                {
                    int count = command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                Connection.Close();
            }
        }
        #endregion
    }
}
