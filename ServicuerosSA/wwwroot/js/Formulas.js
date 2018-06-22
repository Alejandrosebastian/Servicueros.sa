
class Formulas {
    constructor(fecha_creacion, nombre, tipo_proceso, tipo_piel,  accion) {
        this.fecha_creacion = fecha_creacion;
        this.nombre = nombre;
        this.tipo_proceso = tipo_proceso;
        this.tipo_piel = tipo_piel;
        this.accion = accion;
    }
    ListaFormulas() {
        var accion = this.accion;
        var contador = 1;
        $.ajax({
            type: "POST",
            url: accion,
            data: {},
            success: (respuesta) => {
                //console.log(respuesta);
                if (0 < respuesta.length) {
                    for (var i = 0; i < respuesta.length; i++) {
                        document.getElementById('formulaId').options[contador] = new Option(respuesta[i].nombre, respuesta[i].formulaId);
                        contador++;
                    }
                }
            }
        });
    }
    CabeceraFormula(id) {
        var accion = this.accion;
        $.post(accion,
            { id },
            (respuesta) => {
                console.log(respuesta);
                document.getElementById('codigo').value = respuesta[0].codigo;
                document.getElementById('version').value = respuesta[0].version;
                document.getElementById('fecha_act').value = respuesta[0].fechaCreacionFormula;
                document.getElementById('tipoPiel').value = respuesta[0].tipoPiel;
                document.getElementById('fecha_vigencia').value = respuesta[0].fechaValida;
                document.getElementById('fechaImpresion').value = respuesta[0].fechaImpresion;
                document.getElementById('parada').value = respuesta[0].parada;
                document.getElementById('bombo').value = respuesta[0].bombo;
                document.getElementById('peso').value = respuesta[0].peso;
                document.getElementById('cantidad').value = respuesta[0].cantidad;
                document.getElementById('promedio').value = respuesta[0].promedio;
                document.getElementById('autorizado').value = respuesta[0].nombreAutorizado;
                document.getElementById('procesado').value = respuesta[0].nombreProcesado;
                document.getElementById('entregado').value = respuesta[0].nombreEntregado;
            }
        );
    }
    CuerpoFormula(id) {
        var accion = this.accion;
        $.post(
            accion,
            { id },
            (respuesta) => {
                $.each(respuesta, (index, val) => {
                    $('#TablaDetalleForula').html(val[0]);
                });
            }
        );
    }
  
}
