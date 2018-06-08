class ClaseJSPersonal {
    constructor(cedula, nombre, apellidos, fechanacimiento, sexo, telefono, celular, direccion, accion) {
        this.cedula = cedula;
        this.nombre = nombre;
        this.apellidos = apellidos;
        this.fechanacimiento = fechanacimiento;
        this.sexo = sexo;
        this.telefono = telefono;
        this.celular = celular;
        this.direccion = direccion;
        this.accion = accion;

    }
    clasJslsitapersonal() {
        var accion = this.accion;
        $.ajax({
            type: "POST",
            url: accion,
            data: {},
            seccess: (respuesta) => {
                $.each(respuesta, (index, val) => {
                    $('#resultado').html(val[0]);
                });
            }
        });
    }
    clasJscedula() {
        var accion = this.accion;
        var cedula = this.cedula;
        var mensaje = '';
        $.ajax({
            type: "POST",
            url: accion,
            data: { cedula },
            success: (respuesta) => {
                if (respuesta[0].code == "si") {
                    $('#ced').css('visibility', 'visible');
                    $('#graba').prop('disabled', true);
                }
                else {
                    $('#ced').css('visibility', 'hidden');
                    $('#graba').prop('disabled', false);
                }
            }
        });
    }

    ListaPersonal() {
        var accion = this.accion;
        var contador = 1;
        $.ajax({
            type: "POST",
            url: accion,
            data: {},
            success: (respuesta) => {
                
                if (0 < respuesta.length) {
                    for (var i = 0; i < respuesta.length; i++) {
                        document.getElementById('personalId').options[contador] = new Option(respuesta[i].nombres + ' ' + respuesta[i].apellidos, respuesta[i].personalId);
                        contador++;
                    }
                }
            }
        });



        
    }

}
