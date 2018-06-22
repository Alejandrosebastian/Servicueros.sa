
class Formulas {
    constructor(nombre, fecha_creacion, tipo_proceso, tipo_piel, accion) {
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
                $('#codigo').val = respuesta[0].codigo;
                $('#version').val = respuesta[0].version;
                $('#fechaCreacion').val = respuesta[0].fechaCreacion;
                $('#nombre').val = respuesta[0].nombre;
                $('#tipoProceso').val = respuesta[0].tipoProces;
                $('#tipoPiel').val = respuesta[0].tipoPiel;
                $('#fechaVigencia').val = respuesta[0].fechaVigencia;
                $('#vigencia').val = respuesta[0].vigencia;
                $('pagina').val = respuesta[0].pagina;
                $('#fecha').val = respuesta[0].fecha;
                $('#parada').val = respuesta[0].parada;
                $('#bombo').val = respuesta[0].bombo;
                $('#peso').val = respuesta[0].peso;
                $('cantidad').val = respuesta[0].cantidad;
                $('#promedio').val = respuesta[0].promedio;
                $('#autorizado').val = respuesta[0].autorizado;
                $('#procesado').val = respuesta[0].procesado;
                $('#entregado').val = respuesta[0].entregado;
            }
        );
    }
    CuerpoFormula(id) {

    }
}
