<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ChangeMovie.aspx.cs" Inherits="ChangeMovie" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderLeft" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contentBody" Runat="Server">
    <p>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Book registration</p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;</p>
    <p>
        Title:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="textBoxTitle" Display="Dynamic" ErrorMessage="Title field could not be empty" ForeColor="Red">*</asp:RequiredFieldValidator>
        <asp:TextBox ID="textBoxTitle" runat="server"></asp:TextBox>
    </p>
    <p>
        Distribution:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="textBoxDistribution" Display="Dynamic" ErrorMessage="Author field could not be empty" ForeColor="Red">*</asp:RequiredFieldValidator>
        <asp:TextBox ID="textBoxDistribution" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="textBoxDistribution" Display="Dynamic" ErrorMessage="Error author" ForeColor="Red" ValidationExpression="^[a-zA-Z''-;'\s]{1,100}$">*</asp:RegularExpressionValidator>
    </p>
    <p>
        IMBD:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="textBoxIMBD" Display="Dynamic" ErrorMessage="ISBN field could not be empty" ForeColor="Red">*</asp:RequiredFieldValidator>
        <asp:TextBox ID="textBoxIMBD" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="textBoxIMBD" Display="Dynamic" ErrorMessage="Error ISBN" ForeColor="Red" ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?">*</asp:RegularExpressionValidator>
    </p>
    <p>
        Category:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;<asp:DropDownList ID="ddlCategory" runat="server" Height="16px"  style="margin-left: 0px" Width="124px">
            <asp:ListItem Selected="True">None</asp:ListItem>
            <asp:ListItem>Thriller</asp:ListItem>
            <asp:ListItem>Romance</asp:ListItem>
            <asp:ListItem>Children</asp:ListItem>
            <asp:ListItem>Science</asp:ListItem>
        </asp:DropDownList>
    </p>
    <p>
        Picture&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="textBoxPicture" Display="Dynamic" ErrorMessage="RequiredFieldValidator" ForeColor="Red">*</asp:RequiredFieldValidator>
&nbsp;<asp:TextBox ID="textBoxPicture" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="textBoxPicture" Display="Dynamic" ErrorMessage="RegularExpressionValidator" ForeColor="Red" ValidationExpression="^[a-zA-Z''-_'\s]{1,80}$">*</asp:RegularExpressionValidator>
    </p>
    <p>
        Price:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="textBoxPrice" Display="Dynamic" ErrorMessage="Price field could not be empty" ForeColor="Red">*</asp:RequiredFieldValidator>
        <asp:TextBox ID="textBoxPrice" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="textBoxPrice" Display="Dynamic" ErrorMessage="Price error" ForeColor="Red" ValidationExpression="^\d*\.?\d*$">*</asp:RegularExpressionValidator>
    </p>
    <p>
        Quantity&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="textBoxQuantity" ErrorMessage="RequiredFieldValidator" ForeColor="Red">*</asp:RequiredFieldValidator>
        <asp:TextBox ID="textBoxQuantity" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="textBoxQuantity" ErrorMessage="RegularExpressionValidator" ValidationExpression="^\d+$">*</asp:RegularExpressionValidator>
    </p>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" DisplayMode="List" />
   
     
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button11" runat="server"  Text="Back"  CausesValidation="false" OnClick="Button11_Click" Width="49px"/>
          <asp:Button ID="Button1" runat="server"  Text="Update"  CausesValidation="false" OnClick="Button1_Click" style="margin-left: 44px"/>

</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolderRight" Runat="Server">
</asp:Content>

