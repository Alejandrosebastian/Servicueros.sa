using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ServicuerosSA.Data;

namespace ServicuerosSA.Models
{
    public class EscurridoModels
    {
        private ApplicationDbContext _contexto;

        public EscurridoModels(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }
        public List<Curtido> Modelolistacurtido()
        {
            return _contexto.Curtido.Where(c => c.Activo == true).ToList();
        }
        public List<IdentityError> Modelonumeropielescurrido(int codigocurti, int valor)
        { 
            List<IdentityError> lista = new List<IdentityError>();
        IdentityError er = new IdentityError();
            int curtidonum = _contexto.Curtido.Where(c => c.CurtidoId == codigocurti && c.NPieles == valor).Count();
                if(valor <= curtidonum)
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
        public List<IdentityError> GuardarEscurrido(int bombo, int cantidad, string codilote, DateTime fecha, string curtido, int personal, string codiuniescurridio)
        {
            List<IdentityError> listaerror = new List<IdentityError>();
            List<curtidolis> curtilista = (from cu in _contexto.Curtido
                                              where cu.CurtidoId == Convert.ToInt32(curtido)
                                              select new curtidolis
                                              {
                                                  activo = cu.Activo,
                                                  BomboId = cu.BomboId,
                                                  codigolote = cu.codigolote,
                                                  npieles = cu.NPieles,
                                                  PersonalId = cu.PersonalId,
                                                  BodegaId = cu.BodegaId,
                                                  curtidoId = cu.CurtidoId,
                                                  fecha = cu.Fecha,
                                                  BodegaTripaId = cu.BodegaTripaId,
                                                  MedidaId = cu.MedidaId,
                                                  FormulaId = cu.FormulaId,
                                                  observaciones = cu.Observaciones,
                                                  codicurtido= cu.codicurtido,
                                                  peso = cu.Peso
                                              }).ToList();
            foreach (var item in curtilista)
            {
                try
                {
                    var guardaescurrido = new Escurrido
                    {
                        
                        CurtidoId = item.curtidoId,
                        BomboId = bombo,
                        Cantidad = cantidad,
                        CodigoLote = codilote,
                        Fecha = DateTime.Now,
                        PersonalId = personal,
                        codiuniescurridio= codiuniescurridio,
                        Activo = true
                    };
                    _contexto.Escurrido.Add(guardaescurrido);
                    _contexto.SaveChanges();

                    Curtido curt = (from curti in _contexto.Curtido
                                     where curti.CurtidoId == item.curtidoId
                                    select new Curtido
                                     {
                                         Activo =false,
                                         BomboId = curti.BomboId,
                                         codigolote = curti.codigolote,
                                         NPieles = curti.NPieles,
                                         PersonalId = curti.PersonalId,
                                         BodegaId = curti.BodegaId,
                                         CurtidoId = curti.CurtidoId,
                                         Fecha = curti.Fecha,
                                         BodegaTripaId = curti.BodegaTripaId,
                                         MedidaId = curti.MedidaId,
                                         FormulaId = curti.FormulaId,
                                         Observaciones = curti.Observaciones,
                                         codicurtido = curti.codicurtido,
                                         Peso = curti.Peso
                                     }).FirstOrDefault();
                    _contexto.Curtido.Update(curt);
                    _contexto.SaveChanges();
                    listaerror.Add(new IdentityError
                    {
                        Code = "ok",
                        Description = "ok"
                    });
                }
                catch(Exception e)
                {
                    listaerror.Add(new IdentityError
                    {
                        Code= e.Message,
                        Description = e.Message
                    });
                }
            }
            return listaerror; 
        }



    }
}
