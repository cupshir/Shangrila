using ShangriLa.Classes;
using ShangriLa.Models;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShangriLa
{
    public partial class Scoresheet : System.Web.UI.Page
    {
        List<GamePlayer> currentGame = new List<GamePlayer>();        

        protected void Page_Load(object sender, EventArgs e)
        {
            // If no active game in Session then redirect back to default
            if (!Page.IsPostBack)
            {
                if (Session["ActiveGame"] == null)
                {
                    Server.Transfer("Default.aspx");
                }
                else
                {
                    ActiveGameId.Value = Session["ActiveGame"].ToString();

                    // Load current game and display Scoresheet
                    bindScoresheet(int.Parse(ActiveGameId.Value));
                    calculateTotalScores();
                    bindScoresheet(int.Parse(ActiveGameId.Value));
                }
            }
        }

        // Calculate total score column
        private void calculateTotalScores()
        {
            for (int i = 0; i < gvScoresheet.Rows.Count; i++)
            {
                int totalScore = 0;
                for (int j = 1; j < 8 ; j++)
                {
                    totalScore += int.Parse(gvScoresheet.Rows[i].Cells[j].Text);
                }
                DataRepository.UpdatePlayerTotalScore(int.Parse(ActiveGameId.Value), int.Parse(gvScoresheet.Rows[i].Cells[9].Text), totalScore);
            }
        }

        // Bind datasource to gridview
        private void bindScoresheet(int gameId)
        {
            currentGame = DataRepository.GetGamePlayers(gameId);
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
        }

        // Edit panel for single player score
        private void displayPlayerScoreEntry(GridView grid)
        {
            int rowIndex = grid.SelectedIndex;
            SelectedRow.Value = rowIndex.ToString();
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
            int rowIndex = grid.SelectedIndex;
            SelectedRow.Value = rowIndex.ToString();
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
        
        // Clear text entry boxes on edit form
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

        // Save single score to database
        private void saveSinglePlayerScores(int playerId)
        {
            int selectedCellIndex = int.Parse(this.SelectedGridCellIndex.Value);

            TextBox tbScore = (TextBox)pnlEditPanel.FindControl("tbPlayerScore" + SelectedRow.Value);
            int score = int.Parse(tbScore.Text);

            DataRepository.UpdatePlayerScore(Int32.Parse(ActiveGameId.Value), playerId, gvScoresheet.HeaderRow.Cells[selectedCellIndex].Text, score);
        }

        // Save all player scores to database
        private void saveAllPlayersScores()
        {
            int selectedCellIndex = int.Parse(this.SelectedGridCellIndex.Value);

            for (int i = 0; i < gvScoresheet.Rows.Count; i++)
            {
                Panel namePanel = (Panel)pnlEditPanel.FindControl("pnlPlayer" + i);

                TextBox tbScore = (TextBox)pnlEditPanel.FindControl("tbPlayerScore" + i);
                int score = int.Parse(tbScore.Text);
                int playerId = int.Parse(gvScoresheet.Rows[i].Cells[9].Text);

                DataRepository.UpdatePlayerScore(Int32.Parse(ActiveGameId.Value), playerId, gvScoresheet.HeaderRow.Cells[selectedCellIndex].Text, score);
            }
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

        // Button to Default page
        protected void btnMainMenu_Click(object sender, EventArgs e)
        {
            Server.Transfer("Default.aspx");
        }

        // Button to complete a game
        protected void btnCompleteGame_Click(object sender, EventArgs e)
        {
            DataRepository.CompleteGame(int.Parse(Session["ActiveGame"].ToString()));

            Session["ActiveGame"] = "";

            Server.Transfer("Default.aspx");
        }

        // Button to save player scores to database
        protected void btnEditPanelSave_Click(object sender, EventArgs e)
        {
            int playerId = int.Parse(SelectedPlayerId.Value);
            // Save value(s) to database
            if (playerId != -5)
            {
                saveSinglePlayerScores(playerId);
            }
            else if (playerId == -5)
            {
                saveAllPlayersScores();
            }

            // Clear form and hide player panels
            clearEditForm();

            // Reset SelectedPlayerId
            SelectedPlayerId.Value = "-5";

            // Refresh Scoresheet
            bindScoresheet(int.Parse(ActiveGameId.Value));
            calculateTotalScores();
            bindScoresheet(int.Parse(ActiveGameId.Value));

            // Hide edit form and show Grid
            hideEditShowGrid();
        }
    }
}