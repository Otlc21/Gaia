﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidade
{
    public class Car
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Modelo {  get; set; }

        [Required]
        public string Marca {  get; set; }

        [Required]
        public short Ano { get; set; }

        [Required]
        public string Categoria { get; set; }

        [Required]
        public int LocationId { get; set; }

        [ForeignKey("LocationId")]
        public Location Location { get; set; }

        [Required]
        public float Preco { get; set; }

        [Required]
        public int Quantidade { get; set; }

        [Required]
        public DateTime Criacao { get; set; }

    }
}
