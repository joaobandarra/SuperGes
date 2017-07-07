using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SuperGes.Models
{
    public class TiposEnvio
    {
        public TiposEnvio()
        {
            ListaEncomendas = new HashSet<Encomenda>();

        }

        [Key]
        [Display(Name = "ID: ")]
        public int ID { set; get; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Tipo de Envio: ")]
        public string TipoEnvio { set; get; }


        // especificar que um cliente faz muitas encomendas
        public virtual ICollection<Encomenda> ListaEncomendas { get; set; }
    }
}