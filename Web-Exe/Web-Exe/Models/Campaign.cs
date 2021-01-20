using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace resturantwebApp.Models.DAL
{
    public class Campaign
    {
        int id;
        string rest_name;
        int id_rest;
        int budget;
        double balance;
        int num_clicks;
        int num_views;
        bool status;

        int difference;

        public Campaign(int id, string rest_name, int id_rest, int budget, double balance, int num_clicks, int num_views, bool status, int difference)
        {
            Id = id;
            Rest_name = rest_name;
            Id_rest = id_rest;
            Budget = budget;
            Balance = balance;
            Num_clicks = num_clicks;
            Num_views = num_views;
            Status = status;
            Difference = difference;
        }

        public int Id { get => id; set => id = value; }
        public string Rest_name { get => rest_name; set => rest_name = value; }
        public int Id_rest { get => id_rest; set => id_rest = value; }
        public int Budget { get => budget; set => budget = value; }
        public double Balance { get => balance; set => balance = value; }
        public int Num_clicks { get => num_clicks; set => num_clicks = value; }
        public int Num_views { get => num_views; set => num_views = value; }
        public bool Status { get => status; set => status = value; }
        public int Difference { get => difference; set => difference = value; }



        public Campaign() { }

        public List<Campaign> Read()
        {
            DBServices dbs = new DBServices();
            List<Campaign> campaignsList = dbs.getcampaingns();
            return campaignsList;
        }

        public int Insert()
        {
            DBServices dbs = new DBServices();
            return dbs.Insert(this);

        }

        public int Update_Budget(int id, int difference)
        {
            DBServices dbs = new DBServices();
            return dbs.Update_Budget(id, difference);
        }
        public int DeleteCampain(int id)
        {
            DBServices dbs = new DBServices();
            return dbs.DeleteCampain(id);
        }

        //CampaignClick
        public int CampaignClick(int id)
        {
            DBServices dbs = new DBServices();
            int res = dbs.CampaignClick(id);
            if (res <= 0)
            {
                return dbs.DeleteCampain(id);
            }
            else
            {
                return res;
            }
        }
    }
}