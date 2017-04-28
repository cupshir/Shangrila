<%@ Page Title="" Language="C#" MasterPageFile="~/ShangriLa.Master" AutoEventWireup="true" CodeBehind="NewGame.aspx.cs" Inherits="ShangriLa.NewGame" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="page-header">
            <h2>Start A New Game</h2>
        </div>
        <asp:Panel ID="pnlNewGame" runat="server">
            <div class="row">
                <asp:Button ID="btnStartGame" runat="server" Text="Start Game" OnClick="btnStartGame_Click" /><br />
                <br />
            </div>
            <div class="row">
                <asp:PlaceHolder ID="phNewGame" runat="server"></asp:PlaceHolder>
            </div>
            <div class="row">
                <asp:Button ID="btnAddPlayer" runat="server" Text="Add Player" OnClick="btnAddPlayer_Click" />&nbsp;&nbsp;
                <asp:Button ID="btnRemovePlayer" runat="server" Text="Remove Player" OnClick="btnRemovePlayer_Click" /><br />
                <br />
                <asp:Button ID="btnCreateNewPlayer" runat="server" OnClick="btnCreateNewPlayer_Click" Text="Create New Player" />
            </div>
        </asp:Panel>
        <asp:Panel ID="pnlCreateNewPlayer" runat="server" Visible="False">
            <div class="row">
                Player Name:  <asp:TextBox ID="tbPlayerName" runat="server"></asp:TextBox><br />
                Player Email:&nbsp; <asp:TextBox ID="tbPlayerEmail" runat="server"></asp:TextBox><br />
                <br />
                <asp:Button ID="btnSaveNewPlayer" runat="server" Text="Create New Player" OnClick="btnSaveNewPlayer_Click" />
            </div>
        </asp:Panel>
    </div>
</asp:Content>
