class Curtidojs {
    constructor(tipotripa, numbombo, numpieles, medida, formula, fecha, peso, bodega, personal, Codicurtido,codigolote,accion) {
        this.tipotripa = tipotripa;
        this.numbombo = numbombo;
        this.numpieles = numpieles;
        this.medida = medida;
        this.formula = formula;
        this.fecha = fecha;
        this.peso = peso;
        this.bodega = bodega;
        this.personal = personal;
        this.Codicurtido = Codicurtido;
        this.codigolote = codigolote;
        this.accion = accion;
    }


    

    ListaIndexCurt() {
        var accion = this.accion;
        $.ajax({
            type: "POST",
            url: accion,
            data: {},
            success: (respuesta) => {
                $.each(respuesta, (index, val) => {
                    $('#CurtidoLista').html(val[0]);
                });
            }
        });
    }

    Guardacurtido() {
        if (this.numbombo == '0') {
            document.getElementById('mensajebo').innerHTML = "Seleccione el bombo";
        } else {
            document.getElementById('mensajebo').innerHTML = "";
            if (this.formula == '0') {
                document.getElementById('mensajefor').innerHTML = "Seleccione la formula";
            } else {
                document.getElementById('mensajefor').innerHTML = "";
                if (this.personal == '0') {
                    document.getElementById('mensajep').innerHTML = "Seleccione al personal asignado";
                } else {
                    var tipotripa = this.tipotripa;
                    var numbombo = this.numbombo;
                    var medida = this.medida;
                    var numpieles = this.numpieles;
                    var formula = this.formula;
                    var fecha = this.fecha;
                    var peso = this.peso;
                    var bodega = this.bodega;
                    var personal = this.personal;
                    var Codicurtido = this.Codicurtido;
                    var codigolote = this.codigolote;
                    var accion = this.accion;
                    $.ajax({
                        type: "POST",
                        url: accion,
                        data: {
                            tipotripa, numbombo, numpieles,medida, formula, fecha, peso, bodega, personal, Codicurtido, codigolote
                        },
                        success: (respuesta) => {
                            if (respuesta[0].code == "ok") {
                                swal("Curtido", "Se guardo exitosamente", "success");
                                ListaIndexCurt();
                                this.limpiarcajas();
                            } else {
                                this.limpiarcajas();
                                swal("Curtido", "Ocurrio un error", "error");
                            }

                        }
                    });
                }
            }
        }
    }
    LLenaTablaModalCurtido() {
        var accion = this.accion;
        $.post(accion,
            {  },
            (respuesta) => {
                console.log(respuesta);
                $.each(respuesta, (index, val) => {
                    $('#ListaCurtido').html(val[0]);
                });
            });
    }
    ClaseListaClasificacionTripacurtido() {
        var accion = this.accion;
        var contador = 1;
        $.ajax({
            type: "POST",
            url: accion,
            data: {},
            success: (respuesta) => {
                if (0 < respuesta.length) {
                    for (var i = 0; i < respuesta.length; i++) {
                        document.getElementById('ClasificaciontripaId').options[contador] = new Option(respuesta[i].detalle.toUpperCase(),respuesta[i].clasificacionTripaId);
                        contador++;
                    }
                }


            }
        });
    }
    limpiarcajas() {
        document.getElementById('bomboId').selectedIndex = 0;
        document.getElementById('formulaId').selectedIndex = 0;
        document.getElementById('personalId').selectedIndex = 0;
        document.getElementById('fecha').value = '';
        $('#ListaCurtido').html('');
        $('#IngresoCurtido').modal('hide');
        ListaIndexCurt();

    }
    //Cabecera formula Curtido
    CabeceraFormulaCurtido(id) {
        var accion = this.accion;
        $.ajax({
            type: 'POST',
            url: accion,
            data: { id },
            success: (respuesta) => {
                console.log(respuesta);
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
    CuerpoFormulaCurtido(id) {
        var accion = this.accion;
        $.post(
            accion,
            { id },
            (respuesta) => {
                $.each(respuesta, (index, val) => {
                    $('#TablaDetalleFormula').html(val[0]);
                });
            }
        );
    }
   
}