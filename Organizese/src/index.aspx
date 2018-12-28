<%@ Page Title="" Language="C#" MasterPageFile="~/src/Home.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Organizese.src.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="bodyPosts">
        <asp:Repeater runat="server" ID="RptPosts">
            <ItemTemplate>
                <div class="textPost">
                    <div class="textRight">
                        <img style="width: 25px; height: 25px;" src="img/calendar.png" />
                        <span runat="server"><%#Eval("DATA")%></span>
                    </div>
                    <p class="title"><%# Eval("TITULO") %></p>
                   
                     <!--Imagem Linha inteira-->
                    <div>
                        <asp:Image runat="server" src=<%# "data:image/png;base64,"+ Eval("ARQUIVO") %> class="imgFull" />
                    </div>
                    <br/>
                    <br/>
                    <p>
                        <%# Eval("TEXTO") %>
                    </p>

                     <!--
                    <div class="textRight">
                        <a class="btn btn-primary btn-xs">Read more</a>
                        <a class="btn btn-danger btn-xs">Delete</a>
                    </div>
                         -->
                </div>
                <div class="separador">
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>

