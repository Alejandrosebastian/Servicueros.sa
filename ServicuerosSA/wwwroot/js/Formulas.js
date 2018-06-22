
class Formulas {
    constructor(fechaCreacionFormula, version, tipoPiel,fechaValida,fechaImpresion, parada, bombo, peso, cantidad, promedio, nombreAutorizado, nombreProcesado,nombreEntregado,  accion) {
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
                $('#version').val = respuesta[0].version;
                $('#fechaCreacion').val = respuesta[0].fechaCreacionFormula;
                $('#tipoPiel').val = respuesta[0].tipoPiel;
                $('#fechaValida').val = respuesta[0].fechaValida;
                $('#fechaImpresion').val = respuesta[0].fechaImpresion;
                $('#parada').val = respuesta[0].parada;
                $('#bombo').val = respuesta[0].bombo;
                $('#peso').val = respuesta[0].peso;
                $('cantidad').val = respuesta[0].cantidad;
                $('#promedio').val = respuesta[0].promedio;
                $('#autorizado').val = respuesta[0].nombreAutorizado;
                $('#procesado').val = respuesta[0].nombreProcesado;
                $('#entregado').val = respuesta[0].nombreEntregado;
            }
        );
    }
    CuerpoFormula(id) {

    }
}
