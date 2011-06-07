<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="TopicList.aspx.cs" Inherits="Etalk.Web.Admin.TopicList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
    <asp:GridView ID="grvTopics" runat="server" AutoGenerateColumns="False" 
        onrowdeleting="grvTopics_RowDeleting">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Topic id" />
            <asp:BoundField DataField="Title" HeaderText="Topic name" />
            <asp:BoundField DataField="IsDisabled" HeaderText="Is disabled" />
            <asp:TemplateField HeaderText="Edit">
                <ItemTemplate>
                    <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edit" 
                        PostBackUrl='<%# "topicedit.aspx?id=" + Eval("Id") %>'>Edit</asp:LinkButton>
                    &nbsp;&nbsp;
                    <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete" 
                        CommandArgument='<%# Eval("Id") %>' 
                        onclientclick="javascript:return confirm('Do you want to remove this item ?')">Delete</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            There is no series.
        </EmptyDataTemplate>
    </asp:GridView>
    <asp:Label ID="lblMessage" runat="server" ForeColor="red"></asp:Label>
</asp:Content>
