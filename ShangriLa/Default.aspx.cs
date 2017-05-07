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
    public partial class Default : System.Web.UI.Page
    {
        List<Player> availablePlayers = DataRepository.GetAllPlayers();
        List<Game> activeGames = new List<Game>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                initializePlayerCountSessionVariable();
                initializePlayerDropDownLists();
                showPlayerPanels(getPlayerCount());
            }
        }

        private void bindActiveGames()
        {
            activeGames = DataRepository.GetActiveGames();
            gvActiveGames.DataSource = activeGames;
            gvActiveGames.DataBind();
        }
        
        private void addPlayersFromForm(int gameId, int playerCount)
        {
            for (int i = 1; i <= playerCount; i++)
            {
                string ddlName = "ddlPlayer" + i;
                DropDownList ddlPlayer = (DropDownList)pnlNewGame.FindControl(ddlName);
                int playerId;
                if (int.TryParse(ddlPlayer.SelectedValue, out playerId))
                {
                    if (!DataRepository.IsPlayerInGame(gameId, playerId))
                    {
                        DataRepository.AddPlayerToGame(gameId, playerId);
                    }
                }
            }
        }

        private int getPlayerCount()
        {
            return Convert.ToInt32(Session["PlayerCount"].ToString());
        }

        private void initializePlayerCountSessionVariable()
        {
            if (Session["PlayerCount"] == null)
            {
                Session.Add("PlayerCount", 5);
            }
        }

        private void initializePlayerDropDownLists()
        {
            for (int i = 1; i < 10; i++)
            {
                string pnlName = "ddlPlayer" + i;
                DropDownList playerDDL = (DropDownList)pnlNewGame.FindControl(pnlName);
                playerDDL.DataSource = availablePlayers;
                playerDDL.DataTextField = "Name";
                playerDDL.DataValueField = "Id";
                playerDDL.DataBind();
            }
        }

        private void showPlayerPanels(int playerCount)
        {
            hideAllPlayerPanels();
            for (int i = 1; i <= playerCount; i++)
            {
                string pnlName = "pnlPlayer" + i;
                Panel showPanel = (Panel)pnlNewGame.FindControl(pnlName);
                showPanel.Visible = true;
            }
        }

        private void hideAllPlayerPanels()
        {
            for (int i = 1; i < 10; i++)
            {
                string pnlName = "pnlPlayer" + i;
                Panel hidePanel = (Panel)pnlNewGame.FindControl(pnlName);
                hidePanel.Visible = false;
            }
        }

        private void increasePlayerCountSessionVariable()
        {
            if (getPlayerCount() < 9)
            {
                Session["PlayerCount"] = Convert.ToInt32(Session["PlayerCount"].ToString()) + 1;
            }
        }

        private void decreasePlayerCountSessionVariable()
        {
            if (getPlayerCount() > 5)
            {
                Session["PlayerCount"] = Convert.ToInt32(Session["PlayerCount"].ToString()) - 1;
            }
        }

        protected void gvActiveGames_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    TableCell cell = e.Row.Cells[i];
                    cell.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                    cell.Attributes["onmouseout"] = "this.style.textDecoration='none';";
                    cell.Attributes["ondblclick"] = string.Format("document.getElementById('{0}').value = {1}; {2}", SelectedGridCellIndex.ClientID, i
                        , Page.ClientScript.GetPostBackClientHyperlink((GridView)sender, string.Format("Select${0}", e.Row.RowIndex)));
                }
            }
        }

        protected void gvActiveGames_SelectedIndexChanged(object sender, EventArgs e)
        {
            var grid = (GridView)sender;
            int rowIndex = grid.SelectedIndex;

            Session["ActiveGame"] = gvActiveGames.Rows[rowIndex].Cells[0].Text;

            Server.Transfer("Scoresheet.aspx");

        }

        protected void btnCancelActiveGames_Click(object sender, EventArgs e)
        {
            pnlActiveGames.Visible = false;
            pnlDefaultPanel.Visible = true;
        }

        protected void btnCancelCreateNewPlayer_Click(object sender, EventArgs e)
        {
            pnlCreateNewPlayer.Visible = false;
            initializePlayerDropDownLists();
            showPlayerPanels(getPlayerCount());
            pnlNewGame.Visible = true;
        }

        protected void btnCancelNewGame_Click(object sender, EventArgs e)
        {
            pnlNewGame.Visible = false;
            pnlDefaultPanel.Visible = true;
        }

        protected void btnStartNewGame_Click(object sender, EventArgs e)
        {
            pnlDefaultPanel.Visible = false;
            pnlNewGame.Visible = true;
        }

        protected void btnActiveGames_Click(object sender, EventArgs e)
        {
            bindActiveGames();
            pnlDefaultPanel.Visible = false;
            pnlActiveGames.Visible = true;
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
            Player newPlayer = DataRepository.CreateNewPlayer(tbPlayerName.Text, tbPlayerEmail.Text);
            availablePlayers.Add(newPlayer);
            pnlCreateNewPlayer.Visible = false;
            initializePlayerDropDownLists();
            showPlayerPanels(getPlayerCount());
            pnlNewGame.Visible = true;
        }

        protected void btnAddPlayer_Click(object sender, EventArgs e)
        {
            increasePlayerCountSessionVariable();
            showPlayerPanels(getPlayerCount());
        }

        protected void btnRemovePlayer_Click(object sender, EventArgs e)
        {
            decreasePlayerCountSessionVariable();
            showPlayerPanels(getPlayerCount());
        }

        protected void btnStartGame_Click(object sender, EventArgs e)
        {
            Game newGame = DataRepository.CreateNewGame();
            addPlayersFromForm(newGame.Id, getPlayerCount());
            Session.Add("ActiveGame", newGame.Id);
            Server.Transfer("Scoresheet.aspx");
        }
    }
}