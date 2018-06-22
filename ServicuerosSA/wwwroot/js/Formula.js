
class ClaseFormula {
    constructor(codigo, fechaCreacion, version, tipoPiel,fechaVigencia, vigencia, pagina, fecha, parada, bombo, peso,cantidad, promedio, autorizado, procesado, entregado, accion) {
        this.codigo = codigo;
        this.fechaCreacion = fechaCreacion;
        this.version = version;
        this.tipoPiel = tipoPiel;
        this.fechaVigencia = fechaVigencia;
        this.vigencia = vigencia;
        this.pagina = pagina;
        this.fecha = fecha;
        this.parada = parada;
        this.bombo = bombo;
        this.peso = peso;
        this.cantidad = cantidad;
        this.promedio = promedio;
        this.autorizado = autorizado;
        this.procesado = procesado;
        this.entregado = entregado;
        
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
                $('#tipoProceso').val = respuesta[0].tipoProces;
                $('#tipoPiel').val = respuesta[0].tipoPiel;
                $('#fechaVigencia').val = respuesta[0].fechaVigencia;
                $('#vigencia').val = respuesta[0].vigencia;
                $('pagina').val = respuesta[0].pagina;
                $('#fecha').val = respuesta[0].fecha;
                $('#parada').val = respuesta[0].parada;
                $('#bombo').val = respuesta[0].bombo;
                $('#peso').val = respuesta[0].peso;
                $('cantidad').val = respuesta[0].cantidad;
                $('#promedio').val = respuesta[0].promedio;
                $('#autorizado').val = respuesta[0].autorizado;
                $('#procesado').val = respuesta[0].procesado;
                $('#entregado').val = respuesta[0].entregado;

            }
        );
    }
    CuerpoFormula(id) {

    }
}
