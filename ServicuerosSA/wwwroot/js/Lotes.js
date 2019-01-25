
class ClaseJSLotes {
    constructor(codigolote,numeropieles,fechaingreso,personal,tipopiel,observaciones, accion)
    {
        this.codigolote = codigolote;
        this.numeropieles = numeropieles;
        this.fechaingreso = fechaingreso;
        this.personal = personal;
        this.observaciones = observaciones;
        this.tipopiel = tipopiel;
        this.accion = accion;
    }

    clasJsListaLotes(id) {
        var accion = this.accion;
        $.ajax({
            type: "POST",
            url: accion,
            data: {id},
            success: (respuesta) => {
                $.each(respuesta, (index, val) => {
                    $('#resultado').html(val[0]);
                    $('#paginado').html(val[1]);

                });
            }
        });
    }

    claseJsCodigoLote() {
        var accion = this.accion;
        var codigolote = this.codigolote;
        var mensaje = '';
        $.ajax({
            type: "POST",
            url: accion,
            data: { codigolote },
            success: (respuesta) => {
                if (respuesta[0].code == 'si') {
                    $('#codigo').css('visibility', 'visible');
                    $('#graba').prop('disabled', true);
                } else {
                    $('#codigo').css('visibility', 'hidden');
                    $('#graba').prop('disabled', false);
                }               
            }
        });
    }

    obtenerUnLote() {
        var accion = this.accion;
        var codigoLote = this.codigolote;
        $.ajax({
            type: "POST",
            url: accion,
            data: { codigoLote },
            success: (respuesta) => {
                $('#Lotes').html(respuesta[0]);
            }
        });
    }

    NumeroPielesLote() {
        var accion = this.accion;
        var coolo = this.codigolote;
        var numeropieles = this.numeropieles;
        $.post(accion,
            { coolo, numeropieles },
            (respuesta) => {
                
                if (respuesta[0].code == 'no') {
                    alert("El numero de pieles excede a lo almacenado");

                    $('#numpieles').css('visibility', 'visible');
                    $('#graba').addClass('hidden');
                } else if (respuesta[0].code == 'no!') {
                    $('#MensajeLoteNumeroPieles').addClass('hiidden');
                    alert("Se actualizó el estado de los lotes. La pagina de volvera a vargar");
                    location.reload();
                } else if (respuesta[0].code == 'men') {
                    alert('El numero de pieles disponibles es: ' + respuesta[0].description);
                    $('#graba').addClass('hidden');
                } else {
                    $('#MensajeLoteNumeroPieles').addClass('hiidden');
                    $('#numpieles').css('visibility', 'hidden');
                    $('#graba').removeClass('hidden');
                }
            }
        );

    }

   


}
