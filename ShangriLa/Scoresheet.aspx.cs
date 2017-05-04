using ShangriLa.Classes;
using ShangriLa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace ShangriLa
{
    public partial class Scoresheet : System.Web.UI.Page
    {
        List<GamePlayer> currentGame = new List<GamePlayer>();        

        protected void Page_Load(object sender, EventArgs e)
        {
            // Hardcode game for testing
            ActiveGameId.Value = "2";

            // If no active game in Session then rediret back to default
            if (!Page.IsPostBack)
            {
                if (Session["ActiveGame"] == null)
                {
                    Server.Transfer("Default.aspx");
                }
                else
                {
                    if (SelectedPlayerId.Value == null)
                    {
                        SelectedPlayerId.Value = "-1";
                    }

                    // Load current game and display Scoresheet
                    currentGame = DataRepository.GetGamePlayers(Int32.Parse(ActiveGameId.Value));
                    displayScoresheet();
                }

            }
            
        }

        // Display Scoresheet
        private void displayScoresheet()
        {
            gvScoresheet.DataSource = currentGame;
            gvScoresheet.DataBind();
        }

        // Configure clickable cells
        protected void gvScoresheet_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType == DataControlRowType.Header || e.Row.RowType == DataControlRowType.DataRow)
            {
                for (int i = 1; i < e.Row.Cells.Count - 2; i++)
                {
                    TableCell cell = e.Row.Cells[i];
                    cell.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                    cell.Attributes["onmouseout"] = "this.style.textDecoration='none';";
                    cell.Attributes["ondblclick"] = string.Format("document.getElementById('{0}').value = {1}; {2}", SelectedGridCellIndex.ClientID, i
                       , Page.ClientScript.GetPostBackClientHyperlink((GridView)sender, string.Format("Select${0}", e.Row.RowIndex)));
                }
            }
        }

        // On double click hide scoresheet and display edit panel
        protected void gvScoresheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            var grid = (GridView)sender;
            int rowIndex = grid.SelectedIndex;

            // Set Selected Player if data row selected
            if (rowIndex != -1)
            {
                SelectedPlayerId.Value = gvScoresheet.Rows[rowIndex].Cells[9].Text;
            }

            // If header row show the all players scores edit window
            if (rowIndex == -1)
            {
                displayAllPlayersScoreEntry(grid);
            }
            // If datarow show the single player score edit window
            else if (rowIndex > -1)
            {
                displayPlayerScoreEntry(grid);
            }

            // Temp info...
            //lblResult.Text += "Row Index: " + rowIndex + "<br />";
            //lblResult.Text += "Cell Index: " + selectedCellIndex + "<br />";
            //lblResult.Text += "Selected Hand: " + gvScoresheet.HeaderRow.Cells[selectedCellIndex].Text + "<br />";
            //lblResult.Text += "Selected Player: " + gvScoresheet.Rows[rowIndex].Cells[0].Text + "<br />";
            //lblResult.Text += "Selected PlayerID: " + gvScoresheet.Rows[rowIndex].Cells[9].Text + "<br />";
            //lblResult.Text += "Cell Value: " + gvScoresheet.Rows[rowIndex].Cells[selectedCellIndex].Text + "<br /><br />";



        }

        // Edit panel for single player score
        private void displayPlayerScoreEntry(GridView grid)
        {
            GridViewRow selectedRow = grid.SelectedRow;
            int rowIndex = grid.SelectedIndex;
            int selectedCellIndex = int.Parse(this.SelectedGridCellIndex.Value);

            lblHand.Text = gvScoresheet.HeaderRow.Cells[selectedCellIndex].Text;

            Panel namePanel = (Panel)pnlEditPanel.FindControl("pnlPlayer" + rowIndex);
            namePanel.Visible = true;

            Label nameLabel = (Label)pnlEditPanel.FindControl("lblPlayerName" + rowIndex);
            nameLabel.Text = gvScoresheet.Rows[rowIndex].Cells[0].Text;

            hideGridShowEdit();
        }

        // Edit panel for All players scores
        private void displayAllPlayersScoreEntry(GridView grid)
        {
            GridViewRow selectedRow = grid.SelectedRow;
            int rowIndex = grid.SelectedIndex;
            int selectedCellIndex = int.Parse(this.SelectedGridCellIndex.Value);

            lblHand.Text = gvScoresheet.HeaderRow.Cells[selectedCellIndex].Text;

            for (int i = 0; i < gvScoresheet.Rows.Count; i++)
            {
                Panel namePanel = (Panel)pnlEditPanel.FindControl("pnlPlayer" + i);
                namePanel.Visible = true;

                Label nameLabel = (Label)pnlEditPanel.FindControl("lblPlayerName" + i);
                nameLabel.Text = gvScoresheet.Rows[i].Cells[0].Text;

            }

            hideGridShowEdit();
        }
        

        protected void btnEditPanelSave_Click(object sender, EventArgs e)
        {
            int playerId = Int32.Parse(SelectedPlayerId.Value);
            // Save value(s) to database
            if (playerId != -1)
            {
                saveSinglePlayerScores(playerId);
            }
            else if(playerId == -1)
            {
                saveAllPlayersScores();
            }

            // Clear form and hide player panels
            clearEditForm();
   
            // Hide edit form and show Grid
            hideEditShowGrid();
        }

        private void hidePlayerPanels()
        {
            throw new NotImplementedException();
        }

        private void clearEditForm()
        {
            for (int i = 0; i < gvScoresheet.Rows.Count; i++)
            {
                Panel namePanel = (Panel)pnlEditPanel.FindControl("pnlPlayer" + i);
                
                TextBox textBox = (TextBox)pnlEditPanel.FindControl("tbPlayerScore" + i);
                textBox.Text = "";
                namePanel.Visible = false;
            }
        }

        private void saveSinglePlayerScores(int playerId)
        {
            int selectedCellIndex = int.Parse(this.SelectedGridCellIndex.Value);

            Panel namePanel = (Panel)pnlEditPanel.FindControl("pnlPlayer" + )



            //int score = 


            DataRepository.UpdatePlayerScore(ActiveGameId.Value, playerId, gvScoresheet.HeaderRow.Cells[selectedCellIndex].Text, score);

            //throw new NotImplementedException();
        }

        private void saveAllPlayersScores()
        {
            //throw new NotImplementedException();
        }

        // Hide scoresheet panel and Show Edit panel
        private void hideGridShowEdit()
        {
            pnlGridView.Visible = false;
            pnlEditPanel.Visible = true;
        }

        // Hide Edit panel and Show Scoresheet panel
        private void hideEditShowGrid()
        {
            pnlEditPanel.Visible = false;
            pnlGridView.Visible = true;
        }
    }
}