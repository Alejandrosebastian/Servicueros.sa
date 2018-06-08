
class Formulas {
    constructor(nombre, fecha_creacion, tipo_proceso, tipo_piel, accion) {
        this.fecha_creacion = fecha_creacion;
        this.nombre = nombre;
        this.tipo_proceso = tipo_proceso;
        this.tipo_piel = tipo_piel;
        this.accion = accion;
    }
    ListaFormulas() {
        var accion = this.accion;
        var contador = 1;
        $.ajax({
            type: "POST",
            url: accion,
            data: {},
            success: (respuesta) => {
                //console.log(respuesta);
                if (0 < respuesta.length) {
                    for (var i = 0; i < respuesta.length; i++) {
                        document.getElementById('formulaId').options[contador] = new Option(respuesta[i].nombre, respuesta[i].formulaId);
                        contador++;
                    }
                }
            }
        });
    }
}
