using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//Entity Framework 
using BusTravelPlanner.Models;
using System.Linq.Dynamic;

namespace BusTravelPlanner.admin
{
    public partial class station : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {                
                //get the course if editing
                if (!String.IsNullOrEmpty(Request.QueryString["STATION_ID"]))
                {
                    GetStation();
                }
            }
        }

        protected void GetStation()
        {
            //populate the existing course for editing
            using (TravelConnection db = new TravelConnection())
            {
                Int32 StationID = Convert.ToInt32(Request.QueryString["STATION_ID"]);

                station_master objStation = (from s in db.station_master
                               where s.STATION_ID == StationID
                               select s).FirstOrDefault();

                //populate the form
                txtStation.Text = objStation.STATION_NAME;                
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            //do insert or update
            using (TravelConnection db = new TravelConnection())
            {
                station_master objStation = new station_master();

                if (!String.IsNullOrEmpty(Request.QueryString["STATION_ID"]))
                {
                    Int32 STATION_ID = Convert.ToInt32(Request.QueryString["STATION_ID"]);

                    objStation = (from s in db.station_master
                            where s.STATION_ID == STATION_ID
                            select s).FirstOrDefault();
                }

                //populate the course from the input form
                objStation.STATION_NAME = txtStation.Text;                

                if (String.IsNullOrEmpty(Request.QueryString["STATION_ID"]))
                {
                    //add
                    db.station_master.Add(objStation);
                }

                //save and redirect
                db.SaveChanges();
                Response.Redirect("station-info.aspx");
            }
        }

      
    }
}