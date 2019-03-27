using System;
using MTM.Shop;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Threading.Tasks;
using System.Collections.Generic;
using Collective.ProductCategories;
using Collective.VoucherTypes;
using Collective.Currencies;
using MTM.Products;

namespace Tests
{
    [TestFixture]
    internal class TestClass
    {
        [TestCase]
        public void TestCaseOne()
        {
            Shop Shop = new Shop(new CashDesk(50));

            Basket Basket1 = new Basket();

            Basket1.AddToBasket(
                new Product[] {
                    new Product("Hat", 10.50m,  ProductCategory.Hats, Currencies.GBP, 1),
                    new Product("Jumper", 54.65m, ProductCategory.Jumpers, Currencies.GBP, 1)
                });

            Assert.AreEqual(60.15m,
                Shop.GetTotal(Basket1,
                new Voucher("XXX-XXX", 5.00m, Currencies.GBP, VoucherType.Gift))
                );
        }

        [TestCase]
        public void TestCaseTwo()
        {
            Shop Shop = new Shop(new CashDesk(50));

            Basket Basket2 = new Basket();

            Basket2.AddToBasket(
                new Product[] {
                    new Product("Hat", 25.00m, ProductCategory.Hats,Currencies.GBP, 1),
                    new Product("Jumper", 26.00m, ProductCategory.Jumpers, Currencies.GBP, 1)
                });

            Assert.AreEqual(51.00m,
                Shop.GetTotal(
                    Basket2,
                    new Voucher("YYY-YYY", 5.00m, Currencies.GBP, VoucherType.Offer, ProductCategory.HeadGear))
                    );
        }

        [TestCase]
        public void TestCaseThree()
        {
            Shop Shop = new Shop(new CashDesk(50));

            Basket Basket3 = new Basket();

            Basket3.AddToBasket(
                new Product[] {
                    new Product("Hat", 25.00m, ProductCategory.Hats, Currencies.GBP, 1),
                    new Product("Jumper", 26.00m, ProductCategory.Jumpers, Currencies.GBP, 1),
                    new Product("Head Light", 3.50m, ProductCategory.HeadGear, Currencies.GBP, 1)
                });

            Assert.AreEqual(51.00m,
                Shop.GetTotal(
                    Basket3,
                    new Voucher("YYY-YYY", 5.00m, Currencies.GBP, VoucherType.Gift, ProductCategory.HeadGear))
                    );
        }

        [TestCase]
        public void TestCaseFour()
        {
            Shop Shop = new Shop(new CashDesk(50));

            Basket Basket4 = new Basket();

            Basket4.AddToBasket(
                new Product[] {
                    new Product("Hat", 25.00m, ProductCategory.Hats, Currencies.GBP, 1),
                    new Product("Jumper", 26.00m, ProductCategory.HeadGear, Currencies.GBP, 1)
                });

            Assert.AreEqual(41.00m,
                Shop.GetTotal(
                    Basket4,
                    new Voucher("YYY-YYY", 5.00m, Currencies.GBP, VoucherType.Gift),
                    new Voucher("YYY-YYY", 5.00m, Currencies.GBP, VoucherType.Offer))
                );
        }

        [TestCase]
        public void TestCaseFive()
        {
            Shop Shop = new Shop(new CashDesk(50));

            Basket Basket5 = new Basket();

            Basket5.AddToBasket(
                new Product[] {
                    new Product("Hat", 25.00m, ProductCategory.Hats,  Currencies.GBP, 1),
                    new Voucher("YYY-YYY", 30.00m, Currencies.GBP, VoucherType.Offer)
                });

            Assert.AreEqual(55.00m,
                Shop.GetTotal(
                    Basket5,
                    new Voucher("YYY-YYY", 5.00m, Currencies.GBP, VoucherType.Gift))
                    );
        }
    }
}
