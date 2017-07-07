using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SuperGes.Models
{
    public class EncomendaProduto
    {
        [Key]
        [Display(Name = "ID: ")]
        public int IDEncomendaProduto { get; set; }


        [Required]
        [StringLength(255)]
        [Display(Name = "Nome do Produto: ")]
        public string NomeProduto { set; get; }

        [Required]
        [Display(Name = "Quantidade: ")]
        public int Quantidade { set; get; }

        [Required]
        [Display(Name = "Preço: ")]
        public double Preco { set; get; }

        [Required]
        [Display(Name = "IVA: ")]
        public double IVA { get; set; }

        // criar a chave forasteira
        // relaciona o objeto Encomenda com um objeto EncomendaProduto
        public virtual Encomenda Encomenda { get; set; }
        // relaciona o objeto Produto com um objeto EncomendaProduto
        public virtual Produto Produto { get; set; }

        // cria um atributo para funcionar como FK, na BD
        // e relaciona-o com o atributo anterior
        [ForeignKey("Encomenda")]
        public int IDEncomendaFK { get; set; }

        [ForeignKey("Produto")]
        public int IDProdutoFK { get; set; }
    }
}