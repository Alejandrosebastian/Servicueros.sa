
class ClaseTipoPiel {
    constructor(detalle, accion) {
        this.detalle = detalle;
        this.accion = accion;
    }

    claseJsListaTipoPiel() {
        var accion = this.accion;
        var contador = 1;
        $.ajax({
            type: "POST",
            url: accion,
            data: {},
            success: (respuesta) => {
                
                for (var i = 0; i < respuesta.length; i++) {
                    document.getElementById('tipoPiel').options[contador] = new Option(respuesta[i].detalle, respuesta[i].tipoPielId);
                    contador++;
                }
            }
        });
    }

}
