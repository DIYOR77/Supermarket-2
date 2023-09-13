using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Category category = new Category();
           // category.CreateCategory("NON");
           //category.ReadAllCategory();
           //category.ReadbyID(3);

          ProductdbServise productdb = new ProductdbServise();
            // productdb.CreateProduct(1, "coca cola", 17000);
            //roductdb.ReadbyID(1);
            // productdb.ReadbyName("FANTA");

        }
    }
}
