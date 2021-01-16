﻿using System;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;
using System.Text;
using System.Collections.Generic;


using cuisin.Models;
using resturantwebApp.Models.DAL;
using Web_Exe.Models;

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



    //Insert New Campaingn
    public int Insert(Campaign campaign)
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

        String cStr = BuildInsertCommand(campaign);      // helper method to build the insert string

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
    private String BuildInsertCommand(Campaign campaign)
    {
        String command;

        StringBuilder sb = new StringBuilder();
        // use a string builder to create the dynamic string
        sb.AppendFormat("Values({0}, {1}, {2}, {3}, {4}, '{5}')", campaign.Id_rest, campaign.Budget, campaign.Amount_use, campaign.Num_clicks, campaign.Num_views, campaign.Status);
        String prefixc = "INSERT INTO [campaingn_2021] " + "([id_rest],[budget],[amount_use],[num_clicks],[num_views],[status])";
        command = prefixc + sb.ToString();

        return command;
    }


    //Insert Insert_Att_In_Rest
    public int Insert_Att_In_Rest(Attribute_In_rest attribute_In_Rest)
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

        String cStr = BuildInsertCommand(attribute_In_Rest);      // helper method to build the insert string

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
    private String BuildInsertCommand(Attribute_In_rest attribute_In_Rest)
    {
        String command;

        StringBuilder sb = new StringBuilder();
        // use a string builder to create the dynamic string
        sb.AppendFormat("Values({0}, {1})", attribute_In_Rest.Id_attr, attribute_In_Rest.Id_rest);
        String prefixc = "INSERT INTO [Attribute_rest_2021] " + "([Id_attribute],[Id_rest])";
        command = prefixc + sb.ToString();

        return command;
    }


    //Update Budget of Campaign by id
    public int Update_Budget(int id, int budget)
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

        String cStr = BuildUpdateCommand(id,budget);      // helper method to build the insert string

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
    private String BuildUpdateCommand(int id, int budget)
    {
        String command;
        command = "UPDATE campaingn_2021 SET budget = " + budget + " WHERE id_rest = " +id+ "; ";
        return command;
    }

    //Delete Campaign by id - change status to false
    public int DeleteCampain(int id, bool? status)
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

        String cStr = BuildUpdateCommand(id, status);      // helper method to build the insert string

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
    private String BuildUpdateCommand(int id, bool? status)
    {
        String command;
        command = "UPDATE campaingn_2021 SET status = '" + status + "' WHERE id_rest = " + id + "; ";
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

   
    
    //Get all resturant Data
    public List<Businesses> getBusinesses(string category=null)
    {
        SqlConnection con = null;
        List<Businesses> bList = new List<Businesses>();
        string selectSTR = null;
        try
        {
            con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file
            if(category == null)
            {
                selectSTR = "select * from Restaurants_2021";
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendFormat("select * from Restaurants_2021 where category like '%{0}%'", category);
                selectSTR = sb.ToString();
            }

            
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



    //Get all Campaingns Data
    public List<Campaign> getcampaingns()
    {
        SqlConnection con = null;
        List<Campaign> campaignsList = new List<Campaign>();

        try
        {
            con = connect("DBConnectionString"); // create a connection to the database using the connection String defined in the web config file

            String selectSTR = "select ca.id,id_rest,[name],budget,amount_use,num_clicks,num_views,[status] from campaingn_2021 as ca inner join Restaurants_2021 as re on ca.id_rest = re.id where[status] = 'true'";
            SqlCommand cmd = new SqlCommand(selectSTR, con);

            // get a reader
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection); // CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

            while (dr.Read())
            {   // Read till the end of the data into a row
                Campaign C = new Campaign();

                C.Id = Convert.ToInt32(dr["id"]);
                C.Id_rest = Convert.ToInt32(dr["id_rest"]);
                C.Rest_name = (string)(dr["name"]);
                C.Budget = Convert.ToInt32(dr["budget"]);
                C.Amount_use = Convert.ToDouble((dr["amount_use"]));
                C.Num_clicks = Convert.ToInt32(dr["num_clicks"]);
                C.Num_views = Convert.ToInt32(dr["num_views"]);
                C.Status = Convert.ToBoolean(dr["status"]);
                campaignsList.Add(C);
            }

            return campaignsList;
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
