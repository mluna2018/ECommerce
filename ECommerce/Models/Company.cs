using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace ECommerce.Models
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }

        [Required(ErrorMessage = "El campo  {0} es requerido.")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener maximo {1} caracteres.")]
        [Display(Name = "Compañia")]
        [Index("Company_Name_Index", IsUnique = true)]
        public string Name { get; set; }

        [Required(ErrorMessage = "El campo  {0} es requerido.")]
        [MaxLength(20, ErrorMessage = "El campo {0} debe tener maximo {1} caracteres.")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telefono")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "El campo  {0} es requerido.")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener maximo {1} caracteres.")]
        [Display(Name = "Direccion")]
        public string Address { get; set; }

        
        [DataType(DataType.ImageUrl)]
        public string Logo { get; set; }

        [Required(ErrorMessage = "El campo  {0} es requerido.")]
        [Range(1, double.MaxValue, ErrorMessage = "Debe seleccionar un {0}.")]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "El campo  {0} es requerido.")]
        [Range(1, double.MaxValue, ErrorMessage = "Debe seleccionar un {0}.")]
        public int CityId { get; set; }

        [NotMapped]
        public HttpPostedFileBase LogoFile { get; set; }
        public virtual Department Department { get; set; }
        public virtual City City { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
    }
}