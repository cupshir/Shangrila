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
    public partial class NewGame : System.Web.UI.Page
    {
        List<Player> availablePlayers = DataRepository.GetAllPlayers();

        protected void Page_Init(object sender, EventArgs e)
        {

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                intializeFormCountSessionVariable();
                drawPlayerSelectionDropDownLists();
            }
        }

        protected void btnAddPlayer_Click(object sender, EventArgs e)
        {
            increaseFormCountSessionVariable(1);
            drawPlayerSelectionDropDownLists();
        }

        protected void btnRemovePlayer_Click(object sender, EventArgs e)
        {
            decreaseFormCountSessionVariable(1);
            drawPlayerSelectionDropDownLists();

        }

        protected void btnStartGame_Click(object sender, EventArgs e)
        {
            Game newGame = DataRepository.CreateNewGame();
            addPlayersFromForm(newGame.Id);
            Session.Add("ActiveGame", newGame.Id);
            Server.Transfer("Default.aspx");
        }

        protected void btnCreateNewPlayer_Click(object sender, EventArgs e)
        {
            tbPlayerEmail.Text = "";
            tbPlayerName.Text = "";
            pnlNewGame.Visible = false;
            pnlCreateNewPlayer.Visible = true;
        }

        protected void btnSaveNewPlayer_Click(object sender, EventArgs e)
        {
            DataRepository.CreateNewPlayer(tbPlayerName.Text, tbPlayerEmail.Text);
            availablePlayers = DataRepository.GetAllPlayers();
            pnlCreateNewPlayer.Visible = false;
            pnlNewGame.Visible = true;
            drawPlayerSelectionDropDownLists();
        }

        private void addPlayersFromForm(int gameId)
        {
            drawPlayerSelectionDropDownLists();
            int formCount = getFormCount();
            for (int i = 1; i <= formCount; i++)
            {
                string ddlName = "ContentPlaceHolder1_ddl" + i;
                DropDownList ddl = (DropDownList)phNewGame.FindControl("ddl" + i);
                int playerId;
                if (int.TryParse(ddl.SelectedValue, out playerId))
                {
                    if (!DataRepository.IsPlayerInGame(gameId, playerId))
                    {
                        DataRepository.AddPlayerToGame(gameId, playerId);
                    }
                    
                }
            }
        }

        private int getFormCount()
        {
            return Convert.ToInt32(Session["FormCount"].ToString());
        }

        private void intializeFormCountSessionVariable()
        {
            if (Session["FormCount"] == null)
            {
                Session.Add("FormCount", 5);
            }
        }

        private void drawPlayerSelectionDropDownLists()
        {
            int formCount = getFormCount();
            

            for (int i = 1; i <= formCount; i++)
            {
                Literal ltlPre = new Literal();
                ltlPre.Text = "Player " + i + " ";
                phNewGame.Controls.Add(ltlPre);

                DropDownList dropDownList = new DropDownList();
                dropDownList.DataSource = availablePlayers;
                dropDownList.DataTextField = "Name";
                dropDownList.DataValueField = "Id";
                dropDownList.DataBind();
                dropDownList.ID = "ddl" + i;
                phNewGame.Controls.Add(dropDownList);

                Literal ltlPost = new Literal();
                ltlPost.Text = "<br /><br />";
                phNewGame.Controls.Add(ltlPost);
            }
        }

        private void increaseFormCountSessionVariable(int x)
        {
            int formCount = getFormCount();
            if (formCount < 9)
            {
                Session["FormCount"] = Convert.ToInt32(Session["FormCount"].ToString()) + x;
            }
        }

        private void decreaseFormCountSessionVariable(int x)
        {
            int formCount = getFormCount();
            if (formCount > 5)
            {
                Session["FormCount"] = Convert.ToInt32(Session["FormCount"].ToString()) - x;
            }
        }


    }
}