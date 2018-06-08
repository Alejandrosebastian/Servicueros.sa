using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServicuerosSA.Data;
namespace ServicuerosSA.Models
{
    public class TipoPielModel
    {
        private ApplicationDbContext _contexto;
        public TipoPielModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }
        public List<TipoPiel> ClaseModelListaTipoPiel()
        {
            return _contexto.TipoPiel.ToList();
        }
    }
}
