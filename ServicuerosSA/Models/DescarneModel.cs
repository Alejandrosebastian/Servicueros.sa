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
                           p.TotalPieles,
                           
                           p.CodigoLote,
                           p.Codigo
                       });

            foreach (var item in res)
            {
                datos += "<tr>" +
                    "<td>" + item.Cantidad + "</td>" +
                   "<td>" + item.TotalPieles + "</td>" +
                        
                    "<td>" + item.CodigoLote +" "+ item.Codigo + "</td>" +
                      "<td><a class='btn btn-success' onclick='EliminarDescarne'>Eliminar</a></td>" +
                    "</tr>";

            }

            object[] objetodatos = { datos };
            ListaDescarne.Add(objetodatos);
            return ListaDescarne;
        }
    
        public List<IdentityError> ClaseGuardarDescarne(int cantidad, DateTime fecha, int personal, int pelambre)
        {
            List<IdentityError> Listaerrores = new List<IdentityError>();
            try
            {
                var guardarDescarne = new Descarne
                {
                    Cantidad = cantidad,

                    PersonalId = personal,
                    Activo = true,
                    PelambreId = pelambre,               

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
        public List<IdentityError> ModeloNumeroPielesDescarne(int codigopelambre,  int valor)
        {
            List<IdentityError> Lista = new List<IdentityError>();
            IdentityError er = new IdentityError();
            int pelambrenum = _contexto.Pelambre.Where(p => p.PelambreId == codigopelambre && p.TotalPieles == valor).Count();
            
                if (valor <= pelambrenum)
                {
                    er = new IdentityError
                    {
                        Code = "vale",
                        Description = "vale"
                    };
                }
                else
                {
                    er = new IdentityError
                    {
                        Code = "no",
                        Description = "no"
                    };
                }
            return Lista;     
        }
        public List<IdentityError> ClaseEliminarDescarne(string codigoUnico)
        {
            List<IdentityError> listaerrores = new List<IdentityError>();
            try
            {
                var des = from d in _contexto.Descarne
                          where d.codigodescarne == codigoUnico
                          select new Descarne { DescarneId = d.DescarneId, PelambreId = d.PelambreId };
                foreach (var item in des.ToList())
                {
                    var pelambre = (from p in _contexto.Pelambre
                                    where p.PelambreId == item.PelambreId
                                    select new Pelambre
                                    {
                                        Activo= true,
                                        Fecha= p.Fecha,
                                        Observaciones=p.Observaciones,
                                        Bodega1Id=p.Bodega1Id,
                                        BomboId=p.BomboId,
                                        FormulaId=p.FormulaId,
                                        PersonalId=p.PersonalId,
                                        Codigo=p.Codigo,
                                        TotalPieles=p.TotalPieles,
                                        Peso=p.Peso,
                                        CodigoLote=p.CodigoLote,
                                        codigopelambre=p.codigopelambre
                                    }).FirstOrDefault();
                    _contexto.Pelambre.Update(pelambre);
                    _contexto.SaveChanges();

                    _contexto.Descarne.Remove(item);
                    _contexto.SaveChanges();
                }
                listaerrores.Add(new IdentityError
                {
                    Code="Save",
                    Description="Save"
                });
            }
            catch (Exception e)
            {
                listaerrores.Add(new IdentityError
                {
                    Code = e.Message,
                    Description = e.Message
                });
            }
            return listaerrores;
        }
    }
}
