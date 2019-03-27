using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Collective.ProductCategories;
using Collective.Currencies;
using MTM.Products;

namespace MTM.Shop
{
    public interface ICashDesk
    {
        Decimal GetTotal(Basket Basket, params Voucher[] Vouchers);
    }
}
