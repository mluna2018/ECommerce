using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ECommerce.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "El campo  {0} es requerido.")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener maximo {1} caracteres.")]
        [Display(Name = "Descripcion")]
        [Index("Category_CompanyId_Description_Index", 2, IsUnique = true)]
        public string Description { get; set; }

        [Required(ErrorMessage = "El campo  {0} es requerido.")]
        [Range(1, double.MaxValue, ErrorMessage = "Debe seleccionar un dpto.")]

        [Index("Category_CompanyId_Description_Index", 1, IsUnique = true)]
        [Display(Name = "Compañia")]
        public int CompanyId { get; set; }

        public virtual Company Company { get; set; }
        public virtual ICollection<Product> Products { get; set; }

    }
}