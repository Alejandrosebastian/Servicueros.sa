
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
        $.ajax({
            type: 'POST',
            url: accion,
            data: { id },
            success: (respuesta) => {
                console.log(respuesta);
                $('#codigo').text(respuesta[0].codigo);
                $('#version').text(respuesta[0].version);
                $('#fecha_act').text(respuesta[0].fechaCreacionFormula);

                $('#fechaCreacion').text(respuesta[0].fechaCreacion);
                $('#nombre').text(respuesta[0].nombre);
                $('#tipoProceso').text(respuesta[0].tipoProces);
                $('#tipoPiel').text(respuesta[0].tipoPiel);
                $('#fecha_vigencia').text(respuesta[0].fechaImpresion);
                $('#vigencia').text(respuesta[0].fechaImpresion);
                $('#pagina').text(respuesta[0].pagina);
                $('#fecha').text(respuesta[0].fecha);
                $('#parada').text(respuesta[0].parada);
                $('#bombo').text(respuesta[0].bombo);
                $('#peso').text(respuesta[0].peso);
                $('#cantidad').text(respuesta[0].cantidad);
                $('#promedio').text(respuesta[0].promedio);
                $('#autorizado').text(respuesta[0].nombreAutoirzado);
                $('#procesado').text(respuesta[0].nombreProcesado);
                $('#entregado').text(respuesta[0].nombreEntregado);
            }
        });
        
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
