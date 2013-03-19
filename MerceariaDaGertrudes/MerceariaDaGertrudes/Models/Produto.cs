using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MerceariaDaGertrudes.Models
{
    public class Produto
    {
        public int ProdutoId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome")]
        [StringLength(75, ErrorMessage = "O {0} deve ter no minimo {2} caracteres e no maximo {1}.", MinimumLength = 2)]
        public string Nome { get; set; }
        
        [Required(ErrorMessage = "Preencha o campo {0}")]
        [Display(Name = "Preço")]
        public decimal Preco { get; set; }
        
        [Required(ErrorMessage = "Preencha o campo {0}")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Validade { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
    }
}