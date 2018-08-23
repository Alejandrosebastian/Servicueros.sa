using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServicuerosSA.Data;
namespace ServicuerosSA.Models
{
    public class ClasificacionTripaModel
    {
        ApplicationDbContext _contexto;
        private ClasificacionTripaModel listatipotripas;
        public ClasificacionTripaModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }
        public List<ClasificacionTripa> ClaseModeloListaClasificacionTripa()
        {
            return _contexto.ClasificacionTripa.OrderBy(c => c.Detalle).ToList();
        }
       public List<Descarne> Claselistadescarnes()
        {
            return _contexto.Descarne.OrderBy(d => d.DescarneId).ToList();
        }
     
       public List<object[]>ModeloFiltrarClasificacionTripa()
       {
           List<object[]> lista = new List<object[]>();
           string datos = "";
            var res = (from de in _contexto.Descarne
                       join pe in _contexto.Pelambre on de.PelambreId equals pe.PelambreId
                       where pe.PelambreId == 9
                       select new
                       {
                           pe.CodigoLote,
                           pe.Codigo,
                           de.Cantidad,
                           pe.Peso

                       }).ToList();
            foreach(var item in res)
            {
                datos ="<tr>"+
                    "<td>" + item.CodigoLote + ""+ item.Codigo + "</td>" +
                    "<td>" + item.Cantidad + "</td>" +
                    "<td>" + item.Peso + "</td>" +
                   
                    "</tr>";
            }
            object[] objetodatos = { datos };
            lista.Add(objetodatos);
            return lista;
       }
    }
}
