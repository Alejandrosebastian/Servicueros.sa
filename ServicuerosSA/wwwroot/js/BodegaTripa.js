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
    GuardaBodegaTripa(personal, numeropieles, descarne, clasificaciontripa, activo, peso) {
        var personal = this.personal;
        var numeropieles = this.numeropieles;
        var descarne = this.descarne;
        var clasificaciontripa = this.clasificaciontripa;
        var activo = this.activo;
        var peso = this.peso;
        var accion = this.accion;
        $.ajax({
            type: "POST",
            url: accion,
            data: {
                personal, numeropieles, descarne, clasificaciontripa, activo, peso
            },
            success: (respuesta) => {
                if (total == 'limpia') {
                    this.limpiarcajas();
                }
            }
        });
    }
}