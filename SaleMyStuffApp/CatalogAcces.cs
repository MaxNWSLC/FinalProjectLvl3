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
                command.CommandText = @"SELECT id, login, password FROM usersTable WHERE login = @login AND password = @password";
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
                command.CommandText = @"UPDATE usersTable SET inventory = @newInventory WHERE id = @id";
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
                command.CommandText = @"UPDATE usersTable SET money = @newMoney WHERE id = @id";
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
                command.CommandText = @"UPDATE usersTable SET saved = @newSave WHERE id = @id";
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
        /// Set salling field in user table
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="userId"></param>
        public void SetSelling(string newSale, int uId)
        {
            using (var Connection = new SQLiteConnection(ConnectionString))
            {
                Connection.Open();
                var command = Connection.CreateCommand();
                command.CommandText = @"UPDATE usersTable SET selling = @newSale WHERE id = @id";
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
        /// <summary>
        /// update the state of the Item to: "NotForSale" or "Selling"
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="userId"></param>
        public void SetState(string newState, int uId)
        {
            using (var Connection = new SQLiteConnection(ConnectionString))
            {
                Connection.Open();
                var command = Connection.CreateCommand();
                command.CommandText = @"UPDATE itemsTable SET state = @newState WHERE id = @id";
                command.Parameters.AddWithValue("@id", uId);
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
                command.CommandText = @"UPDATE itemsTable SET owner = @newOwner WHERE id = @id";
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
        /// <param name="itemId"></param>
        /// <param name="userId"></param>
        public void SetTempPrice(decimal price, int uId)
        {
            using (var Connection = new SQLiteConnection(ConnectionString))
            {
                Connection.Open();
                var command = Connection.CreateCommand();
                command.CommandText = @"UPDATE itemsTable SET tempPrice = @newPrice WHERE id = @id";
                command.Parameters.AddWithValue("@id", uId);
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
            List <ItemsClass> result = new List<ItemsClass>();
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
                            result.Add (new ItemsClass(id: reader.GetInt32(0),
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
        public ItemsClass[] GetItemsForSale()
        {
            List<ItemsClass> result = new List<ItemsClass>();
            using (var Connection = new SQLiteConnection(ConnectionString))
            {
                Connection.Open();
                var command = Connection.CreateCommand();
                command.CommandText = @"SELECT * FROM itemsTable WHERE state = @str";
                command.Parameters.AddWithValue("@str", "Selling");
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
    }
}
