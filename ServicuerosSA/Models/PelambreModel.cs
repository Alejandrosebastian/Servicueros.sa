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
        string dato = "";

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

        public List<IdentityError> ActualizaClasificacionPelo(int bogeda)
        {
            List<IdentityError> listaerrores = new List<IdentityError>();
            try
            { 
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
                                   NumeroPieles = b1.NumeroPieles,
                                   Observaciones = b1.Observaciones,
                                   Peso = b1.Peso,
                                   MedidaId = b1.MedidaId

                               }).FirstOrDefault();
                try
                {
                    _contexto.Bodega1.Update(bodega1);
                    _contexto.SaveChanges();
                }
                catch (Exception e)
                {

                    throw e;
                }
                
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

        public List<IdentityError> ClaseGuardaPelambre(DateTime fecha, string obsrvaciones, int bogeda, int bombo, int formula,  int personal, string codlote, int pesototal, int pieles)
        {
            List<IdentityError> listaerrores = new List<IdentityError>();
            try
            {
               

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
                    Peso = pesototal,
                    CodigoLote = codlote,
                    Codigo = "A"
                };
                    _contexto.Pelambre.Add(guardaPelambre);
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
                    "<a class='btn btn-info' data-toggle='modal' data-target='#ImpresionPelambre' onclick='ImprimirPelambre(" + item.PelambreId +"); componentesFormula(" + item.PelambreId + ");'>Imprimir Detalle con Formula</a> " +
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
                           Codigo = p.CodigoLote + p.Codigo,
                          Parada = p.PelambreId.ToString(),
                          Peso = p.Peso.ToString(),
                          Promedio = (p.Peso / p.TotalPieles).ToString(),
                          Version = fo.Version,
                          TipoPiel = tp.Detalle
                      }).ToList();
            return res;


        }
        public List<object[]> ModeloImprimirComponentes(int id)
        {
            List<object[]> lista = new List<object[]>();
            var res = (from p in _contexto.Pelambre
                      join f in _contexto.Formula on p.FormulaId equals f.FormulaId
                      join c in _contexto.Componente on f.FormulaId equals c.FormulaId
                      join m in _contexto.Medida on c.MedidaId equals m.MedidaId
                      where p.PelambreId == id
                      select new
                      {
                          c.Detalle,
                          c.Porcentaje,
                          p.Peso,
                          c.Tiempo,
                          m.Abreviatura
                      }).ToList();
            foreach (var item in res)
            {
                if (item.Detalle.ToUpper() == "BORRON DL")
                {
                    dato += "<tr><td>ESCURRIR BIEN</td><td></td><td></td><td></td><td></td></tr>";
                };

                dato += "<tr>" +
                "<td>" + item.Detalle.ToUpper() + "</td>" +                             
                "<td>" + item.Porcentaje.ToUpper() + "</td>" +
                "<td>" + (item.Peso * Int32.Parse(item.Porcentaje) ) + "</td>" +
                "<td>" + item.Tiempo + " "+ item.Abreviatura.ToUpper() + "</td>" +
                "<td> </td>"  +
                "</tr>";
                if (item.Detalle.ToUpper() == "AGUA")
                {
                    dato += "<tr><td>ESCURRIR BIEN</td><td></td><td></td><td></td><td></td></tr>";
                };
               
                if (item.Detalle.ToUpper() == "SAL LIMPIA")
                {
                   dato += "<tr><td>CONTROL</td><td></td><td></td><td></td><td></td></tr>";
                    dato += "<tr><td>PH = 9,0-9,5</td><td></td><td></td><td></td><td></td></tr>";
                    dato += "<tr><td>PH = ºB = 0-1,0</td><td></td><td></td><td></td><td></td></tr>";
                    dato += "<tr><td>ºB = TEMP 25ºC - 28ºC</td><td></td><td></td><td></td><td></td></tr>";
                    dato += "<tr><td>TEMP = LAVADO  </td><td></td><td></td><td>10 MIN</td><td></td></tr>";
                    dato += "<tr><td>ESCURRIR BAÑO</td><td></td><td></td><td></td><td></td></tr>";
                };
                if (item.Detalle.ToUpper() == "ESCURRIR BAÑO")
                {
                    dato += "<tr><td>AGUA A 28 ºC</td><td></td><td></td><td></td><td></td></tr>";

                };
            }
            object[] objeto = { dato };
            lista.Add(objeto);
            return lista;
        }
    }
}
