using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace resturantwebApp.Models.DAL
{
    public class Campaingn
    {
        int id;
        int id_rest;
        int budget;
        float amount_use;
        int num_clicks;
        int num_views;
        bool status;

        public Campaingn(int id, int id_rest, int budget, float amount_use, int num_clicks, int num_views, bool status)
        {
            Id = id;
            Id_rest = id_rest;
            Budget = budget;
            Amount_use = amount_use;
            Num_clicks = num_clicks;
            Num_views = num_views;
            Status = status;
        }

        public int Id { get => id; set => id = value; }
        public int Id_rest { get => id_rest; set => id_rest = value; }
        public int Budget { get => budget; set => budget = value; }
        public float Amount_use { get => amount_use; set => amount_use = value; }
        public int Num_clicks { get => num_clicks; set => num_clicks = value; }
        public int Num_views { get => num_views; set => num_views = value; }
        public bool Status { get => status; set => status = value; }

        public Campaingn() {}


    }
}