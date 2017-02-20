<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderLeft" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contentBody" Runat="Server">
   <asp:Label Text="Email:" runat="server"/>
   <asp:TextBox runat="server" ID="emailTB"/>
   <asp:Label Text="Passward:" runat="server"/>
   <asp:TextBox runat="server" ID="passTB"/>
   <asp:Button ID="loginB" runat="server" Text="Log in" OnClick="loginB_Click"/>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolderRight" Runat="Server">
</asp:Content>

