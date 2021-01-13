using System;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;
using System.Text;
using System.Collections.Generic;


using cuisin.Models;

public class DBServices
    {
        public SqlDataAdapter da;
        public DataTable dt;
        public SqlConnection connect(String conString)
        {

            // read the connection string from the configuration file
            string cStr = WebConfigurationManager.ConnectionStrings[conString].ConnectionString;
            SqlConnection con = new SqlConnection(cStr);
            con.Open();
            return con;
        }


    // Build the Insert command String
    //--------------------------------------------------------------------
    

    // Create the SqlCommand
    //---------------------------------------------------------------------------------
    private SqlCommand CreateCommand(String CommandSTR, SqlConnection con)
        {

            SqlCommand cmd = new SqlCommand(); // create the command object

            cmd.Connection = con;              // assign the connection to the command object

            cmd.CommandText = CommandSTR;      // can be Select, Insert, Update, Delete 

            cmd.CommandTimeout = 10;           // Time to wait for the execution' The default is 30 seconds

            cmd.CommandType = System.Data.CommandType.Text; // the type of the command, can also be stored procedure

            return cmd;
        }


    //Insert New Customer 
    public int Insert(Customer customer)
        {

            SqlConnection con;
            SqlCommand cmd;

            try
            {
                con = connect("DBConnectionString"); // create the connection
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            String cStr = BuildInsertCommand(customer);      // helper method to build the insert string

            cmd = CreateCommand(cStr, con);             // create the command

            try
            {
                int numEffected = cmd.ExecuteNonQuery(); // execute the command
                return numEffected;
            }
            catch (Exception ex)
            {
                // write to log
                throw (ex);
            }

            finally
            {
                if (con != null)
                {
                    // close the db connection
                    con.Close();
                }
            }

        }
    //--------------------------------------------------------------------
    private String BuildInsertCommand(Customer customer)
        {
            String command;

            StringBuilder sb = new StringBuilder();
            // use a string builder to create the dynamic string
            sb.AppendFormat("Values('{0}', '{1}','{2}','{3}', '{4}', '{5}')", customer.Fname, customer.Lname, customer.Mail, customer.Phone, customer.Password, customer.Image); String prefix = "INSERT INTO [Customers_2021] " + "(id,name,user_rating,category,price_range,location,phone_numbers,featured_image )";
            String prefixc = "INSERT INTO [Customers_2021] " + "([name],[lastname],[email],[phone],[password],[image])";
            command = prefixc + sb.ToString();

            return command;
        }

    
    //Check if customer is Exits, if yes give back all the data about the customer
    public List<Customer> CheckIfExits(string mail, string password)
    {
        SqlConnection con = null;
        List<Customer> customers = new List<Customer>();

        try
        {
            con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

            String selectSTR = "select [name],lastname,email,phone,password,[image] from Customers_2021 where email = '" + mail.ToString()+ "' and [password] = '" +password.ToString() + "'";
            SqlCommand cmd = new SqlCommand(selectSTR, con);

            // get a reader
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

            while (dr.Read())
            {   // Read till the end of the data into a row
                Customer c = new Customer();

                    c.Fname = (string)dr["name"];
                    c.Lname = (string)dr["lastname"];
                    c.Mail = (string)dr["email"];
                    c.Phone = (string)dr["phone"];
                    c.Password = (string)dr["password"];



                if (!dr.IsDBNull(5))
                {
                    c.Image = (string)dr["image"];
                }
                else
                {
                    c.Image = string.Empty;
                }
                
                customers.Add(c);
            }

            return customers;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }

        }
    }

    //Get all resturant data
    public List<Businesses> getBusinesses()
    {
        SqlConnection con = null;
        List<Businesses> bList = new List<Businesses>();

        try
        {
            con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

            String selectSTR = "select * from Restaurants_2021";
            SqlCommand cmd = new SqlCommand(selectSTR, con);

            // get a reader
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

            while (dr.Read())
            {   // Read till the end of the data into a row
                Businesses B = new Businesses();

                B.Id = Convert.ToInt32(dr["id"]);
                B.Name = (string)dr["name"];
                B.User_rating = Convert.ToDouble(dr["user_rating"]);
                B.Category = (string)dr["category"];
                B.Price_range = Convert.ToInt32(dr["price_range"]);
                B.Location = (string)dr["location"];
                B.Phone_numbers = (string)dr["phone_numbers"];
                B.Featured_image = (string)dr["featured_image"];
                bList.Add(B);
            }

            return bList;
        }
        catch (Exception ex)
        {
            // write to log
            throw (ex);
        }
        finally
        {
            if (con != null)
            {
                con.Close();
            }

        }

    }
}
