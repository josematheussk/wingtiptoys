﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WingtipToys.Models
{
    public class Categoria
    {
        [ScaffoldColumn(false)]
        public int CategoriaID { get; set; }

        [Required, StringLength(100), Display(Name = "Nome")]
        public string CategoriaNome { get; set; }

        [Display(Name = "Descrição do Produto")]
        public string Descricao { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }
    }
}