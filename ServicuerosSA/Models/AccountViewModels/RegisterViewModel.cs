using Microsoft.AspNetCore.Mvc.Rendering;
using ServicuerosSA.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServicuerosSA.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Correo")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirma contraseña")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Permisos")]
        [UIHint("List")]
        public List<SelectListItem> Roles { get; set; }
        public string Rol { get; set; }

        public RegisterViewModel()
        {
            Roles = new List<SelectListItem>();
            //Roles.Add(new SelectListItem()
            //{
            //    Value = "1",
            //    Text = "Admin"
            //});
            //Roles.Add(new SelectListItem()
            //{
            //    Value = "2",
            //    Text = "Secretaria"
            //});
            //Roles.Add(new SelectListItem()
            //{
            //    Value = "3",
            //    Text = "Obrero"
            //});
        }

        public void getRoles(ApplicationDbContext _context)
        {
            var roles = from r in _context.identityRole select r;
            var listRole = roles.ToList();
            foreach (var data in listRole)
            {
                Roles.Add(new SelectListItem()
                {
                    Value = data.Id,
                    Text = data.Name
                });
            }
        }

    }
}
