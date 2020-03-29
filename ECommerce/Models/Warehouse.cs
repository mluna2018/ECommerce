using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ECommerce.Models
{
    public class Warehouse
    {
        [Key]
        public int WarehouseId { get; set; }

        [Required(ErrorMessage = "El campo  {0} es requerido.")]
        [Range(1, double.MaxValue, ErrorMessage = "Debe seleccionar un {0}.")]
        [Display(Name = "Compañia")]
        [Index("Warehouse_CompanyId_Name_Index", 1, IsUnique = true)]
        public int CompanyId { get; set; }

        [Required(ErrorMessage = "El campo  {0} es requerido.")]
        [MaxLength(256, ErrorMessage = "El campo {0} debe tener maximo {1} caracteres.")]
        [Display(Name = "Bodega")]
        [Index("Warehouse_CompanyId_Name_Index", 2, IsUnique = true)]
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

        [Required(ErrorMessage = "El campo  {0} es requerido.")]
        [Range(1, double.MaxValue, ErrorMessage = "Debe seleccionar un {0}.")]
        [Display(Name = "Departamento")]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "El campo  {0} es requerido.")]
        [Range(1, double.MaxValue, ErrorMessage = "Debe seleccionar un {0}.")]
        [Display(Name = "Ciudad")]
        public int CityId { get; set; }

        public virtual Department Department { get; set; }
        public virtual City City { get; set; }
        public virtual Company Company { get; set; }
        public virtual ICollection<Inventory> Inventories { get; set; }

    }
}