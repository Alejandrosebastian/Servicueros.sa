﻿
class Descarne {

    constructor(PelambreId, cantidad,fecha,   PersonalId, codigolote,codiunidescarne,accion) {
        this.PelambreId = PelambreId;
        this.cantidad = cantidad;
        this.fecha = fecha;
        this.PersonalId = PersonalId;
        //this.codigodescarne = codigodescarne;
        this.codigolote = codigolote;
        this.codiunidescarne = codiunidescarne;
         this.accion = accion;

    }
    

    ListaIndexdescarne() {
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

    GuardarPelambre() {
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

                    if (this.codigolote == '') {
                        $("#mensajep").removeClass("hidden");
                    } else {
                        var pelambre = this.PelambreId;
                        var cantidad = this.cantidad;
                        var fecha = this.fecha;
                        var personal = this.PersonalId;
                        var codigolote = this.codigolote;
                        var codiunidescarne = this.codiunidescarne;
                        var accion = this.accion;
                        
                        $.ajax({
                            type: "POST",
                            url: accion,
                            data: {
                                pelambre, cantidad, fecha, personal,  codigolote, codiunidescarne
                            },
                            success: (respuesta) => {
                                if (respuesta[0].code == "ok") {
                                    swal("Descarne", "Se guardo exitosamente", "success");
                                    ListaIndexDescarne();
                                    this.limpiarcajas();
                                    this.limpiacajasPelambre();
                                } else {
                                    this.limpiarcajas();
                                    this.limpiacajasPelambre();
                                    swal("Descarne", "Ocurrio un error", "error");
                                }
                            }
                        });
                    }
                }
            }
        }
    }

    limpiacajasPelambre() {
        document.getElementById("PelambreId").options.length = 1;
       
        

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
                        console.log(respuesta);
                        for (var i = 0; i < respuesta.length; i++) {
                            document.getElementById('PelambreId').options[contador] = new Option(respuesta[i].codigo , respuesta[i].codigopelambre);
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
                    document.getElementById('TotalPielesInput').value = respuesta;
                    $('#TotalPielesInput').value = respuesta;
                    $("#TotalPielesInput").removeClass("hidden");
                    
                }
            });
        }
        codilote(id) {
            var accion = this.accion;
            $.ajax({
                type: "POST",
                url: accion,
                data: { id },
                success: (respuesta) => {
                    document.getElementById('codiloteInput').value = respuesta[0].codigoLote;
                    $('#codigoloteInput').value = respuesta[0].codigoLote;
                    $('#codigoloteInput').removeClass('hidden');
                    
                }
            });
        }


    EliminarDescarne(codigoUnico)
    {
            var accion = this.accion;
            $.post(accion, { codigoUnico },
                (respuesta) =>
                {
                    ListaIndexDescarne(1);
                    alert("El registro se ha borrado exitosamente!!");
                    this.limpiarcajas();
                });
     }
    limpiarcajas()
    {
            document.getElementById('CantidadPieles').value = '';
            document.getElementById('PelambreId').selectedIndex = 0;
            document.getElementById('personalId').selectedIndex = 0;
            document.getElementById('codigoloteInput').value = '';
            document.getElementById('TotalPielesInput').value = '';

            $('#IngresoDescarne').modal('hide');
        ListaIndexDescarne;
        this.limpiacajasPelambre();

    }
}