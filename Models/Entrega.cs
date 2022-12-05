using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Postagem.Models
{
    public class Entrega
    {
        
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            [Key, Column(Order = 0)]
             public int Id { get; set; }

            [Required]
            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
            public  DateTime Data { get; set; }

            
            [ForeignKey("Carta"), Column(Order = 1)]
            [Required]
            public string IdCarta{ get; set; }
            public virtual Carta Carta{ get; set; }

           
            [ForeignKey("Territorio"), Column(Order = 2)]
            [Required]
            public int IdTerritorio { get; set; }
            public virtual Territorio Territorio { get; set; }

            [Required]
            public string Local { get; set; }

            [Required]
            public string Status { get; set; }

             public ICollection<Carta> CartasEntregues{get;set;}

              public ICollection<Territorio> TerritoriosPercorrido  {get;set;}

    }
}