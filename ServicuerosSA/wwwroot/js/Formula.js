﻿
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
                $('#ingrediente').val = respuesta[0].ingrediente;
                $('#porcentaje').val = respuesta[0].porcentaje;
                $('#cantidadFormula').val = respuesta[0].cantidadFormula;
                $('#tiempo').val = respuesta[0].tiempo;
                $('#observaciones').val = respuesta[0].observaciones;
                $('#accion').val = respuesta[0].accion;



            }
        );
    }
    CuerpoFormula(id) {

    }
}
