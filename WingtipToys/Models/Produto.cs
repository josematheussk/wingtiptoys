using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WingtipToys.Models
{
    public class Produto
    {
        
        [ScaffoldColumn(false)]
        public int ProdutoID { get; set; }
        
        [Required, StringLength(100), Display(Name = "Nome")]
        public string ProdutoNome { get; set; }

        [Required, StringLength(10000), Display(Name = "Descrição do produto"), DataType(DataType.MultilineText)]
        public string Descricao { get; set; }

        public string ImagePath { get; set; }

        [Display(Name = "Preço")]
        public double? Preco { get; set; }

        public int? CategoriaID { get; set; }
        
        public virtual Categoria Categoria { get; set; }
    }
}