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
    public partial class busschedule_info : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //set sort
                Session["SortDirection"] = "ASC";
                Session["SortColumn"] = "SCHEDULE_ID";

                //populate grid
                GetSchedule();
            }
        }

        protected void GetSchedule()
        {
            using (TravelConnection db = new TravelConnection())
            {
                var Schedules = (from s in db.busschedule_master
                                select new { s.SCHEDULE_ID, s.bus_master.BUS_NO, s.DEPARTURE_TIME, s.ARRIVAL_TIME, s.SEAT_AVAILABILITY});

                //append the current direction to the Sort Column
                String Sort = Session["SortColumn"].ToString() + " " + Session["SortDirection"].ToString();

                grdSchedule.DataSource = Schedules.AsQueryable().OrderBy(Sort).ToList();
                grdSchedule.DataBind();
            }
        }

        protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            //set the page size and refresh the grid
            grdSchedule.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue);
            GetSchedule();
        }

        protected void grdSchedule_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Int32 ScheduleID = Convert.ToInt32(grdSchedule.DataKeys[e.RowIndex].Values["SCHEDULE_ID"].ToString());

            using (TravelConnection db = new TravelConnection())
            {
                busschedule_master objStaion = (from s in db.busschedule_master
                                            where s.SCHEDULE_ID == ScheduleID
                                            select s).FirstOrDefault();

                db.busschedule_master.Remove(objStaion);
                db.SaveChanges();
            }

            GetSchedule();
        }

        protected void grdSchedule_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //set the page index and refresh the grid
            grdSchedule.PageIndex = e.NewPageIndex;
            GetSchedule();
        }

        protected void grdSchedule_Sorting(object sender, GridViewSortEventArgs e)
        {
            //set the global sort column to column clicked on by the user
            Session["SortColumn"] = e.SortExpression;
            GetSchedule();

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

        protected void grdSchedule_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (IsPostBack)
            {
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    Image SortImage = new Image();

                    for (int i = 0; i <= grdSchedule.Columns.Count - 1; i++)
                    {
                        if (grdSchedule.Columns[i].SortExpression == Session["SortColumn"].ToString())
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
    }
}