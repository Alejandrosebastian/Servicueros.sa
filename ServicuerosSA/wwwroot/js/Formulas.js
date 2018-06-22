
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
                document.getElementById('codigo').val = respuesta[0].codigo;
                document.getElementById('version').val = respuesta[0].version;
                document.getElementById('fechaCreacion').val = respuesta[0].fechaCreacionFormula;
                document.getElementById('tipoPiel').val = respuesta[0].tipoPiel;
                document.getElementById('fechaValida').val = respuesta[0].fechaValida;
                document.getElementById('fechaImpresion').val = respuesta[0].fechaImpresion;
                document.getElementById('parada').val = respuesta[0].parada;
                document.getElementById('bombo').val = respuesta[0].bombo;
                document.getElementById('peso').val = respuesta[0].peso;
                document.getElementById('cantidad').val = respuesta[0].cantidad;
                document.getElementById('promedio').val = respuesta[0].promedio;
                document.getElementById('autorizado').val = respuesta[0].nombreAutorizado;
                document.getElementById('procesado').val = respuesta[0].nombreProcesado;
                document.getElementById('entregado').val = respuesta[0].nombreEntregado;
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
                    $('#tabla_formula_componente').html(val[0]);
                });
            }
        );
    }
}
