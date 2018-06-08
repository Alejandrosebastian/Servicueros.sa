using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServicuerosSA.Data;
using ServicuerosSA.Models;
namespace ServicuerosSA.Models
{
    public class FormulaModel
    {
        private ApplicationDbContext _contexto;
        public FormulaModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }
        internal List<Formula> ModelListaFormula()
        {
            return _contexto.Formula.OrderBy(f => f.FormulaId).ToList();
        }
    }
}
