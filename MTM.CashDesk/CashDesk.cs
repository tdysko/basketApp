using System;
using System.Linq;
using System.Text;
using Collective.Currencies;
using System.Threading.Tasks;
using Collective.VoucherTypes;
using Collective.ProductCategories;
using System.Collections.Generic;
using MTM.Exceptions;
using MTM.Products;

namespace MTM.Shop
{
    public static class ExtensionMethods
    {
        public static Boolean IsProduct(this object Object)
        {
            if (Object.GetType() == typeof(Product))
            {
                return true;
            }

            return false;
        }

        public static Boolean IsVoucher(this object Object)
        {
            if (Object.GetType() == typeof(Voucher))
            {
                return true;
            }

            return false;
        }
    }

    public class CashDesk : BaseCashDesk, ICashDesk
    {       
        public Decimal AddToVoucherPriceSum(ref decimal VoucherSum, decimal Price)
        {
            return VoucherSum = VoucherSum + Price;
        }

        public Decimal GetTotal(Basket Basket, params Voucher[] Vouchers)
        {
            ClientVouchers = Vouchers;

            ProductsTape = Basket.BasketObjects;

            decimal ProductsSum = 0;
            decimal GiftVoucherSum = 0;

            foreach (object Object in Basket.BasketObjects)
            {
                if (Object.IsProduct())
                {
                    AddProductPriceToSum(ref ProductsSum, (Product)Object);                    
                }
                else if (Object.IsVoucher())
                {
                    AddToVoucherPriceSum(ref GiftVoucherSum, ((Voucher)Object).Price);
                }
                else
                {
                    throw new InvalidBasketObjectException("Invalid object in basket");
                }
            }

            return ApplyVouchers(ProductsSum) + GiftVoucherSum;
        }

        public Decimal AddProductPriceToSum(ref decimal ProductsSum, Product Product)
        {
            int AppliedVouchers = 0;

            foreach (KeyValuePair<int, Voucher> Voucher in RedeemedVouchers(Product.Category))
            {
                AppliedVouchers++;
                ProductsSum = ProductsSum + (Voucher.Value.Price > (Product).Price ? 0 : Product.Quantity * Product.Price - Voucher.Value.Price);

                RemoveVoucher(Voucher.Key);
            }

            if (AppliedVouchers == 0)
            {
                ProductsSum = ProductsSum + Product.Price * Product.Quantity;
            }

            return ProductsSum;
        }

        public void RemoveVoucher(int Key)
        {
            ClientVouchers[Key] = null;
        }

        public IEnumerable<KeyValuePair<int, Voucher>> RedeemedVouchers(ProductCategory ProductCategory)
        {
            for (int i = 0; i < ClientVouchers.Length; i++)
            {
                if (ClientVouchers[i].Category == ProductCategory)
                {
                    yield return new KeyValuePair<int, Voucher>(i, ClientVouchers[i]);
                }
            }
        }

        public Decimal ApplyVouchers(Decimal ProductsSum)
        {
            foreach (Voucher Voucher in ClientVouchers)
            {
                if (Voucher != null)
                {
                    if (Voucher.Type == VoucherType.Gift)
                    {
                        if (ProductsSum > OfferThreshold)
                        {
                            ProductsSum = ProductsSum - Voucher.Price;
                        }
                        else
                        {
                            Console.WriteLine("You have not reached the spend threshold for voucher " +
                                Voucher.Code + ". Spend another " + GetCurrencySymbol(Voucher.Currency) + (OfferThreshold - ProductsSum + 0.01m).ToString() +
                                "  to receive " + GetCurrencySymbol(Voucher.Currency) + Voucher.Price + " discount from your basket total.");
                        }
                    }
                    if (Voucher.Type == VoucherType.Offer)
                    {
                        if (Voucher.Category == 0)
                        {
                            ProductsSum = ProductsSum - Voucher.Price;
                        }
                        else
                        {
                            Console.WriteLine("“There are no products in your basket applicable to Voucher  " + Voucher.Code + "”");
                        }
                    }
                }
            }

            return ProductsSum;
        }

        private String GetCurrencySymbol(Currencies Currency)
        {
            switch (Currency)
            {
                case Currencies.GBP:
                    return "£";

                default:
                    throw new InvalidCurrencyException("Invalid currency");
            }
        }

        public CashDesk(decimal Threshold)
        {
            OfferThreshold = Threshold;
        }

        internal CashDesk(IBasket Basket)
        {
            _basket = Basket;
        }
    }
}
