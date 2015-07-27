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
    public partial class busschedule : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {           

            GetBusNo();

            AddRow();

            if (!IsPostBack)
            {
                //get the course if editing
                if (!String.IsNullOrEmpty(Request.QueryString["SCHEDULE_ID"]))
                {
                    GetBusSchedule();
                }
            }
        }

        protected void GetBusSchedule()
        {
            //populate the existing course for editing
            using (TravelConnection db = new TravelConnection())
            {
                Int32 ScheduleId = Convert.ToInt32(Request.QueryString["SCHEDULE_ID"]);

                busschedule_master objSchedule = (from s in db.busschedule_master
                                             where s.SCHEDULE_ID == ScheduleId
                                             select s).FirstOrDefault();

                //populate the form
                ddlBus.Text = objSchedule.BUS_ID.ToString();
                cldrDeparture.SelectedDate = Convert.ToDateTime(objSchedule.DEPARTURE_TIME.ToString());
                cldrArrival.SelectedDate = Convert.ToDateTime(objSchedule.ARRIVAL_TIME.ToString());
                txtSeat.Text = objSchedule.SEAT_AVAILABILITY.ToString();

            }
        }

        protected void GetBusNo()
        {
            using (TravelConnection db = new TravelConnection())
            {
                var bus = (from b in db.bus_master
                            orderby b.BUS_NO
                            select b);

                ddlBus.DataSource = bus.ToList();
                ddlBus.DataBind();
            }
        }
        
        protected void AddRow()
        {            
            ListItem newItem = new ListItem("-Select-", "0");
            ddlBus.Items.Insert(0, newItem);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //do insert or update
            using (TravelConnection db = new TravelConnection())
            {
                busschedule_master objSchedule = new busschedule_master();

                if (!String.IsNullOrEmpty(Request.QueryString["SCHEDULE_ID"]))
                {
                    Int32 ScheduleId = Convert.ToInt32(Request.QueryString["SCHEDULE_ID"]);

                    objSchedule = (from s in db.busschedule_master
                                  where s.SCHEDULE_ID == ScheduleId
                                  select s).FirstOrDefault();
                }

                //populate the course from the input form
                objSchedule.BUS_ID = Convert.ToInt32(ddlBus.SelectedValue);
                objSchedule.DEPARTURE_TIME =Convert.ToDateTime(cldrDeparture.SelectedDate.ToLongDateString());
                objSchedule.ARRIVAL_TIME= Convert.ToDateTime(cldrArrival.SelectedDate.ToLongDateString());
                objSchedule.SEAT_AVAILABILITY = Convert.ToInt32(txtSeat.Text);
                
                if (String.IsNullOrEmpty(Request.QueryString["SCHEDULE_ID"]))
                {
                    //add
                    db.busschedule_master.Add(objSchedule);
                }

                //save and redirect
                db.SaveChanges();
                Response.Redirect("busschedule-info.aspx");
            }        
            
        }

        
    }
}