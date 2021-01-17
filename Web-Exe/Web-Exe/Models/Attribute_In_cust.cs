using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cuisin.Models
{
    public class Attribute_In_cust
    {
        int id_att;
        int id_cust;

        public Attribute_In_cust(int id_att, int id_cust)
        {
            Id_att = id_att;
            Id_cust = id_cust;
        }

        public int Id_att { get => id_att; set => id_att = value; }
        public int Id_cust { get => id_cust; set => id_cust = value; }


        public Attribute_In_cust() { }


        public int Insert()
        {
            DBServices dbs = new DBServices();
            return dbs.Attribute_att_In_cust(this);
        } 
    }
}