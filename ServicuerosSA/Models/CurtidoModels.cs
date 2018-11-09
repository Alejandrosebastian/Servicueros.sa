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
        public List<IdentityError> ClaseGuardaCurtido(int tipotripa, int numbombo, int numpieles,int medida, int formula, DateTime fecha, int peso, int Bodega, int personal, string Codicurtido)
        {
            List<IdentityError> Listaerrores = new List<IdentityError>();
            var curtidolista = _contexto.Bodegatripa.Where(cu => cu.BodegaTripaId == tipotripa).ToList();
            foreach (var item in curtidolista)
            {
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
                                       where bt.BodegaTripaId == item.BodegaTripaId
                                       select new Bodegatripa
                                       {
                                           DescarneId = item.DescarneId,
                                           BodegaId = item.BodegaId,
                                           ClasificacionTripaId = item.ClasificacionTripaId,
                                           PersonalId = personal,
                                           MedidaId = item.MedidaId,
                                           activo = false
                                       }).FirstOrDefault();
                    _contexto.Bodegatripa.Update(cla);
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
                        Description = e.Message,
                    });
                }

            }
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
    }


}
