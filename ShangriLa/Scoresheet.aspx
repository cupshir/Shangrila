<%@ Page Title="" Language="C#" MasterPageFile="~/ShangriLa.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Scoresheet.aspx.cs" Inherits="ShangriLa.Scoresheet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .hiddencol { display: none; }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
            <asp:Panel ID="pnlEditPanel" runat="server" Visible="true">
                <asp:Label ID="lblResult" runat="server" Text=""></asp:Label>
                <p></p>
                <asp:Button ID="btnCloseEditPanel" runat="server" Text="Close" OnClick="btnCloseEditPanel_Click" />
            </asp:Panel>
            <p></p>
            
            <p></p>
            <asp:LinkButton ID="lnkDummy" runat="server"></asp:LinkButton>
            <asp:HiddenField ID="SelectedGridCellIndex" runat="server" Value="-1" />
        </div>
    </div>
</asp:Content>
