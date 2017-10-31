namespace Domain
{
    public class Sale
    {
        private Customer buyer;
        public Customer Buyer
        {
            get { return buyer; }
            set
            {
                if (IsValidBuyer(value))
                {
                    buyer = value;
                }
                else
                {
                    throw new SaleException(ErrorMessages.BuyerIsNull);
                }
            }
        }

        protected static bool IsValidBuyer(Customer value)
        {
            return Utilities.IsNotNull(value);
        }

        private int sellingPrice;
        public int SellingPrice
        {
            get { return sellingPrice; }
            set
            {
                if (IsValidPrice(value))
                {
                    sellingPrice = value;
                }
                else
                {
                    throw new SaleException(ErrorMessages.SalePriceMustBePositive);
                }
            }
        }

        protected bool IsValidPrice(int value)
        {
            return value > 0;
        }

        internal static Sale InstanceForTestingPurposes()
        {
            return new Sale();
        }

        private Sale() { }
    }
}