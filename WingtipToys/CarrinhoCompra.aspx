<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CarrinhoCompra.aspx.cs" Inherits="WingtipToys.CarrinhoCompra" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div id="CarrinhoTitle" runat="server" class="ContentHead">Carrinho de Compras</div>
    <asp:GridView 
        ID="CarrinhoLista" 
        runat="server" 
        AutoGenerateColumns="False" 
        ShowFooter="True" 
        GridLines="Vertical" 
        CellPadding="4"
        ItemType="WingtipToys.Models.CarrinhoItem"
        SelectMethod="GetCarrinhoContent"
        CssClass="table table-striped table-bordered" 
    >
        <Columns>
            <asp:BoundField DataField="ProdutoID" HeaderText="ID" SortExpression="ProdutoID" />
            <asp:BoundField DataField="Produto.ProdutoNome" HeaderText="Nome" />
            <asp:BoundField DataField="Produto.Preco" HeaderText="Preco" DataFormatString="{0:c}"  />            
            <asp:TemplateField HeaderText="Quantidade">
                <ItemTemplate>
                    <asp:TextBox ID="CompraQuantidade" Width="40" runat="server" Text="<%#: Item.Quantidade %>"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Total de itens">
                <ItemTemplate>
                    <<%#: String.Format("{0:c}", ((Convert.ToDouble(Item.Quantidade)) *  Convert.ToDouble(Item.Produto.Preco)))%>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Remover item">
                <ItemTemplate>
                    <asp:CheckBox ID="Remover" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <div>
        <p></p>
        <strong>
            <asp:Label ID="LabelTotalText" runat="server" Text="Total do pedido: "></asp:Label>
            <asp:Label ID="lblTotal" runat="server" EnableViewState="false"></asp:Label>
        </strong>
    </div>
    <br />
    <table>
        <tr>
            <td>
                <asp:Button ID="UpdateBtn" runat="server" Text="Atualizar" OnClick="UpdateBtn_Click" />
            </td>
            <td>

            </td>
        </tr>
    </table>
</asp:Content>
