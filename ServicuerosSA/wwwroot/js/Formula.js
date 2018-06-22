
class ClaseFormula {
    constructor(nombre, fechaCreacion, version, tipoProceso, tipoPiel, accion) {
        this.nombre = nombre;
        this.fechaCreacion = fechaCreacion;
        this.version = version;
        this.tipoProceso = tipoProceso;
        this.tipoPiel = tipoPiel;
    }

    CabeceraFormula(id) {
        var accion = this.accion;
        $.post(accion,
            { id },
            (respuesta) => {
                $('#codigo').val = respuesta[0].codigo;
                //completar los campos que faltan

            }
        );
    }
    CuerpoFormula(id) {

    }
}
