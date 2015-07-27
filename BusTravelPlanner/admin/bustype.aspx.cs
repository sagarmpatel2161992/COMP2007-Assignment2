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
    public partial class bustype : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //get the course if editing
                if (!String.IsNullOrEmpty(Request.QueryString["BUSTYPE_ID"]))
                {
                    GetBusType();
                }
            }
        }

        protected void GetBusType() 
        {
            //populate the existing course for editing
            using (TravelConnection db = new TravelConnection())
            {
                Int32 BustypeId = Convert.ToInt32(Request.QueryString["BUSTYPE_ID"]);

                bustype_master objBustype = (from t in db.bustype_master
                                             where t.BUSTYPE_ID== BustypeId
                                             select t).FirstOrDefault();

                //populate the form
                txtBustype.Text = objBustype.BUS_TYPE;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //do insert or update
            using (TravelConnection db = new TravelConnection())
            {
                bustype_master objBustype = new bustype_master();

                if (!String.IsNullOrEmpty(Request.QueryString["BUSTYPE_ID"]))
                {
                    Int32 BusTypeId = Convert.ToInt32(Request.QueryString["BUSTYPE_ID"]);

                    objBustype = (from t in db.bustype_master
                                  where t.BUSTYPE_ID == BusTypeId
                                  select t).FirstOrDefault();
                }

                //populate the course from the input form
                objBustype.BUS_TYPE= txtBustype.Text;

                if (String.IsNullOrEmpty(Request.QueryString["BUSTYPE_ID"]))
                {
                    //add
                    db.bustype_master.Add(objBustype);
                }

                //save and redirect
                db.SaveChanges();
                Response.Redirect("bustype-info.aspx");
            }
        }
    }
}