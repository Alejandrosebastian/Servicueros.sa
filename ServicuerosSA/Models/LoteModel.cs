using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ServicuerosSA.Data;
namespace ServicuerosSA.Models
{
    public class LoteModel
    {
        string dato = "";
        ApplicationDbContext _contexto;
        public LoteModel(ApplicationDbContext context)
        {
            _contexto = context;
        }
        public List<IdentityError> ClaseModeloCodigoLote(string codigolote)
        {
            List<IdentityError> Lista = new List<IdentityError>();
            IdentityError dato = new IdentityError();
            var contar = from l in _contexto.Lote
                         where l.Codigolote == codigolote
                         select l;
            if (contar.Count() != 0)
            {
                dato = new IdentityError {
                    Code = "si",
                    Description = "si"
                };
            }
            else
            {
                dato = new IdentityError
                {
                    Code = "no",
                    Description = "no"
                };
            }
            Lista.Add(dato);
            return Lista;
        }
        //vista Lotes
        public List<object[]> ClaseModelListaLotes(int numeroPagina)
        {
            int cant, numRegistros = 0, inicio = 0, reg_por_pagina = 10;
            int can_paginas, pagina;
            string paginador = "";
            string resultado = "";

            List<object[]> ListaLotes = new List<object[]>();
            IEnumerable<MostrarListaLoteModel> query;
            List<MostrarListaLoteModel> lotes = null;

            lotes = (from l in _contexto.Lote
                        join p in _contexto.Personal on l.PersonalId equals p.PersonalId
                        join tp in _contexto.TipoPiel on l.TipoPielId equals tp.TipoPielId
                     where l.estado == true
                        select new MostrarListaLoteModel
                        {
                            LoteId = l.LoteId,
                           Codigolote = l.Codigolote,
                           Fechaingreso = l.Fechaingreso,
                           Numerodepieles = l.Numerodepieles,
                          Observaciones = l.Observaciones,
                            nombres = p.Nombres + " " + p.Apellidos,
                           Detalle= tp.Detalle
                        }).OrderByDescending(f => f.Fechaingreso).ToList();

            numRegistros = lotes.Count;
            inicio = (numeroPagina - 1) * reg_por_pagina;
            can_paginas = (numRegistros / reg_por_pagina);

            query = lotes.Skip(inicio).Take(reg_por_pagina);
            cant = query.Count();

            foreach (var item in query)
            {
                resultado += "<tr>" +
                  
                    "<td>" + item.Codigolote + "</td>" +
                    "<td>" + item.Fechaingreso.ToString("dd-MM-yyyy") + "</td>" +
                    "<td>" + item.Numerodepieles + "</td>" +
                    "<td>" + item.nombres + "</td>" +
                    "<td>" + item.Detalle + "</td>" +
                    "<td>" + item.Observaciones + "</td>" +
                    "<td>" +
                    "<a class='btn btn-success' href='Lotes/edit/"+ item.LoteId + "'>Editar</a>"+
                    "</td>"

                    +"</tr>";
            }
            
                if (numeroPagina > 1)
                {
                    pagina = numeroPagina - 1;
                    paginador += "<a class='btn btn-default' onclick='claseJsLlamarListaLotes(" + 1 + ")'> << </a>" +
                       "<a class='btn btn-default' onclick='claseJsLlamarListaLotes(" + pagina + ")'> < </a>";
                }
                if (1 < can_paginas)
                {
                    paginador += "<strong class='btn btn-success'>"
                        + numeroPagina + " de " + can_paginas + "</strong>";
                }
                if (numeroPagina < can_paginas)
                {
                    pagina = numeroPagina + 1;
                    paginador += "<a class='btn btn-default' onclick='claseJsLlamarListaLotes(" + pagina + ")'> > </a>" +
                       "<a class='btn btn-default' onclick='claseJsLlamarListaLotes(" + can_paginas +")'> >> </a>";
                }
            

            object[] contenedor = { resultado, paginador };
            ListaLotes.Add(contenedor);
            return ListaLotes;

        }
        public List<object[]> ClaseSacarUnlote(int codilote)
        {
            List<object[]> lista = new List<object[]>();
            var lote = (from l in _contexto.Lote
                        where l.LoteId == codilote
                        select l).ToList();
                        
            var dato = "";
            foreach (var item in lote)
            {
                dato += "<spam>Codigo de lote :" + item.Codigolote + "</spam><br/>" +
                        "<spam>Fecha de ingreso:" + item.Fechaingreso + "</spam><br/>" +
                        "<spam>Numero de pieles:" + item.Numerodepieles + "</spam><br/>" +
                        "<spam>Observaciones:" + item.Observaciones + "</spam>";
                        
             }
            object[] objetos = { dato };
            lista.Add(objetos);
            return lista;
        }

        public List<IdentityError> ModeloNumeroPielesLote(int codilote, int valor)
        {
            List<IdentityError> Lista = new List<IdentityError>();
            IdentityError er = new IdentityError();

            var lotenumero = (from l in _contexto.Lote
                        where l.LoteId == codilote
                        select l.Numerodepieles).FirstOrDefault();


            var total = _contexto.Bodega1.Where(b1 => b1.LoteId == codilote).Sum(b1 => b1.NumeroPieles);

            int totalpieles = total + valor;

            if (valor <= lotenumero)
            {
                if (totalpieles <= lotenumero)
                {
                    er = new IdentityError
                    {
                        Code = "vale",
                        Description = "vale"
                    };
                }
                else
                {
                    if (lotenumero == total)
                    {
                        var lot = (from lote in _contexto.Lote
                                   where lote.LoteId == codilote
                                   select new Lote
                                   {
                                       LoteId = lote.LoteId,
                                       estado = false,
                                       Codigolote = lote.Codigolote,
                                       Fechaingreso = lote.Fechaingreso,
                                       Numerodepieles = lote.Numerodepieles,
                                       Observaciones = lote.Observaciones,
                                       PersonalId = lote.PersonalId,
                                       TipoPielId = lote.TipoPielId
                                   }).FirstOrDefault();
                        try
                        {
                            _contexto.Lote.Update(lot);
                            _contexto.SaveChanges();
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                        er = new IdentityError
                        {
                            Code = "no!",
                            Description = "no!"
                        };
                    }
                    else
                    {
                        er = new IdentityError
                        {
                            Code = "men",
                            Description =  (totalpieles - lotenumero).ToString()
                        };
                    }
                   

                }
            }
            else
            {
                er = new IdentityError
                {
                    Code = "no",
                    Description = "no"
                };
                

            }
            Lista.Add(er);
            return Lista;
        }

        //IMPRIMIR LOTE
        public List<object[]> ModeloImprimirLote(string id)
        {
            List<object[]> lista = new List<object[]>();
            var lotes = (from l in _contexto.Lote
                     join p in _contexto.Personal on l.PersonalId equals p.PersonalId
                     join tp in _contexto.TipoPiel on l.TipoPielId equals tp.TipoPielId
                     where l.estado == true
                     select new 
                     {                         
                       l.Codigolote,
                       l.Fechaingreso,
                       l.Numerodepieles,
                       nombres = p.Nombres + " " + p.Apellidos,
                       tp.Detalle,
                       l.Observaciones
                     }).OrderByDescending(f => f.Fechaingreso).ToList();
            foreach (var item in lotes)
            {
                dato += "<tr>" +
                    "<td>" + item.Codigolote + "</td>" +
                    "<td>" + item.Fechaingreso.ToString("dd-MM-yyyy") + "</td>" +
                    "<td>" + item.Numerodepieles + "</td>" +
                    "<td>" + item.nombres + "</td>" +
                    "<td>" + item.Detalle + "</td>" +
                    "<td>" + item.Observaciones + "</td>" +
                    
                    "</tr>";
            }
            object[] objeto = { dato };
            lista.Add(objeto);
            return lista;
        }
       
    }
}










