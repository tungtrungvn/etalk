<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="TopicEdit.aspx.cs" Inherits="Etalk.Web.Admin.TopicEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
    <table>
        <tr id="SeriesId" runat="server" visible="false">
            <td>Topic Id</td>
            <td>
                <asp:Label ID="lblTopicId" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>Topic title</td>
            <td>
                <asp:TextBox ID="txtTopicTitle" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr runat="server" id="IsDisabled" visible="false">
            <td>Is disabled</td>
            <td>
                <asp:CheckBox ID="chkIsDisabled" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                <asp:Button ID="btnSave" runat="server" Text="Save" onclick="btnSave_Click" 
                    Width="63px" />
            </td>
        </tr>
    </table>
    <asp:Label ID="lblMessage" runat="server" ForeColor="red"></asp:Label>

</asp:Content>
