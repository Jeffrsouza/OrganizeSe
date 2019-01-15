<%@ Page Title="" Language="C#" MasterPageFile="~/src/Home.Master" AutoEventWireup="true" CodeBehind="blog.aspx.cs" Inherits="Organizese.src.blog" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="bodyPosts">
        <asp:Repeater runat="server" ID="RptPrincipal">
            <ItemTemplate>
                <div class="textPost">
                    <div>
                        <asp:Image runat="server" src='<%# "data:image/png;base64,"+ Eval("ARQUIVO") %>' class="imgFull"  />
                    </div>
                    <a href="index.aspx?id=<%# Eval("ID") %>"><p class="title"><%# Eval("TITULO") %></p></a>
                    <div class="textRight">
                        <span runat="server"><%#Eval("CATEGORIA")%></span>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <div class="separador"></div>
        <div class="separador"></div>
        <div class="separador"></div>
        <div class="bodyPostsSecundarios">
            <asp:Repeater runat="server" ID="RptSecundario">
                <ItemTemplate>                               
                    <div class="postsSecundarios">  
                        <div class="textRight">
                            <span runat="server"><%#Eval("CATEGORIA")%></span>
                        </div>        
                        <a href="index.aspx?id=<%# Eval("ID") %>">   
                         <asp:Image runat="server" src='<%# "data:image/png;base64,"+ Eval("ARQUIVO") %>' class="imgSecundaria" />
                        <p class="subTitle"><%# Eval("TITULO") %></p></a>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
