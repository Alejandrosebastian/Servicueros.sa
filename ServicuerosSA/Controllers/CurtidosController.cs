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
    public class CurtidosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private ClasificacionTripaModel tipotripa;
        private BomboModel bombos;
        private PersonalModel personas;
        private CurtidoModels curtido;
        private CurtidoModels claseCurtido;
       
        public CurtidosController(ApplicationDbContext context)
        {
            _context = context;
            tipotripa = new ClasificacionTripaModel(context);
            bombos = new BomboModel(context);
            personas = new PersonalModel(context);
            curtido = new CurtidoModels(context);
            claseCurtido = new CurtidoModels(context);
        }
        public List<ClasificacionTripa> listatripas()
        {
            return curtido.Combomodelotripa();
        }
        public List<object[]> ControladorListacurtido()
        {
            return curtido.Modelolistacurtido();
        }
        public List<object[]> ControladorListaIndexCurtido(int id)
        {
            return curtido.ClaseIndexCurtido(id);
            
        }
        public List<object[]> ControladorImprimircurtido()
        {
            return curtido.Modeloimprimircurtido();
        }
        public List<object[]> ControladorListaChecks(int id)
        {
            List<object[]> lista = new List<object[]>();
            List<ListaCurtidoCheck> datos = new List<ListaCurtidoCheck>();
            if (id == 0)
            {
                datos = (from bt in _context.Bodegatripa
                         join me in _context.Medida on bt.MedidaId equals me.MedidaId
                         join d in _context.Descarne on bt.DescarneId equals d.DescarneId

                         join cl in _context.ClasificacionTripa on bt.ClasificacionTripaId equals cl.ClasificacionTripaId
                         join p in _context.Personal on bt.PersonalId equals p.PersonalId
                         join b in _context.Bodega on bt.BodegaId equals b.BodegaId

                         where bt.ClasificacionTripaId != 8 && bt.ClasificacionTripaId != 9
                         select new ListaCurtidoCheck
                         {
                             BodegaId = bt.BodegaId,
                             Detalle = cl.Detalle,
                             BodegaTripaId = bt.BodegaTripaId,
                             peso = bt.peso,
                             NumeroPieles = bt.NumeroPieles,
                             CodigoLote = d.CodigoLote,
                             Abreviatura = me.Abreviatura,
                             MedidaId = me.MedidaId
                         }).ToList();
            }
            else
            {
                datos = (from bt in _context.Bodegatripa
                         join me in _context.Medida on bt.MedidaId equals me.MedidaId
                         join d in _context.Descarne on bt.DescarneId equals d.DescarneId

                         join cl in _context.ClasificacionTripa on bt.ClasificacionTripaId equals cl.ClasificacionTripaId
                         join p in _context.Personal on bt.PersonalId equals p.PersonalId
                         join b in _context.Bodega on bt.BodegaId equals b.BodegaId

                         where bt.ClasificacionTripaId != 8 && bt.ClasificacionTripaId != 9 && bt.ClasificacionTripaId == id
                         select new ListaCurtidoCheck
                         {

                             BodegaId = bt.BodegaId,
                             Detalle = cl.Detalle,
                             BodegaTripaId = bt.BodegaTripaId,
                             peso = bt.peso,
                             NumeroPieles = bt.NumeroPieles,
                             CodigoLote = d.CodigoLote,
                             Abreviatura = me.Abreviatura,
                             MedidaId = me.MedidaId
                         }).ToList();
            }


            string html = "";
            foreach (var item in datos)
            {
                html += "<tr>" +
                    "<td><input type='checkbox' class='form-control' value=" + item.BodegaId + "/>" +

                     "<td class='hidden'>" + item.BodegaId + "</td>" +
                     "<td class='hidden'>" + item.BodegaTripaId + "</td>" +
                     "<td class='hidden'>" + item.MedidaId + "</td>" +
                     "<td>" + item.CodigoLote + "</td>" +
                     "<td>" + item.Detalle + "</td>" +
                    "<td>" + item.NumeroPieles + "</td>" +
                    "<td>" + item.peso + "</td>" +
                     "<td>" + item.Abreviatura + "</td>" +

                    "</tr>";

            }
            object[] llena = { html };
            lista.Add(llena);
            return lista;

        }
        public List<ClasificacionTripa> Controcurtilistatripa()
        {
            return tipotripa.ClaseModeloListaClasificacionTripa();
        }
        public List<Bombo> Controcurtibombo()
        {
            return bombos.ClaseListaBombo();
        }
        public List<Personal> Contrucurtiperso()
        {
            return personas.ListaPersonal();
        }

        public List<IdentityError> ControladorGuardaCurtido(int tipotripa, int numbombo, decimal numpieles, int medida, int formula, DateTime fecha, int peso, int bodega, int personal, string Codicurtido)
        {
            return curtido.ClaseGuardaCurtido(tipotripa, numbombo, numpieles, medida, formula, fecha, peso, bodega, personal, Codicurtido);
        }
        // GET: Curtidos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Curtido.Include(c => c.Bombo).Include(c => c.Formula).Include(c => c.Personal);
            return View(await applicationDbContext.ToListAsync());
        }
        //IMPRESION FORMULA
        public List<ModeloEncabezadoFormula> ControladorImprimirEncabezadoFormula(string id)
        {
            return claseCurtido.ModeloImprimirEncabezadoFormula(id);
        }
        //IMPRIMIR COMPONENTES FORMULA
        public List<object[]> ControladorComponentesFormula(string id)
        {
            return claseCurtido.ModeloImprimirComponentes(id);
        }
        // GET: Curtidos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var curtido = await _context.Curtido
                .Include(c => c.Bombo)
                
                .Include(c => c.Formula)
                .Include(c => c.Personal)
                .SingleOrDefaultAsync(m => m.CurtidoId == id);
            if (curtido == null)
            {
                return NotFound();
            }

            return View(curtido);
        }

        // GET: Curtidos/Create
        public IActionResult Create()
        {
            ViewData["BomboId"] = new SelectList(_context.Bombo, "BomboId", "BomboId");
            ViewData["ClasificacionTripaId"] = new SelectList(_context.ClasificacionTripa, "ClasificacionTripaId", "Detalle");
            ViewData["FormulaId"] = new SelectList(_context.Formula, "FormulaId", "Nombre");
            ViewData["PersonalId"] = new SelectList(_context.Personal, "PersonalId", "Apellidos");
            return View();
        }

        // POST: Curtidos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CurtidoId,Fecha,Peso,Observaciones,NPieles,FormulaId,PersonalId,ClasificacionTripaId,BomboId")] Curtido curtido)
        {
            if (ModelState.IsValid)
            {
                _context.Add(curtido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BomboId"] = new SelectList(_context.Bombo, "BomboId", "BomboId", curtido.BomboId);
            
            ViewData["FormulaId"] = new SelectList(_context.Formula, "FormulaId", "Nombre", curtido.FormulaId);
            ViewData["PersonalId"] = new SelectList(_context.Personal, "PersonalId", "Apellidos", curtido.PersonalId);
            return View(curtido);
        }

        // GET: Curtidos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var curtido = await _context.Curtido.SingleOrDefaultAsync(m => m.CurtidoId == id);
            if (curtido == null)
            {
                return NotFound();
            }
            ViewData["BomboId"] = new SelectList(_context.Bombo, "BomboId", "BomboId", curtido.BomboId);
            
            ViewData["FormulaId"] = new SelectList(_context.Formula, "FormulaId", "Nombre", curtido.FormulaId);
            ViewData["PersonalId"] = new SelectList(_context.Personal, "PersonalId", "Apellidos", curtido.PersonalId);
            return View(curtido);
        }

        // POST: Curtidos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CurtidoId,Fecha,Peso,Observaciones,NPieles,FormulaId,PersonalId,ClasificacionTripaId,BomboId")] Curtido curtido)
        {
            if (id != curtido.CurtidoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(curtido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CurtidoExists(curtido.CurtidoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["BomboId"] = new SelectList(_context.Bombo, "BomboId", "BomboId", curtido.BomboId);
            
            ViewData["FormulaId"] = new SelectList(_context.Formula, "FormulaId", "Nombre", curtido.FormulaId);
            ViewData["PersonalId"] = new SelectList(_context.Personal, "PersonalId", "Apellidos", curtido.PersonalId);
            return View(curtido);
        }

        // GET: Curtidos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var curtido = await _context.Curtido
                .Include(c => c.Bombo)
                
                .Include(c => c.Formula)
                .Include(c => c.Personal)
                .SingleOrDefaultAsync(m => m.CurtidoId == id);
            if (curtido == null)
            {
                return NotFound();
            }

            return View(curtido);
        }

        // POST: Curtidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var curtido = await _context.Curtido.SingleOrDefaultAsync(m => m.CurtidoId == id);
            _context.Curtido.Remove(curtido);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CurtidoExists(int id)
        {
            return _context.Curtido.Any(e => e.CurtidoId == id);
        }
    }
}
