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
    public partial class station_info : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //set sort
                Session["SortDirection"] = "ASC";
                Session["SortColumn"] = "STATION_ID";

                //populate grid
                GetStation();
            }
        }

        protected void GetStation()
        {
            using (TravelConnection db = new TravelConnection())
            {
                var stations = (from s in db.station_master
                               select new { s.STATION_ID, s.STATION_NAME });

                //append the current direction to the Sort Column
                String Sort = Session["SortColumn"].ToString() + " " + Session["SortDirection"].ToString();

                grdStation.DataSource = stations.AsQueryable().OrderBy(Sort).ToList();
                grdStation.DataBind();
            }
        }

        protected void grdStation_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (IsPostBack)
            {
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    Image SortImage = new Image();

                    for (int i = 0; i <= grdStation.Columns.Count - 1; i++)
                    {
                        if (grdStation.Columns[i].SortExpression == Session["SortColumn"].ToString())
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

        protected void grdStation_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Int32 StationID = Convert.ToInt32(grdStation.DataKeys[e.RowIndex].Values["STATION_ID"].ToString());

            using (TravelConnection db = new TravelConnection())
            {
                station_master objStaion = (from s in db.station_master
                               where s.STATION_ID == StationID
                               select s).FirstOrDefault();

                db.station_master.Remove(objStaion);
                db.SaveChanges();
            }

            GetStation();
        }

        protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            //set the page size and refresh the grid
            grdStation.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue);
            GetStation();
        }

        protected void grdStation_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //set the page index and refresh the grid
            grdStation.PageIndex = e.NewPageIndex;
            GetStation();
        }

        protected void grdStation_Sorting(object sender, GridViewSortEventArgs e)
        {
            //set the global sort column to column clicked on by the user
            Session["SortColumn"] = e.SortExpression;
            GetStation();

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