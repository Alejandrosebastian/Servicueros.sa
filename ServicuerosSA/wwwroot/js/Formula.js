
class ClaseFormula {
    constructor(nombre, fechaCreacion, version, tipoProceso, tipoPiel,
        fechaVigencia, vigencia, pagina, fecha, parada, bombo, peso,
        cantidad, promedio, autorizado, procesado, entregado, ingrediente,
        porcentaje,cantidadFormula, tiempo, observaciones, accion) {
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
                $('#version').val = respuesta[0].version;
                $('#fechaCreacion').val = respuesta[0].fechaCreacion;
                $('#nombre').val = respuesta[0].nombre;
                $('#')



            }
        );
    }
}
