using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using WingtipToys.Logic;


namespace WingtipToys
{
    public partial class AddCarrinho : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string rawId = Request.QueryString["ProdutoID"];
            int produtoId;
            if (!String.IsNullOrEmpty(rawId) && int.TryParse(rawId, out produtoId))
            {
                using (CarrinhoCompraAto usuarioCarrinhoCompra = new CarrinhoCompraAto())
                {
                    usuarioCarrinhoCompra.AddToCarrinho(Convert.ToInt16(rawId));
                }
            }
            else
            {
                Debug.Fail("ERRO: Não deverívamos ter te enviado para AddCarrinho.aspx sem um ProdutoId.");
                throw new Exception("ERRO:É ilegal carregar AddCarrinho.aspx sem um ProdutoId. ");
            }
            Response.Redirect("CarrinhoCompra.aspx");
        }
    }
}