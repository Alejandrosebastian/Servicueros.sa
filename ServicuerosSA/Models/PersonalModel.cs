using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ServicuerosSA.Data;



namespace ServicuerosSA.Models
{
    public class PersonalModel
    {
        ApplicationDbContext _contexto;   
        public PersonalModel (ApplicationDbContext context)
        {
            _contexto = context;
        }
        public List<object[]> Clasemodelistapersonal()
        {
            List<object[]> listapersonal = new List<object[]>();
            string resultado = "";
            var personal = from p in _contexto.Personal
                           join s in _contexto.Sexo on p.SexoId equals s.SexoId
                           select new
                           {
                               p.Cedula,
                               p.Nombres,
                               p.Apellidos,
                               p.FechaNacimiento,
                               p.Telefono,
                               p.Celular,
                               p.Direccion,
                               s.Detalle
                           };
            foreach (var item in personal)
            {
                resultado += "<tr>" +
                    "<td>" + item.Cedula + "</td>" +
                    "<td>" + item.Nombres + "</td>" +
                    "<td>" + item.Apellidos + "</td>" +
                    "<td>" + item.FechaNacimiento + "</td>" +
                    "<td>" + item.Telefono + "</td>" +
                    "<td>" + item.Celular + "</td>" +
                    "<td>" + item.Direccion + "</td>" +
                    "<td>" + item.Detalle + "</td>" +
                    "<td>" +
                    "<a class = 'btn btn-success>Editar</a>" +
                    "</td>"
                    + "</tr>";
            }
            object[] contenedor = { resultado };
            listapersonal.Add(contenedor);
            return listapersonal;

        }
        
        public List<IdentityError> ClasemodelCedula(string cedula)
        {
            List<IdentityError> Lista = new List<IdentityError>();
            IdentityError dato = new IdentityError();
            var cont = from p in _contexto.Personal
                       where p.Cedula == cedula
                       select p;
            if(cont.Count() !=0)
            {
                dato = new IdentityError
                {
                    Code = "si",
                    Description = "si"
                };
            }
            else
            {
                dato = new IdentityError
                {
                    Code = "no",
                    Description = "no"
                };
            }
            Lista.Add(dato);
            return Lista;
        }

        public List<Personal> ListaPersonal()
        {
            return _contexto.Personal.OrderBy(p => p.Apellidos).ToList();

        }
    }
}
