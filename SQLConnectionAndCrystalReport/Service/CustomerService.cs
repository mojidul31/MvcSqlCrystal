using System;
using System.Collections.Generic;
using SQLConnectionAndCrystalReport.IRepository;
using SQLConnectionAndCrystalReport.IService;
using SQLConnectionAndCrystalReport.Models;
using SQLConnectionAndCrystalReport.Repository;

namespace SQLConnectionAndCrystalReport.Service
{
    public class CustomerService: ICustomerService
    {
        public ICustomRepository CustomRepository { get; set; }
        public CustomerService()
        {
            CustomRepository = new CustomRepositoryImpl();
        }
        public bool CreateCustomer(Customer customer, out string resultMsg)
        {
            try
            {
                var result = CustomRepository.CreateCustomer(customer, out resultMsg);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception(e.Message);
            }
        }
        public bool UpdateCustomer(Customer customer, out string resultMsg)
        {
            try
            {
                var result = CustomRepository.UpdateCustomer(customer, out resultMsg);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception(e.Message);
            }
        }
        public bool DeleteCustomer(int id, out string resultMsg)
        {
            try
            {
                var result = CustomRepository.DeleteCustomer(id, out resultMsg);
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception(e.Message);
            }
        }

        public List<Customer> GetAllCustomers(out string resultMsg)
        {
            try
            {
                var customers = CustomRepository.GetAllCustomers(out resultMsg);
                return customers;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception(e.Message);
            }
        }

        public Customer GetCustomerById(int id, out string resultMessage)
        {
            Customer customer = null;
            string resultMsg = "";

            try
            {
                if (id > 0)
                {
                    customer = CustomRepository.GetCustomerById(id, out resultMsg);
                    resultMessage = resultMsg;
                }
                else
                {
                    resultMessage = resultMsg;
                }
                return customer;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception(e.Message);
            }
        }
        
    }
}