using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ServicuerosSA.Data;
using ServicuerosSA.Models;

namespace ServicuerosSA.Controllers
{
    public class DescarnesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private DescarneModel claseDescarne;
        private PelambreModel clasePelambre;
        public DescarnesController(ApplicationDbContext context)
        {
            _context = context;
            claseDescarne = new DescarneModel(context);
            clasePelambre = new PelambreModel(context);
        }
        public List<Pelambre> Controladorlistapelambre()
        {
            return claseDescarne.Modelolistapelambres();
        }
        // GET: Descarnes
        public async Task<IActionResult> Index()
        {

            return View();
        }
        public List<object[]>ControladorListaDescarne()
        {
            return claseDescarne.ClaseListaDescarne();
        }

        // GET: Descarnes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var descarne = await _context.Descarne
                .Include(d => d.Pelambres)
                .SingleOrDefaultAsync(m => m.DescarneId == id);
            if (descarne == null)
            {
                return NotFound();
            }

            return View(descarne);
        }

        public List<IdentityError> ControladorGuardaDescarne(int cantidad , DateTime fecha, int personal, int pelambre, string codigolote)
        {
            return claseDescarne.ClaseGuardarDescarne(pelambre, cantidad, fecha, personal,codigolote);
        }
        public List<IdentityError> ControladorNumeroPielesDescarne(int idPelambre, int valor)
        {
            return claseDescarne.ModeloNumeroPielesDescarne(idPelambre, valor);
        }
        public List<IdentityError> ControladorEliminarDescarne(string codigoUnico)
        {
            return claseDescarne.ClaseEliminarDescarne(codigoUnico);
        }
        // GET: Descarnes/Creat     


        public int ControladorUnPelambreDescarne(string id)
        {
            return _context.Pelambre.Where(p => p.Codigo == id && p.Activo == true).Sum(p => p.TotalPieles);
        }

    }
}
