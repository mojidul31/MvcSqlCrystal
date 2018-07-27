using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SQLConnectionAndCrystalReport.IRepository;
using SQLConnectionAndCrystalReport.Models;
using SQLConnectionAndCrystalReport.Models.Exceptions;

namespace SQLConnectionAndCrystalReport.Repository
{
    public class CustomRepositoryImpl: ICustomRepository
    {
        private readonly DbConnection _connectionDao;
        public CustomRepositoryImpl()
        {
            _connectionDao = new DbConnection();
        }

        public bool CreateCustomer(Customer customer, out string resultMsg)
        {
            string successMsg = "Customer Information Save Successfully!";
            string errorMsg = "Customer Information Failed to Save!";

            using (SqlConnection conn = _connectionDao.GetConnection())
            {
                try
                {
                    using (var cmd = new SqlCommand())
                    {
                        cmd.CommandText = "dbo.SaveCustomer";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = conn;
                        conn.Open();
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add("Cus_Name", SqlDbType.NVarChar).Value = customer.CusName;
                        cmd.Parameters.Add("Cus_Father_Name", SqlDbType.NVarChar).Value = customer.CusFatherName;
                        cmd.Parameters.Add("Cus_Mother_Name", SqlDbType.NVarChar).Value = customer.CusMotherName;
                        cmd.Parameters.Add("Cus_Contact_No", SqlDbType.NVarChar).Value = customer.CusPhone;
                        cmd.Parameters.Add("Cus_Address", SqlDbType.NVarChar).Value = customer.CusAddress;

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected < 0)
                        {
                            resultMsg = successMsg;
                            return true;
                        }
                        else
                        {
                            resultMsg = errorMsg;
                            return false;
                        }
                    }
                }
                catch (SqlException sqlEx)
                {
                    throw new DatabaseException(sqlEx.Message, ExceptionConstants.CommonUserExceptionMessage);
                }
                catch (Exception e)
                {
                   throw new DatabaseException(e.Message, ExceptionConstants.CommonUserExceptionMessage);

                }
                finally
                {
                    conn?.Close();
                }
            }
        }
        public bool UpdateCustomer(Customer customer, out string resultMsg)
        {
            string successMsg = "Customer Information Update Successfully!";
            string errorMsg = "Customer Information Failed to Update!";

            using (SqlConnection conn = _connectionDao.GetConnection())
            {
                try
                {
                    using (var cmd = new SqlCommand())
                    {
                        cmd.CommandText = "dbo.EditCustomer";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = conn;
                        conn.Open();
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add("Cus_Id", SqlDbType.Int).Value = customer.CusId;
                        cmd.Parameters.Add("Cus_Name", SqlDbType.NVarChar).Value = customer.CusName;
                        cmd.Parameters.Add("Cus_Father_Name", SqlDbType.NVarChar).Value = customer.CusFatherName;
                        cmd.Parameters.Add("Cus_Mother_Name", SqlDbType.NVarChar).Value = customer.CusMotherName;
                        cmd.Parameters.Add("Cus_Contact_No", SqlDbType.NVarChar).Value = customer.CusPhone;
                        cmd.Parameters.Add("Cus_Address", SqlDbType.NVarChar).Value = customer.CusAddress;

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected < 0)
                        {
                            resultMsg = successMsg;
                            return true;
                        }
                        else
                        {
                            resultMsg = errorMsg;
                            return false;
                        }
                    }
                }
                catch (SqlException sqlEx)
                {
                    throw new DatabaseException(sqlEx.Message, ExceptionConstants.CommonUserExceptionMessage);
                }
                catch (Exception e)
                {
                    throw new DatabaseException(e.Message, ExceptionConstants.CommonUserExceptionMessage);

                }
                finally
                {
                    conn?.Close();
                }
            }
        }
        public bool DeleteCustomer(int id, out string resultMsg)
        {
            string successMsg = "Customer Information Delete Successfully!";
            string errorMsg = "Customer Information Failed to Delete!";

            using (SqlConnection conn = _connectionDao.GetConnection())
            {
                try
                {
                    using (var cmd = new SqlCommand())
                    {
                        cmd.CommandText = "dbo.DeleteCustomer";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = conn;
                        conn.Open();
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add("Cus_Id", SqlDbType.Int).Value = id;
                        
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected < 0)
                        {
                            resultMsg = successMsg;
                            return true;
                        }
                        else
                        {
                            resultMsg = errorMsg;
                            return false;
                        }
                    }
                }
                catch (SqlException sqlEx)
                {
                    throw new DatabaseException(sqlEx.Message, ExceptionConstants.CommonUserExceptionMessage);
                }
                catch (Exception e)
                {
                    throw new DatabaseException(e.Message, ExceptionConstants.CommonUserExceptionMessage);

                }
                finally
                {
                    conn?.Close();
                }
            }
        }

        public List<Customer> GetAllCustomers(out string resultMsg)
        {
            string successMsg = "Customer Information Available!";
            string errorMsg = "Customer Information Not Found!";
            List<Customer> customers = new List<Customer>();

            using (SqlConnection conn = _connectionDao.GetConnection())

            {

                try
                {
                    using (var cmd = new SqlCommand())
                    {
                        cmd.CommandText = "dbo.GetAllCustomer";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = conn;
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var customer = new Customer();
                                customer.CusId = (int)reader["Cus_Id"];
                                customer.CusName = reader["Cus_Name"].ToString();
                                customer.CusFatherName = reader["Cus_Father_Name"].ToString();
                                customer.CusMotherName = reader["Cus_Mother_Name"].ToString();
                                customer.CusPhone = reader["Cus_Contact_No"].ToString();
                                customer.CusAddress = reader["Cus_Address"].ToString();
                                customers.Add(customer);
                            }
                        }
                        resultMsg = successMsg;
                        return customers;
                    }

                }
                catch (SqlException sqlEx)
                {
                    resultMsg = errorMsg;
                    throw new DatabaseException(sqlEx.Message, ExceptionConstants.CommonUserExceptionMessage);
                }
                catch (Exception e)
                {
                    resultMsg = errorMsg;
                    throw new DatabaseException(e.Message, ExceptionConstants.CommonUserExceptionMessage);

                }
                finally
                {
                    conn?.Close();
                }

            }
        }

        public Customer GetCustomerById(int id, out string resultMsg)
        {
            string successMsg = "Customer Information Available!";
            string errorMsg = "Customer Information Not Found!";
            Customer customer = null;

            using (SqlConnection conn = _connectionDao.GetConnection())

            {

                try
                {
                    using (var cmd = new SqlCommand())
                    {
                        cmd.CommandText = "dbo.GetCustomerById";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = conn;
                        conn.Open();
                        cmd.Parameters.Clear();
                        cmd.Parameters.Add("Cus_Id", SqlDbType.Int).Value = id;
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                customer = new Customer();
                                customer.CusId = (int)reader["Cus_Id"];
                                customer.CusName = reader["Cus_Name"].ToString();
                                customer.CusFatherName = reader["Cus_Father_Name"].ToString();
                                customer.CusMotherName = reader["Cus_Mother_Name"].ToString();
                                customer.CusPhone = reader["Cus_Contact_No"].ToString();
                                customer.CusAddress = reader["Cus_Address"].ToString();
                            }
                        }
                        resultMsg = successMsg;
                        return customer;
                    }

                }
                catch (SqlException sqlEx)
                {
                    resultMsg = errorMsg;
                    throw new DatabaseException(sqlEx.Message, ExceptionConstants.CommonUserExceptionMessage);
                }
                catch (Exception e)
                {
                    resultMsg = errorMsg;
                    throw new DatabaseException(e.Message, ExceptionConstants.CommonUserExceptionMessage);

                }
                finally
                {
                    conn?.Close();
                }

            }
        }
       
    }
}