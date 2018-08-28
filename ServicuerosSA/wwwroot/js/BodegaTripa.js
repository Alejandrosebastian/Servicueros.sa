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
    GuardaClasificacionTripa(tipotripa,descarne,personal) {
        if (this.tipotripa == '0') {
            document.getElementById('mensajede').innerHTML = 'Selecciona un tipo de clasificacion';
        } else {
            document.getElementById('mensajede').innerHTML = '';
            if (this.descarne == '0') {
                document.getElementById('mensajetri').innerHTML = 'seleccione que desea clasificar';
            } else {
                document.getElementById('mensajetri').innerHTML = '';
                if (this.personal == '0') {
                    document.getElementById('mensajeper').innerHTML = 'Seleccione a la persona indicada en este proceso';
                } else {
                    var numeropieles = this.numeropieles;
                    var peso = this.peso;
                    var accion = this.accion;
                    $.ajax({
                        type: "POST",
                        url: accion,
                        data: {
                            tipotripa,descarne,numeropieles,peso,personal
                        },
                        success: (respuesta) => {
                            this.limpiarcajas();
                        }
                    });
                }
            }
        }
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
                        document.getElementById('Descarneid').options[contador] = new Option(respuesta[i].codigoLote, respuesta[i].descarneId);
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
                console.log(respuesta);
                $('#PielesInput').text(respuesta[0].cantidad);
                $('#PielesInput').removeClass("hidden");
            }
        });
    }
    Listaclasificaciontripaindex() {
        var accion = this.accion;
        $.post(accion,
            {},
            (res) => {
                console.log(res);
                $.each(res, (contador, valor) => {
                    $('#BodegaTripa').html(valor[0]);
                });
            });
      
    }
    limpiarcajas() {
        document.getElementById('Descarneid').selectIndex = 0;
        document.getElementById('PielesInput').value = '';
        document.getElementById('ClasificaciontripaId').selectIndex = 0;
        document.getElementById('NumeroPielesInput').value = '';
        document.getElementById('personalId').selectedIndex = 0;
        $('#IngresoClasificacionTripa').html = '';
        $('#IngresoClasificacionTripa').modal('hide');
       
        listatripasindex();

    }
    
   
}
