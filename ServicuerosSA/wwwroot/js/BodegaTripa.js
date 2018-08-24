class BodegaTripa {
    constructor(tipotripa,descarne,numeropieles, peso,personal,activo, accion) {
        this.tipotripa = tipotripa;
        this.descarne = descarne;
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


    ClaseListaClasificacionTripa() {
        var accion = this.accion;
        var contador = 1;
        $.ajax({
            type: "POST",
            url: accion,
            data: {},
            success: (respuesta) => {
                console.log(respuesta);
                if (0 < respuesta.length) {

                for (var i = 0; i < respuesta.length; i++) {
                    document.getElementById('ClasificaciontripaId').options[contador] = new Option(respuesta[i].detalle, respuesta[i].clasificacionTripaId);
                    contador++;
                    }
                }

               
            }
        });
    }
    ClaseListadescarnes() {
        var accion = this.accion;
        var contador = 1;
        $.ajax({
            type: "POST",
            url: accion,
            data: {},
            success: (respuesta) => {
                console.log(respuesta);
                if (0 < respuesta.length) {

                    for (var i = 0; i < respuesta.length; i++) {
                        document.getElementById('Descarneid').options[contador] = new Option(respuesta[i].codigoLote, respuesta[i].descarneid);
                        contador++;
                    }
                }


            }
        });
    }
    Numeropielstripas(id) {
        var accion = this.accion;
        $.ajax({
            type: "POST",
            url: accion,
            data: { id },
            success: (respuesta) => {
                $('#PielesInput').text(respuesta[0].Cantidad);
                $("#PielesInput").removeClass("hidden");
            }
        });
    }

    //GuardaBodegaTripa(personal, numeropieles, descarne, clasificaciontripa, activo, peso) {
    //    var personal = this.personal;
    //    var numeropieles = this.numeropieles;
    //    var descarne = this.descarne;
    //    var clasificaciontripa = this.clasificaciontripa;
    //    var activo = this.activo;
    //    var peso = this.peso;
    //    var accion = this.accion;
    //    $.ajax({
    //        type: "POST",
    //        url: accion,
    //        data: {
    //            personal, numeropieles, descarne, clasificaciontripa, activo, peso
    //        },
    //        success: (respuesta) => {
    //            if (total == 'limpia') {
    //                this.limpiarcajas();

    //            }
    //        }
    //    });
    //}
}