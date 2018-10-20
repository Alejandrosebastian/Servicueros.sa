class Clasemedidas {
    constructor(detalle, abreviatura, accion) {
        this.detalle = detalle;
        this.abreviatura = abreviatura;
        this.accion = accion;
    }
    listamedidas() {
        var accion = this.accion;
        var contador = 1;
        $.ajax({
            type: "POST",
            url: accion,
            data: {},
            success: (respuesta) => {
                console.log(respuesta);
                for (var i = 0; i < respuesta.length; i++) {
                    document.getElementById('MedidaId').options[contador] = new Option(respuesta[i].detalle, respuesta[i].edidaId);
                    contador++;
                }
            }
        });
    }
}