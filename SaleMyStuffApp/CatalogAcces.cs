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
        /// Save the Item
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="userId"></param>
        public void SaveTheItem(string newSave, int uId)
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
        /// UnSave the Item
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="userId"></param>
        public void UnSaveTheItem(string newSave, int uId)
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
                                                    owner: reader.GetInt32(6)));
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
                                                owner: reader.GetInt32(6)));
                    }
                }
                Connection.Close();
            }
            return result.ToArray();
        }
    }
}
