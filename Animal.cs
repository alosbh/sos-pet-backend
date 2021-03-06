﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiSOSPet
{
    public partial class Animal
    {
        public Animal()
        {
            Ocorrencia = new HashSet<Ocorrencia>();
        }

        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Required]
        [Column("especie")]
        [StringLength(20)]
        public string Especie { get; set; }
        [Required]
        [Column("porte")]
        [StringLength(1)]
        public string Porte { get; set; }
        [Column("raca")]
        [StringLength(20)]
        public string Raca { get; set; }
        [Column("foto")]
        [StringLength(50)]
        public string Foto { get; set; }

        [InverseProperty("IdanimalNavigation")]
        public virtual ICollection<Ocorrencia> Ocorrencia { get; set; }
    }
}