<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DataTableSample.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

        <asp:Button ID="ButtonShowAll" runat="server" Text="vis alt" OnClick="ButtonShowAll_Click" />

        <asp:GridView ID="GridView1" runat="server"  AllowPaging="True" PageSize="10" Width="1509px" style="margin-right: 27px" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical"  ViewStateMode="Enabled">
                <AlternatingRowStyle BackColor="#CCCCCC" />           
            </asp:GridView>
        <asp:TextBox ID="TextBoxSearchTelefonNR" runat="server"></asp:TextBox>
        <asp:Button ID="ButtonSearchTelefonNR" runat="server" Text="Søk på TelefonNR" OnClick="ButtonSearchTelefonNR_Click" />
    </form>
</body>
</html>
