<%@ Page Title="" Language="C#" MasterPageFile="~/ShangriLa.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ShangriLa.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="page-header">
            <h2>ShangriLa Scoresheet</h2>
        </div>
        <asp:Button ID="btnStartNewGame" runat="server" Text="Start A Game" OnClick="btnStartNewGame_Click" /><br />
        <br />
        <asp:Button ID="btnJoinActiveGame" runat="server" Text="Join A Game" OnClick="btnJoinActiveGame_Click" /><br />
        <br />
    </div>
</asp:Content>
