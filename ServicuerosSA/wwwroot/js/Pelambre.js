
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


    DesactivaClasificacionPelo(total, accion) {
        var bodega = this.bodega;
        var bodegaid;
        var contador = 0;
        $.each(bodega, (index, val) => {
            bodegaid = bodega[contador];
            $.ajax({
                type: "POST",
                url: accion,
                data: {
                     bodegaid
                },
                success: (respuesta) => {
                   

                }
            });
            contador++;
        });
        return bodegaid;
    }


    GuardaPelambre(personal, codlote, pesototal, pieles, codigoUnico, total) {

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
                    var accion = this.accion;
                        $.ajax({
                            type: "POST",
                            url: accion,
                            data: {
                                fecha, obsrvaciones, bodega, bombo, formula, personal, codlote, pesototal, pieles, codigoUnico
                            },
                            success: (respuesta) => {
                                if (total == 'limpia') {
                                    this.limpiarcajas();
                                }
                            }
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

    EliminaPelambre(cadigounico) {
        var accion = this.accion;
        $.post(accion, { cadigounico },
            (respuesta) => {
                ListaIndex(1);
                alert("El registro se ha borrado con exito!!!");
            }
        );
    }

    Pesaje(id) {
        var accion = this.accion;
        $.ajax({
            type: 'POST',
            url: accion,
            data: { id },
            success: (respuesta) => {
                $.each(respuesta, (index, val) => {
                    $('#TablaPesaje').html(val[0]);
                });
            }
        });
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
