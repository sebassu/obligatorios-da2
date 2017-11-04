using Domain;
using System.Collections.Generic;

namespace Persistence
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
    }
}