﻿
// Write your JavaScript code.

$().ready(() => {
    claseJsLlamarListaProveedor();
    claseJsLlamarListaLotes(1);
    ListaIndex();
    listatripasindex();
    ImprimirCarnaza();
    ImprimirClasiTripa();
   /// ListaIndexcurtido();
    ImprimirClasiPelo();
    ListaIndexcurtido();



    // claseJsLlamarListaDescarne();
   // ListaDescarne();
   //Listatipotripa();

   
   // ListaDescarne();
   // Listatipotripa();
    

    // claseJsLlamarListaDescarne();
    // ListaDescarne();
    //Listatipotripa();

    ListaIndexDescarne();
    //Listatipotripa();
    tablaFormulas();
    TablaPelo();
    
    
});

////////////////////cerrar modales
var cerrarmodalLotes = () => {
    $('#Impresionlote').modal('hide');
}
var cerrarmodalcurtido = () => {
    $('Impresioncurtido').modal('hide');
}
/////////////

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
var ListaIndexDescarne = () => {
    var accion = '../Descarnes/ControladorListaDescarne';
    var listaDescarne = new Descarne('', '', '', '','','',accion);
    listaDescarne.ListaIndexdescarne();
}
var Listatipotripa = () => {
    var accion = 'Bodegatripas/Controladorlistatipotripa';
    var listatrip = new BodegaTripa('','','','', '', '', '','','', accion);
    listatrip.ClaseListaClasificacionTripa();
}
var listadescarne = () => {

    var accion = '../Bodegatripas/Controladorlistadescarnes';
    var lisdescarnes = new BodegaTripa('', '','', '', '', '', '','','', accion);
    lisdescarnes.ClaseListadescarnes();
}
//LISTA CURTIDO
var ListaIndexcurtido = () => {
    var accion = '../Curtidos/ControladorListaIndexCurtido';
    var listacurti = new Curtidojs('', '', '', '', '', '', '', '', '', '','',accion);
    listacurti.ListaIndexCurt();
}


var ListaIndex = () => {
    var accion = '../Pelambres/ControladorListaIndex';
    var index = new Pelambre('', '', '', '', '', '', accion);
    index.ListaIndex();
}
var listatripasindex = () => {
    var accion = '../BodegaTripas/Controllistaindesxtripa';
    var inde = new BodegaTripa('','','','','','','','','',accion);
    inde.Listaclasificaciontripaindex();
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
/////clasificacion tripas bedegas
var bodegastri = () => {
    var accion = '../ClasificacionTripas/controladorlistabode';
    var bod = new BodegaTripa('', '','', '', '', '','','','', accion);
    bod.Claselistabodegas();

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
///control numero pieles lote
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
var EliminarClasiTripa = (id) => {
    var c = confirm("Esta seguro que desea borrar el registro");
    if (c == true) {
        var accion = 'Pelambres/ControladorEliminarPelambre';
        var pelambre = new Pelambre('', '', '', '', '', '', accion);
        pelambre.EliminaPelambre(id);
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
//IMPRESION FORMULA CURTIDO
var imprimirCurtido = (id) => {
    var accion = 'Curtidos/ControladorImprimirEncabezadoFormula';
    var impresioncurtido = new Curtidojs('', '', '', '', '', '', '', '', '', '','', accion);
    impresioncurtido.CabeceraFormulaCurtido(id);
}
var componentesFormulaCurtido = (id) => {
    var accion = 'Curtidos/ControladorComponentesFormula';
    var impresioncomponetescurtido = new Curtidojs('','','','','','','','','','','',accion);
    impresioncomponetescurtido.CuerpoFormulaCurtido(id);
}
////////////////
var componentesFormula = (id) => {
    var accion = 'Pelambres/ControladorComponentesFormula';
    var componente = new Formulas('', '', '', '', accion);
    componente.CuerpoFormula(id);
}
// QUIMICO
var ImprimirQuimico = (id) => {
    var accion = 'Pelambres/ControladorImprimirEncabezadoQuimico';
    var impresionquimico = new Formulas('', '', '', '', accion);
    impresionquimico.CabeceraQuimico(id);
}
var componentesQuimico = (id) => {
    var accion = 'Pelambres/ControladorComponenteQuimico';
    var quimico = new Formulas('', '', '', '', accion);
    quimico.CuerpoQuimico(id);
}
///areaimprimir
var impresion = () => {
    var contenido = document.getElementById('areaImprimir').innerHTML;
    var contenidooriginal = document.body.innerHTML;
    document.body.innerHTML = contenido;
    window.print();
    $('#Impresionlote').modal('hide');

}
///areaimprimirreporpelambre
var impresionrepopelambre = () => {
    var contenido = document.getElementById('areaImprime').innerHTML;
    var contenidooriginal = document.body.innerHTML;
    document.body.innerHTML = contenido;
    window.print();
   

}
//pesaje
var ImprimirPesaje = (id) => {
    var accion = 'Pelambres/ControladorImprimirPesaje';
    var impresionPesaje = new Formulas('', '', '', '', accion);
    impresionPesaje.CuerpoPesaje(id);
}
//reporte lote
var ImprimirLote = (id) => {
    var accion = 'Lotes/ControladorImprimirLote';
    var impresionLote = new Formulas('', '', '', '', accion);
    impresionLote.CuerpoLote(id);
}
//reporte pelambre
var ImprimeReportePelambre = (id) => {
    var accion = 'Pelambres/ControladorReportePelambre';
    var impresionreportePelambre = new Formulas('', '', '', '', accion);
    impresionreportePelambre.CuerpoPelambre(id);
}
//reporte Descarne
var ImprimirDescarne = (id) => {
    var accion = 'Descarnes/ControladorImprimirDescarne';
    var imprimirDescarne = new Formulas('', '', '', '', accion);
    imprimirDescarne.CuerpoDescarne(id);

}
//reporte Clasificacion Tripa
var ImprimirClasiTripa = (id) => {
    var accion = '../ClasificacionTripas/ControladorImprimirDescarne';
    var imprimirClasiTripa = new Formulas('', '', '', '', accion);
    imprimirClasiTripa.CuerpoClasiTripa(id);
}
//reporte Carnaza
var ImprimirCarnaza = () => {
    var accion = '../ClasificacionTripas/ControladorImprimirCarnaza';
    var imprimirCarnaza = new Formulas('', '', '', '', accion);
    imprimirCarnaza.CuerpoCarnaza();
}
//reporte Curtido
var Imprimircurtido = () => {
    var accion = '../Curtidos/ControladorImprimircurtido';
    var imprimirCurtido = new Formulas('', '', '', '', accion);
    imprimirCurtido.CuerpoCurtido();
}
//reporte clasi Pelo
var ImprimirClasiPelo = () => {
    var accion = 'Clasificaciones/ControladorImprimirClasiPelo';
    var imprimirclasipelo = new Formulas('', '', '', '', accion);
    imprimirclasipelo.CuerpoClasiPelo();
}
///////combo pelambres
var ListaPelambreDescarne = () => {
    var accion = 'Descarnes/Controladorlistapelambre';
    var descarne = new Descarne('','','','','','',accion);
    descarne.listapelambre();
}
////combo curtido para escurrido
var listaescurrido = () => {
    var accion = 'Escurridos/listacurtidoscbx';
    var escu = new Escurridojs('', '', '', '', '','','',accion);
    escu.listacurtidos();
}

var NumeroPielesPelambre = () => {
    var accion = 'Descarnes/ControladorUnPelambreDescarne';
    var combopelambres = document.getElementById('PelambreId');
    var unpelabrecombo = combopelambres.options[combopelambres.selectedIndex].text;
    var des = new Descarne('', '', '', '', '', '', accion);
    des.NumeroPielesPelambre(unpelabrecombo);
}


var numeropielestripa = () => {
    var accion = 'Bodegatripas/Controladorundescarnetripa';
    var ya = document.getElementById('Descarneid');
    var untrips = ya.options[ya.selectedIndex].value;
    var tripa = new BodegaTripa('', '','', '', '', '', '','','', accion);
    tripa.Numeropielstripas(untrips);
}
var GuardaDescarne = () => {
    var accion = 'Descarnes/ControladorGuardaDescarne';
    var pelambres = document.getElementById("PelambreId");
    var pelambre = pelambres.options[pelambres.selectedIndex].value;
    var personales = document.getElementById("personalId");
    var personal = personales.options[personales.selectedIndex].value;
    var codigolote = pelambres.options[pelambres.selectedIndex].text;
    //alert(codigolote);
    var cantidad = document.getElementById("CantidadPieles").value;
    var d = new Date();
    var fecha = d.getDate();
    var dt = new Date();
    var month = dt.getMonth() + 1;
    var day = dt.getDate();
    var year = dt.getFullYear();
    var fech = day + '|' + month + '|' + year + '|' + dt.getHours() + '|' + dt.getMinutes() + '|' + dt.getSeconds();
    var guades = new Descarne(pelambre,cantidad,d,personal,codigolote,fech,accion);
    guades.GuardarPelambre();
}
var GuardaEscurrido = () => {
    var accion = 'Escurridos/Controladordurdaescurrdio';
    var curtidos = document.getElementById("CurtidoId");
    var curtido = curtidos.options[curtidos.selectedIndex].value;
    var bombos = document.getElementById("bomboId");
    var bombo = bombos.options[bombos.selectedIndex].value;
    var cantidad = document.getElementById("Cantidad").value;
    var codigolotecurt = curtidos.options[curtidos.selectedIndex].text;
    var personales = document.getElementById("personalId");
    var personal = personales.options[personales.selectedIndex].value;
    var d = new Date();
    var fecha = d.getDate();
    var dt = new Date();
    var month = dt.getMonth() + 1;
    var day = dt.getDate();
    var year = dt.getFullYear();
    var fech = day + '|' + month + '|' + year + '|' + dt.getHours() + '|' + dt.getMinutes() + '|' + dt.getSeconds();
    var guarda = new Escurridojs(bombo, cantidad, codigolotecurt, fecha, curtido, personal, fech, accion);
    guarda.Guardaescurrdio();

}
///////// guardar clasificacion en tripa
var Guardarbodetripas = () => {
    var accion = 'BodegaTripas/Controladorguardabodetripas';
    var clasifi = document.getElementById("ClasificaciontripaId");
    var clasifica = clasifi.options[clasifi.selectedIndex].value;
    var descarne = document.getElementById("Descarneid");
    var descarnes = descarne.options[descarne.selectedIndex].value;
    var codigolote = descarne.options[descarne.selectedIndex].text;
    var bode = document.getElementById("BodegaId");
    var bodega = bode.options[bode.selectedIndex].value;
    var numpielesSIN = document.getElementById('NumeroPielesInput').value;
    var numpieles = numpielesSIN.replace('.', ',');
    var medi = document.getElementById('MedidaId');
    var medidas = medi.options[medi.selectedIndex].value;
    var peso = document.getElementById('PesoInput').value;
    var personal = document.getElementById('personalId');
    var personales = personal.options[personal.selectedIndex].value;
    var guarda = new BodegaTripa(clasifica, descarnes, bodega,codigolote, numpieles, peso, medidas, personales, '', accion);
    guarda.GuardaClasificacionTripa(clasifica, descarnes,codigolote, bodega, medidas, personales);


}
////////////////////////////pelqmbre
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
///////////////////clsificacaion tripa

var controlnumeropieltripa = () => {
    var descarne = $("#PielesInput").html();
    var tripa = document.getElementById("NumeroPielesInput").value;
    if (parseInt(tripa) > parseInt(descarne)) {
        $("#mensajeper").removeClass("hidden");
        $('#graba').prop('disabled', true);
        } else {
        $("#mensajeper").addClass("hidden");
        $("#graba").prop('disabled', false);
        }
    
}
////////// control pieles descarne
var controlnumeropielesDes = () => {
    var pelambre = document.getElementById("TotalPielesInput").value;
    var cantidad = document.getElementById("CantidadPieles").value;
    if (pelambre <= cantidad) {
        if (pelambre == cantidad) {
            $("#mensajec").addClass("hidden");
            $('#guarda').prop('disabled', false);
        } else {
            $("#mensajec").removeClass("hidden");
            $('#guarda').prop('disabled', true);
        }
       
    } else {
        $("#mensajec").addClass("hidden");
        $('#guarda').prop('disabled', false);
    }

}

var pesa = (id) => {
    var accion = 'Pelambres/COntroladorImprimirPesaje';
    var pesaje = new Pelambre('', '', '', '', '', '', accion);
    pesaje.Pesaje(id);
}
var tablaFormulas = () => {
    $('#TablaFormulas').DataTable();
}
var TablaPelo = () => {
  //  $('#TablaPelo').DataTable();
    var table = $('#TablaPelo').DataTable({

        buttons: [
            'print'
        ],

        "lengthMenu": [[5, 10, 25, 50, -1], [5, 10, 25, 50, "Todos"]],
        "oLanguage": {
            "oPaginate": {
                "sPrevious": "Anterior",
                "sNext": "Siguiente"
            },
            "sSearch": "Buscar:",
           "sLengthMenu": "Ver registros",
            "sInfo": "Paginas",
            "sZeroRecords": "No se encontraron resultados"
        }

    });
}
/////////////////////Curtido


////// medida
var medidas = () => {
    var accion = '../Medidas/listasmedidas';
    var medi = new Clasemedidas('', '', accion);
    medi.listamedidas()
}



var seleccionFormula = () => {
    var selecciones = document.getElementById('dato');
    var sleeccion = selecciones.options[selecciones.selectedIndex].value;
    if (sleeccion == 1) {
        $('#tipoPiel').addClass('hidden');
    } else {
        $('#tipoPiel').removeClass('hidden');

    }
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
    var codigoUnico = '';
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
//////guardar curtido
var guardarCurtido = () => {
    var accion = 'Curtidos/ControladorGuardaCurtido';
    var bombos = document.getElementById('bomboId');
    var bomboId = bombos.options[bombos.selectedIndex].value;
    var formulas = document.getElementById('formulaId');
    var formulaId = formulas.options[formulas.selectedIndex].value;
    var personales = document.getElementById('personalId');
    var personalId = personales.options[personales.selectedIndex].value;
    var d = new Date();
    var contador = 0;
    var fecha = d.getDate();
    var dt = new Date();
    var month = dt.getMonth() + 1;
    var day = dt.getDate();
    var year = dt.getFullYear();
    var fech = day + '|' + month + '|' + year + '|' + dt.getHours() + '|' + dt.getMinutes() + '|' + dt.getSeconds();
    $('#ListaCurtido tr').each(function () {
        var celdas = $(this).find('td');
        var ClasificacionTripa = ($(celdas[1]).html());
        var BodegaId = ($(celdas[2]).html());
        var MedidaId = ($(celdas[3]).html());
        var CodigoLote = ($(celdas[4]).html());
        var NumeroPieles = ($(celdas[5]).html());
        var peso = ($(celdas[6]).html());
        var fecha = ($(celdas[7]).html());
        var ch = $(celdas[0]).html();
        var BodegaTripaId = $(ch).attr('id');
        $(this).find("input:checkbox:checked").each(() => {
            var clase = new Curtidojs(BodegaTripaId, bomboId, NumeroPieles, MedidaId, formulaId, fecha, peso, BodegaId, personalId, fech, CodigoLote, accion);
             clase.Guardacurtido();
        });

       
    });
}

var listatripas = () => {
    var accion = 'Curtidos/listatripas';
    var curti = new Curtidojs('', '', '', '', '', '', '', '', '', '', '',accion);
    curti.ClaseListaClasificacionTripacurtido();
}

///////////////////////////////para curtido
var ListaCuridoCheck = () => {
    var accion = 'Curtidos/ControladorListacurtido';
    var escu = new Curtidojs('', '', '', '', '', '', '', '', '', '', '', accion);
    escu.LLenaTablaModalCurtido();
}

var numeropielescurtido = () =>
{
    var accion = 'Escurridos/controladorunescurtidoescurrir';
    var combocurtido = document.getElementById('CurtidoId');
    var uncurtido = combocurtido.options[combocurtido.selectedIndex].text;
    var cur = new Escurridojs('', '', '', '', '','','', accion);
    cur.NumeroPielesCurtido(uncurtido);

}
/////////control numero pieles escurrdio
var controlpielesescurrir = () => {
    var curti = document.getElementById("TotalPielesInput").value;
    var canti = document.getElementById("Cantidad").value;
    if (canti > curti) {
            $("#mensajeca").removeClass("hidden");
        $("#guarda").addClass("hidden");
        
    } else {
        $("#mensajeca").addClass("hidden");
        $("#guarda").removeClass("hidden");
    }
}