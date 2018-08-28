class Descarne {

    constructor(cantidad, fecha, PelambreId, PersonalId, accion) {
        this.fecha = fecha;
        this.cantidad = cantidad;
        this.PelambreId = Pelambre;
        this.PersonalId = PersonalId;
         this.accion = accion;

    }
    //ListaDescarne() {
    //    var accion = this.accion;
    //    var contador = 1;
    //    $.ajax({
    //        type: "POST",
    //        url: accion,
    //        data: {},
    //        success: (respuesta) => {
    //            if (0 < respuesta.length) {
    //                for (var i = 0; i < respuesta.length; i++) {
    //                    document.getElementById('PelambreId').options[contador] = new Option(respuesta[i].nombre, respuesta[i].formulaId);
    //                    contador++;
    //                }
    //            }
    //        }
    //    });
    //}

    ListaIndex() {
        var accion = this.accion;
        $.ajax({
            type: "POST",
            url: accion,
            data: {},
            success: (respuesta) => {
                $.each(respuesta, (index, val) => {
                    $('#DescarneLista').html(val[0]);
                });
            }

        });
    
    }

    GuardarPelambre(personal, pelambre) {
        if (pelambre == '0') {
            $("#mensajep").removeClass("hidden");
        } else {
            $("#mensajep").addClass("hidden");
            if (this.cantidad == '') {
                $("#mensajec").removeClass("hidden");
            } else {
                $("#mensajec").addClass("hidden");
                if (personal == '0') {
                    $("#mensajeper").removeClass("hidden");
                } else {
                    $("#mensajeper").addClass("hidden");
                    var cantidad = this.cantidad;                   
                    var fecha = this.fecha;
                    var accion = this.accion;
                    $.ajax({
                        type: "POST",
                        url: accion,
                        data: {
                            pelambre, cantidad, fecha, personal
                        },
                        success: (respuesta) => {
                            console.log(respuesta);
                            this.limpiarcajas();
                        }
                    });
                }
            }
        }
    }
    //combo
    listapelambre() {
        var accion = this.accion;
        var contador = 1;
        $.ajax({
            type: "POST",
            url: accion,
            data: {},
            success: (respuesta) => {
                if (0 < respuesta.length) {
                    for (var i = 0; i < respuesta.length; i++) {
                        document.getElementById('PelambreId').options[contador] = new Option(respuesta[i].codigoLote +  respuesta[i].codigo, respuesta[i].pelambreId );
                        contador++;
                    }
                }   
            }
        });
    }
    //NumeroPielesPelambre(id) {
    //    var accion = this.accion;
    //    $.ajax({
    //        type: "POST", 
    //        url: accion,
    //        data: { id },
    //        success: (respuesta) => {
    //            console.log(respuesta);
    //            document.getElementById('TotalPielesInput').value = respuesta[0].totalPieles;
    //            $('#TotalPielesInput').value = respuesta[0].totalPieles;
    //            $("#TotalPielesInput").removeClass("hidden");
    //        }
    //    });
    //}  
    EliminarDescarne(codigoUnico) {
        var accion = this.accion;
        $.post(accion, { codigoUnico },
            (respuesta) => {
                ListaIndexDescarne(1);
                alert("El registro se ha borrado exitosamente!!");
            }
        );
    }
    limpiarcajas() {
        document.getElementById('CantidadPieles').value = '';
        document.getElementById('PelambreId').selectedIndex = 0;
        document.getElementById('personalId').selectedIndex = 0;
        $('#IngresoDescarne').modal('hide');
        ListaIndex;

    }
}