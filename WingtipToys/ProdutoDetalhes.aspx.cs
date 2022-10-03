using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WingtipToys.Models;
using System.Web.ModelBinding;

namespace WingtipToys
{
    public partial class ProdutoDetalhes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<Produto> GetProduct(
                            [QueryString("ProdutoID")] int? produtoId,
                            [RouteData] string produtoNome)
        {
            var _db = new WingtipToys.Models.ProdutoContexto();
            IQueryable<Produto> query = _db.Produtos;
            if (produtoId.HasValue && produtoId > 0)
            {
                query = query.Where(p => p.ProdutoID == produtoId);
            }
            else if (!String.IsNullOrEmpty(produtoNome))
            {
                query = query.Where(p =>
                          String.Compare(p.ProdutoNome, produtoNome) == 0);
            }
            else
            {
                query = null;
            }
            return query;
        }
    }
}