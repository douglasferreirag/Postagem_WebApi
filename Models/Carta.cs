using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Postagem.Models
{
    public class Carta
    {

            [Key]
             public string Id { get; set; }

            [Required]
            public string Tema { get; set; }

            [Required]
            public string Base { get; set; }

          

        
    }
}