class Curtidojs {
    constructor(tipotripa, numbombo, numpieles, medida, formula, fecha, peso, bodega, personal, Codicurtido,accion) {
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
        this.accion = accion;
    }

    
    


    ListaIndexCurtido() {
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
                    var numbombo = this.numbombo;
                    var formula = this.formula;
                    var fecha = this.fecha;
                    var tipotripa = this.tipotripa;
                    var numpieles = this.numpieles;
                    var medida = this.medida;
                    var peso = this.peso;
                    var bodega = this.bodega;
                    var accion = this.accion;
                    var personal = this.personal;
                    var Codicurtido = this.Codicurtido;
                    $.ajax({
                        type: "POST",
                        url: accion,
                        data: {
                            tipotripa, numbombo, numpieles,medida, formula, fecha, peso, bodega, personal, Codicurtido
                        },
                        success: (respuesta) => {
                            if (respuesta[0].code == "ok") {
                                this.limpiarcajas();
                                swal("Curtido", "Se guardo exitosamente", "success");
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
    LLenaTablaModalCurtido(id) {
        var accion = this.accion;
        $.post(accion,
            { id },
            (respuesta) => {
                
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
                        document.getElementById('ClasificaciontripaId').options[contador] = new Option(respuesta[i].detalle.toUpperCase(), respuesta[i].clasificacionTripaId);
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
        $('#IngresoCurtido').modal('hide');
        //ListaIndexCurtido;

    }

}