using System.Collections.Generic;
using SQLConnectionAndCrystalReport.Models;

namespace SQLConnectionAndCrystalReport.IRepository
{
    public interface ICustomRepository
    {
        bool CreateCustomer(Customer customer, out string resultMsg);
        bool UpdateCustomer(Customer customer, out string resultMsg);
        bool DeleteCustomer(int id, out string resultMsg);
        List<Customer> GetAllCustomers(out string resultMsg);
        Customer GetCustomerById(int id, out string resultMsg);
    }
}
