﻿using ECommerce.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace ECommerce.Clases
{

    public class UsersHelper : IDisposable
    {
        /// <summary>
        /// contextos de BDS
        /// </summary>
        private static ApplicationDbContext userContext = new ApplicationDbContext();
        private static ECommerceContext db = new ECommerceContext();

        /// <summary>
        /// Metodo para eliminar usuario de la tabla netUser
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static bool DeleteUser(string userName)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(userContext));
            var serASP = userManager.FindByEmail(userName);
            if (serASP == null)
            {
                return false;
            }
            var response = userManager.Delete(serASP);
           return  response.Succeeded;
        }

        /// <summary>
        /// Metodo para Actualizar usuario de la tabla netUser
        /// </summary>
        /// <param name="CurrentUserName"></param>
        /// <param name="newUserName"></param>
        /// <returns></returns>
        public static bool UpdateUserName(string CurrentUserName, string newUserName )
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(userContext));
            var userASP = userManager.FindByEmail(CurrentUserName);
            if (userASP == null)
            {
                return false;
            }
            userASP.UserName = newUserName;
            userASP.Email = newUserName;
            var response = userManager.Update(userASP);
            return response.Succeeded;
        }

        /// <summary>
        /// Valida el Rol si no existe lo crea
        /// </summary>
        /// <param name="roleName"></param>
        public static void CheckRole(string roleName)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(userContext));

            // Check to see if Role Exists, if not create it
            if (!roleManager.RoleExists(roleName))
            {
                roleManager.Create(new IdentityRole(roleName));
            }
        }

        /// <summary>
        /// Crea usuarios en el aplicativo
        /// </summary>
        public static void CheckSuperUser()
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(userContext));
            var email = WebConfigurationManager.AppSettings["AdminUser"];
            var password = WebConfigurationManager.AppSettings["AdminPassWord"];
            var userASP = userManager.FindByName(email);
            if (userASP == null)
            {
                CreateUserASP(email, "Admin", password);
                return;
            }

            userManager.AddToRole(userASP.Id, "Admin");
        }
        public static void CreateUserASP(string email, string roleName)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(userContext));

            var userASP = new ApplicationUser
            {
                Email = email,
                UserName = email,
            };

            userManager.Create(userASP, email);
            userManager.AddToRole(userASP.Id, roleName);
        }

        /// <summary>
        /// Crea usuario en la tabla net user
        /// </summary>
        /// <param name="email"></param>
        /// <param name="roleName"></param>
        /// <param name="password"></param>
        public static void CreateUserASP(string email, string roleName, string password)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(userContext));

            var userASP = new ApplicationUser
            {
                Email = email,
                UserName = email,
            };

            userManager.Create(userASP, password);
            userManager.AddToRole(userASP.Id, roleName);
        }

        /// <summary>
        /// Recuperacion de contraseña
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static async Task PasswordRecovery(string email)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(userContext));
            var userASP = userManager.FindByEmail(email);
            if (userASP == null)
            {
                return;
            }

            var user = db.Users.Where(tp => tp.UserName == email).FirstOrDefault();
            if (user == null)
            {
                return;
            }

            var random = new Random();
            var newPassword = string.Format("{0}{1}{2:04}*",
                user.FirstName.Trim().ToUpper().Substring(0, 1),
                user.LastName.Trim().ToLower(),
                random.Next(10000));

            userManager.RemovePassword(userASP.Id);
            userManager.AddPassword(userASP.Id, newPassword);

            var subject = "Taxes Password Recovery";
            var body = string.Format(@"
                <h1>Taxes Password Recovery</h1>
                <p>Yor new password is: <strong>{0}</strong></p>
                <p>Please change it for one, that you remember easyly",
                newPassword);

            await MailHelper.SendMail(email, subject, body);
        }

        /// <summary>
        /// Cierra conexiones a BD
        /// </summary>
        public void Dispose()
        {
            userContext.Dispose();
            db.Dispose();
        }
    }
}
