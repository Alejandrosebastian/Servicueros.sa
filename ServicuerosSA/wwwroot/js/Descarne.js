﻿class Descarne {

    constructor(cantidad, fecha, PelambreId, PersonalId, codigodescarne, CodigoLote, accion) {
        this.fecha = fecha;
        this.cantidad = cantidad;
        this.PelambreId = Pelambre;
        this.PersonalId = PersonalId;
        this.codigodescarne = codigodescarne;
        this.CodigoLote = CodigoLote;
        this.accion = accion;

    }
    ListaDescarne() {
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
                    var codigodescarne = this.codigodescarne;
                    var CodigoLote = this.CodigoLote;
                    var accion = this.accion;
                    $.ajax({
                        type: "POST",
                        url: accion,
                        data: {
                            cantidad, fecha, personal, pelambre, codigodescarne, CodigoLote
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
    NumeroPielesPelambre(id) {
        var accion = this.accion;
        $.ajax({
            type: "POST", 
            url: accion,
            data: { id },
            success: (respuesta) => {
                $('#TotalPielesInput').text(respuesta[0].totalPieles);
                $("#TotalPielesInput").removeClass("hidden");
            }
        });
    }  
    EliminarDescarne(codigoUnico) {
        var accion = this.accion;
        $.post(accion, { codigoUnico },
            (respuesta) => {
                ListaDescarne(1);
                alert("El registro se ha borrado exitosamente!!")
            }
        );
    }
    limpiarcajas() {
        document.getElementById('CantidadPieles').value = '';
        document.getElementById('PelambreId').selectedIndex = 0;
        document.getElementById('personalId').selectedIndex = 0;
        $('#IngresoDescarne').modal('hide');
        ListaDescarne();

    }
   
}