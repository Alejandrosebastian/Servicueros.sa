class BodegaTripa {
    constructor(numeropieles, peso,personal,activo, accion) {
        this.numeropieles = numeropieles;
        this.peso = peso;
        this.personal = personal;
        this.activo = activo;
        this.accion = accion;
    }
    bodegatripa() {
        var bodegatripaId = this.numeropieles;
        var accion = this.accion;
        $.ajax({
            type: "POST",
            url: accion,
            data: { bodegatripaId },
            success: (respuesta) => {
                $('#BodegaTripa').html(respuesta[0]);
            }
        });
    }
    listatipotripa() {
        var accion = this.accion;
        var contador = 1;
        $.ajax({
            type: "POST",
            url: accion,
            data: {},
            success: (respuesta) => {
                if (0 < respuesta.lenght) {
                    for (var i = 0; i < respuesta.length; i++) {
                        document.getElementById('ClasificacionTripaId').option[contador] = new Option(respuesta[i].detalle, respuesta[i].clasificacionTripaId)
                        contador++
                    }
                }
                });
            }
        });
    }
}