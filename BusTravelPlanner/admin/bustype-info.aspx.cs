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
    public partial class bustype_info : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //set sort
                Session["SortDirection"] = "ASC";
                Session["SortColumn"] = "BUSTYPE_ID";

                //populate grid
                GetBusType();
            }
        }

        protected void GetBusType()
        {
            using (TravelConnection db = new TravelConnection())
            {
                var bustype = (from t in db.bustype_master
                                select new { t.BUSTYPE_ID, t.BUS_TYPE});

                //append the current direction to the Sort Column
                String Sort = Session["SortColumn"].ToString() + " " + Session["SortDirection"].ToString();

                grdBustype.DataSource = bustype.AsQueryable().OrderBy(Sort).ToList();
                grdBustype.DataBind();
            }
        }

        protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            //set the page size and refresh the grid
            grdBustype.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue);
            GetBusType();                
        }

        protected void grdBustype_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Int32 BusTypeId = Convert.ToInt32(grdBustype.DataKeys[e.RowIndex].Values["BUSTYPE_ID"].ToString());

            using (TravelConnection db = new TravelConnection())
            {
                bustype_master objBustype = (from t in db.bustype_master
                                            where t.BUSTYPE_ID== BusTypeId
                                            select t).FirstOrDefault();

                db.bustype_master.Remove(objBustype);
                db.SaveChanges();
            }

            GetBusType();
        }

        protected void grdBustype_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //set the page index and refresh the grid
            grdBustype.PageIndex = e.NewPageIndex;
            GetBusType();
        }

        protected void grdBustype_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (IsPostBack)
            {
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    Image SortImage = new Image();

                    for (int i = 0; i <= grdBustype.Columns.Count - 1; i++)
                    {
                        if (grdBustype.Columns[i].SortExpression == Session["SortColumn"].ToString())
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

        protected void grdBustype_Sorting(object sender, GridViewSortEventArgs e)
        {
            //set the global sort column to column clicked on by the user
            Session["SortColumn"] = e.SortExpression;
            GetBusType();

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