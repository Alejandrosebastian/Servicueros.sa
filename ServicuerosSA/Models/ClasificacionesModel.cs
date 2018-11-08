using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServicuerosSA.Data;
namespace ServicuerosSA.Models
{
    public class ClasificacionesModel
    {
        ApplicationDbContext _contexto;
        public ClasificacionesModel(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public List<Clasificacion> ClaseModeloListaClasificaciones()
        {
            return _contexto.Clasificacion.OrderBy(c => c.Selecciones).ToList();
        }

        public List<object[]> ModeloFiltroPelambreClasificacion(int id)
        {
            List<object[]> lista = new List<object[]>();
            string res = "";

            var datos = (from b1 in _contexto.Bodega1
                       join l in _contexto.Lote on b1.LoteId equals l.LoteId
                       join tp in _contexto.TipoPiel on l.TipoPielId equals tp.TipoPielId
                       join cl in _contexto.Clasificacion on b1.ClasificacionId equals cl.ClasificacionId
                       where b1.activo == true && cl.ClasificacionId == id
                       select new
                       {
                           b1.Bodega1Id,
                           l.Codigolote,
                           cl.Selecciones,
                           b1.NumeroPieles,
                           tp.Detalle,
                           b1.Peso
                       });
            foreach (var item in datos)
            {
                res += "<tr>" +
                    "<td>" +
                    "<input type='checkbox' class='form-control' name='chb' id='chb' value=" + item.Bodega1Id + "/>" +
                    "</td>" +
                    "<td>" + item.Codigolote + "</td>" +
                    "<td>" + item.Detalle + "</td>" +
                    "<td>" + item.Selecciones + "</td>" +
                    "<td><label id='cantidad'>" + item.NumeroPieles + "</label></td>" +
                    "<td><label id='peso'>" + item.Peso + "</label></td>" +
                    "</tr>";
            }
            object[] ya = { res };
            lista.Add(ya);
            return lista;
        }
        public List<object[]> ModeloImprimirClasiPelo()
        {
            List<object[]> lista = new List<object[]>();
            string clasipelo = "";
            var clasi = (from bc in _contexto.Bodega1
                         join b in _contexto.Bodega on bc.BodegaId equals b.BodegaId
                         join c in _contexto.Clasificacion on bc.ClasificacionId equals c.ClasificacionId
                         join l in _contexto.Lote on bc.LoteId equals l.LoteId
                         join m in _contexto.Medida on bc.MedidaId equals m.MedidaId
                         join tp in _contexto.TipoPiel on bc.TipoPielId equals tp.TipoPielId 
                         where bc.activo== true
                         select new
                         {
                             bc.Fechaingreso,
                             bc.NumeroEstanteria,
                             bc.NumeroPieles,
                             bc.Peso,
                             m.Abreviatura,
                             b.NombreBodega,
                             c.Selecciones,
                             l.Codigolote,
                             tp.Detalle,
                             bc.Observaciones
                         });
            foreach(var item in clasi)
            {
                clasipelo += "<tr>" +
                     "<td>" + item.Fechaingreso + "</td>" +
                    "<td>" + item.NumeroEstanteria + "</td>" +
                    "<td>" + item.NumeroPieles + "</td>" +
                    "<td>"+ item.Peso +" "+item.Abreviatura + "</td>"+
                    "<td>" + item.NombreBodega + "</td>" +
                    "<td>" + item.Selecciones + "</td>" +
                    "<td>" + item.Codigolote + "</td>" +
                    "<td>" + item.Detalle + "</td>" +
                    "<td>" + item.Observaciones + "</td>" +
                    "</tr>";
            }
            object[] datos = {clasi};
            lista.Add(datos);
            return lista;



        }

    }
}
