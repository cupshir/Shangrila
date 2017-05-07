<%@ Page Title="" Language="C#" MasterPageFile="~/ShangriLa.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Default.aspx.cs" Inherits="ShangriLa.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .hiddencol { display: none; }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:HiddenField ID="SelectedGridCellIndex" runat="server" Value="-5" />

    <div class="container">
        <asp:Panel ID="pnlDefaultPanel" runat="server">
            <div class="page-header">
                <h2>ShangriLa Scoresheet</h2>
            </div>
            <asp:Button ID="btnStartNewGame" runat="server" Text="Start A Game" OnClick="btnStartNewGame_Click" /><br />
            <br />
            <asp:Button ID="btnActiveGames" runat="server" Text="Active Games" OnClick="btnActiveGames_Click" /><br />
            <br />
        </asp:Panel>
        <asp:Panel ID="pnlNewGame" runat="server" Visible="false">
            <div class="page-header">
                <h2>Start A New Game</h2>
            </div>
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
            <div class="page-header">
                <h2>Create A Player</h2>
            </div>
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
        <asp:Panel ID="pnlActiveGames" runat="server" Visible="false">
            <div class="page-header">
                <h2>Active Games</h2>
            </div>
            <div class="row">
                <asp:GridView ID="gvActiveGames" runat="server" AutoGenerateColumns="false" AllowSorting="true" CssClass="table table-bordered text-center"
                              OnRowDataBound="gvActiveGames_RowDataBound" OnSelectedIndexChanged="gvActiveGames_SelectedIndexChanged">
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="GameId" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                        <asp:BoundField DataField="CreatedDateTime" HeaderText="Created Date" HeaderStyle-CssClass="text-center" />
                    </Columns>
                </asp:GridView>

            </div>
            <div class="row">
                <asp:Button ID="btnCancelActiveGames" runat="server" OnClick="btnCancelActiveGames_Click" Text="Cancel" />
            </div>
        </asp:Panel>



    </div>
</asp:Content>
