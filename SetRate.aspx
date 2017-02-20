<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SetRate.aspx.cs" Inherits="SetRate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderLeft" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contentBody" Runat="Server">
    Choose operation:&nbsp;&nbsp;&nbsp;
    <br />
    <br />
&nbsp;<asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged1">
        <asp:ListItem  Selected="True">Comments</asp:ListItem>
        <asp:ListItem>Rate</asp:ListItem>
    </asp:RadioButtonList>
    <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
    <br />
    List:
<br />
    <asp:DropDownList ID="DropDownListRate" runat="server">
    </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="buttonRate" runat="server" Text="Set a rate" />
    <br />
    <br />
    <asp:DropDownList ID="DropDownListComments" runat="server">
    </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="buttonComments" runat="server" Text="Set a comment" />
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolderRight" Runat="Server">
</asp:Content>

