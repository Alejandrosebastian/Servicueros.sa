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


    }
}
