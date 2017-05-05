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
                <asp:Panel ID="pnlPlayer1" runat="server" Visible="false">
                    <asp:DropDownList ID="ddlPlayer1" runat="server"></asp:DropDownList><br />
                </asp:Panel>
                <asp:Panel ID="pnlPlayer2" runat="server" Visible="false">
                    <asp:DropDownList ID="ddlPlayer2" runat="server"></asp:DropDownList><br />
                </asp:Panel>
                <asp:Panel ID="pnlPlayer3" runat="server" Visible="false">
                    <asp:DropDownList ID="ddlPlayer3" runat="server"></asp:DropDownList><br />
                </asp:Panel>
                <asp:Panel ID="pnlPlayer4" runat="server" Visible="false">
                    <asp:DropDownList ID="ddlPlayer4" runat="server"></asp:DropDownList><br />
                </asp:Panel>
                <asp:Panel ID="pnlPlayer5" runat="server" Visible="false">
                    <asp:DropDownList ID="ddlPlayer5" runat="server"></asp:DropDownList><br />
                </asp:Panel>
                <asp:Panel ID="pnlPlayer6" runat="server" Visible="false">
                    <asp:DropDownList ID="ddlPlayer6" runat="server"></asp:DropDownList><br />
                </asp:Panel>
                <asp:Panel ID="pnlPlayer7" runat="server" Visible="false">
                    <asp:DropDownList ID="ddlPlayer7" runat="server"></asp:DropDownList><br />
                </asp:Panel>
                <asp:Panel ID="pnlPlayer8" runat="server" Visible="false">
                    <asp:DropDownList ID="ddlPlayer8" runat="server"></asp:DropDownList><br />
                </asp:Panel>
                <asp:Panel ID="pnlPlayer9" runat="server" Visible="false">
                    <asp:DropDownList ID="ddlPlayer9" runat="server"></asp:DropDownList><br />
                </asp:Panel>
                <br />
            </div>
            <div class="row">
                <asp:Button ID="btnAddPlayer" runat="server" Text="+" OnClick="btnAddPlayer_Click" />&nbsp;&nbsp;
                <asp:Button ID="btnRemovePlayer" runat="server" Text="-" OnClick="btnRemovePlayer_Click" /><br />
                <br />
                <asp:Button ID="btnCreateNewPlayer" runat="server" OnClick="btnCreateNewPlayer_Click" Text="Create New Player" />&nbsp;&nbsp;
                <asp:Button ID="btnCancelNewGame" runat="server" OnClick="btnCancelNewGame_Click" Text="Cancel" />
            </div>
        </asp:Panel>
        <asp:Panel ID="pnlCreateNewPlayer" runat="server" Visible="False">
            <div class="row">
                Player Name:<br /> 
                <asp:TextBox ID="tbPlayerName" runat="server"></asp:TextBox><br />
                Player Email:<br /> 
                <asp:TextBox ID="tbPlayerEmail" runat="server"></asp:TextBox><br />
                <br />
                <asp:Button ID="btnSaveNewPlayer" runat="server" Text="Create New Player" OnClick="btnSaveNewPlayer_Click" />&nbsp;&nbsp;
                <asp:Button ID="btnCancelCreateNewPlayer" runat="server" OnClick="btnCancelCreateNewPlayer_Click" Text="Cancel"/>
            </div>
        </asp:Panel>
    </div>
</asp:Content>
