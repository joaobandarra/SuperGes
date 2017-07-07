using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SuperGes.Models
{
    public class Cliente
    {
        // vai representar os dados da tabela dos Clientes

        // criar o construtor desta classe
        // e carregar a lista de Carrinhos de compras
        public Cliente()
        {
            ListaCarrinhoCompras = new HashSet<CarrinhoCompras>();
            ListaEncomendas = new HashSet<Encomenda>();
        }

        [Key]
        [Display(Name = "ID: ")]
        public int IDCliente { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Nome: " )]
        [RegularExpression("[A-Z][a-záéíóúàèìòùçâêîôûãõäëïöüñ]+(( |'|-|( (de|das|dos|e|) )| ( d'))[A-Z][a-záéíóúàèìòùçâêîôûãõäëïöüñ]+)*", ErrorMessage ="Por favor, certifique-se de que o nome tem de conter pelo menos duas palavras que têm de começar por maiusculas e não deverá conter algarismos")]
        public string Nome { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Morada: ")]
        public string Morada { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Email: ")]
        //[RegularExpression("[\w._%+-]+@[\w.-]+\.[\w]{2,}", ErrorMessage ="por favor verifique se introduziu bem o mail, certifique-se que não insira caracteres especiais com a excepção de um ponto final ou um hifen.")]
        public string Email { get; set; }

        [StringLength(255)]
        [Display(Name = "Informação Cartão de Crédito: ")]
        public string InfoCartaoCredito { get; set; }

        [Required]
        [StringLength(9), MinLength(9)]
        [RegularExpression("[0-9]{9}", ErrorMessage ="Por favor, certifique-se de que o nif tenha apenas 9 caracteres numéricos")]
        [Display(Name = "Numero de Identificação Fiscal: ")]
        public string NIF { get; set; }

        // especificar que um cliente tem muitos Carrinhos de compras
        public virtual ICollection<CarrinhoCompras> ListaCarrinhoCompras { get; set; }
        // especificar que um cliente faz muitas encomendas
        public virtual ICollection<Encomenda> ListaEncomendas { get; set; }
    }
}
