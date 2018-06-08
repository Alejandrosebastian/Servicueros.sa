using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServicuerosSA.Data;
namespace ServicuerosSA.Models
{
    public class BomboModel
    {
        private ApplicationDbContext _contexto;
        public BomboModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }
        internal List<Bombo> ClaseListaBombo()
        {
            return _contexto.Bombo.OrderBy(b => b.BomboId).ToList();
        }
        public List<object[]> ClaseBombo(int bomboid)
        {
            List<object[]> lista = new List<object[]>();
            var bombo = _contexto.Bombo.Where(b => b.BomboId == bomboid).ToList();
            var dato = "";
            foreach (var item in bombo)
            {
                dato += "<div>" +
                    "<spam>Numero de Bombo: " + item.Num_bombo + "</spam>" +
                    "<spam>Capacidad: " + item.Capacidad + " kg</spam>";
            }
            object[] objetos = { dato };
            lista.Add(objetos);
            return lista;

        }
    }
}
