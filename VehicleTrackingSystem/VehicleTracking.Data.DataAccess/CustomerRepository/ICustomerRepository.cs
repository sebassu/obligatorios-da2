using Domain;
using System.Collections.Generic;

namespace Persistence
{
    public interface ICustomerRepository
    {
        void AddNewCustomer(Customer customerToAdd);
        IEnumerable<Customer> Elements { get; }
        Customer IfExistsGetCustomerWithData(string nameToFind,
            string phoneNumberToFind);
    }
}
