using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day21_Practice
{
    public class Customer
    {
        public static SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ado_dbb;Integrated Security=true;");
        public static void Insert()
        {
            try
            {
                CustomerDetails customer = new CustomerDetails();
                Console.WriteLine("Enter Name : ");
                customer.Customer_Name = Console.ReadLine();
                Console.WriteLine("Enter Phone Number : ");
                customer.Phone = Convert.ToInt64(Console.ReadLine());
                Console.WriteLine("Enter Address : ");
                customer.Address = Console.ReadLine();
                Console.WriteLine("Enter Country : ");
                customer.Country = Console.ReadLine();
                Console.WriteLine("Enter Salary : ");
                customer.Salary = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Pincode : ");
                customer.Pincode = Convert.ToInt32(Console.ReadLine());
                con.Open();
                string query = "insert into Customer values('" + customer.Customer_Name + "'," + customer.Phone + ",'" + customer.Address + "','" + customer.Country + "'," + customer.Salary + "," + customer.Pincode + ")";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
                Console.WriteLine("Inserted Data Successfully");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error is :" + e.Message);
            }
            
        }
        public static void Retrieve()
        {
            try
            {
                con.Open();
                string query = "select * from Customer";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    Console.WriteLine("Records from Customer Table : ");
                    while (reader.Read())
                    {
                        int Columns_Id = reader.GetInt32(0);
                        string Columns_Name = reader.GetString(1);
                        long phone = reader.GetInt64(2);
                        string Address = reader.GetString(3);
                        string Country = reader.GetString(4);
                        long Salary = reader.GetInt64(5);
                        long Pincode = reader.GetInt64(6);

                        Console.WriteLine($"{Columns_Id}\t\t{Columns_Name}\t{phone}\t{Address}\t{Country}\t{Salary}\t{Pincode}");
                        
                    }
                }
                else
                {
                    Console.WriteLine("No records are there in Customer Table");
                }

                reader.Close();
                con.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error is : " + e.Message);
            }
        }
        public static void Delete()
        {
            try
            {
                con.Open();
                string query = "delete from Customer Where Customer_Name='simar'";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Data is Deleted From Table");
                con.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error is : " + e.Message);
            }
        }
        public static void Update()
        {
            try
            {
                con.Open();
                string query = "Update Customer Set Salary = 70000 Where Customer_Name='Abhinav Kumar'";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Data is Updated");
                con.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error is : " + e.Message);
            }
        }
    }
}
