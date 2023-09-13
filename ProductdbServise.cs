using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket
{
    internal class ProductdbServise
    {
        public void CreateProduct(int category_id, string name, decimal price)
        {
            string command = $"INSERT INTO Product (category_id,Product_Name, Price) VALUES ('{category_id}','{name}',{price})";

            DAL.ExecteNonQuery(command);

        }
        public void UpdateProduct(int id, string newName, decimal newPrice)
        {
            string command = $"UPDATE dbo.Product" +
                    $" SET ProductName = '{newName}', Price = {newPrice}" +
                    $" WHERE Id = {id};";
            DAL.ExecteNonQuery(command);
        }
        public void DeleteProduct(int id)
        {
            string command = $"DELETE dbo.Product WHERE Id = {id}";
            DAL.ExecteNonQuery(command);
        }
        public void ReadAllProducts()
        {
            string command = "SELECT * FROM dbo.Product;";

            DAl.ExecuteQuery(command, ReadProductsFromDataReader);


        }
        public void ReadbyID(int id)
        {
            string command = "SELECT * FROM dbo.Product " +
                $"WHERE ID={id};";

            try
            {
                using (SqlConnection connection = new SqlConnection(DAL.Connection_String))
                {
                    connection.Open();

                    SqlCommand sqlCommand = new SqlCommand(command, connection);

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        DAL.ReadProductsFromDataReader(reader);
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Database error: {ex.Message}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something went wrong while reading products. {ex.Message}.");
            }
        }
        public void ReadbyName(string name)
        {
            string command = "SELECT * FROM dbo.Product " +
                $"WHERE Product_Name='{name}';";

            try
            {
                using (SqlConnection connection = new SqlConnection(DAL.Connection_String))
                {
                    connection.Open();

                    SqlCommand sqlCommand = new SqlCommand(command, connection);

                    using (SqlDataReader reader = sqlCommand.ExecuteReader())
                    {
                        DAL.ReadProductsFromDataReader(reader);
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Database error: {ex.Message}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Something went wrong while reading products. {ex.Message}.");
            }
        }



        private static void ReadProductsFromDataReader(SqlDataReader reader)
        {
            if (reader is null)
            {
                return;
            }

            if (reader.HasRows)
            {
                Console.WriteLine("{0}\t{1}\t{2}\t{3}",
                    reader.GetName(0),
                    reader.GetName(1),
                    reader.GetName(2),
                    reader.GetName(3));

                while (reader.Read())
                {
                    object id = reader.GetValue(0);
                    object name = reader.GetValue(1);
                    object price = reader.GetValue(2);
                    object categoryId = reader.GetValue(3);

                    Console.WriteLine("{0} \t{1} \t{2} \t{3}", id, name, price, categoryId);
                }
                reader.Close();
            }

        }
    }
}
