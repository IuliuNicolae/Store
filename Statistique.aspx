<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Statistique.aspx.cs" Inherits="Statistique" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderLeft" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contentBody" Runat="Server">


    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    
   @{ 
var myChart = new Chart(width: 600, height: 400) 
   .AddTitle("Employees") 
   .AddSeries(chartType: "column",
      xValue: new[] { "Peter", "Andrew", "Julie", "Mary", "Dave" }, 
      yValues: new[] { "2", "6", "4", "5", "3" }) 
   .Write();
}

    


</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolderRight" Runat="Server">
</asp:Content>

