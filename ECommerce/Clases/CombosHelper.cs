using ECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerce.Clases
{
    public class CombosHelper : IDisposable
    {
        private static ECommerceContext db = new ECommerceContext();

        public static List<Department> GetDepartments()
        {
            var departments = db.Departments.ToList();
            departments.Add(new Department
            {
                DepartmentId = 0,
                Nombre = "[Seleccione un dpto...]"
            });

            return departments.OrderBy(d => d.Nombre).ToList();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}