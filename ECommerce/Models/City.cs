using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ECommerce.Models
{
    public class City
    {
        [Key]
        public int CityId { get; set; }
        [Required(ErrorMessage = "El campo  {0} es requerido.")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener maximo {1} caracteres.")]
        [Display(Name = "Ciudad")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo  {0} es requerido.")]
        [Range(1, double.MaxValue, ErrorMessage = "Debe seleccionar un dpto.")]
        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; }

        public virtual ICollection<Company> Companies { get; set; }
    }
}