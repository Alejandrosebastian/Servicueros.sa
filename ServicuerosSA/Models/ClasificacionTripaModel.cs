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
        public ClasificacionTripaModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }
        public List<ClasificacionTripa> ClaseModeloListaClasificacionTripa()
        {
            return _contexto.ClasificacionTripa.OrderBy(c => c.Detalle).ToList();
        }
        //public List<object[]>ModeloFiltrarClasificacionTripa(int id)
        //{
        //    List<object[]> lista = new List<object[]>();
        //    string res = "";
        //    var datos = ();
        //}
    }
}
