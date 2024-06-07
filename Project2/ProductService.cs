using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Project2
{
    public class ProductService : IProductRepository
    {
        private string connectionString = "Server=127.0.0.1; Database=prodb; User=root; Password=;";
        public void Create(Product product)
        {
            //throw new NotImplementedException();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "insert into products(name,price,description) values(@name,@price,@description)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", product.Name);
                cmd.Parameters.AddWithValue("@price", product.Price);
                cmd.Parameters.AddWithValue("@description", product.Description);
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            //throw new NotImplementedException();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "delete from products where id = @id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Product> GetAll()
        {
            // throw new NotImplementedException();
            List<Product> products = new List<Product>();
            // using thay try catch
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "select * from products ";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (var read = cmd.ExecuteReader())
                {
                    while (read.Read())
                    {
                        products.Add(new Product
                        {
                            Id = read.GetInt32("Id"),
                            Name = read.GetString("Name"),
                            Price = read.GetDecimal("Price"),
                            Description = read.GetString("Description")
                        });
                    }
                }
                return products;
            }
        }

        public Product Read(int id)
        {
            //throw new NotImplementedException();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "select * from products where id = @id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                using (var read = cmd.ExecuteReader())
                {
                    if (read.Read())
                    {
                        return new Product
                        {
                            Id = read.GetInt32("Id"),
                            Name = read.GetString("Name"),
                            Price = read.GetDecimal("Price"),
                            Description = read.GetString("Description")
                        };
                    }
                }
                return null;
            }
        }

        public void Update(Product product)
        {
            //throw new NotImplementedException();
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "update products set name = @name, price = @price, description = @description where id = @id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", product.Name);
                cmd.Parameters.AddWithValue("@price", product.Price);
                cmd.Parameters.AddWithValue("@description", product.Description);
                cmd.Parameters.AddWithValue("@id", product.Id);
                cmd.ExecuteNonQuery();

            }
        }
    }
}