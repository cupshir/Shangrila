using ShangriLa.Classes;
using ShangriLa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShangriLa
{
    public partial class Scoresheet : System.Web.UI.Page
    {
        List<GamePlayer> currentGame = new List<GamePlayer>();
        

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["ActiveGame"] = 19;
            if (!Page.IsPostBack)
            {
                if (Session["ActiveGame"] == null)
                {
                    Server.Transfer("Default.aspx");
                }
                else
                {
                    currentGame = DataRepository.GetGamePlayers((int)Session["ActiveGame"]);
                    displayScoresheet();
                }

            }


        }

        private void displayScoresheet()
        {
            gvScoresheet.DataSource = currentGame;
            gvScoresheet.DataBind();
        }
    }
}