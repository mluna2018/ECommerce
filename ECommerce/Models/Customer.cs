﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ECommerce.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "El campo  {0} es requerido.")]
        [Range(1, double.MaxValue, ErrorMessage = "Debes seleccionar una {0}")]
        [Display(Name = "Compañia")]
        public int CompanyId { get; set; }

        [Required(ErrorMessage = "El campo  {0} es requerido.")]
        [MaxLength(256, ErrorMessage = "El campo {0} debe tener maximo {1} caracteres.")]
        [Display(Name = "E-Mail")]
        [Index("Customer_UserName_Index", IsUnique = true)]
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
        public string Phone { get; set; }

        [Required(ErrorMessage = "El campo  {0} es requerido.")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener maximo {1} caracteres.")]
        [Display(Name = "Direccion")]
        public string Address { get; set; }

        [Required(ErrorMessage = "El campo  {0} es requerido.")]
        [Range(1, double.MaxValue, ErrorMessage = "Debes seleccionar una {0}")]
        [Display(Name = "Departamento")]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "El campo  {0} es requerido.")]
        [Range(1, double.MaxValue, ErrorMessage = "Debes seleccionar una {0}")]
        [Display(Name = "Ciudad")]
        public int CityId { get; set; }

        [Display(Name = "Cliente")]
        public string FullName { get { return string.Format("{0} {1}", FirstName, LastName); } }

        public virtual Department Department { get; set; }

        public virtual City City { get; set; }

        public virtual Company Company { get; set; }

    }
}