using System;
using System.Linq;
using System.Text;
using MTM.Products;
using Collective.Currencies;
using System.Threading.Tasks;
using Collective.VoucherTypes;
using System.Collections.Generic;
using Collective.ProductCategories;

namespace MTM.Products
{
    [System.Serializable]
    public class Voucher : Product
    {
        #region Properties
        [ThreadStatic]
        internal decimal _value;

        [ThreadStatic]
        internal VoucherType _voucherType;

        [ThreadStatic]
        internal string _voucherCode;
        #endregion

        #region Property Accessors
        public string Code
        {
            get { return _voucherCode; }
            set { _voucherCode = value; }
        }

        internal decimal Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public VoucherType Type
        {
            get { return _voucherType; }
            set { _voucherType = value; }
        }
        #endregion

        public Voucher(String voucherCode, Decimal VoucherPrice, Currencies VoucherCurrency, VoucherType VoucherType)
        {
            Price = VoucherPrice;
            Currency = VoucherCurrency;
            Type = VoucherType;
            Code = voucherCode;
        }

        public Voucher(String voucherCode, Decimal VoucherPrice, Currencies VoucherCurrency, VoucherType VoucherType, ProductCategory ProductCategory)
        {
            Price = VoucherPrice;
            Type = VoucherType;
            Category = ProductCategory;
            Currency = VoucherCurrency;
            Code = voucherCode;
        }
    }
}
