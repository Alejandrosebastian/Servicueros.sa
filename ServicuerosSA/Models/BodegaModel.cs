using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServicuerosSA.Data;
namespace ServicuerosSA.Models
{

    public class BodegaModel
    {
        private ApplicationDbContext _contexto;
        public BodegaModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }
        public List<object[]> ClaseBodega(int bodegaId)
        {
            List<object[]> lista = new List<object[]>();
            var bodega = (from b in _contexto.Bodega
                          join tb in _contexto.TipoBodega on b.TipoBodegaId equals tb.TipoBodegaId
                          where b.BodegaId == bodegaId
                          select new
                          {
                              b.NombreBodega,
                              b.NumeroEstantes,
                              b.CantidadAlmacenamiento,
                              tb.Detalle
                          }).ToList();
            
            var dato = "";
            foreach (var item in bodega)
            {
                dato += "<spam> Nombre: " + item.NombreBodega + "</spam><br/> "+
                    " <spam> Numero de Estantes: " + item.NumeroEstantes + "</spam> <br/>" +
                    " <spam> Capacidad: " + item.CantidadAlmacenamiento + "kg</spam> <br/>" +
                    " <spam> Tipo de Bodega: " + item.Detalle + " </spam >";
            }
            object[] objetos = { dato };
            lista.Add(objetos);
            return lista;

        }
        
    }
    
}
