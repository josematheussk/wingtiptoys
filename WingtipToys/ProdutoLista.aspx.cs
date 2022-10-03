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
    public partial class ProdutoLista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<Produto> GetProducts(
            [QueryString("id")] int? categoriaId,
            [RouteData] string categoriaNome)
        {
            var _db = new WingtipToys.Models.ProdutoContexto();
            IQueryable<Produto> query = _db.Produtos;

            if(categoriaId.HasValue && categoriaId > 0)
            {
                query = query.Where(p => p.CategoriaID == categoriaId);
            }

            if (!String.IsNullOrEmpty(categoriaNome))
            {
                query = query.Where(p => String.Compare(p.Categoria.CategoriaNome, categoriaNome) == 0);
            }

            return query;
        }
    }
}