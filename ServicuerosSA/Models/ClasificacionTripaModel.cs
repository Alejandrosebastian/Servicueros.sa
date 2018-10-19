using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ServicuerosSA.Data;

namespace ServicuerosSA.Models
{
    public class ClasificacionTripaModel
    {
        ApplicationDbContext _contexto;
       //private ClasificacionTripaModel listatipotripas;
        public ClasificacionTripaModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }
        public List<ClasificacionTripa> ClaseModeloListaClasificacionTripa()
        {
            return _contexto.ClasificacionTripa.OrderBy(c => c.Detalle).ToList();
        }
        public List<Bodega> Claselistabode()
        {
            return _contexto.Bodega.OrderBy(b => b.NombreBodega).ToList();
        }
       public List<Descarne> Claselistadescarnes()
        {
         return _contexto.Descarne.Where(d => d.Activo == true).ToList();
        }
       
       public List<IdentityError> Modelonumeropieles(int numdes, int numet)
        {
            List<IdentityError> lista = new List<IdentityError>();
            IdentityError er = new IdentityError();
            int trip = _contexto.Descarne.Where(d => d.DescarneId == numdes && d.Cantidad == numet).Count();
            if(numet <= trip)
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
            return lista;
        }
        //public List<object[]> Claselistabode()
        //{
        //    List<object[]> lista = new List<object[]>();
        //    string datos = "";
        //    var res = (from b in _contexto.Bodega
        //               select new
        //               {
        //                   b.NombreBodega
        //               }).ToList();
        //    object[] objetodatos = { datos };
        //    lista.Add(objetodatos);
        //    return lista;
        //}
       public List<object[]>ModeloFiltrarClasificacionTripa()
       {
           List<object[]> lista = new List<object[]>();
           string datos = "";

           var res = (from bt in _contexto.Bodegatripa
                       join de in _contexto.Descarne on bt.DescarneId equals de.DescarneId
                       join cl in _contexto.ClasificacionTripa on bt.ClasificacionTripaId equals cl.ClasificacionTripaId
                       where bt.activo == true 
                       select new
                       {
                           de.CodigoLote,
                           bt.NumeroPieles,
                           cl.Detalle,
                           bt.peso
                       }).ToList();
            foreach(var item in res)
            {
                datos +="<tr>"+
                    "<td>" + item.CodigoLote + "</td>" +
                    "<td>" + item.NumeroPieles + "</td>" +
                    "<td>" + item.Detalle + "</td>" +
                    "<td>" + item.peso + "</td>" +
                    "</tr>";
            }
            object[] objetodatos = { datos };
            lista.Add(objetodatos);
            return lista; 
       }
        public List<IdentityError> Claseguardabodetripa(int tipotripa, int descarne, int bodega, int numeropieles,  int peso, int personal)
        {
            List<IdentityError> listatripa = new List<IdentityError>();
            try
            {
                var guardatripas = new Bodegatripa
                {
                    ClasificacionTripaId = tipotripa,
                    DescarneId = descarne,
                    BodegaId = bodega,
                    NumeroPieles = numeropieles,
                    peso = peso,
                    PersonalId = personal,
                    activo = true

                };
                
                _contexto.Bodegatripa.Add(guardatripas);
                _contexto.SaveChanges();

                ///desactivo atras
                var descarnes = (from des in _contexto.Descarne
                               where des.DescarneId == descarne
                               select new Descarne
                               {
                                   
                                   PelambreId = descarne,
                                   PersonalId = des.PersonalId,
                                   Activo = false,
                                   Cantidad = des.Cantidad,
                                   codigodescarne = des.codigodescarne,
                                   CodigoLote = des.CodigoLote
                               }).FirstOrDefault();

                _contexto.Descarne.Update(descarnes);
                _contexto.SaveChanges();


                listatripa.Add(new IdentityError
                {
                    Code = "ok",
                    Description = "ok"
                });
            }
            catch(Exception e)
            {
                listatripa.Add(new IdentityError
                {
                    Code = "no",
                    Description = "no"
                });
            }
            return listatripa;
        }
        public List<object[]> ModeloImprimirClasiTripa(string id)
        {
            List<object[]> lista = new List<object[]>();
            string desc = "";
            var res = (from bt in _contexto.Bodegatripa
                       join de in _contexto.Descarne on bt.DescarneId equals de.DescarneId
                       join cl in _contexto.ClasificacionTripa on bt.ClasificacionTripaId equals cl.ClasificacionTripaId
                       where bt.activo == true
                       select new
                       {
                           de.CodigoLote,
                           bt.NumeroPieles,
                           cl.Detalle,
                           bt.peso
                       }).ToList();
            foreach (var item in res)
            {
                desc += "<tr>" +
                    "<td>" + item.CodigoLote + "</td>" +
                    "<td>" + item.NumeroPieles + "</td>" +
                    "<td>" + item.Detalle + "</td>" +
                    "<td>" + item.peso + "</td>" +
                    "</tr>";
            }
            object[] objetodatos = { desc };
            lista.Add(objetodatos);
            return lista;
        }
    }
   
}
