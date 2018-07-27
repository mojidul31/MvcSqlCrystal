using System;
using System.Web.Mvc;
using SQLConnectionAndCrystalReport.IService;
using SQLConnectionAndCrystalReport.Models;
using SQLConnectionAndCrystalReport.Service;

namespace SQLConnectionAndCrystalReport.Controllers
{
    public class CustomerController : Controller
    {
        public ICustomerService CustomerService { get; set; }
        public CustomerController()
        {
            CustomerService = new CustomerService();
        }
        // GET: Customer
        public ActionResult ShowAllCustomers()
        {
            string resulMsg;
            var customers = CustomerService.GetAllCustomers(out resulMsg);
            return View(customers);
        }
        [HttpGet]
        public ActionResult InsertCustomer()
        {
            Customer customer = new Customer();
            return View(customer);
        }
        [HttpPost]
        public ActionResult InsertCustomer(Customer customer)
        {
            string resultMsg;
            var result = CustomerService.CreateCustomer(customer, out resultMsg);
            if (result)
            {
                TempData["Message"] = resultMsg;
                return RedirectToAction("ShowAllCustomers");
            }
            else
            {
                return View(customer);
            }
        }
        
        [HttpGet]
        public ActionResult UpdateCustomer(int id)
        {
            var customer = id > 0 ? GetCustomerById(id) : new Customer();
            return View(customer);
        }
        [HttpPost]
        public ActionResult UpdateCustomer(Customer customer)
        {
            string resultMsg;
            var result = CustomerService.UpdateCustomer(customer, out resultMsg);
            if (result)
            {
                TempData["Message"] = resultMsg;
                return RedirectToAction("ShowAllCustomers");
            }
            else
            {
                return View(customer);
            }
        }

        [HttpGet]
        public ActionResult DeleteCustomer(int id)
        {
            var customer = id > 0 ? GetCustomerById(id) : new Customer();
            return View(customer);
        }
        [HttpPost]
        public ActionResult DeleteCustomer(Customer customer)
        {
            string resultMsg;
            int id = Convert.ToInt32(customer.CusId);
            var result = CustomerService.DeleteCustomer(id, out resultMsg);
            if (result)
            {
                TempData["Message"] = resultMsg;
                return RedirectToAction("ShowAllCustomers");
            }
            else
            {
                return View(customer);
            }
        }
        private Customer GetCustomerById(int id)
        {
            string resultMsg;
            var customer = CustomerService.GetCustomerById(id, out resultMsg);
            return customer;
        }
    }
}