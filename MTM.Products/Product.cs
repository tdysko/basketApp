using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Collective.Currencies;
using Collective.ProductCategories;
using MTM.Exceptions;

namespace MTM.Products
{
    [Serializable]
    public class Product : BaseProduct
    {
        public Product(string name, decimal price, ProductCategory category, Currencies currency, int quantity)
        {
            Title = name;

            if (price < 0)
                throw new InvalidProductPrice();

            Price = price;
            Currency = currency;
            Category = category;

            if (quantity < 0)
                throw new InvalidProductQuantity();

            Quantity = quantity;
        }

        public Product()
        {

        }
    }
}
