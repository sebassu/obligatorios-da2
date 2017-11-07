using System.Collections.Generic;
using VehicleTracking_Data_Entities;

namespace VehicleTracking_Data_DataAccess
{
    public interface ICustomerRepository
    {
        void AddNewCustomer(Customer customerToAdd);
        IEnumerable<Customer> Elements { get; }
        Customer IfExistsGetCustomerWithData(string nameToFind,
            string phoneNumberToFind);
    }
}
