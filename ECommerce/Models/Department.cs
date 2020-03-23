using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Display(Name = "Departamento")]
        [Index("Department_Nombre_Index", IsUnique = true)]

        public string Nombre { get; set; }

        public virtual  ICollection<City> Cities { get; set; }
        public virtual  ICollection<Company> Companies { get; set; }
        public virtual  ICollection<User> Users { get; set; }



    }
}