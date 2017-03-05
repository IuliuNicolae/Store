<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CheckOut.aspx.cs" Inherits="CheckOut" EnableEventValidation="false"%>


<asp:Content ID="Content1" ContentPlaceHolderID="title" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderLeft" Runat="Server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="contentBody" Runat="Server">

    <p>
        <br />
    </p>
    <p>
        <asp:Button ID="Button10" runat="server" OnClick="Button10_Click" style="width: 46px" Text="Back" />
    &nbsp;&nbsp;
        <!--<form action="https://www.sandbox.paypal.com/cgi-bin/webscr" method="POST"> -->
       
        
        <input type="hidden" name="upload" value="1"/>
        <input type="hidden" name="return" value="http://localhost:52483/paymentConfermation.aspx"/>
        <input type="hidden" name="cmd" value="_cart"/>
        <input type="hidden" name="business" value="business@moviestore.se"/>
        <input type="hidden" name="currency_code" value="lei"/>
       
        <%List<Movies> movies = (List<Movies>)Session["myMovies"];


            for (int i = 0; i < movies.Count; i++)
            {

        %>
        <input type="hidden" name="item_name_<%=i + 1 %>" value="<%=movies[i].Title%>"/>
        <input type="hidden" name="amount_<%=i + 1 %>" value="<%=movies[i].Price %>"/>
        <input type="hidden" name="quantity_<%=i + 1 %>" value="<%=movies[i].Quantity%>"/>
        <%
            }
             %>
        <asp:Button id="payNow" text="Complete purchase" runat="server" PostBackUrl="https://www.sandbox.paypal.com/cgi-bin/webscr" OnClick="payNow_Click" />
        <!-- </form> -->
    </p>
    <p>
        &nbsp;</p>
    <p>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Total Price &nbsp;<asp:Label ID="labelPrice" runat="server" ForeColor="Red"></asp:Label>
    </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:GridView ID="showContent" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDeleting="showContent_RowDeleting" >
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:CommandField HeaderText="Operation" ShowDeleteButton="True" ShowHeader="True" />
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
    </p>

</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolderRight" Runat="Server">
</asp:Content>

