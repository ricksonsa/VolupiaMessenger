<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="VolupiaWebClient._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="Login">
        <asp:TextBox ID="LoginTxtBox" runat="server"></asp:TextBox>
        <asp:Button ID="LoginBtn" runat="server" Text="Entrar" OnClick="LoginBtn_Click;return false;" UseSubmitBehavior="False" AutoPostBack="false" Visible="true"/>
    </div>


    <div class="grid">
        <div style="margin-top: 20px">
            <asp:TextBox ID="DisplayTxtBox" ClientIDMode="Static" runat="server" Height="200px" Width="1225px" TextMode="MultiLine" ReadOnly="true" OnTextChanged="DisplayTxtBox_TextChanged" Visible="true"></asp:TextBox>

            

            <asp:TextBox ID="InputTxtBox" ClientIDMode="Static" runat="server" Width="1229px"></asp:TextBox>
            <asp:Button ID="SendTxtBtn" runat="server" Text="Enviar" OnClick="SendTxtBtn_Click"  Visible="true"/>
        </div>
        <div>
            <label>Online</label>
            <asp:ListBox ID="UserListBox" ClientIDMode="Static" Visible="true" runat="server"></asp:ListBox>
        </div>
    </div>

</asp:Content>
