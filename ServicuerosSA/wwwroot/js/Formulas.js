
class Formulas {
    constructor(fecha_creacion, nombre, tipo_proceso, tipo_piel, accion) {
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

                $('#codigo').text(respuesta[0].codigo);
                $('#codigoquimico').text(respuesta[0].codigo);
                $('#version').text(respuesta[0].version);
                $('#fecha_act').text(respuesta[0].fechaCreacionFormula);
                $('#fechaCreacion').text(respuesta[0].fechaCreacion);
                $('#nombre').text(respuesta[0].nombre);
                $('#tipoProceso').text(respuesta[0].tipoProces);
                $('#tipoPiel').text(respuesta[0].tipoPiel);
                $('#fecha_vigencia').text(respuesta[0].fechaImpresion);
                $('#fecha_vigencia_quimico').text(respuesta[0].fechaImpresion);
                $('#vigencia').text(respuesta[0].fechaImpresion);
                $('#pagina').text(respuesta[0].pagina);
                $('#fecha').text(respuesta[0].fecha);
                $('#parada').text(respuesta[0].parada);
                $('#bombo').text(respuesta[0].bombo);
                $('#bomboquimico').text(respuesta[0].bombo);
                $('#peso').text(respuesta[0].peso);
                $('#pesoquimico').text(respuesta[0].peso);
                $('#cantidad').text(respuesta[0].cantidad);
                $('#pieles').text(respuesta[0].cantidad);
                $('#promedio').text(respuesta[0].promedio);
                $('#PromedioQuimico').text(respuesta[0].promedio);
                $('#autorizado').text(respuesta[0].nombreAutoirzado);
                $('#procesado').text(respuesta[0].nombreProcesado);
                $('#procesadoquimico').text(respuesta[0].nombreAutoirzado);
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
    CabeceraQuimico(id) {
        var accion = this.accion;
        $.ajax({
            type: 'POST',
            url: accion,
            data: { id },
            success: (respuesta) => {
                $('#fecha').text(respuesta[0].fecha);
                $('#promedio').text(respuesta[0].promedio);
                $('#lote').text(respuesta[0].lote);
                $('#bombo').text(respuesta[0].bombo);
                $('#peso').text(respuesta[0].peso);
                $('#pieles').text(respuesta[0].pieles);
                $('#promedio').text(respuesta[0].promedio);
            }
        });
    }
    CuerpoPesaje(id) {
        var accion = this.accion;
        $.post(
            accion,
            { id },
            (respuesta) => {
                $.each(respuesta, (index, val) => {
                    $('#TablaProductoQuimico').html(val[0]);
                });
            });
    }
    CuerpoQuimico(id) {
        var accion = this.accion;
        $.post(
            accion,
            { id },
            (respuesta) => {
                $.each(respuesta, (index, val) => {
                    $('#TablaDetalleQuimico').html(val[0]);
                });
            });
    }
    //REPORTES
    CuerpoLote(id) {
        var accion = this.accion;
        $.post(
            accion,
            { id },
            (respuesta) => {
                $.each(respuesta, (index, val) => {
                    $('#TablaLote').html(val[0]);
                });
            });
    }
    CuerpoPelambre(id) {
        var accion = this.accion;
        $.post(
            accion,
            { id },
            (respuesta) => {
                $.each(respuesta, (index, val) => {
                    $('#TablaPelambre').html(val[0]);
                });
            });
    }
    CuerpoDescarne(id) {
        var accion = this.accion;
        $.post(
            accion,
            { id },
            (respuesta) => {
                $.each(respuesta, (index, val) => {
                    $('#TablaDescarne').html(val[0]);
                });
            });
    }
    CuerpoClasiTripa(id) {
        var accion = this.accion;
        $.post(
            accion,
            { id },
            (respuesta) => {
                $.each(respuesta, (index, val) => {
                    $('#TablaClasiTripas').html(val[0]);
                });
            });
    }
    CuerpoCarnaza() {
        var accion = this.accion;
        $.post(
            accion,
            {},
            (respuesta) => {
               /// console.log(respuesta);
                $.each(respuesta, (index, val) => {
                    $('#TablaCarnaza').html(val[0]);
                });
            });
    }
}
