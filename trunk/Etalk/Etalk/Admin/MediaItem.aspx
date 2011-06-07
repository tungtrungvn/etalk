<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="MediaItem.aspx.cs" Inherits="Etalk.Web.Admin.MediaItem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
    <table>
        <tr>
            <td>Media type</td>
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>Series</td>
            <td>
                <asp:DropDownList ID="DropDownList2" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>Path</td>
            <td>
            
            </td>
        </tr>
        <tr>
            <td>Website</td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>File type</td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Script</td>
            <td>
                <asp:TextBox ID="TextBox3" runat="server" Height="100px" TextMode="MultiLine" 
                    Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Is disabled</td>
            <td>
                <asp:CheckBox ID="chkIsDisabled" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>
