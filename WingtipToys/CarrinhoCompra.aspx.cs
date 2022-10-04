using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WingtipToys.Models;
using WingtipToys.Logic;
using System.Collections.Specialized;
using System.Collections;
using System.Web.ModelBinding;

namespace WingtipToys
{
    public partial class CarrinhoCompra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (CarrinhoCompraAto usuarioCarrinhoCompra = new CarrinhoCompraAto())
            {
                decimal carrinhoTotal = 0;
                carrinhoTotal = usuarioCarrinhoCompra.GetTotal();
                if(carrinhoTotal > 0)
                {
                    lblTotal.Text = String.Format("{0:c}", carrinhoTotal);
                }
                else
                {
                    LabelTotalText.Text = "";
                    lblTotal.Text = "";
                    CarrinhoTitle.InnerText = "Carrinho de compras está vazio";
                    UpdateBtn.Visible = false;
                }
            }
        }

        public List<CarrinhoItem> GetCarrinhoContent()
        {
            CarrinhoCompraAto atos = new CarrinhoCompraAto();
            return atos.GetCarrinhoContent();
        }

        public List<CarrinhoItem> AtualizarItensCarrinho()
        {
            using (CarrinhoCompraAto usersShoppingCart = new CarrinhoCompraAto())
            {
                String cartId = usersShoppingCart.GetCarrinhoId();

                CarrinhoCompraAto.ShoppingCartUpdates[] cartUpdates = new CarrinhoCompraAto.ShoppingCartUpdates[CarrinhoLista.Rows.Count];
                for (int i = 0; i < CarrinhoLista.Rows.Count; i++)
                {
                    IOrderedDictionary rowValues = new OrderedDictionary();
                    rowValues = GetValues(CarrinhoLista.Rows[i]);
                    cartUpdates[i].ProdutoId = Convert.ToInt32(rowValues["ProdutoID"]);

                    CheckBox cbRemove = new CheckBox();
                    cbRemove = (CheckBox)CarrinhoLista.Rows[i].FindControl("Remover");
                    cartUpdates[i].RemoveItem = cbRemove.Checked;

                    TextBox quantityTextBox = new TextBox();
                    quantityTextBox = (TextBox)CarrinhoLista.Rows[i].FindControl("CompraQuantidade");
                    cartUpdates[i].PurchaseQuantity = Convert.ToInt16(quantityTextBox.Text.ToString());
                }
                usersShoppingCart.AttCarrinhoDB(cartId, cartUpdates);
                CarrinhoLista.DataBind();
                lblTotal.Text = String.Format("{0:c}", usersShoppingCart.GetTotal());
                return usersShoppingCart.GetCarrinhoContent();
            }
        }

        public static IOrderedDictionary GetValues(GridViewRow row)
        {
            IOrderedDictionary values = new OrderedDictionary();
            foreach (DataControlFieldCell cell in row.Cells)
            {
                if (cell.Visible)
                {
                    // Extract values from the cell.
                    cell.ContainingField.ExtractValuesFromCell(values, cell, row.RowState, true);
                }
            }
            return values;
        }

        protected void UpdateBtn_Click(object sender, EventArgs e)
        {
            AtualizarItensCarrinho();
        }

    }
}