class ClasificacionTripa {
    constructor(detalle, accion) {
        this.detalle = detalle;
        this.accion = accion;
    }
    ClaseListaClasificacionTripa() {
        var accion = this.accion;
        var contador = 1;
        $.ajax({
            type: "POST",
            url: accion,
            data: {},
            success: (respuesta) => {
                for (var i = 0; i < respuesta.length; i++) {
                    document.getElementById('clasificaciontripa').options[contador] = new Option(respuesta[i].detalle, respuesta[i].ClasificacionTripaId);
                    contador++;
                }
            }
        });
    }
}