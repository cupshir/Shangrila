<%@ Page Title="" Language="C#" MasterPageFile="~/ShangriLa.Master" AutoEventWireup="true" CodeBehind="NewGame.aspx.cs" Inherits="ShangriLa.NewGame" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="page-header">
            <h2>Start A New Game</h2>
        </div>
        <asp:Button ID="btnAddPlayer" runat="server" Text="Add Player" OnClick="btnAddPlayer_Click" />
        &nbsp;<asp:Button ID="btnRemovePlayer" runat="server" Text="Remove Player" OnClick="btnRemovePlayer_Click" />
&nbsp;<div class="row">
            <asp:PlaceHolder ID="phNewGame" runat="server"></asp:PlaceHolder>
        </div>
        
    </div>
</asp:Content>
