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
        public List<IdentityError> ClaseGuardaCurtido(int tipotripa, int numbombo, int numpieles, int formula, DateTime fecha, int peso, int Bodega, int Personal, string Codicurtido)
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
                        FormulaId = formula,
                        Fecha = DateTime.Now,
                        Peso = peso,
                        BodegaId = Bodega,
                        PersonalId = Personal,
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
                                           PersonalId = Personal,
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
                        Code = "ok",
                        Description = "ok"
                    });
                }

            }
            return Listaerrores;
        }

    }
}
