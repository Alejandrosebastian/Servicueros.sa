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
            string compara = "";
            foreach(var item in res)
            {
                datos += "<tr>" +
                    "<td>" + item.CodigoLote + "</td>" +
                    "<td>" + item.NumeroPieles + "</td>" +
                    "<td>" + item.Detalle + "</td>" +
                    "<td>" + item.peso + "</td>";
                   
                string ya = item.CodigoLote;
                if (compara != item.CodigoLote)
                {
                    datos += "<td>" +
                       "<a class='btn btn-success' onclick='EliminarClasiTripa(&#039;" + ya + "&#039;)'>Eliminar</a>" +
                           "</td>" +
                           "</tr>";
                }

            }
            object[] objetodatos = { datos };
            lista.Add(objetodatos);
            return lista; 
       }
        //ELIMINAR
        public List<IdentityError> ClaseEliminarClasiTripa(string CodigoLote)
        {
            List<IdentityError> listaerrores = new List<IdentityError>();
            try
            {
                var cla = from ct in _contexto.Bodegatripa
                          where ct.codigolote == CodigoLote
                          select new Bodegatripa { BodegaTripaId = ct.BodegaTripaId, ClasificacionTripaId = ct.ClasificacionTripaId, DescarneId = ct.DescarneId };
                 foreach (var item in cla.ToList())
                 {
                    var descarne = (from d in _contexto.Descarne
                                       where d.DescarneId == item.DescarneId
                                       select new Descarne
                                       {
                                           Activo= true,
                                           Cantidad = d.Cantidad,
                                           Fecha = d.Fecha,
                                           DescarneId= d.DescarneId,
                                           PersonalId= d.PersonalId,
                                           PelambreId= d.PelambreId
          


                                       }).FirstOrDefault();
                    _contexto.Descarne.Update(descarne);
                    _contexto.SaveChanges();
                    _contexto.Bodegatripa.Remove(item);
                    _contexto.SaveChanges();

                 }
            }
            catch(Exception e)
            {
                listaerrores.Add(new IdentityError
                {
                    Code = e.Message,
                    Description = e.Message
                });
            }
            return listaerrores;
        }

        public List<IdentityError> Claseguardabodetripa(int tipotripa, int descarne,  int bodega, string codigolote, decimal numeropieles, int peso, int medida, int personal)
        {
            List<IdentityError> listatripa = new List<IdentityError>();
            List<DescarnelistId> descarnelista = (from de in _contexto.Descarne
                                                  where de.codiunidescarne == codigolote
                                                  select new DescarnelistId
                                                  {
                                                      activo = de.Activo,
                                                      cantidad = de.Cantidad,
                                                      fecha = de.Fecha,
                                                      codiunicodescarne = de.codigodescarne,
                                                      codigolote = de.CodigoLote,
                                                      descarneId = de.DescarneId
                                                  }).ToList();
            

            try
            {
                var guardatripas = new Bodegatripa
                {
                    ClasificacionTripaId = tipotripa,
                    DescarneId = descarne,
                    BodegaId = bodega,
                    codigolote = codigolote,
                    NumeroPieles = numeropieles,
                    peso = peso,
                    MedidaId = medida,
                    PersonalId = personal,
                    fecha = DateTime.Now,
                    activo = true
                };

                _contexto.Bodegatripa.Add(guardatripas);
                _contexto.SaveChanges();
                
                ///desactivo atras
                Descarne descarnes = (from des in _contexto.Descarne
                                      where des.DescarneId == descarne
                                      select new Descarne
                                      {
                                          PelambreId = des.PelambreId,
                                          PersonalId = des.PersonalId,
                                          Activo = false,
                                          Cantidad = des.Cantidad,
                                          codigodescarne = codigolote,
                                          CodigoLote = des.CodigoLote,
                                          DescarneId = descarne,
                                          Fecha= des.Fecha,
                                          codiunidescarne = des.codiunidescarne
                                      }).FirstOrDefault();

                _contexto.Descarne.Update(descarnes);
                _contexto.SaveChanges();


                var descarneNuevo =   (from des in _contexto.Descarne
                                          where des.DescarneId == descarne
                                          select new Descarne
                                      {
                                          PelambreId = des.PelambreId,
                                          PersonalId = des.PersonalId,
                                          Activo = true,
                                          Cantidad = des.Cantidad,
                                          codigodescarne = codigolote,
                                          CodigoLote = des.CodigoLote,
                                          
                                          Fecha = des.Fecha, 
                                          codiunidescarne = des.codiunidescarne
                                      }).FirstOrDefault();

                Descarne dato = new Descarne()
                {
                    PelambreId = descarneNuevo.PelambreId,
                    PersonalId = descarneNuevo.PersonalId,
                    Activo = true,
                    Cantidad = descarneNuevo.Cantidad - Convert.ToInt32(numeropieles),
                    codigodescarne = codigolote,
                    CodigoLote = descarneNuevo.CodigoLote,
                    Fecha = descarneNuevo.Fecha,
                    codiunidescarne = descarneNuevo.codiunidescarne
                };

                _contexto.Descarne.Add(dato);
                _contexto.SaveChanges();




                listatripa.Add(new IdentityError
                {
                    Code = "ok",
                    Description = "ok"
                });
            }
            catch (Exception ex)
            {
                listatripa.Add(new IdentityError
                {
                    Code = ex.Message,
                    Description = ex.Message
                });
            }
        
            return listatripa;
        }
        public List<object[]> ModeloImprimirCarnaza()
        {
            List<object[]> lista = new List<object[]>();
            string desc = "";
            var res = (from bt in _contexto.Bodegatripa
                       join de in _contexto.Descarne on bt.DescarneId equals de.DescarneId
                       join cl in _contexto.ClasificacionTripa on bt.ClasificacionTripaId equals cl.ClasificacionTripaId
                       where cl.Detalle == "carnaza" || cl.Detalle == "malas"
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
            object[] objetodatos= {desc};
            lista.Add(objetodatos);
            return lista;
        }
        public List<object[]> ModeloImprimirClasiTripa()
        {
            List<object[]> lista = new List<object[]>();
            string desc = "";
            var res = (from bt in _contexto.Bodegatripa
                       join de in _contexto.Descarne on bt.DescarneId equals de.DescarneId
                       join cl in _contexto.ClasificacionTripa on bt.ClasificacionTripaId equals cl.ClasificacionTripaId
                       where bt.activo == true && cl.Detalle !="carnaza" && cl.Detalle != "malas"
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
