<%@ Page Title="Produtos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
         CodeBehind="ProdutoLista.aspx.cs" Inherits="WingtipToys.ProdutoLista" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section>
        <div>
            <hgroup>
                <h2><%: Page.Title %></h2>
            </hgroup>

            <asp:ListView ID="produtoLista" runat="server" 
                DataKeyNames="ProdutoID" GroupItemCount="4"
                ItemType="WingtipToys.Models.Produto" SelectMethod="GetProducts">
                <EmptyDataTemplate>
                    <table >
                        <tr>
                            <td>No data was returned.</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <EmptyItemTemplate>
                    <td/>
                </EmptyItemTemplate>
                <GroupTemplate>
                    <tr id="itemPlaceholderContainer" runat="server">
                        <td id="itemPlaceholder" runat="server"></td>
                    </tr>
                </GroupTemplate>
                <ItemTemplate>
                    <td runat="server">
                        <table>
                            <tr>
                                <td>
                                    <a href="ProdutoDetalhes.aspx?produtoID=<%#:Item.ProdutoID%>">
                                        <img src="/Catalog/Images/Thumbs/<%#:Item.ImagePath%>"
                                            width="100" height="75" style="border: solid" /></a>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <a href="ProdutoDetalhes.aspx?produtoID=<%#:Item.ProdutoID%>">
                                        <span>
                                            <%#:Item.ProdutoNome%>
                                        </span>
                                    </a>
                                    <br />
                                    <span>
                                        <b>Preço: </b><%#:String.Format("{0:c}", Item.Preco)%>
                                    </span>
                                    <br />
                                    <a href="/AddCarrinho.aspx?produtoID=<%#:Item.ProdutoID %>">               
                                        <span class="ProutoListaItem">
                                            <b>Adicionar ao carrinho<b>
                                        </span>           
                                    </a>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                        </p>
                    </td>
                </ItemTemplate>
                <LayoutTemplate>
                    <table style="width:100%;">
                        <tbody>
                            <tr>
                                <td>
                                    <table id="groupPlaceholderContainer" runat="server" style="width:100%">
                                        <tr id="groupPlaceholder"></tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                            </tr>
                            <tr></tr>
                        </tbody>
                    </table>
                </LayoutTemplate>
            </asp:ListView>
        </div>
    </section>
</asp:Content>