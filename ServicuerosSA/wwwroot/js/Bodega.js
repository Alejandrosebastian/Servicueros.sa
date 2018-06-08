
class Bodegas {
    constructor(nombreBodega, ubicacion, cantidad, estantes, tipo, accion) {
        this.Nombrebodega = nombreBodega;
        this.cantidad = cantidad;
        this.estantes = estantes;
        this.nombreBodega = nombreBodega;
        this.tipo = tipo;
        this.ubicacion = ubicacion;
        this.accion = accion;
    }
    bodega()
    {
        var bodegaId = this.Nombrebodega;
        var accion = this.accion;
        $.ajax({
            type: "POST",
            url: accion,
            data: { bodegaId },
            success: (respuesta) => {
                $('#Bodegas').html(respuesta[0]);
            }
        });
    }
}
