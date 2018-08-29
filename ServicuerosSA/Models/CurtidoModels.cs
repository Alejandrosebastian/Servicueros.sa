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
        private ClasificacionTripa tipotripa;
        public CurtidoModels(ApplicationDbContext contexto)
        {
            _contexto = contexto;
            tipotripa = new ClasificacionTripa();
        }
        public List<ClasificacionTripa> Combomodelotripa()
        {
            return _contexto.ClasificacionTripa.OrderBy(cl => cl.Detalle).ToList();
        }
        

    }
}
