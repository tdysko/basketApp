using System;
using System.Linq;
using System.Text;
using MTM.Products;
using System.Threading.Tasks;
using System.Collections.Generic;
using MTM.Shop;

namespace MTM.Shop
{
    public abstract class BaseCashDesk
    {
        #region Properties

        [ThreadStatic]
        private List<Object> _ProductsTape;

        [ThreadStatic]
        private Voucher[] _ClientVouchers;

        [ThreadStatic]
        private Decimal _OfferThreshold = 50;

        public IBasket _basket { get; set; }

        #endregion

        #region Accessors

        public Decimal OfferThreshold { get { return _OfferThreshold; } set { _OfferThreshold = value; } }

        public Voucher[] ClientVouchers
        {
            get { return _ClientVouchers; }
            set { _ClientVouchers = value; }
        }

        public List<Object> ProductsTape
        {
            get { return _ProductsTape; }
            set { _ProductsTape = value; }
        }

        #endregion
    }
}
