using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLConnectionAndCrystalReport.Models;

namespace SQLConnectionAndCrystalReport.IService
{
    public interface ICustomerService
    {
        bool CreateCustomer(Customer customer, out string resultMsg);
        bool UpdateCustomer(Customer customer, out string resultMsg);
        bool DeleteCustomer(int id, out string resultMsg);
        List<Customer> GetAllCustomers(out string resultMsg);
        Customer GetCustomerById(int id, out string resultMsg);

    }
}
