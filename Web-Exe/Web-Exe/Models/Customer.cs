using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cuisin.Models
{
    public class Customer
    {
        string fname;
        string lname;
        string mail;
        string phone;
        string password;
        string image;

        public Customer(string fname, string lname, string mail, string phone, string password, string Image)
        {
            Fname = fname;
            Lname = lname;
            Mail = mail;
            Phone = phone;
            Password = password;
            Image = image;
        }

        public string Fname { get => fname; set => fname = value; }
        public string Lname { get => lname; set => lname = value; }
        public string Mail { get => mail; set => mail = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Password { get => password; set => password = value; }
        public string Image { get => image; set => image = value; }


        public Customer() { }
        public List<Customer> CheckIfLog(string mail, string password)
        {
            DBServices dbs = new DBServices();
            List<Customer> l = dbs.CheckIfExits(mail, password);
            return l;
        }

        public int Insert()
        {
            DBServices dbs = new DBServices();
            return dbs.Insert(this);

        }
    }
}