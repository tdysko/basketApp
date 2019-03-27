using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MTM.Products;

namespace MTM.Shop
{
    public class Shop
    {
        public ICashDesk CashDesk { get; set; }

        public Shop(ICashDesk Cashdesk)
        {
            CashDesk = Cashdesk;
        }

        public Decimal GetTotal(Basket Basket, params Voucher[] Vouchers)
        {
            return CashDesk.GetTotal(Basket, Vouchers);
        }
    }
}
