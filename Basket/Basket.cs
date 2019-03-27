using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Collective.Currencies;
using MTM.Products;

namespace MTM.Shop
{
    [Serializable]
    public class Basket : BaseBasket, IBasket
    {
        public void AddToBasket(object[] Objects) // object[] type as we may allow in future different types of products (for ex. tickets, bookings) 
        {
            if (BasketObjects != null)
            {
                foreach (object Object in Objects)
                {
                    BasketObjects.Add(Object);
                }
            }
            else
            {
                BasketObjects = new List<object>();
                AddToBasket(Objects);
            }
        }

        public Basket(Object[] Objects, Voucher[] Vouchers)
        {
            AddToBasket(Objects);
        }

        public Basket()
        {
            BasketObjects = new List<object>();
        }

    }
}
