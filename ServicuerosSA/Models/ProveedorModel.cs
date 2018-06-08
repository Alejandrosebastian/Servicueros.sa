using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ServicuerosSA.Data;
namespace ServicuerosSA.Models
{
    public class ProveedorModel
    {
        ApplicationDbContext _contexto;
        public ProveedorModel(ApplicationDbContext context)
        {
            _contexto = context;
        }
        public List<IdentityError> ClaseCedulaProveedor(string ruc)
        {
            List<IdentityError> Lista = new List<IdentityError>();
            IdentityError dato = new IdentityError();
            var cont = from p in _contexto.Proveedor
                       where p.Ruc == ruc
                       select p;
            if (cont.Count() != 0)
            {
                dato = new IdentityError
                {
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
        public List<object[]> ClaseModeloProveedor()
        {
            List<object[]> ListaProveedor = new List<object[]>();
            string resultado = "";
            var prov = from p in _contexto.Proveedor
                       select new
                       {
                           p.ProveedorId,
                           p.Ruc,
                           p.Nombres,
                           p.Direccion,
                           p.Telefono,
                           p.Celular,
                           p.Email,
                           p.Estado,
                           p.Fechaingreso,
                           p.Marcaproveedor

                       };
            foreach (var item in prov)
            {
                resultado += "<tr>" + 
                    "<td>"+item.Ruc+"</td>"+
                    "<td>"+item.Nombres+ "</td>" +
                    "<td>" +item.Direccion + "</td>" +
                    "<td>" +item.Telefono + "</td>" +
                    "<td>" +item.Celular+ "</td>" +
                    "<td>" +item.Email+ "</td>" +
                    "<td>" +item.Estado+ "</td>" +
                    "<td>" +item.Fechaingreso+ "</td>" +
                    "<td>" +item.Marcaproveedor+ "</td>" +
                    "<td>" +
                    "<a href='Proveedores/Edit/" + item.ProveedorId +"'  class='btn btn-success'> Editar </a> |" +
                    "<a href='Proveedores/Details/"+ item.ProveedorId +"'class='btn btn-info' > Detalles de Proveedor </a>" +
                    "</td>" +
                    "</tr>";
            }
            object[] contenedor = { resultado };
            ListaProveedor.Add(contenedor);
            return ListaProveedor;
        }
        
    }
        
    
}
