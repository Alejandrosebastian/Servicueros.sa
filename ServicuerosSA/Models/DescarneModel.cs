using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ServicuerosSA.Data;
namespace ServicuerosSA.Models
{
    public class DescarneModel
    {
        private ApplicationDbContext _contexto;
        public DescarneModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }
        //Completar la consulta con el total de pieles d descarne falta
        public List<object[]> ClaseListaDescarne()
        {
            List<object[]> ListaDescarne = new List<object[]>();
            string datos = "";
            var res = (from p in _contexto.Pelambre
                       join des in _contexto.Descarne on p.PelambreId equals des.PelambreId
                       where p.Activo == true
                       select new
                       {
                           des.Cantidad,
                           des.Fecha,
                           p.TotalPieles,
                           p.PelambreId
                       });
            foreach (var item in res)
            {
                datos += "<tr>" +
                    "<td>"+item.Cantidad+"</td>" +
                    "<td>"+item.Fecha+"</td>" +
                    "<td>"+item.TotalPieles+"</td>"+
                    "</tr>";
            }
            object[] objetodatos = { datos };
            ListaDescarne.Add(objetodatos);
            return ListaDescarne;
        }
        public List<IdentityError> ClaseGuardarDescarne(string cantidad, DateTime fecha, int personal, int pelambre)
        {
            List<IdentityError> Listaerrores = new List<IdentityError>();
            try
            {
                var guardarDescarne = new Descarne
                {
                    Cantidad = cantidad,
                    Fecha= fecha,
                    PersonalId = personal,
                    PelambreId = pelambre,
                    Activo= true
                
                };
                _contexto.Descarne.Add(guardarDescarne);
                _contexto.SaveChanges();
                Listaerrores.Add(new IdentityError
                {
                    Code = "ok",
                    Description = "ok"
                });
            }
            catch (Exception e)
            {
                Listaerrores.Add(new IdentityError
                {
                    Code = e.Message,
                    Description = e.Message
                });
            }
            return Listaerrores;
        }

    }
}
