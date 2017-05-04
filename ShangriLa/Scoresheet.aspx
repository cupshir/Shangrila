<%@ Page Title="" Language="C#" MasterPageFile="~/ShangriLa.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Scoresheet.aspx.cs" Inherits="ShangriLa.Scoresheet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .hiddencol { display: none; }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:HiddenField ID="SelectedGridCellIndex" runat="server" Value="-1" />
    <asp:HiddenField ID="SelectedPlayerId" runat="server" Value="-1" />
    <asp:HiddenField ID="ActiveGameId" runat="server" Value="-1" />

    <div class="container">
        <div class="page-header text-center">
            <h2>ShangriLa Scoresheet</h2>
        </div>
        <div class="row">
            <asp:Panel ID="pnlGridView" runat="server">
                <asp:GridView ID="gvScoresheet" runat="server" AutoGenerateColumns="false" AllowSorting="true" CssClass="table table-bordered text-center" 
                              OnRowDataBound="gvScoresheet_RowDataBound" OnSelectedIndexChanged="gvScoresheet_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="PlayerName" HeaderText="Player" HeaderStyle-CssClass="text-center" />
                        <asp:BoundField DataField="TwoSetsOneRun" HeaderText="2 Sets 1 Run" HeaderStyle-CssClass="text-center" />
                        <asp:BoundField DataField="TwoRunsOneSet" HeaderText="2 Runs 1 Set" HeaderStyle-CssClass="text-center" />
                        <asp:BoundField DataField="ThreeSets" HeaderText="3 Sets" HeaderStyle-CssClass="text-center" />
                        <asp:BoundField DataField="ThreeRuns" HeaderText="3 Runs" HeaderStyle-CssClass="text-center" />
                        <asp:BoundField DataField="ThreeSetsOneRun" HeaderText="3 Sets 1 Run" HeaderStyle-CssClass="text-center" />
                        <asp:BoundField DataField="TwoSetsTwoRuns" HeaderText="2 Sets 2 Runs" HeaderStyle-CssClass="text-center" />
                        <asp:BoundField DataField="FourSets" HeaderText="4 Sets" HeaderStyle-CssClass="text-center" />
                        <asp:BoundField DataField="TotalScore" HeaderText="Total Score" HeaderStyle-CssClass="text-center" />
                        <asp:BoundField DataField="PlayerId" HeaderText="PlayerId" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                    </Columns>
                </asp:GridView>
            </asp:Panel>
            <p></p>
            <asp:Panel ID="pnlEditPanel" runat="server" Visible="false">
                <h2><asp:Label ID="lblHand" runat="server" Text=""></asp:Label></h2>
                <p>
                    <asp:Panel ID="pnlPlayer0" runat="server" Visible="false">
                        <asp:Label ID="lblPlayerName0" runat="server"></asp:Label><br />
                        <asp:TextBox ID="tbPlayerScore0" runat="server"></asp:TextBox><br />
                    </asp:Panel>
                    <asp:Panel ID="pnlPlayer1" runat="server" Visible="false">
                        <asp:Label ID="lblPlayerName1" runat="server"></asp:Label><br />
                        <asp:TextBox ID="tbPlayerScore1" runat="server"></asp:TextBox><br />
                    </asp:Panel>
                    <asp:Panel ID="pnlPlayer2" runat="server" Visible="false">
                        <asp:Label ID="lblPlayerName2" runat="server"></asp:Label><br />
                        <asp:TextBox ID="tbPlayerScore2" runat="server"></asp:TextBox><br />
                    </asp:Panel>
                    <asp:Panel ID="pnlPlayer3" runat="server" Visible="false">
                        <asp:Label ID="lblPlayerName3" runat="server"></asp:Label><br />
                        <asp:TextBox ID="tbPlayerScore3" runat="server"></asp:TextBox><br />
                    </asp:Panel>
                    <asp:Panel ID="pnlPlayer4" runat="server" Visible="false">
                        <asp:Label ID="lblPlayerName4" runat="server"></asp:Label><br />
                        <asp:TextBox ID="tbPlayerScore4" runat="server"></asp:TextBox><br />
                    </asp:Panel>
                    <asp:Panel ID="pnlPlayer5" runat="server" Visible="false">
                        <asp:Label ID="lblPlayerName5" runat="server"></asp:Label><br />
                        <asp:TextBox ID="tbPlayerScore5" runat="server"></asp:TextBox><br />
                    </asp:Panel>
                    <asp:Panel ID="pnlPlayer6" runat="server" Visible="false">
                        <asp:Label ID="lblPlayerName6" runat="server"></asp:Label><br />
                        <asp:TextBox ID="tbPlayerScore6" runat="server"></asp:TextBox><br />
                    </asp:Panel>
                    <asp:Panel ID="pnlPlayer7" runat="server" Visible="false">
                        <asp:Label ID="lblPlayerName7" runat="server"></asp:Label><br />
                        <asp:TextBox ID="tbPlayerScore7" runat="server"></asp:TextBox><br />
                    </asp:Panel>
                    <asp:Panel ID="pnlPlayer8" runat="server" Visible="false">
                        <asp:Label ID="lblPlayerName8" runat="server"></asp:Label><br />
                        <asp:TextBox ID="tbPlayerScore8" runat="server"></asp:TextBox><br />
                    </asp:Panel>
                    <p>
                    </p>
                    <asp:Button ID="btnEditPanelSave" runat="server" OnClick="btnEditPanelSave_Click" Text="Save" />
                    <p>
                    </p>
                    <p>
                    </p>
                    <p>
                    </p>
                </p>
            </asp:Panel>
            <asp:LinkButton ID="lnkDummy" runat="server"></asp:LinkButton>

        </div>
    </div>
</asp:Content>
