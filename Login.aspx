<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderLeft" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contentBody" Runat="Server">
    <asp:Label runat="server" >Login</asp:Label>
    <br />
    <asp:Label runat="server" ID="errorL"></asp:Label>
    <br />
    <asp:Label runat="server">Email:</asp:Label>
    <asp:TextBox runat="server" ID="emailTB"></asp:TextBox>
    <br />
    <asp:Label runat="server">Password:</asp:Label>
    <asp:TextBox runat="server" ID="passTB" TextMode="Password" ></asp:TextBox>
    <br />
    <asp:Button runat="server" Text="Login" OnClick ="login_Click"/>
    <br />
    <asp:LinkButton runat="server" OnClick="createUser_Click">Create User</asp:LinkButton>

</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolderRight" Runat="Server">
</asp:Content>

