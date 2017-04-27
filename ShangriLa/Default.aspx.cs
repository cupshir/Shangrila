using ShangriLa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShangriLa
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnStartNewGame_Click(object sender, EventArgs e)
        {
            Server.Transfer("NewGame.aspx");
        }

        protected void btnJoinActiveGame_Click(object sender, EventArgs e)
        {
            Server.Transfer("JoinGame.aspx");
        }
    }
}