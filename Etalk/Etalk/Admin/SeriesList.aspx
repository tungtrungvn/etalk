<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="SeriesList.aspx.cs" Inherits="Etalk.Web.Admin.SeriesList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
    <asp:GridView ID="grvSeries" runat="server" AutoGenerateColumns="False" 
        onrowdeleting="grvSeries_RowDeleting">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Series id" />
            <asp:BoundField DataField="Name" HeaderText="Series name" />
            <asp:TemplateField HeaderText="Edit">
                <ItemTemplate>
                    <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edit" 
                        PostBackUrl='<%# "seriesedit.aspx?id=" + Eval("Id") %>'>Edit</asp:LinkButton>
                    &nbsp;&nbsp;
                    <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" 
                        CommandArgument='<%# Eval("Id") %>' 
                        onclientclick="javascript:return confirm('Do you want to remove this item ?')">Delete</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:Label ID="lblMessage" runat="server" ForeColor="red"></asp:Label>
</asp:Content>
