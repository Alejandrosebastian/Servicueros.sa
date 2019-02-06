class Escurridojs {
    constructor(Bombo, Cantidad, Codigolote, Fecha, Curtidos, personal, codiuniescurridio, accion)
    {
        this.Bombo = Bombo;
        this.Cantidad = Cantidad;
        this.Codigolote = Codigolote;
        this.Fecha = Fecha;
        this.CurtidoId = Curtidos;
        this.personal = personal,
        this.codiuniescurridio = codiuniescurridio,
        this.accion = accion;
    }
    ListaIndexEscurrido() {
        var accion = this.accion;
        $.ajax({
            type: "POST",
            url: accion,
            data: {},
            success: (respuesta) => {
                $.each(respuesta, (index, val) => {
                    $('#EscurridoLista').html(val[0]);
                });
            }
        });
    }
    ///combo lista curtidos
    listacurtidos() {
        var accion = this.accion;
        var contador = 1;
        $.ajax({
            type: "POST",
            url: accion,
            data: {},
            success: (respuesta) => {
                if (0 < respuesta.length) {
                    for (var i = 0; i < respuesta.length; i++) {
                        document.getElementById('CurtidoId').options[contador] = new Option(respuesta[i].codigolote, respuesta[i].curtidoId);
                        contador++;
                    }
                }
            }
        });
    }
    Guardaescurrdio() {
        if (this.curtidos == '0') {
            $("mensajees").remove.removeClass("hidden");
        } else {
            $("mensajees").addClass("hidden");
            if (this.Bombo == '0') {
                $("mensajebo").remove.removeClass("hidden");
            } else {
                $("mensajebo").addClass("hidden");
                if (this.Cantidad == '') {
                    $("mensajeca").remove.removeClass("hidden");
                } else {
                    $("mensajeca").addClass("hidden");
                    if (this.Codigolote == '') {
                        $("mensajees").remove.removeClass("hidden");
                    } else {
                        $("mensajees").addClass("hidden");
                        if (this.personal == '0') {
                            document.getElementById('mensajeper').innerHTML = 'Seleccione a la persona indicada en este proceso';
                        } else {
                        var bombo = this.Bombo;
                        var codigolote = this.Codigolote;
                        var cantidad = this.Cantidad;
                        var curtido = this.CurtidoId;
                        var fecha = this.Fecha;
                            var personal = this.personal;
                        var codiuniescurridio = this.codiuniescurridio;
                        var accion = this.accion;
                        $.ajax({
                            type: "POST",
                            url: accion,
                            data: {
                                bombo, cantidad, codigolote, curtido, fecha, personal,codiuniescurridio
                            },
                            success: (respuesta) => {
                                console.log(respuesta);
                                if (respuesta[0].code == "ok") {
                                    swal("Escurrido", "Se guardo exitosamente", "success");
                                    ListaIndexEscurrido();
                                    this.limpiarcajas();
                                    this.limpiarcajarEscurrido();
                                } else {
                                    this.limpiarcajas();
                                    this.limpiarcajarEscurrido();
                                    swal("Escurrido", "Ocurrio un error", "error");

                                }
                            }
                            });
                        }
                    }
                   
                }

            }
        }
    }

    limpiarcajarEscurrido() {
        document.getElementById("CurtidoId").options.length = 1;
    }
 
    NumeroPielesCurtido(id) {
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
                document.getElementById('codigolotecurt').value = respuesta[0].codigolote;
                $('#codigolotecurt').value = respuesta[0].codigoLote;
                $('#codigolotecurt').removeClass('hidden');

            }
        });
    }
    limpiarcajas() {
        document.getElementById('Cantidad').value = '';
        document.getElementById('CurtidoId').selectedIndex = 0;
        document.getElementById('fecha').selectedIndex = 0;
        document.getElementById('codigolotecurt').value = '';
        document.getElementById('bomboId').value = '';
        document.getElementById('TotalPielesInput').value = '';
        $('#IngresoEscurrido').modal('hide');
        //ListaIndexEscurrido;
        this.limpiarcajarEscurrido();

    }
}