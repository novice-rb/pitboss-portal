using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pitboss_portal
{
    public partial class civstats : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            litTitle.Text = Parser.GetSetting("GameName", "Pitboss Game");
        }
    }
}