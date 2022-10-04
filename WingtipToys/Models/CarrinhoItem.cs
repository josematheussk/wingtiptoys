using System.ComponentModel.DataAnnotations;

namespace WingtipToys.Models
{
    public class CarrinhoItem
    {
        [Key]
        public string ItemId { get; set; }
        public string CarrinhoId { get; set; }
        public int Quantidade { get; set; }
        public System.DateTime DataCriado { get; set; }
        public int ProdutoId { get; set; }
        public virtual Produto Produto { get; set; }
    }
}