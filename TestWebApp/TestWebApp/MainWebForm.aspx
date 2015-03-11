<%@ Page Language="C#" Async="true" AutoEventWireup="true" EnableEventValidation="true" CodeBehind="MainWebForm.aspx.cs" Inherits="TestWebApp.MainWebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head>
        <title>
            Properties for SALE in London
        </title>
    </head>

    <body style="background: #ebebeb;">
        <h2 style=" text-align:center; font-size: 24px;">
            Properties for SALE in London
        </h2>

        <form id="form1" runat="server">
            <asp:Panel
                runat="server"
                Style="position: absolute; width: 99%; height: 99%; margin: 0;"
                BorderStyle="None">
                <asp:Table runat="server" Style="position: absolute; width: 100%; height: 100%; margin: 5px;">
                    <asp:TableRow>
                    
                        <asp:TableCell Style="width: 55%; vertical-align: top;">
                            <asp:FormView ID="PropertyDetailsView" runat="server">
                                <ItemTemplate>
                                    <tr style="vertical-align: top;"> 
                                        <td>
                                            <tr style="vertical-align: top;">
                                                <td>
                                                    <img src='<%# Eval("Image_Url")%>' style="image-rendering:optimizeQuality; background-size:cover; width:100%; margin-bottom:5px;"/>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="word-wrap:break-word; vertical-align: top;">
                                                    <div style="margin-bottom:15px; font-size: 22px; text-decoration: underline;">
                                                        <b> £ <%# Eval("Price") %> </b> - <%# Eval("Num_Bedrooms") %> bedroom  <%# Eval("Property_Type") %>    
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <tr>
                                                        <td>
                                                            <table style="width:100%;">
                                                                <tr style="vertical-align: top; margin-left:auto; margin-right:0;">
                                                                    <td style="vertical-align: top;">
                                                                        <div>
                                                                            <b>Location</b>
                                                                        </div>
                                                                        <div style="word-wrap:break-word; text-overflow: ellipsis; overflow: auto;">
                                                                            <%# Eval("Displayable_Address")%>    
                                                                        </div>
                                                                    </td>
                                                                    <td style="vertical-align: top; margin-left:auto; margin-right:0;">
                                                                        <div>
                                                                            <b>Published</b>
                                                                        </div>
                                                                        <div style="word-wrap:break-word; text-overflow: ellipsis; overflow: auto;">
                                                                            <%# Eval("Last_Published_Date")%>    
                                                                        </div>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr style="vertical-align: top;">
                                                        <td>
                                                            <div style="vertical-align: top; margin-top:10px; margin-left:1px;">
                                                                <b>Agency details</b>
                                                            </div>
                                                            <div>
                                                                <table>
                                                                    <tr>
                                                                        <td>
                                                                            <img src='<%# Eval("Agent_Logo")%>' style="background-size:contain; vertical-align:top; max-height:80px; margin-right:3px;"/>
                                                                        </td>
                                                                        <td style="vertical-align:top;">
                                                                            <div style="margin-bottom:3px; vertical-align:top;">
                                                                                Adress: <%# Eval("Agent_Address")%>            
                                                                            </div>
                                                                            <div>
                                                                                Phone number: <%# Eval("Agent_Phone")%> 
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </td>
                                                    </tr>    
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div style="text-overflow: ellipsis; overflow: auto; vertical-align: top; font-size: 15px; margin-top:15px">
                                                        <%# Eval("Description") %>             
                                                    </div>
                                                </td>
                                            </tr>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:FormView>
                        </asp:TableCell>
                    
                        <asp:TableCell Style="width: 45%;">
                            <asp:ListView ID="PropertiesListView"
                                runat="server"
                                EnableViewState="false"
                                OnSelectedIndexChanging="lvProperties_SelectedChanging"
                                OnSelectedIndexChanged="lvProperties_SelectedChanged"
                                ItemType="TestWebApp.Models.PropertyListing">
                                <LayoutTemplate>
                                    <table runat="server" style="margin-left:10px; margin-right:10px;">
                                        <tr id="ItemPlaceholder" runat="server"/>
                                    </table>
                                </LayoutTemplate>
                           
                                <ItemTemplate>
                                    <tr> 
                                        <td style="background: #D4D4D4">
                                            <table runat="server">
                                                <tr style="vertical-align: top;">
                                                    <td>
                                                        <asp:LinkButton runat="server" 
                                                            CommandName="Select"
                                                            Width="210px"
                                                            Height="160px"
                                                            style='<%# "background-image: url(" + Eval("Image_Url") + ")" %>'>
                                                        </asp:LinkButton>
                                                    </td>
                                                    <td >
                                                        <table runat="server" style="margin-left:5px">
                                                             <tr>
                                                                <td style="word-wrap:break-word; vertical-align: top; font-size: 18px;">
                                                                    <b> £ <%# Item.Price %> </b> - <%# Item.Num_Bedrooms %> bedroom  <%# Item.Property_Type %>
                                                                </td>
                                                            </tr>
                                                             <tr>
                                                                <td>
                                                                    <div style="text-overflow: ellipsis; overflow: auto; vertical-align: top; height: 125px; font-size: 15px; margin-top:10px">
                                                                        <%# Item.Description %>             
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr style="vertical-align: top;">
                                                    <td style="word-wrap:break-word; text-overflow: ellipsis; overflow: auto; vertical-align: top">
                                                        <%# Item.Displayable_Address %>
                                                    </td>
                                                </tr>
                                            </table>
                                            <div style="height: 1px; background: black;"/>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:ListView>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>

            </asp:Panel>
        </form>
    </body>
</html>
