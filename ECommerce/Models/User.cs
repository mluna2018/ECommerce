using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace ECommerce.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "El campo  {0} es requerido.")]
        [MaxLength(256, ErrorMessage = "El campo {0} debe tener maximo {1} caracteres.")]
        [Display(Name = "E-Mail")]
        [Index("User_UserName_Index", IsUnique = true)]
        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "El campo  {0} es requerido.")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener maximo {1} caracteres.")]
        [Display(Name = "Nombre")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "El campo  {0} es requerido.")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener maximo {1} caracteres.")]
        [Display(Name = "Apellido")]
        public string LastName { get; set; }

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
        [Display(Name = "Foto")]
        public string Photo { get; set; }

        [Required(ErrorMessage = "El campo  {0} es requerido.")]
        [Range(1, double.MaxValue, ErrorMessage = "Debe seleccionar un {0}.")]
        [Display(Name = "Departamento")]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "El campo  {0} es requerido.")]
        [Range(1, double.MaxValue, ErrorMessage = "Debe seleccionar un {0}.")]
        [Display(Name = "Ciudad")]
        public int CityId { get; set; }

        [Required(ErrorMessage = "El campo  {0} es requerido.")]
        [Range(1, double.MaxValue, ErrorMessage = "Debe seleccionar un {0}.")]
        [Display(Name = "Compañia")]
        public int CompanyId { get; set; }

        [Display(Name = "Usuario")]
        public string FullName { get { return string.Format("{0} {1}", FirstName, LastName); } }

        [NotMapped]
        public HttpPostedFileBase PhotoFile { get; set; }
        public virtual Department Department { get; set; }
        public virtual City City { get; set; }
        public virtual Company Company { get; set; }

    }
}