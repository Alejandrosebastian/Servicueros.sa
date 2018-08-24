
// Write your JavaScript code.

$().ready(() => {
    claseJsLlamarListaProveedor();
    claseJsLlamarListaLotes(1);
    ListaIndex();
   // claseJsLlamarListaDescarne();
    ListaDescarne();
   //Listatipotripa();
})
var Impresion = (id) => {
    var contenido = document.getElementById(id).innerHTML;
    var contenidooriginal = document.body.innerHTML;
    document.body.innerHTML = contenido;
    window.print();
    document.body.innerHTML = contenidooriginal;
}
var claseJsLlamarListaLotes = (id) => {
    var accion = '../Lotes/ContraladorListaLotes';
    var listalotes = new ClaseJSLotes('', '', '', '', '', '', accion);
    listalotes.clasJsListaLotes(id);
}
var claseJsLlamarListaProveedor = () => {
    var accion = '../Proveedores/ControladorListaProveedores';
    var listaproveedor = new ClaseJSProveedor('', '', '', '', '', '', '', '', '', accion);
    listaproveedor.claseJsListaProveedor();
}
var ListaFormulas = () => {
    var accion = 'Formulas/ControladorListaFormulas';
    var listaformulas = new Formulas('', '', '', '', accion);
    listaformulas.ListaFormulas();
}
var ListaBombos = () => {
    var accion = 'Bombos/ControladorListaBombos';
    var ListaBombos = new Bombos('', '', '', '', accion);
    ListaBombos.ListaBombos();
}
var ListaPelambre = () => {
    var accion = 'Pelambres/ControladorListaPelambre';
    var listaPelambre = new Pelambre('', '', '', '', '','', accion);
    listaPelambre.ListaPelabre();
}
var ListaDescarne = () => {
    var accion = 'Descarnes/ControladorListaDescarne';
    var listaDescarne = new Descarne('', '', accion);
    listaDescarne.ListaDescarne();
}
var Listatipotripa = () => {
    var accion = 'Bodegatripas/Controladorlistatipotripa';
    var listatrip = new BodegaTripa('','','', '', '', '', accion);
    listatrip.ClaseListaClasificacionTripa();
}
var listadescarne = () => {
    var accion = 'Bodegatripas/Controladorlistadescarnes';
    var lisdescarnes = new BodegaTripa('', '', '', '', '', '', accion);
    lisdescarnes.ClaseListadescarnes();
}
var GuardaPelambre = () => {
    var bombos = document.getElementById('bomboId');
    var bombo = bombos.options[bombos.selectedIndex].value;
    var formulas = document.getElementById('formulaId');
    var formula = formulas.options[formulas.selectedIndex].value;
    var obsrvaciones = document.getElementById('observacion').value;
    var accion = 'Pelambres/ControladorGuardarPelambre';
    var cajafecha = document.getElementById('fecha').value;
    var personales = document.getElementById('personalId');
    var personal = personales.options[personales.selectedIndex].value;
    var totalcheck = $('input:checkbox:checked').length;
    var contador = 0;
    var bodegaid = new Array;
    var codlote = new Array;
    var peso = 0;
    var pieles = 0;
    var dt = new Date();
    var month = dt.getMonth() + 1;
    var day = dt.getDate();
    var year = dt.getFullYear();
    var fecha = day + '|' + month + '|' + year + '|' + dt.getHours() + '|' + dt.getMinutes() + '|' + dt.getSeconds();
    var codigoUnico='';
    $("input:checkbox:checked").each(function () {
        var ya = ($(this).val()).split("|");
        contador++;
        var guardaPelambre = new Pelambre(cajafecha, obsrvaciones, ya[0], bombo, formula, ya[3], accion);
        if (contador != totalcheck) {
            guardaPelambre.GuardaPelambre(personal, ya[1], ya[3], ya[2], fecha, '');
        } else {
            guardaPelambre.GuardaPelambre(personal, ya[1], ya[3], ya[2], fecha, 'limpia');
        }
    });
   

}
var ListaIndex = () => {
    var accion = '../Pelambres/ControladorListaIndex';
    var index = new Pelambre('', '', '', '', '', '', accion);
    index.ListaIndex();
}
var listaTipoPiel = () => {
    var accion = 'TipoPiels/ControladorTipoPielLista';
    var tipopiellista = new ClaseTipoPiel('', accion);
    tipopiellista.claseJsListaTipoPiel();
}
var listaClasificaciones = () => {
    var accion = 'Clasificaciones/ControladorListaClasificaciones';
    var tipoClasificacion = new ClaseClasificaciones('', accion);
    tipoClasificacion.ClaseListaClasificaciones();
}
var CodigoLotes = () => {
    var accion = '../Lotes/ControladorCodigoLote';
    var codigolote = document.getElementById('Codigolote').value;
    var codigo = new ClaseJSLotes(codigolote, '', '', '', '', '', accion);
    codigo.claseJsCodigoLote();
}
var CedulaProveedor = () => {
    var accion = '../Proveedores/ControladorCedulaProveedor';
    var ruc = document.getElementById('Ruc').value;
    var ced = new ClaseJSProveedor(ruc, '', '', '', '', '', '', '', '', accion);
    ced.claseJsCedulaProveedor();
}
var boodegas = () => {
        var accion = '../Bodegas/ControladorBodega';
        var bodegas = document.getElementById('BodegaId');
        var bodega = bodegas.options[bodegas.selectedIndex].value;
        var bo = new Bodegas(bodega, '', '', '', '', accion);
        bo.bodega();
    }
var tipopiel = () => {
        var accion = 'Pelambres/ControladorListaPelambrexTipoPiel';
        var tipopieles = document.getElementById('tipoPiel');
        var tipopiel = tipopieles.options[tipopieles.selectedIndex].value;
        var clasificaciones = document.getElementById('clasificaciones');
        var clasificacion = clasificaciones.options[clasificaciones.selectedIndex].value;
        var listaXTipoPiel = new Pelambre('', '', '', '', '', '', accion);
        listaXTipoPiel.ListaIndeXTipoPiel(tipopiel, clasificacion);
    }
var cedula = () => {
    var accion = '../Personales/ControladorCedulaPersonal';
    var cedula = document.getElementById('Cedula').value;
    var ced = new ClaseJSPersonal(cedula, '', '', '', '', '', '', '', accion);
    ced.clasJscedula();
}
var lote = () => {
    var accion = '../Lotes/ContraladorUnLote';
    var cod = document.getElementById('LoteId');
    var Lote = cod.options[cod.selectedIndex].value;
    var code = new ClaseJSLotes(Lote, '', '', '', '', '', accion);
    code.obtenerUnLote();
}
var numeropileslote = () => {
    var accion = '../Lotes/ControladorComparaNumeroPieles';
    var cod = document.getElementById('LoteId');
    var Lote = cod.options[cod.selectedIndex].value;
    var valor = document.getElementById('NumeroPieles').value;
    var nupilo = new ClaseJSLotes(Lote, valor, '', '', '', '', accion);
    nupilo.NumeroPielesLote();

}
var listaPersonal = () => {
    var accion = '../Personales/ControladorListaPersonalPerlambre';
    var per = new ClaseJSPersonal('', '', '', '', '', '', '', '', accion);
    per.ListaPersonal();

}
var EliminarPelambre = (id) => {
    var r = confirm("Esta seguro que desea borrar el registro");
    if (r == true) {
        var accion = 'Pelambres/ControladorEliminarPelambre';
        var pelambre = new Pelambre('', '', '', '', '', '', accion);
        pelambre.EliminaPelambre(id);
    }
   
}
var EliminarDescarne = (id) => {
    var r = confirm("Esta seguro que desea borrar el registro");
    if (r == true) {
        var accion = 'Descarnes/ControladorEliminarDescarne';
        var descarne = new Descarne('', '', accion);
        descarne.EliminarDescarne(id);
    }
}
var ImprimirPelambre = (id) => {
    var accion = 'Pelambres/ControladorImprimirEmcabezadoFormula';
    var impresionformula = new Formulas('', '', '', '', accion);
    impresionformula.CabeceraFormula(id);
}
var componentesFormula = (id) => {
    var accion = 'Pelambres/ControladorComponentesFormula';
    var componente = new Formulas('', '', '', '', accion);
    componente.CuerpoFormula(id);
}
var impresion = () => {
    var contenido = document.getElementById('areaImprimir').innerHTML;
    var contenidooriginal = document.body.innerHTML;
    document.body.innerHTML = contenido;
    window.print();

}
var ImprimirPesaje = (id) => {
    var accion = 'Pelambres/ControladorImprimirPesaje';
    var impresionPesaje = new Formulas('', '', '', '', accion);
    impresionPesaje.CuerpoPesaje(id);
}
var ListaPelambreDescarne = () => {
    var accion = 'Descarnes/ControladorListaPelambre';
    var descarne = new Descarne('', '', accion);
    descarne.listapelambre();
}
var NumeroPielesPelambre = () => {
    var accion = 'Descarnes/ControladorUnPelambreDescarne';
    var combopelambres = document.getElementById('PelambreId');
    var unpelabrecombo = combopelambres.options[combopelambres.selectedIndex].value;
    var des = new Descarne('', '', accion);
    des.NumeroPielesPelambre(unpelabrecombo);
}
var numeropielestripa = () => {
    var accion = 'Bodegatripas/Controladornumeropiel';
    var trips = document.getElementById('Descarnesid');
    var untrips = trips.options[trips.selectedIndex].value;
    var tripa = new BodegaTripa('', '', '', '', '', '', accion);
    tripa.Numeropielstripas();
}
var GuardaDescarne = () => {
    var accion = 'Descarnes/ControladorGuardaDescarne';
    var pelambres = document.getElementById("PelambreId");
    var pelambre = pelambres.options[pelambres.selectedIndex].value;
    var personales = document.getElementById("personalId");
    var personal = personales.options[personales.selectedIndex].value;
    var cantidad = document.getElementById("CantidadPieles").value;
    var d = new Date();
    var fecha = d.getDate();
    var guades = new Descarne(cantidad, d, accion);
    guades.GuardarPelambre(personal,pelambre);
}
var controlnumeropieles = () => {
    var pelambre = document.getElementById("TotalPielesInput").value;
    var cantidad = document.getElementById("CantidadPieles").value;
    if (pelambre == cantidad) {
        $("#mensajep").addClass("hidden");
    } else {
        $("#mensajec").removeClass("hidden");
        $('#graba').prop('disabled', true);
    }

}
var pesa = (id) => {
    var accion = 'Pelambres/COntroladorImprimirPesaje';
    var pesaje = new Pelambre('', '', '', '', '', '', accion);
    pesaje.Pesaje(id);
}
