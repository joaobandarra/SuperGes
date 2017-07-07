using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SuperGes.Models
{
    public class CarrinhoCompras
    {
        public CarrinhoCompras()
        {
            ListaCarrinhoComprasProdutos = new HashSet<CarrinhoComprasProdutos>();
        }

        [Key]
        [Display(Name = "ID: ")]
        public int IDCarrinhoCompras { get; set; }

        [Required]
        [Column(TypeName = "date")]
        [Display(Name = "Data de Adição do Produto: ")]
        public DateTime DataAdicaoProduto { get; set; }


        // relaciona o objeto Cliente com um objeto CarrinhoCompras
        public virtual Cliente Cliente { get; set; }

        // cria um atributo para funcionar como FK, na BD
        // e relaciona-o com o atributo anterior
        [ForeignKey("Cliente")]
        public int IDClienteFK { get; set; }

        // especificar que um carrinho de compras tem muitos Carrinhos de compras/produto
        public virtual ICollection<CarrinhoComprasProdutos> ListaCarrinhoComprasProdutos { get; set; }
    }
}