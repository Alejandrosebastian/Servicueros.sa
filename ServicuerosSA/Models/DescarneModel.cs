﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ServicuerosSA.Data;
namespace ServicuerosSA.Models
{
    public class DescarneModel
    {
        string dato = "";
        private ApplicationDbContext _contexto;
       
        public DescarneModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }
        public List<Pelambre> Modelolistapelambres()
        {
            return _contexto.Pelambre.Where(p => p.Activo == true).GroupBy(p => p.CodigoLote + p.Codigo).Select(p => p.First()).Distinct().ToList();
        }
        //Completar la consulta con el total de pieles d descarne falta
        public List<object[]> ClaseListaDescarne()
        {
            List<object[]> ListaDescarne = new List<object[]>();
            string datos = "";
            var res = (from des in _contexto.Descarne 
                         where des.Activo == true
                       select new
                       {
                           des.CodigoLote,
                          
                           des.Cantidad
                          
                       }).Distinct();

            foreach (var item in res)
            {
                datos += "<tr>" +
                    "<td>" + item.CodigoLote + "</td>" +
                    "<td>" + item.Cantidad + "</td>" +
                    //"<td>" + item.Pelambres + "</td>" +
                    //"<td>" + item.CodigoLote +" "+ item.Codigo + "</td>" +
                    // "<td><a class='btn btn-success' onclick='EliminarDescarne(" + item.codigodescarne + ")'>Eliminar</a></td>" +
                    "</tr>";

            }

            object[] objetodatos = { datos };
            ListaDescarne.Add(objetodatos);
            return ListaDescarne;
        }
        public List<IdentityError> ClaseGuardarDescarne(string pelambre, int cantidad, DateTime fecha, int personal, string codigolote, string codiunidescarne)

        {
            List<IdentityError> Listaerrores = new List<IdentityError>();
            List<PelambreListaId> pelambreLista = (from ya in _contexto.Pelambre
                                                  where  ya.codigopelambre == pelambre
                                                  select new PelambreListaId {
                                                      Activo = ya.Activo,
                                                      BodegaId1 = ya.Bodega1Id,
                                                      BomboId = ya.BomboId,
                                                      Codigo = ya.Codigo,
                                                      CodigoLote = ya.CodigoLote,
                                                      codigopelambre = ya.codigopelambre,
                                                      FormulaId = ya.FormulaId,
                                                      Peso = ya.Peso,
                                                      TotalPieles = ya.TotalPieles,
                                                      PersonalId = ya.PersonalId,
                                                      observaciones = ya.Observaciones,
                                                      fecha = ya.Fecha,
                                                      pelambreId = ya.PelambreId
                                                  }).ToList();


            foreach (var item in pelambreLista)
            {
                try
                {
                    var guardarDescarne = new Descarne
                    {
                        PelambreId = item.pelambreId,
                        Activo = true,
                        Cantidad = cantidad,
                        PersonalId = personal,
                        Fecha = DateTime.Now,
                        CodigoLote = codigolote,
                        codiunidescarne = codiunidescarne
                    };
                    _contexto.Descarne.Add(guardarDescarne);
                    _contexto.SaveChanges();


                    Pelambre pe = (from p in _contexto.Pelambre
                                   where p.PelambreId == item.pelambreId
                                   select new Pelambre
                                   {
                                       Activo = false,
                                       PelambreId = p.PelambreId,
                                       FormulaId = p.FormulaId,
                                       PersonalId = p.PersonalId,
                                       Bodega1Id = p.Bodega1Id,
                                       BomboId = p.BomboId,
                                       Codigo = p.Codigo,
                                       CodigoLote = p.CodigoLote,
                                       Fecha = p.Fecha,
                                       TotalPieles = p.TotalPieles,
                                       codigopelambre = p.codigopelambre,
                                       Peso = p.Peso
                                   }).FirstOrDefault();
                    _contexto.Pelambre.Update(pe);
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
        public List<object[]> ModeloImprimirDescarne(string id)
        {
            List<object[]> lista = new List<object[]>();
            var res = (from des in _contexto.Descarne
                       where des.Activo == true
                       select new
                       {
                           des.CodigoLote,
                           des.Cantidad,
                           fecha = des.Fecha.ToString("dd-MM-yyyy")
                       }).OrderByDescending(f=> f.fecha);
           
            foreach (var item in res)
            {
                dato += "<tr>" +
                    "<td>" + item.CodigoLote + "</td>" +
                    "<td>" + item.Cantidad + "</td>" +
                    "<td>"+ item.fecha + "</td>"+
                    "</tr>";
            }
            object[] objeto = { dato };
            lista.Add(objeto);
            return lista;
        }


    }
}
