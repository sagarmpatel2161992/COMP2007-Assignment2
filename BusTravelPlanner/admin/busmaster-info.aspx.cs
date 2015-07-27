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
    public partial class busmaster_info : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //set sort
                Session["SortDirection"] = "ASC";
                Session["SortColumn"] = "BUS_ID";

                //populate grid
                GetBus();
            }
        }

        protected void GetBus()
        {
            using (TravelConnection db = new TravelConnection())
            {
                var bus = (from b in db.bus_master
                           select new { b.BUS_ID, b.BUS_NO, b.bustype_master.BUS_TYPE , s1 = b.station_master.STATION_NAME, s2 = b.station_master1.STATION_NAME });

                //append the current direction to the Sort Column
                String Sort = Session["SortColumn"].ToString() + " " + Session["SortDirection"].ToString();

                grdBus.DataSource = bus.AsQueryable().OrderBy(Sort).ToList();
                grdBus.DataBind();
            }
        }


        protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            //set the page size and refresh the grid
            grdBus.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue);
            GetBus();                
        }

        protected void grdBus_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Int32 BusId = Convert.ToInt32(grdBus.DataKeys[e.RowIndex].Values["BUS_ID"].ToString());

            using (TravelConnection db = new TravelConnection())
            {
                bus_master objBus = (from t in db.bus_master
                                             where t.BUS_ID == BusId
                                             select t).FirstOrDefault();

                db.bus_master.Remove(objBus);
                db.SaveChanges();
            }

            GetBus();
        }

        protected void grdBus_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //set the page index and refresh the grid
            grdBus.PageIndex = e.NewPageIndex;
            GetBus();
        }

        protected void grdBus_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (IsPostBack)
            {
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    Image SortImage = new Image();

                    for (int i = 0; i <= grdBus.Columns.Count - 1; i++)
                    {
                        if (grdBus.Columns[i].SortExpression == Session["SortColumn"].ToString())
                        {
                            if (Session["SortDirection"].ToString() == "DESC")
                            {
                                SortImage.ImageUrl = "/images/desc.jpg";
                                SortImage.AlternateText = "Sort Descending";
                            }
                            else
                            {
                                SortImage.ImageUrl = "/images/asc.jpg";
                                SortImage.AlternateText = "Sort Ascending";
                            }

                            e.Row.Cells[i].Controls.Add(SortImage);

                        }
                    }
                }

            }
        }

        protected void grdBus_Sorting(object sender, GridViewSortEventArgs e)
        {
            //set the global sort column to column clicked on by the user
            Session["SortColumn"] = e.SortExpression;
            GetBus();

            //toggle the direction
            if (Session["SortDirection"].ToString() == "ASC")
            {
                Session["SortDirection"] = "DESC";
            }
            else
            {
                Session["SortDirection"] = "ASC";
            }
        }
    }
}