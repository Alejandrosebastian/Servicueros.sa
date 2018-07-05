﻿class Descarne {

    constructor(cantidad, fecha, accion) {
        this.fecha = fecha;
        this.cantidad = cantidad;
        this.accion = accion;
    }
    ListaDescarne() {
        var accion = this.accion;
        $.ajax({
            type: "POST",
            url: accion,
            data: {},
            success: (respuesta) => {
                $.each(respuesta, (index, val) => {
                    $('#DescarneLista').html(val[0]);
                });
            }
        });
    }
    GuardarPelambre(cantidad, fecha) {
        if (this.Descarne == '0') {
            document.getElementById('mensajed').innerHTML = "Ingrese un numero de pieles a Descarnar";
        }
        else
        {
            var cantidad = this.cantidad; 
            var fecha = this.fecha;
            var mensaje = '';
            var accion = this.accion;
            
                $.ajax({
                    type: "POST",
                    url: accion,
                    data: {
                        cantidad, fecha
                    },
                    success: (respuesta) => {
                        this.limpiarCajas();
                    }
                });
         
        }
    }
    listapelambre() {
        var accion = this.accion;
        var contador = 1;
        $.ajax({
            type: "POST",
            url: accion,
            data: {},
            success: (respuesta) => {
                if (0 < respuesta.length) {
                    document.getElementById('PelambreId').options[contador] = new Option(respuesta[i].cantidad);
                }
            }
        });
    }

  
    limpiarcajas() {
        document.getElementById('cantidad').value = '';
        document.getElementById('fecha').selectedIndex = 0;
        $('#DescarneLista').html('');
        $('#IngresoDescarne').modal('hide');
        ListaIndex();

    }
   
}