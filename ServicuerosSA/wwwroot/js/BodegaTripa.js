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
}