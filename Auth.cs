﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiSOSPet
{
    public partial class Auth
    {
        public Auth()
        {
            Ocorrencia = new HashSet<Ocorrencia>();
        }

 
        [Required]
        [Column("email")]
        [StringLength(50)]
        public string Email { get; set; }
 
        [Required]
        [Column("senha")]
        [StringLength(50)]
        public string Senha { get; set; }

        [InverseProperty("IdusuarioNavigation")]
        public virtual ICollection<Ocorrencia> Ocorrencia { get; set; }
    }
}