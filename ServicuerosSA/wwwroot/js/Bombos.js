
class Bombos {
    constructor(numero, capacidad,fecha_inrgeso, peso, accion)
    {
        this.numero = numero;
        this.capacidad = capacidad;
        this.fecha_inrgeso = fecha_inrgeso;
        this.peso = peso;
        this.accion = accion;
    }
    ListaBombos() {
        var accion = this.accion;
        var contador = 1;
        $.ajax({
            type: "POST",
            url: accion,
            data: {},
            success: (respuesta) => {
                
                if (0 < respuesta.length) {
                    for (var i = 0; i < respuesta.length; i++) {
                        document.getElementById('bomboId').options[contador] = new Option(respuesta[i].num_bombo, respuesta[i].bomboId);
                        contador++;
                    }
                }
            }
        });
    }

    bombo() {
        var bomboId = this.numero;
        var accion = this.accion;
        $.ajax({
            type: "POST",
            url: accion,
            data: { bomboId},
            success: (respuesta) => {
                $.each(respuesta, (index, val) => {

                });
                
            }
        });
    }
}
