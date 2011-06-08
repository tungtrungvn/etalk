<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="MediaItem.aspx.cs" Inherits="Etalk.Web.Admin.MediaItem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .
        {
            display: table-cell
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphContent" runat="server">
    <table>
        <tr>
            <td>Media type</td>
            <td>
                <asp:DropDownList ID="ddlMediaType" runat="server" Width="100px">
                    <asp:ListItem Value="1">Video</asp:ListItem>
                    <asp:ListItem Value="2">Audio</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>Series</td>
            <td>
                <asp:DropDownList ID="ddlSeries" runat="server" Width="300px" 
                    DataSourceID="odsSeries" DataTextField="Name" DataValueField="Id">
                </asp:DropDownList>
                <asp:ObjectDataSource ID="odsSeries" runat="server" 
                    SelectMethod="GetSeriesList" TypeName="Etalk.Bussiness.SeriesProcess">
                </asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td>Topic</td>
            <td>
            <div style="overflow:auto;height:100px;width:300px">
                <asp:CheckBoxList ID="lstTopic" runat="server" Height="100px" Width="280px" 
                    DataSourceID="odsTopics" DataTextField="Title" DataValueField="Id">
                </asp:CheckBoxList>
                <asp:ObjectDataSource ID="odsTopics" runat="server" SelectMethod="GetTopicList" 
                    TypeName="Etalk.Bussiness.TopicProcess"></asp:ObjectDataSource>
                    </div>
            </td>
        </tr>
        <tr>
            <td>Path</td>
            <td>
            
                <asp:TextBox ID="txtPath" runat="server" Width="300px"></asp:TextBox>
            
            </td>
        </tr>
        <tr>
            <td>Website</td>
            <td>
                <asp:TextBox ID="txtWebSite" runat="server" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>File type</td>
            <td>
                <asp:TextBox ID="txtFileType" runat="server" Width="300px"></asp:TextBox>
            </td>
            <td>flv, mp3 ...</td>
        </tr>
        <tr>
            <td>Script</td>
            <td>
                <asp:TextBox ID="txtScript" runat="server" Height="100px" TextMode="MultiLine" 
                    Width="300px"></asp:TextBox>
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
