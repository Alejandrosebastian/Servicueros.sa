
class Pelambre {
    constructor(fecha, observacion, bodega, bombo, formula, peso, accion ) {
        this.fecha = fecha;
        this.observacion = observacion;
        this.bodega = bodega;
        this.bombo = bombo;
            this.formula = formula;
        this.accion = accion;
    }
    ListaPelabre() {
        var accion = this.accion;
        $.ajax({
            type: "POST",
            url: accion,
            data: {},
            success: (respuesta) => {
                $.each(respuesta, (index, val) => {
                    $('#LotesLista').html(val[0]);
                });
            }
        });
    }

    ListaIndeXTipoPiel(tipopielId, clasificacionId) {
        var accion = this.accion;
        
        $.ajax({
            type: "POST",
            url: accion,
            data: { tipopielId, clasificacionId },
            success: (respuesta) => {
                $.each(respuesta, (index, val) => {
                    $('#LotesLista').html(val[0]);
                });
            }
        });
    }

    DesactivaClasificacionPelo(total, personal, codlote, pesototal, pieles, accion) {
        var fecha = this.fecha;
        var obsrvaciones = this.observacion;
        var bodega = this.bodega;
        var bombo = this.bombo;
        var formula = this.formula;
        var peso = this.peso;
        var mensaje = '';
        var accion = this.accion;
        var contador = 0;

        $.each(bodega, (index, val) => {

            var bodegaid = bodega[contador];
            $.ajax({
                type: "POST",
                url: accion,
                data: {
                     bodegaid
                },
                success: (respuesta) => {
                    if (contador == total) {
                        this.limpiarcajas();
                    }

                }
            });
            contador++;
        });
    }

    GuardaPelambre(total, personal, codlote, pesototal, pieles) {

        if (this.formula == '0') {
            document.getElementById('mensajef').innerHTML = "Seleccione una formula";
        }
        else
        {
            document.getElementById('mensajef').innerHTML = "";
            if (this.bombo == '0') {
                document.getElementById('mensajeb').innerHTML = "Seleccione un bombo";

            } else {
                document.getElementById('mensajeb').innerHTML = "";
                if (personal == '0') {
                    document.getElementById('mensajep').innerHTML = "Seleccione al personal asignado";

                } else {
                    var fecha = this.fecha;
                    var obsrvaciones = this.observacion;
                    var bodega = this.bodega;
                    var bombo = this.bombo;
                    var formula = this.formula;
                    var peso = this.peso;
                    var mensaje = '';
                    var accion = this.accion;
                    var contador = 0;

                    $.each(bodega, (index, val) => {

                        var bodegaid = bodega[contador];
                        $.ajax({
                            type: "POST",
                            url: accion,
                            data: {
                                fecha, obsrvaciones, bodegaid, bombo, formula, peso, personal, codlote, pesototal, pieles
                            },
                            success: (respuesta) => {
                                if (contador == total) {
                                    this.limpiarcajas();
                                }
                            
                            }
                        });
                        contador++;
                    });
                }
            }
            
        }
        
    }

    ListaIndex() {
        var accion = this.accion;
        $.ajax({
            type: "POST",
            url: accion,
            data: {},
            success: (respuesta) => {
                $.each(respuesta, (index, val) => {
                    $('#pelambre').html(val[0]);
                });
            }
        });
    }

    ListaDetalle(id) {
        var accion = this.accion;
        $.post(accion, { id },
            (respuesta) => {

            }
        );
    }

    limpiarcajas() {
        document.getElementById('observacion').value = '';
        document.getElementById('bomboId').selectedIndex = 0;
        document.getElementById('formulaId').selectedIndex = 0;
        $('#LotesLista').html('');
        $('#IngresoPelambre').modal('hide');
        ListaIndex();
        
    }

    

}
