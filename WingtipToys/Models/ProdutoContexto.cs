using System.Data.Entity;

namespace WingtipToys.Models
{
    public class ProdutoContexto : DbContext
    {

        public ProdutoContexto() : base("WingtipToys") 
        { 
        }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<CarrinhoItem> ItemCarrinhoCompras { get; set; }

    }
}