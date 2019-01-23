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
        string datoimprime = "";

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
                           b1.Peso,
                           m.Abreviatura
                       });
            foreach (var item in res)
            {
                datos += "<tr>" +
                    "<td>" +
                    "<input type='checkbox' class='form-control' value=" + item.Bodega1Id + "|" + item.Codigolote + "|" + item.NumeroPieles + "|" + item.Peso + ' ' + "/>" +
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

        public List<object[]> ClaseListaPelambrexTipoPiel(int tipopielId, int clasificacionId)
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
                
        public List<IdentityError> ClaseGuardaPelambre(DateTime fecha, string obsrvaciones, int bogeda, int bombo, int formula, int personal, string codlote, int pesototal, int pieles, string codigoUnico)
        {
            List<IdentityError> listaerrores = new List<IdentityError>();
            try
            {      
                string ingresocod = "";
                int codigoDes = (from p in _contexto.Pelambre
                                 where p.Activo == true && p.CodigoLote == codlote && p.Fecha < fecha
                                 select p).Count();
                switch (codigoDes)
                {
                    case 0:
                        ingresocod = "A";
                        break;
                    case 1:
                        ingresocod = "B";
                        break;
                    case 3:
                        ingresocod = "C";
                        break;
                    case 4:
                        ingresocod = "D";
                        break;
                    case 5:
                        ingresocod = "E";
                        break;
                    case 6:
                        ingresocod = "F";
                        break;
                    case 7:
                        ingresocod = "G";
                        break;
                    case 8:
                        ingresocod = "H";
                        break;
                    case 9:
                        ingresocod = "I";
                        break;
                    case 10:
                        ingresocod = "J";
                        break;
                    case 11:
                        ingresocod = "K";
                        break;
                    case 12:
                        ingresocod = "L";
                        break;
                    case 13:
                        ingresocod = "M";
                        break;
                    case 14:
                        ingresocod = "N";
                        break;
                    case 15:
                        ingresocod = "O";
                        break;
                    case 16:
                        ingresocod = "P";
                        break;
                    case 17:
                        ingresocod = "Q";
                        break;
                    case 18:
                        ingresocod = "R";
                        break;
                    case 19:
                        ingresocod = "S";
                        break;
                    case 20:
                        ingresocod = "T";
                        break;
                    case 21:
                        ingresocod = "U";
                        break;
                    case 22:
                        ingresocod = "V";
                        break;
                    case 23:
                        ingresocod = "W";
                        break;
                    case 24:
                        ingresocod = "X";
                        break;
                    case 25:
                        ingresocod = "Y";
                        break;
                    case 26:
                        ingresocod = "Z";
                        break;

                }
                var guardaPelambre = new Pelambre
                {
                    Bodega1Id = bogeda,
                    BomboId = bombo,
                    Fecha = fecha,
                    Observaciones = obsrvaciones,
                    FormulaId = formula,
                    TotalPieles = pieles,
                    PersonalId = personal,
                    Activo = true,
                    Peso = pesototal,
                    CodigoLote = codlote,
                    Codigo = codlote + ingresocod,
                    codigopelambre = codigoUnico
                };
                _contexto.Pelambre.Add(guardaPelambre);
                _contexto.SaveChanges();

                listaerrores.Add(new IdentityError
                {
                    Code = "Save",
                    Description = "Save"
                });
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
                                   TipoPielId = b1.TipoPielId,
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
                       where p.Activo == true
                       select new {
                           p.PelambreId,
                           l.Codigolote,
                           tp.Detalle,
                           c.Selecciones,
                           p.Fecha,
                           b.Num_bombo,
                           f.Nombre,
                           p.codigopelambre
                       }).ToList();

            string compara = "";
            foreach (var item in res)
            {  
                dato += "<tr><td>" + item.Codigolote + "</td>" +
                    "<td>" + item.Detalle + "</td>" +
                    "<td>" + item.Selecciones + "</td>" +
                    "<td>" + item.Fecha.ToString("dd-MM-yyyy hh:mm") + "</td>" +
                    "<td>" + item.Num_bombo + "</td>" +
                    "<td>" + item.Nombre + "</td>";
                string ya = item.codigopelambre;
                if (compara != item.codigopelambre)
                {
                 dato += "<td>" + "<a class='btn btn-info' data-toggle='modal' data-target='#ImpresionPelambre' onclick='ImprimirPelambre(&#039;" + item.codigopelambre + "&#039;); componentesFormula(&#039;" + item.codigopelambre + "&#039;);pesa(&#039;" + item.codigopelambre + "&#039;);componentesQuimico(&#039;" + item.codigopelambre + "&#039;);'>Imprimir Detalle con Formula</a> " +
                    "<a class='btn btn-success' onclick='EliminarPelambre(&#039;" + ya + "&#039;)'>Eliminar</a>" +
                        "</td>" +
                        "</tr>";
                }
                compara = item.codigopelambre;
                    
            }

            object[] objeto = { dato };
            ListaPelambre.Add(objeto);
            return ListaPelambre;
        }

        public List<IdentityError> ClaseEliminarPelambre(string codigoUnico)
        {
            List<IdentityError> listaerrores = new List<IdentityError>();
            try
            {
                var pel = from p in _contexto.Pelambre
                          where p.codigopelambre == codigoUnico
                          select  new Pelambre {PelambreId = p.PelambreId, Bodega1Id = p.Bodega1Id } ;
                
                foreach (var item in pel.ToList())
                {
                    var bodega1 = (from b1 in _contexto.Bodega1
                                   where b1.Bodega1Id == item.Bodega1Id
                                   select new Bodega1
                                   {
                                       activo = true,
                                       ClasificacionId = b1.ClasificacionId,
                                       Fechaingreso = b1.Fechaingreso,
                                       LoteId = b1.LoteId,
                                       NumeroEstanteria = b1.NumeroEstanteria,
                                       BodegaId = b1.BodegaId,
                                       Bodega1Id = b1.Bodega1Id,
                                       NumeroPieles = b1.NumeroPieles,
                                       Observaciones = b1.Observaciones,
                                       Peso = b1.Peso,
                                       MedidaId = b1.MedidaId,
                                       TipoPielId = b1.TipoPielId

                                   }).FirstOrDefault();

                    _contexto.Bodega1.Update(bodega1);
                    _contexto.SaveChanges();

                 
                    _contexto.Pelambre.Remove(item);
                    _contexto.SaveChanges();

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
        public List<ModeloEncabezadoFormula> ModeloImprimirEncabezadoFormula(string id)
        {
            var consultaid = (from p in _contexto.Pelambre
                              where p.codigopelambre == id
                              select p).FirstOrDefault();

            var res = (from p in _contexto.Pelambre
                       join pe in _contexto.Personal on p.PersonalId equals pe.PersonalId
                       join b in _contexto.Bombo on p.BomboId equals b.BomboId
                       join fo in _contexto.Formula on p.FormulaId equals fo.FormulaId
                       join tp in _contexto.TipoPiel on fo.TipoPielId equals tp.TipoPielId
                       where p.PelambreId == consultaid.PelambreId
                       select new ModeloEncabezadoFormula
                       {
                           Bombo = b.Num_bombo.ToString(),
                           Cantidad = p.TotalPieles.ToString(),
                           FechaCreacionFormula = fo.Fecha_Creacion.ToString("dd-MM-yyyy"),
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
        public List<ModeloEncabezadoQuimico> ModeloImprimirEncabezadoQuimico(string id)
        {
            var consultaid = (from p in _contexto.Pelambre
                              where p.codigopelambre == id
                              select p).FirstOrDefault();

            var respuesta = (from p in _contexto.Pelambre
                             join pe in _contexto.Personal on p.PersonalId equals pe.PersonalId
                             join b in _contexto.Bombo on p.BomboId equals b.BomboId
                             where p.PelambreId == consultaid.PelambreId
                             select new ModeloEncabezadoQuimico
                             {
                               Fecha= DateTime.Now.ToString(),
                               Procesado= pe.Nombres+" "+pe.Apellidos,
                               Lote=p.CodigoLote,
                               Bombo= b.Num_bombo.ToString(),
                               Peso= p.Peso.ToString(),
                               Pieles= p.TotalPieles.ToString(),
                               Promedio= (p.Peso / p.TotalPieles).ToString()
     
                             }).ToList();
            return respuesta;
        }

        public List<object[]> ModeloImprimirComponentes(string id)
        {
            List<object[]> lista = new List<object[]>();
            var consultaid = (from p in _contexto.Pelambre
                             where p.codigopelambre == id
                             select p).FirstOrDefault();
            var res = (from p in _contexto.Pelambre
                       join f in _contexto.Formula on p.FormulaId equals f.FormulaId
                       join c in _contexto.Componente on f.FormulaId equals c.FormulaId
                       join m in _contexto.Medida on c.MedidaId equals m.MedidaId
                       where p.PelambreId == consultaid.PelambreId
                       select new
                       {
                           c.Detalle,
                           c.Porcentaje,
                           p.Peso,
                           c.Tiempo,
                           m.Abreviatura
                       }).ToList();
            int pesototal = (from p in _contexto.Pelambre
                             where p.codigopelambre == id
                             select p).Sum( p => p.Peso);
            foreach (var item in res)
            {
                //if (item.Detalle.ToUpper() == "BORRON DL")
                //{
                //    dato += "<tr><td>ESCURRIR BIEN</td><td></td><td></td><td></td><td></td></tr>";
                //};

                dato += "<tr>" +
                "<td>" + item.Detalle.ToUpper() + "</td>" +
                "<td>" + item.Porcentaje.ToUpper() + "</td>" +
                "<td>" + (pesototal * Double.Parse(item.Porcentaje)) / 100 + "</td>" +
                "<td>" + item.Tiempo.ToString() + " " + item.Abreviatura.ToUpper() + "</td>" +
                "<td> </td>" +
                "</tr>";
                //if (item.Detalle.ToUpper() == "AGUA")
                //{
                   // dato += "<tr><td>ESCURRIR BIEN</td><td></td><td></td><td></td><td></td></tr>";
                //};

               // if (item.Detalle.ToUpper() == "SAL LIMPIA")
                //{
                    //dato += "<tr><td>CONTROL</td><td></td><td></td><td></td><td></td></tr>";
                    //dato += "<tr><td>PH = 9,0-9,5</td><td></td><td></td><td></td><td></td></tr>";
                    //dato += "<tr><td>PH = ºB = 0-1,0</td><td></td><td></td><td></td><td></td></tr>";
                    //dato += "<tr><td>ºB = TEMP 25ºC - 28ºC</td><td></td><td></td><td></td><td></td></tr>";
                    //dato += "<tr><td>TEMP = LAVADO  </td><td></td><td></td><td>10 MIN</td><td></td></tr>";
                    //dato += "<tr><td>ESCURRIR BAÑO</td><td></td><td></td><td></td><td></td></tr>";
               // };
                //if (item.Detalle.ToUpper() == "ESCURRIR BAÑO")
                //{
                  //  dato += "<tr><td>AGUA A 28 ºC</td><td></td><td></td><td></td><td></td></tr>";

                //};
            }
            object[] objeto = { dato };
            lista.Add(objeto);
            return lista;
        }

        //imprimir quimicos
        public List<object[]> ModeloImprimirQuimicos(string id)
        {
            List<object[]> lista = new List<object[]>();
            var consultaid = (from p in _contexto.Pelambre
                              where p.codigopelambre == id
                              select p).FirstOrDefault();

            var res = (from p in _contexto.Pelambre
                       join f in _contexto.Formula on p.FormulaId equals f.FormulaId
                       join c in _contexto.Componente on f.FormulaId equals c.FormulaId
                       where p.PelambreId == consultaid.PelambreId && c.Quimico== true
                       select new
                       {
                           c.Detalle,
                           c.Porcentaje,
                           p.Peso
                       }).ToList();
            int pesototal = (from p in _contexto.Pelambre
                             where p.codigopelambre == id
                             select p).Sum(p => p.Peso);
            foreach (var item in res)
            {
                 dato += "<tr>" +
                "<td>" + item.Detalle.ToUpper() + "</td>" +
                "<td>" + item.Porcentaje.ToUpper() + "</td>" +
                "<td>" + (pesototal * Double.Parse(item.Porcentaje)) / 100 + "</td>" +
                "<td> </td>" +
                "</tr>";
            }
            object[] objeto = { dato };
            lista.Add(objeto);
            return lista;
        }

        public List<object[]> ModeloImprimirPesaje(string id)
        {
            List<object[]> lista = new List<object[]>();
            var consultaid = (from p in _contexto.Pelambre
                              where p.codigopelambre == id
                              select p).FirstOrDefault();

            var res = (from p in _contexto.Pelambre
                       join b in _contexto.Bombo on p.BomboId equals b.BomboId
                       join b1 in _contexto.Bodega1 on p.Bodega1Id equals b1.Bodega1Id
                       join bo in _contexto.Bodega on b1.BodegaId equals bo.BodegaId
                       join c in _contexto.Clasificacion on b1.ClasificacionId equals c.ClasificacionId
                       where p.PelambreId == consultaid.PelambreId 
                       select new
                       {
                           p.CodigoLote,
                           b.Num_bombo,
                           bo.NombreBodega,
                           p.Peso,
                           p.Fecha,
                          p.TotalPieles,
                          c.Selecciones
                          }).ToList();
            int pesototal = (from p in _contexto.Pelambre
                             where p.codigopelambre == id
                             select p).Sum(p => p.Peso);
            foreach (var item in res)
            {

                dato += "<tr>" +
                "<td>" + item.CodigoLote.ToUpper() + "</td>" +
                 "<td>" + item.Num_bombo + "</td>" +
                "<td>" + item.TotalPieles + "</td>" +
                 
                    "<td>" + item.Peso + "</td>" +

                    "<td>" + item.Fecha + "</td>" +
                "<td>" + item.NombreBodega.ToUpper() + "Estanteria  </td>" +
                "<td>" + item.Selecciones + "</td>" +
                "<td> </td>" +
                "</tr>";

            }
            object[] objeto = { dato };
            lista.Add(objeto);
            return lista;
        }

        public List<object[]> ModeloImprimirDetallePelambre(string id)
        {
            List<object[]> Enlistar = new List<object[]>();
            var consultaid = (from p in _contexto.Pelambre
                              where p.codigopelambre == id
                              select p).FirstOrDefault();
            var res = (from p in _contexto.Pelambre
                       join b in _contexto.Bombo on p.BomboId equals b.BomboId
                       join b1 in _contexto.Bodega1 on p.Bodega1Id equals b1.Bodega1Id
                       join bd in _contexto.Bodega on b1.BodegaId equals bd.BodegaId
                       join c in _contexto.Clasificacion on b1.ClasificacionId equals c.ClasificacionId
                       where p.PelambreId == consultaid.PelambreId
                       select new
                       {
                           b.Num_bombo,
                           p.TotalPieles,
                           c.Selecciones,
                           p.Peso,
                           p.Fecha,
                           bd.NombreBodega,
                           b1.NumeroEstanteria,
                           p.CodigoLote

                       }).ToList();


            foreach (var item in res)
            {
                dato += "<tr>" +
                "<td>" + item.Num_bombo + "</td>" +
                "<td>" + item.TotalPieles + "</td>" +
                "<td>" + item.Selecciones.ToUpper() + "</td>" +
                "<td>" + item.Peso + "</td>" +
                "<td>" + item.Fecha + "</td>" +
                "<td>" + item.NombreBodega.ToUpper() + "</td>" +
                "<td>" + item.NumeroEstanteria + "</td>" +
                "<td>" + item.CodigoLote.ToUpper() + "</td>" +
                "</tr>";
            }
            object[] objeto = { dato };
            Enlistar.Add(objeto);
            return Enlistar;
        }        
        //imprimir reporte de pelambres
        public List<object[]> ModeloImprimirPelambre(string id)
        {
            List<object[]> listareporte = new List<object[]>();
            var res = (from p in _contexto.Pelambre
                       join b1 in _contexto.Bodega1 on p.Bodega1Id equals b1.Bodega1Id
                       join f in _contexto.Formula on p.FormulaId equals f.FormulaId
                       join b in _contexto.Bombo on p.BomboId equals b.BomboId
                       join l in _contexto.Lote on b1.LoteId equals l.LoteId
                       join c in _contexto.Clasificacion on b1.ClasificacionId equals c.ClasificacionId
                       join tp in _contexto.TipoPiel on l.TipoPielId equals tp.TipoPielId
                       
                       select new
                       {
                           
                           l.Codigolote,
                           tp.Detalle,
                           c.Selecciones,
                           p.Fecha,
                           b.Num_bombo,
                           f.Nombre
                       }).ToList();
            foreach (var item in res)
            {
                datoimprime += "<tr><td>" + item.Codigolote + "</td>" +
                                   "<td>" + item.Detalle + "</td>" +
                                   "<td>" + item.Selecciones + "</td>" +
                                   "<td>" + item.Fecha.ToString("dd-MM-yyyy hh:mm") + "</td>" +
                                   "<td>" + item.Num_bombo + "</td>" +
                                   "<td>" + item.Nombre + "</td>"+
                                   "</tr>";
            }

            object[] objeto = { datoimprime };
            listareporte.Add(objeto);
            return listareporte;
        }

        public List<Pelambre> Listapelambres()
        {
            return _contexto.Pelambre.OrderBy(p => p.Fecha ).ToList();
        }

    }

}
