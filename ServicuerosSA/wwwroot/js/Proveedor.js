class ClaseJSProveedor {
        constructor(Ruc, Nombres, Direccion, Telefono, Celular, Email, Estado, Fechaingreso, Marcaproveedor, accion) {
        
            this.Ruc = Ruc;
            this.Nombres = Nombres;
            this.Direccion = Direccion;
            this.Telefono = Telefono;
            this.Celular = Celular;
            this.Email = Email;
            this.Estado = Estado;
            this.Fechaingreso = Fechaingreso;
            this.Marcaproveedor = Marcaproveedor;
            this.accion = accion;
        
    }
    claseJsListaProveedor() {
        var accion = this.accion;
        $.ajax({
            type: "POST",
            url: accion,
            data: {},
            success: respuesta => {
                $.each(respuesta, (index, val) => {
                    $('#ListaProveedores').html(val[0]);
                });
            }
        });
    }
    claseJsCedulaProveedor() {
        var accion = this.accion;
        var ruc = this.Ruc;

        $.ajax({
            type: "POST",
            url: accion,
            data: { ruc },
            success: (respuesta) => {
                
                if (respuesta[0].code == 'si') {
                    $('#codigo').css('visibility', 'visible');
                    $('#graba').prop('disabled', true);
                } else {
                    $('#codigo').css('visibility', 'hidden');
                    $('#graba').prop('disabled', false);
                }
            }

        });
    }
}