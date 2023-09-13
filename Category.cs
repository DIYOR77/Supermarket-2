using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket
{
    internal class Category
    {
        public void CreateCategory(string name)
        {
            string command = $"INSERT INTO dbo.Category (CategoryName) VALUES ('{name}')";
            DAL.ExecteNonQuery(command);
                
        }
        public void UpdateCategory(int id, string newName)
        {
            string command = $"UPDATE dbo.Category" +
                $" SET CategoryName = '{newName}'" +
                $" WHERE Id = {id};";
            DAL.ExecteNonQuery(command);

        }
        public void DeleteCategory(int id)
        {
            string command = $"DELETE dbo.Category WHERE Id = {id}";
            DAL.ExecteNonQuery(command);
        }
        public void ReadAllCategory()
        {
            string command = "SELECT * FROM Category;";

           
        }
        public void ReadbyID(int id)
        {
            string command = "SELECT * FROM dbo.Category;" +
                $"Where Id={id}";
           
        }
        public void ReadbyName(string name)
        {
            string command = "SELECT * FROM Category;" +
                $"Where name='{name}'";

            ExecuteQuery(command);
        }

        private static List<Category>ExecuteQuery(string query)
        {
            List<Category> categories = new List<Category>();
            try
            {
                using(SqlConnection connection= new SqlConnection(DAL.Connection_String))
                {
                    connection.Open();
                    SqlCommand sqlCommand = new SqlCommand(query, connection);
                    categories=ReadCategoryFromDataReader()
                    

                   
                }
            }
        }
            
            
        private static List<Category> ReadCategoryFromDataReader(SqlDataReader reader)
        {
            List<Category> categories = new List<Category>();
            if (reader == null)
            {
                return categories;
            }

            if (!reader.HasRows)
            {
                Console.WriteLine("No data.");
                return categories;
            }

            Console.WriteLine("{0}\t{1}\t{2}",
                    reader.GetName(0),
                    reader.GetName(1),
                    reader.GetName(2));

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string name = reader.GetString(1);
                int numberOfProducts = reader.GetInt32(2);

                categories.Add(new Category(id, name, numberOfProducts));

                Console.WriteLine("{0} \t{1} \t{2}", id, name, numberOfProducts);
            }
            reader.Close();

            return categories;
        }

    }
}

