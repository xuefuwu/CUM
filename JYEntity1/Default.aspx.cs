using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JYManager
{
    public partial class Default : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IList<Order> orders = DB.Orders.ToList();
            foreach (Order o in orders)
            {
                Response.Write(o.SN);
            }

            IList<RepairDetail> details = DB.RepairDetails.ToList();
            foreach (RepairDetail d in details)
            {
                Response.Write(d.ID);
            }
            GridView1.DataSource = DB.Users.ToList();
            GridView1.DataBind();
        }
    }
}