
class ClaseClasificaciones {
    constructor(selecciones, accion) {
        this.selecciones = selecciones;
        this.accion = accion;
    }

    ClaseListaClasificaciones() {
        var accion = this.accion;
        var contador = 1;
        $.ajax({
            type: "POST",
            url: accion,
            data: {},
            success: (respuesta) => {
                //console.log(respuesta);
                for (var i = 0; i < respuesta.length; i++) {
                    document.getElementById('clasificaciones').options[contador] = new Option(respuesta[i].selecciones, respuesta[i].clasificacionId);
                    contador++;
                }
            }
        });
    }

    

}
