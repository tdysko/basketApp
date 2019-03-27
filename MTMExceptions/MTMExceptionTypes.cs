using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTM.Exceptions
{
    public class InvalidBasketObjectException : Exception
    {
        public InvalidBasketObjectException(string message)
            : base(message) { }
    }

    public class InvalidProductPrice : Exception
    {
        public InvalidProductPrice(string message = "Invalid product price")
            : base(message) { }
    }

    public class InvalidCurrencyException : Exception
    {
        public InvalidCurrencyException(string message)
            : base(message) { }
    }

    public class InvalidProductQuantity : Exception
    {
        public InvalidProductQuantity(string message = "Invalid product quantity")
            : base(message) { }
    }
}
