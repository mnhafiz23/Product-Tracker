using System;
using System.Collections.Generic;
using ProductTracker.Domain;
using ProductTracker.Interface.Web;
using ProductTracker.Interface.Common;
using System.Linq;

namespace ProductTracker.Service.Web
{
    public class CustomerService : ICustomerService
    {
        private readonly IGenericRepository<Customer> _repo;

        public CustomerService(IGenericRepository<Customer> repo)
        {
            _repo = repo;
        }
        public IEnumerable<Customer> GetAll()
        {
            return _repo.GetAll().OrderBy(x => x.Fullname);
        }

        public Customer GetById(int id)
        {
            return _repo.GetById(id);
        }
        public string AddNewCustomer(Customer customer)
        {
            try
            {
                var isCustomerExist = _repo.Get(x => x.MobileNum.ToLower() == customer.MobileNum.ToLower()).Any();
                if (isCustomerExist)
                {
                    return "Customer already exist";
                }

                _repo.Add(customer);
                _repo.Save();

                return null;
            }
            catch (Exception)
            {
                
            }
            return "There was a problem creating new customer";
        }

        public string DeleteCustomer(int id)
        {
            try
            {
                var result = _repo.GetById(id);
                if (result == null)
                {
                    return "Customer does not exist";
                }

                _repo.Delete(id);
                _repo.Save();

                return null;
            }
            catch (Exception)
            {
                
            }
            return "There was a problem deleting the customer";
        }
              
        public string UpdateCustomer(Customer customer)
        {
            try
            {
                var result = _repo.GetById(customer.Id);
                if (result == null)
                {
                    return "Customer does not exist";
                }

                _repo.Update(customer);
                _repo.Save();

                return null;
            }
            catch (Exception)
            {
                
            }
            return "There was a problem updating the customer";
        }
    }
}
