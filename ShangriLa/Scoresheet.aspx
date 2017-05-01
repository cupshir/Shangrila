<%@ Page Title="" Language="C#" MasterPageFile="~/ShangriLa.Master" AutoEventWireup="true" CodeBehind="Scoresheet.aspx.cs" Inherits="ShangriLa.Scoresheet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="page-header">
            <h2>ShangriLa Scoresheet</h2>
        </div>
        <div class="row">
            <asp:GridView ID="gvScoresheet" runat="server" AutoGenerateColumns="false" AllowSorting="true" CssClass="table table-bordered text-center" >
                <Columns>
                    <asp:BoundField DataField="PlayerId" HeaderText="Player" />
                    <asp:BoundField DataField="TwoSetsOneRun" HeaderText="2 Sets 1 Run" />
                    <asp:BoundField DataField="TwoRunsOneSet" HeaderText="2 Runs 1 Set" />
                    <asp:BoundField DataField="ThreeSets" HeaderText="3 Sets" />
                    <asp:BoundField DataField="ThreeRuns" HeaderText="3 Runs" />
                    <asp:BoundField DataField="ThreeSetsOneRun" HeaderText="3 Sets 1 Run" />
                    <asp:BoundField DataField="TwoSetsTwoRuns" HeaderText="2 Sets 2 Runs" />
                    <asp:BoundField DataField="FourSets" HeaderText="4 Sets" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
