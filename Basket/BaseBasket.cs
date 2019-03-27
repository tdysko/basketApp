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
    public abstract class BaseBasket
    {
        #region Properties
        [ThreadStatic]
        [XmlElement(ElementName = "BasketProducts")]
        internal List<object> _BasketObjects = new List<object>();

        [ThreadStatic]
        [XmlElement(ElementName = "BasketVouchers")]
        internal List<Voucher> _Vouchers = new List<Voucher>();

        #endregion

        #region PropertyAccessors

        public List<object> BasketObjects
        {
            get { return _BasketObjects; }
            set { _BasketObjects = value; }
        }

        public List<Voucher> Vouchers
        {
            get { return _Vouchers; }
            set { _Vouchers = value; }
        }
        #endregion
    }
}
