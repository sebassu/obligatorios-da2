using System;
using System.Linq;
using System.Globalization;
using System.Collections.Generic;
using VehicleTracking_Data_Entities;

namespace VehicleTracking_Data_DataAccess
{
    internal class CustomerRepository : GenericRepository<Customer>,
        ICustomerRepository
    {
        public CustomerRepository(VTSystemContext someContext)
            : base(someContext) { }

        public IEnumerable<Customer> Elements => GetElementsWith();

        public void AddNewCustomer(Customer customerToAdd)
        {
            Add(customerToAdd);
        }

        public Customer GetCustomerWithData(string nameToFind,
            string phoneNumberToFind)
        {
            try
            {
                return context.Customers.Single(c => c.Name.Equals(nameToFind)
                && c.PhoneNumber.Equals(phoneNumberToFind));
            }
            catch (InvalidOperationException)
            {
                string errorMessage = string.Format(CultureInfo.CurrentCulture,
                    ErrorMessages.CouldNotFindField, "cliente de nombre", nameToFind);
                throw new RepositoryException(errorMessage);
            }
        }
    }
}