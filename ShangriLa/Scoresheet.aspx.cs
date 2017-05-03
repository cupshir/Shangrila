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
            Session["ActiveGame"] = 2;
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

        protected void gvScoresheet_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType == DataControlRowType.DataRow)
            {
                //e.Row.Attributes["ondblclick"] = Page.ClientScript.GetPostBackClientHyperlink(this.gvScoresheet, "Select$" + e.Row.RowIndex);
                //e.Row.Attributes["style"] = "cursor:pointer";
                for (int i = 1; i < e.Row.Cells.Count - 2; i++)
                {
                    TableCell cell = e.Row.Cells[i];
                    cell.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                    cell.Attributes["onmouseout"] = "this.style.textDecoration='none';";
                    cell.Attributes["ondblclick"] = string.Format("document.getElementById('{0}').value = {1}; {2}"
                       , SelectedGridCellIndex.ClientID, i
                       , Page.ClientScript.GetPostBackClientHyperlink((GridView)sender, string.Format("Select${0}", e.Row.RowIndex)));

                }

            }
        }


        protected void btnCloseEditPanel_Click(object sender, EventArgs e)
        {
            pnlEditPanel.Visible = false;
            pnlGridView.Visible = true;
        }

        protected void gvScoresheet_SelectedIndexChanged(object sender, EventArgs e)
        {
            var grid = (GridView)sender;
            GridViewRow selectedRow = grid.SelectedRow;
            int rowIndex = grid.SelectedIndex;
            int selectedCellIndex = int.Parse(this.SelectedGridCellIndex.Value);

            lblResult.Text += "Row Index: " + rowIndex + "<br />";
            lblResult.Text += "Cell Index: " + selectedCellIndex + "<br />";
            lblResult.Text += "Selected Hand: " + gvScoresheet.HeaderRow.Cells[selectedCellIndex].Text + "<br />";
            lblResult.Text += "Selected Player: " + gvScoresheet.Rows[rowIndex].Cells[0].Text + "<br />";
            lblResult.Text += "Selected PlayerID: " + gvScoresheet.Rows[rowIndex].Cells[9].Text + "<br />";
            lblResult.Text += "Cell Value: " + gvScoresheet.Rows[rowIndex].Cells[selectedCellIndex].Text + "<br /><br />";

            // lblResult.Text += e.CommandName.ToString() + "<br />";
            // lblResult.Text += e.CommandSource.ToString() + "<br />";


            pnlGridView.Visible = false;
            pnlEditPanel.Visible = true;
        }
    }
}