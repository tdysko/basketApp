using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Collective.Currencies;
using Collective.ProductCategories;

namespace MTM.Products
{
    public abstract class BaseProduct
    {
        #region Properties
        [ThreadStatic]
        [XmlElement(ElementName = "ProductName")]
        internal string _ProductTitle;
        [ThreadStatic]
        [XmlElement(ElementName = "ProductPrice")]
        internal decimal _ProductPrice;
        [ThreadStatic]
        [XmlElement(ElementName = "Currency")]
        internal Currencies _ProductCurrency;
        [ThreadStatic]
        [XmlElement(ElementName = "Currency")]
        internal ProductCategory _ProductCategory;
        [ThreadStatic]
        [XmlElement(ElementName = "Quantity")]
        internal int _quantity;
        #endregion

        #region Property Accessors

        public string Title
        {
            get { return _ProductTitle; }
            set { _ProductTitle = value; }
        }

        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }

        public decimal Price
        {
            get { return _ProductPrice; }
            set { _ProductPrice = value; }
        }

        public Currencies Currency
        {
            get { return _ProductCurrency; }
            set { _ProductCurrency = value; }
        }

        public ProductCategory Category
        {
            get { return _ProductCategory; }
            set { _ProductCategory = value; }
        }

        #endregion
    }
}
