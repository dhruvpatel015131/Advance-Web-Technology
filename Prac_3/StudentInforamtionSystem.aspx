<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StudentInforamtionSystem.aspx.cs" Inherits="Prac_3.StudentInforamtionSystem" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="DataBase Handle using Connected"></asp:Label>
        </div>
        <asp:Label ID="Label2" runat="server" Text="Enter RollNo:"></asp:Label>
        <asp:TextBox ID="txtRollNo" runat="server" style="margin-left: 27px"></asp:TextBox>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Enter Name:"></asp:Label>
        <asp:TextBox ID="txtName" runat="server" style="margin-left: 33px"></asp:TextBox>
        <br />
        <asp:Label ID="Label4" runat="server" Text="Enter Address:"></asp:Label>
        <asp:TextBox ID="txtAddress" runat="server" style="margin-left: 18px"></asp:TextBox>
        <asp:GridView ID="GVStudDetails" runat="server">
        </asp:GridView>
        <br /><br />
        <asp:Button ID="btnAdd" runat="server" Text="Add" Height="25px" OnClick="btnAdd_Click" />
        <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
        <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
         <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
         <asp:Button ID="btnSort" runat="server" Text="Sort" OnClick="btnSort_Click" style="height: 26px" />
        <asp:TextBox ID="txtDisplay" runat="server" style="margin-left: 21px"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnStoredProcedure" runat="server" Text="Stored Procedure" OnClick="btnStoredProcedure_Click" />
        &nbsp;<asp:Button ID="btnSearchStoredProcedure" runat="server" style="margin-left: 18px" Text="Search Stored Procedure" Width="156px" OnClick="btnSearchStoredProcedure_Click" />
        <asp:Button ID="btnDeleteStoredProcedure" runat="server" style="margin-left: 39px" Text="Delete Stored Procedure" OnClick="btnDeleteStoredProcedure_Click" />
        <asp:Button ID="btnUpdateStoredProcedure" runat="server" style="margin-left: 44px" Text="Update Stored Procedure" Width="150px" />
        <br />
        <br />
        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>

        
    </form>
</body>
</html>
