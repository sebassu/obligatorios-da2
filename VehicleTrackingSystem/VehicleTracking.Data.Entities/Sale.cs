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
                if (Utilities.IsNotNull(value))
                {
                    buyer = value;
                }
                else
                {
                    throw new SaleException(ErrorMessages.BuyerIsNull);
                }
            }
        }

        internal static Sale InstanceForTestingPurposes()
        {
            return new Sale();
        }

        private Sale() { }
    }
}