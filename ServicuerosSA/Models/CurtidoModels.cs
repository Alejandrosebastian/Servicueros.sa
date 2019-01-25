using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ServicuerosSA.Data;
namespace ServicuerosSA.Models
{
    public class CurtidoModels
    {
        string dato = "";
       
        private ApplicationDbContext _contexto;
        private ClasificacionTripa tipotripas;
        public CurtidoModels(ApplicationDbContext contexto)
        {
            _contexto = contexto;
            tipotripas = new ClasificacionTripa();
        }
        public List<ClasificacionTripa> Combomodelotripa()
        {
            return _contexto.ClasificacionTripa.OrderBy(cl => cl.Detalle).ToList();
        }
        public List<IdentityError> ClaseGuardaCurtido(int tipotripa, int numbombo, decimal numpieles,int medida, int formula, DateTime fecha, int peso, int Bodega, int personal, string Codicurtido)
        {
            List<IdentityError> Listaerrores = new List<IdentityError>();
            IdentityError error = new IdentityError();
                try
                {
                    var guardaCurtido = new Curtido
                    {
                        BodegaTripaId = tipotripa,
                        BomboId = numbombo,
                        NPieles = numpieles,
                        MedidaId = medida,
                        FormulaId = formula,
                        Fecha = DateTime.Now,
                        Peso = peso,
                        BodegaId = Bodega,
                        PersonalId = personal,
                        codicurtido = Codicurtido
                    };
                    _contexto.Curtido.Add(guardaCurtido);
                    _contexto.SaveChanges();
                    Bodegatripa cla = (from bt in _contexto.Bodegatripa
                                       where bt.BodegaTripaId == tipotripa
                                       select new Bodegatripa
                                       {
                                           DescarneId = bt.DescarneId,
                                           BodegaId = bt.BodegaId,
                                           ClasificacionTripaId = bt.ClasificacionTripaId,
                                           PersonalId = personal,
                                           MedidaId = medida,
                                           activo = false, BodegaTripaId = tipotripa
                                       }).FirstOrDefault();
                    _contexto.Bodegatripa.Update(cla);
                    _contexto.SaveChanges();
                    error = new IdentityError
                    {
                        Code = "ok",
                        Description = "ok"
                    };
                }
                catch (Exception e)
                {
                    error = new IdentityError
                    {
                        Code = e.Message,
                        Description = e.Message,
                    };
                }

            Listaerrores.Add(error);
            return Listaerrores;
        }
        public List<object[]> Modelolistacurtido()
        {
            List<object[]> lista = new List<object[]>();
            string lis = "";
            var curt = (from cu in _contexto.Curtido
            join bo in _contexto.Bombo on cu.BomboId equals bo.BomboId
            join fo in _contexto.Formula on cu.FormulaId equals fo.FormulaId
            join bod in _contexto.Bodegatripa on cu.BodegaTripaId equals bod.BodegaTripaId
            join clasi in _contexto.ClasificacionTripa on bod.ClasificacionTripaId equals clasi.ClasificacionTripaId
            join me in _contexto.Medida on cu.MedidaId equals me.MedidaId
            join bode in _contexto.Bodega on cu.BodegaId equals bode.BodegaId


             select new
             {   fecha= DateTime.Now,
                 bode.NombreBodega,
                 clasi.Detalle,
                 cu.Peso,
                 me.Abreviatura,
                 bo.Num_bombo,
                 fo.Nombre

             });
            foreach (var item in curt)
            {
                lis += "<tr>" +
                    "<td>" + item.fecha + "</td>" +
                    "<td>" + item.NombreBodega + "</td>" +
                    "<td>" + item.Detalle + "</td>" +
                    "<td>" + item.Peso + " " + item.Abreviatura + "</td>" +
                    "<td>" + item.Num_bombo + "</td>" +
                    "<td>" + item.Nombre + "</td>" +
                     "</tr>";
            }
            object[] datos = { lis };
            lista.Add(datos);
            return lista;
        }
        //Encabezado Formula
        public List<ModeloEncabezadoFormula> ModeloImprimirEncabezadoFormula(string id)
        {
            var consultaid = (from cu in _contexto.Curtido
                              where cu.codicurtido == id
                              select cu).FirstOrDefault();

            var res = (from cu in _contexto.Curtido
                       join pe in _contexto.Personal on cu.PersonalId equals pe.PersonalId
                       join b in _contexto.Bombo on cu.BomboId equals b.BomboId
                       join fo in _contexto.Formula on cu.FormulaId equals fo.FormulaId
                       join tp in _contexto.TipoPiel on fo.TipoPielId equals tp.TipoPielId
                       
                       where cu.CurtidoId == consultaid.CurtidoId
                       select new ModeloEncabezadoFormula
                       {
                           Bombo = b.Num_bombo.ToString(),
                           Cantidad = cu.NPieles.ToString(),
                           FechaCreacionFormula = fo.Fecha_Creacion.ToString("dd-MM-yyyy"),
                           FechaImpresion = DateTime.Now.ToString(),
                           NombreAutoirzado = pe.Nombres + " " + pe.Apellidos,
                           FechaValida = DateTime.Now.ToString(),
                           NombreEntregado = pe.Nombres + " " + pe.Apellidos,
                           NombreProcesado = fo.TipoProceso,
                           Codigo = cu.codicurtido,
                           Parada = cu.CurtidoId.ToString(),
                           Peso = cu.Peso.ToString(),
                           Promedio = (cu.Peso / cu.NPieles).ToString(),
                           Version = fo.Version,
                           TipoPiel = tp.Detalle
                       }).ToList();
            return res;
        }
        //Imprimir Componentes
        public List<object[]> ModeloImprimirComponentes(string id)
        {
            List<object[]> lista = new List<object[]>();
            var consultaid = (from cu in _contexto.Curtido
                              where cu.codicurtido == id
                              select cu).FirstOrDefault();
            var res = (from cu in _contexto.Curtido
                       join f in _contexto.Formula on cu.FormulaId equals f.FormulaId
                       join c in _contexto.Componente on f.FormulaId equals c.FormulaId
                       join m in _contexto.Medida on c.MedidaId equals m.MedidaId
                       where cu.CurtidoId == consultaid.CurtidoId
                       select new
                       {
                           c.Detalle,
                           c.Porcentaje,
                           cu.Peso,
                          cu.Observaciones
                       }).ToList();
            int pesototal = (from cu in _contexto.Curtido
                             where cu.codicurtido == id
                             select cu).Sum(cu => cu.Peso);
            foreach (var item in res)
            {
                 dato += "<tr>" +
                "<td>" + item.Detalle.ToUpper() + "</td>" +
                "<td>" + item.Porcentaje.ToUpper() + "</td>" +
                "<td>" + (pesototal * Double.Parse(item.Porcentaje)) / 100 + "</td>" +
                "<td>" + item.Observaciones + "</td>" +
                "<td> </td>" +
                "</tr>";
            }
            object[] objeto = { dato };
            lista.Add(objeto);
            return lista;
        }

        //Reporte Curtido
        public List<object[]> Modeloimprimircurtido()
        {
            List<object[]> lista = new List<object[]>();
            string imprime = "";
            var i = (from cu in _contexto.Curtido
                        join bo in _contexto.Bombo on cu.BomboId equals bo.BomboId
                        join fo in _contexto.Formula on cu.FormulaId equals fo.FormulaId
                        join bod in _contexto.Bodegatripa on cu.BodegaTripaId equals bod.BodegaTripaId
                        join clasi in _contexto.ClasificacionTripa on bod.ClasificacionTripaId equals clasi.ClasificacionTripaId
                        join me in _contexto.Medida on cu.MedidaId equals me.MedidaId
                        join bode in _contexto.Bodega on cu.BodegaId equals bode.BodegaId
                        select new
                        {
                            fecha = DateTime.Now,
                            bode.NombreBodega,
                            clasi.Detalle,
                            cu.Peso,
                            me.Abreviatura,
                            bo.Num_bombo,
                            fo.Nombre

                        });
            foreach (var item in i)
            {
                imprime += "<tr>" +
                    "<td>" + item.fecha + "</td>" +
                    "<td>" + item.NombreBodega + "</td>" +
                    "<td>" + item.Detalle + "</td>" +
                    "<td>" + item.Peso + " " + item.Abreviatura + "</td>" +
                    "<td>" + item.Num_bombo + "</td>" +
                    "<td>" + item.Nombre + "</td>" +
                     "</tr>";
            }
            object[] datos = { imprime };
            lista.Add(datos);
            return lista;
        }
        //ListaIndexCurtido
        public List<object[]> ClaseIndexCurtido( int idCurtido)
        {
            List<object[]> ListaCurtido = new List<object[]>();
            string dato = "";
            var cur = (from cu in _contexto.Curtido
                       join bo in _contexto.Bombo on cu.BomboId equals bo.BomboId
                       join fo in _contexto.Formula on cu.FormulaId equals fo.FormulaId
                       join bod in _contexto.Bodegatripa on cu.BodegaTripaId equals bod.BodegaTripaId
                       join clasi in _contexto.ClasificacionTripa on bod.ClasificacionTripaId equals clasi.ClasificacionTripaId
                       join me in _contexto.Medida on cu.MedidaId equals me.MedidaId
                       join bode in _contexto.Bodega on cu.BodegaId equals bode.BodegaId
                       
                       select new
                       {
                           fecha = DateTime.Now,
                           bode.NombreBodega,
                           clasi.Detalle,
                           cu.Peso,
                           me.Abreviatura,
                           bo.Num_bombo,
                           fo.Nombre,
                           cu.codicurtido

                       }).ToList();

            string compara = "";
            foreach (var item in cur)
            {
                dato += "<tr>" +
                    "<td style= width: auto> " + item.fecha + "</td>" +
                    "<td>" + item.NombreBodega + "</td>" +
                    "<td>" + item.Detalle + "</td>" +
                    "<td>" + item.Peso + " " + item.Abreviatura + "</td>" +
                    "<td>" + item.Num_bombo + "</td>" +
                    "<td>" + item.Nombre + "</td>";
                    
                string ya = item.codicurtido;
                if (compara != item.codicurtido)
                {
                    dato += "<td>" + "<a class='btn btn-info' data-toggle='modal' data-target='#ImpresionCurtido' onclick='imprimirCurtido(&#039;" + item.codicurtido + "&#039;);componentesFormulaCurtido(&#039;" + item.codicurtido + "&#039;)'>Imprimir Detalle con Formula</a> " +
                       "<a class='btn btn-success' onclick='EliminarCurtido(&#039;" + ya + "&#039;)'>Eliminar</a>" +
                           "</td>" +
                           "</tr>";
                }
                compara = item.codicurtido;

            }

            object[] objeto = { dato };
            ListaCurtido.Add(objeto);
            return ListaCurtido;
        }
    }


}
