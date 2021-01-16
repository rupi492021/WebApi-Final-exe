using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Exe.Models
{
    public class Attribute_In_rest
    {
        int id_attr;
        int id_rest;

        public Attribute_In_rest(int id_attr, int id_rest)
        {
            Id_attr = id_attr;
            Id_rest = id_rest;
        }

        public int Id_attr { get => id_attr; set => id_attr = value; }
        public int Id_rest { get => id_rest; set => id_rest = value; }


        public Attribute_In_rest() { }

        public int Insert()
        {
            DBServices dbs = new DBServices();
            return dbs.Insert_Att_In_Rest(this);

        }
    }
}