﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdminTools.aspx.cs" Inherits="AdminTools" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderLeft" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contentBody" Runat="Server">
    <p>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Administror&#39;s tools:</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        <asp:LinkButton ID="linkNewBook" runat="server" OnClick="LinkButton2_Click">Add new movie</asp:LinkButton>
    </p>
     <p>
        <asp:LinkButton ID="LinkButton10" runat="server" OnClick="LinkButton10_Click">View All Movies</asp:LinkButton>
    </p>
    <p>
        <asp:LinkButton ID="linkAllCusomers" runat="server" OnClick="linkAllCusomers_Click">View all customers</asp:LinkButton>
    </p>
    <p>
        <asp:LinkButton ID="LinkButton8" runat="server" OnClick="LinkButton8_Click">View advertize situation</asp:LinkButton>
    </p>
    <p>
        <asp:LinkButton ID="LinkButton9" runat="server" OnClick="LinkButton9_Click">Statistics</asp:LinkButton>
    </p>
    
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolderRight" Runat="Server">
</asp:Content>

