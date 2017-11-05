using System.Linq;
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

        public Customer IfExistsGetCustomerWithData(string nameToFind,
            string phoneNumberToFind)
        {
            return context.Customers.SingleOrDefault(c
                => c.Name.Equals(nameToFind) &&
                c.PhoneNumber.Equals(phoneNumberToFind));
        }
    }
}