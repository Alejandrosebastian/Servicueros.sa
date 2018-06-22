using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ServicuerosSA.Data;
namespace ServicuerosSA.Models
{
    public class PelambreModel
    {
        private ApplicationDbContext _contexto;
        public PelambreModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }
        public List<object[]> ClaseListaPelambre()
        {
            List<object[]> ListaPelambre = new List<object[]>();
            string datos = "";
            var res = (from b1 in _contexto.Bodega1
                       join l in _contexto.Lote on b1.LoteId equals l.LoteId
                       join tp in _contexto.TipoPiel on l.TipoPielId equals tp.TipoPielId
                       join cl in _contexto.Clasificacion on b1.ClasificacionId equals cl.ClasificacionId
                       join m in _contexto.Medida on b1.MedidaId equals m.MedidaId
                       where b1.activo == true
                       select new
                       {
                           b1.Bodega1Id,
                           l.Codigolote,
                           cl.Selecciones,
                           b1.NumeroPieles,
                           tp.Detalle,
                           b1.Peso, m.Abreviatura
                       });
            foreach (var item in res)
            {
                datos += "<tr>" + 
                    "<td>" +
                    "<input type='checkbox' class='form-control' value=" + item.Bodega1Id + "|"+ item.Codigolote + "|" + item.NumeroPieles + "|" + item.Peso + ' ' + "/>" +
                    "</td>" +
                    "<td>" + item.Codigolote + "</td>" +
                    "<td>" + item.Detalle + "</td>" +
                    "<td>" + item.Selecciones + "</td>" +
                    "<td>" + item.NumeroPieles + "</td>" +
                    "<td>" + item.Peso + "  " + item.Abreviatura + "</td>" +
                    "</tr>";
            }
            object[] objetodatos = { datos };
            ListaPelambre.Add(objetodatos);
            return ListaPelambre;
           
        }

        public List<object[]> ClaseListaPelambrexTipoPiel(int tipopielId, int clasificacionId )
        {
            List<object[]> ListaPelambre = new List<object[]>();
            string datos = "";
            
            if (clasificacionId == 0)
            {
                var res = (from b1 in _contexto.Bodega1
                           join l in _contexto.Lote on b1.LoteId equals l.LoteId
                           join tp in _contexto.TipoPiel on l.TipoPielId equals tp.TipoPielId
                           join cl in _contexto.Clasificacion on b1.ClasificacionId equals cl.ClasificacionId
                           where b1.activo == true && tp.TipoPielId == tipopielId
                           select new
                           {
                               b1.Bodega1Id,
                               l.Codigolote,
                               cl.Selecciones,
                               b1.NumeroPieles,
                               tp.Detalle,
                               b1.Peso
                           }).OrderByDescending(b1 => b1.Bodega1Id).ToList();
                foreach (var item in res)
                {
                    datos += "<tr>" +
                        "<td>" +
                        "<input type='checkbox' class='form-control' value=" + item.Bodega1Id + "/>" +
                        "</td>" +
                        "<td>" + item.Codigolote + "</td>" +
                        "<td>" + item.Detalle + "</td>" +
                        "<td>" + item.Selecciones + "</td>" +
                        "<td>" + item.NumeroPieles + "</td>" +
                        "<td>" + item.Peso + "</td>" +
                        "</tr>";
                }
            }
            else if (tipopielId == 0)
            {
                var res = (from b1 in _contexto.Bodega1
                           join l in _contexto.Lote on b1.LoteId equals l.LoteId
                           join tp in _contexto.TipoPiel on l.TipoPielId equals tp.TipoPielId
                           join cl in _contexto.Clasificacion on b1.ClasificacionId equals cl.ClasificacionId
                           where b1.activo == true && cl.ClasificacionId == clasificacionId
                           select new
                           {
                               b1.Bodega1Id,
                               l.Codigolote,
                               cl.Selecciones,
                               b1.NumeroPieles,
                               tp.Detalle,
                               b1.Peso
                           }).OrderByDescending(b1 => b1.Bodega1Id).ToList();
                foreach (var item in res)
                {
                    datos += "<tr>" +
                        "<td>" +
                        "<input type='checkbox' class='form-control' value=" + item.Bodega1Id + "/>" +
                        "</td>" +
                        "<td>" + item.Codigolote + "</td>" +
                        "<td>" + item.Detalle + "</td>" +
                        "<td>" + item.Selecciones + "</td>" +
                        "<td>" + item.NumeroPieles + "</td>" +
                        "<td>" + item.Peso + "</td>" +
                        "</tr>";
                }
            }
            else
            {
                var res = (from b1 in _contexto.Bodega1
                           join l in _contexto.Lote on b1.LoteId equals l.LoteId
                           join tp in _contexto.TipoPiel on l.TipoPielId equals tp.TipoPielId
                           join cl in _contexto.Clasificacion on b1.ClasificacionId equals cl.ClasificacionId
                           where b1.activo == true && cl.ClasificacionId == clasificacionId && tp.TipoPielId == tipopielId
                           select new
                           {
                               b1.Bodega1Id,
                               l.Codigolote,
                               cl.Selecciones,
                               b1.NumeroPieles,
                               tp.Detalle,
                               b1.Peso
                           }).OrderByDescending(b1 => b1.Bodega1Id).ToList();
                foreach (var item in res)
                {
                    datos += "<tr>" +
                        "<td>" +
                        "<input type='checkbox' class='form-control' value=" + item.Bodega1Id + "/>" +
                        "</td>" +
                        "<td>" + item.Codigolote + "</td>" +
                        "<td>" + item.Detalle + "</td>" +
                        "<td>" + item.Selecciones + "</td>" +
                        "<td>" + item.NumeroPieles + "</td>" +
                        "<td>" + item.Peso + "</td>" +
                        "</tr>";
                }
            }
            
           
            object[] objetodatos = { datos };
            ListaPelambre.Add(objetodatos);
            return ListaPelambre;
        }     

        public List<IdentityError> ClaseGuardaPelambre(DateTime fecha, string obsrvaciones, int bogeda, int bombo, int formula,  int personal, string codlote, int pesototal, int pieles)
        {
            List<IdentityError> listaerrores = new List<IdentityError>();
            
            try
            {
                var res = (from b1 in _contexto.Bodega1
                           join p in _contexto.Pelambre on b1.Bodega1Id equals p.Bodega1Id
                           join l in _contexto.Lote on b1.LoteId equals l.LoteId
                           where l.Codigolote == codlote && p.Fecha <= fecha
                           select p).Count();
                

                var guardaPelambre = new Pelambre
                {
                    Bodega1Id = bogeda,
                    BomboId = bombo,
                    Fecha = DateTime.Now,
                    Observaciones = obsrvaciones,
                    FormulaId = formula,
                   TotalPieles = pieles,
                    PersonalId = personal,
                    Activo = true,
                    Codigo = "A"
                };
                    _contexto.Pelambre.Add(guardaPelambre);
                    _contexto.SaveChanges();
                
                    var bodega1 = (from b1 in _contexto.Bodega1
                                   where b1.Bodega1Id == bogeda
                                   select new Bodega1
                                   {
                                       activo = false,
                                       ClasificacionId = b1.ClasificacionId,
                                       Fechaingreso = b1.Fechaingreso,
                                       LoteId = b1.LoteId,
                                       NumeroEstanteria = b1.NumeroEstanteria,
                                       BodegaId = b1.BodegaId,
                                       Bodega1Id = b1.Bodega1Id,
                                       NumeroPieles=b1.NumeroPieles,
                                         
                                       Observaciones = b1.Observaciones,
                                       Peso = b1.Peso
                                   }).FirstOrDefault();
                                   
                    _contexto.Bodega1.Update(bodega1);
                    _contexto.SaveChanges();
                
               
                listaerrores.Add(new IdentityError
                {
                    Code = "Save",
                    Description = "Save"
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

        public List<object[]> ClaseIndexPelambre(int numeroPagina)
        {
            List<object[]> ListaPelambre = new List<object[]>();
            string dato = "";
            

            var res = (from p in _contexto.Pelambre
                       join b1 in _contexto.Bodega1 on p.Bodega1Id equals b1.Bodega1Id
                       join f in _contexto.Formula on p.FormulaId equals f.FormulaId
                       join b in _contexto.Bombo on p.BomboId equals b.BomboId
                       join l in _contexto.Lote on b1.LoteId equals l.LoteId
                       join c in _contexto.Clasificacion on b1.ClasificacionId equals c.ClasificacionId
                       join tp in _contexto.TipoPiel on l.TipoPielId equals tp.TipoPielId
                       select new {
                           p.PelambreId,
                           l.Codigolote,
                           tp.Detalle,
                           c.Selecciones,
                           p.Fecha,
                           b.Num_bombo,
                           f.Nombre
                       }).ToList();
            foreach (var item in res)
            {
                dato += "<tr><td>" + item.Codigolote + "</td>"+
                
                    "<td>" + item.Detalle + "</td>" +
                    "<td>" + item.Selecciones + "</td>" +
                    "<td>" + item.Fecha.ToString("dd-MM-yyyy hh:mm") + "</td>" +
                    "<td>" + item.Num_bombo + "</td>" +
                    "<td>" + item.Nombre + "</td>" +
                    "<td>" +
                    "<a class='btn btn-info' data-toogle='modal' data-target='#ImpresionPelambre' onclick='ImprimirPelambre(" + item.PelambreId + ")'>Imprimir Detalle con Formula</a> " +
                    "<a class='btn btn-info' data-toggle='modal' data-target='#DetallePelambre' onclick='DetallePelambre" + item.PelambreId + "'>Detalles</a>" +
                        "</td>" +
                        "</tr>";
            }
            object[] objeto = { dato };
            ListaPelambre.Add(objeto);
            return ListaPelambre;
        }

        public List<ModeloEncabezadoFormula> ModeloImprimirEncabezadoFormula(int id)
        {
            
            //var res = from p in _contexto.Pelambre
            //          join f in _contexto.Formula on p.FormulaId equals f.FormulaId
            //          join c in _contexto.Componente on f.FormulaId equals c.FormulaId
            //          select new
            //          {

            //          };

            var res = (from p in _contexto.Pelambre
                      join pe in _contexto.Personal on p.PersonalId equals pe.PersonalId
                      join b in _contexto.Bombo on p.BomboId equals b.BomboId
                      join fo in _contexto.Formula on p.FormulaId equals fo.FormulaId
                      join tp in _contexto.TipoPiel on fo.TipoPielId equals tp.TipoPielId
                      where p.PelambreId == id
                      select new ModeloEncabezadoFormula
                      {
                          Bombo = b.Num_bombo.ToString(),
                          Cantidad = p.TotalPieles.ToString(),
                          FechaCreacionFormula = fo.Fecha_Creacion.ToString(),
                          FechaImpresion = DateTime.Now.ToString(),
                          NombreAutoirzado = pe.Nombres + " " + pe.Apellidos,
                          FechaValida = DateTime.Now.ToString(),
                          NombreEntregado = pe.Nombres + " " + pe.Apellidos,
                          NombreProcesado = fo.TipoProceso,
                          Codigo = p.Codigo,
                          Parada = p.PelambreId.ToString(),
                          Peso = p.TotalPieles.ToString(),
                          //Promedio = falta peso total en modelo pelambre
                          Version = fo.Version,
                          TipoPiel = tp.Detalle
                      }).ToList();
            return res;


        }
        public List<object[]> ModeloImprimirComponentes(int id)
        {
            List<object[]> lista = new List<object[]>();
            var res = from p in _contexto.Pelambre
                      join f in _contexto.Formula on p.FormulaId equals f.FormulaId
                      join c in _contexto.Componente on f.FormulaId equals c.FormulaId
                      where p.PelambreId == id
                      select new
                      {
                          c.Detalle,
                          c.Porcentaje,
                          c.Cantidad,
                          c.Tiempo
                      };
            string dato = "";
            foreach (var item in res.ToList())
            {
                dato += "<tr>" +
                    "<td>" + item.Detalle +"</td>" +
                "<td>" + item.Porcentaje + "</td>" +
                "<td>" + item.Cantidad + "</td>" +
                "<td>" + item.Tiempo + "</td>" +
                "</tr>";

            }
            object[] objeto = { dato };
            lista.Add(objeto);
            return lista;
        }
    }
}
