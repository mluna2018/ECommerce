using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommerce.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage ="El campo  {0} es requerido.")]
        [MaxLength(50, ErrorMessage ="El campo {0} debe tener maximo {1} caracteres.")]
        public string Nombre { get; set; }

    }
}