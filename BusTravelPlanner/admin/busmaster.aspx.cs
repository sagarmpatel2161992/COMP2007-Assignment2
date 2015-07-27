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
    public partial class busmaster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            GetBusType();
            GetStation();

            //AddRow();

            if (!IsPostBack)
            {
                //get the course if editing
                if (!String.IsNullOrEmpty(Request.QueryString["BUS_ID"]))
                {
                    GetBus();
                }
            }
        }

        protected void GetBus()
        {
            //populate the existing course for editing
            using (TravelConnection db = new TravelConnection())
            {
                Int32 BusId = Convert.ToInt32(Request.QueryString["BUS_ID"]);

                bus_master objBus = (from t in db.bus_master
                                             where t.BUS_ID == BusId
                                             select t).FirstOrDefault();

                //populate the form
                txtBusno.Text = objBus.BUS_NO;
                ddlBustype.SelectedValue = objBus.BUS_TYPE.ToString();
                ddlSource.SelectedValue = objBus.SOURCE_STATION.ToString();
                ddlDestination.SelectedValue = objBus.DESTINATION_STATION.ToString();
            }
        }

        protected void GetBusType()
        {
            using (TravelConnection db = new TravelConnection())
            {
                var busType = (from t in db.bustype_master
                            orderby t.BUS_TYPE
                            select t);

                ddlBustype.DataSource = busType.ToList();
                ddlBustype.DataBind();
            }
        }

        
        protected void GetStation()
        {
            using (TravelConnection db = new TravelConnection())
            {
                var station = (from s in db.station_master
                            orderby s.STATION_NAME
                            select s);

                ddlSource.DataSource = station.ToList();
                ddlSource.DataBind();

                ddlDestination.DataSource = station.ToList();
                ddlDestination.DataBind();
            }
        }

        protected void AddRow()
        {            
            ListItem newItem = new ListItem("-Select-", "0");
            ddlBustype.Items.Insert(0, newItem);
            ddlSource.Items.Insert(0, newItem);
            ddlDestination.Items.Insert(0, newItem);
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            //do insert or update
            using (TravelConnection db = new TravelConnection())
            {
                bus_master objBus = new bus_master();

                if (!String.IsNullOrEmpty(Request.QueryString["BUS_ID"]))
                {
                    Int32 BusId = Convert.ToInt32(Request.QueryString["BUS_ID"]);

                    objBus = (from t in db.bus_master
                                  where t.BUS_ID == BusId
                                  select t).FirstOrDefault();
                }

                //populate the course from the input form
                objBus.BUS_NO = txtBusno.Text;
                objBus.BUS_TYPE = Convert.ToInt32(ddlBustype.SelectedValue);
                objBus.SOURCE_STATION = Convert.ToInt32(ddlSource.SelectedValue);
                objBus.DESTINATION_STATION = Convert.ToInt32(ddlDestination.SelectedValue);

                if (String.IsNullOrEmpty(Request.QueryString["BUS_ID"]))
                {
                    //add
                    db.bus_master.Add(objBus);
                }

                //save and redirect
                db.SaveChanges();
                Response.Redirect("busmaster-info.aspx");
            }
        }

       
    }
}