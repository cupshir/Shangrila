using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShangriLa
{
    public partial class NewGame : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            if(Session["FormCount"] == null)
            {
                Session.Add("FormCount", 5);
            }
            int formCount;
            if (int.TryParse(Session["FormCount"].ToString(), out formCount)) ;
            for (int i = 1; i <= formCount; i++)
            {
                Literal ltlPre = new Literal();
                ltlPre.Text = "Player " + i + " ";

                DropDownList dropDownList = new DropDownList();
                dropDownList.ID = "ddl" + i;

                Literal ltlPost = new Literal();
                ltlPost.Text = "<br /><br />";
                phNewGame.Controls.Add(ltlPre);
                phNewGame.Controls.Add(dropDownList);
                phNewGame.Controls.Add(ltlPost);
            }



        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddPlayer_Click(object sender, EventArgs e)
        {
            int formCount;
            int.TryParse(Session["FormCount"].ToString(), out formCount);
            formCount++;
            Session.Add("FormCount", formCount);
        }

        protected void btnRemovePlayer_Click(object sender, EventArgs e)
        {
            int formCount;
            int.TryParse(Session["FormCount"].ToString(), out formCount);
            formCount--;
            Session.Add("FormCount", formCount);
        }
    }
}