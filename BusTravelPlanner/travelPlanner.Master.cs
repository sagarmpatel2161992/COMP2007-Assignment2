using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//Owin Reference
using Microsoft.Owin.Security;

namespace BusTravelPlanner
{
    public partial class travelPlanner : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //determine which nav to show
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                if((HttpContext.Current.User.IsInRole("admin")))
                {
                    plhPublic.Visible = false;
                    plhUser.Visible = false;
                    plhAdmin.Visible = true;
                }
                else
                {
                    plhPublic.Visible = false;
                    plhUser.Visible = true;
                    plhAdmin.Visible = false;
                }
            }
            else
            {
                plhPublic.Visible = true;
                plhUser.Visible = false;
                plhAdmin.Visible = false;
            }
        }
    }
}