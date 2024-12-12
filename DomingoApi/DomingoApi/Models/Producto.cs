﻿using System.ComponentModel.DataAnnotations;

namespace DomingoApi.Models
{
    public class Producto
    {
        [Key]
        public int? ProductID { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}