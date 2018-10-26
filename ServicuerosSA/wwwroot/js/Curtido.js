class Curtidojs {
    constructor(tipotripa, numbombo, numpieles, formula, fecha, peso, bodega, personal,accion) {
        this.tipotripa = tipotripa;
        this.numbombo = numbombo;
        this.numpieles = numpieles;
        this.formula = formula;
        this.fecha = fecha;
        this.peso = peso;
        this.bodega = bodega;
        this.personal = personal;
        this.accion = accion;

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

}