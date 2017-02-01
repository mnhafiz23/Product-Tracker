using ProductTracker.Domain;
using System.Collections.Generic;

namespace ProductTracker.Interface.Web
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetAll();
        Customer GetById(int id);

        string AddNewCustomer(Customer customer);
        string UpdateCustomer(Customer customer);
        string DeleteCustomer(int id);
    }
}
