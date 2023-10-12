﻿
function getOrdini(admin, data)
{
    let tot = 0
    $("#tbody").empty()
    $.ajax
    ({
        method: 'POST',
        url: "Ordine/getOrdini",
        data:
        {
            Data: data
        },
        success: function (ordini)
        {
            console.log(ordini)
            $.each(ordini, function (i, item)
            {

                tot += (item.Quantita * item.Costo)
                console.log(item)

                let tr = "<tr>" +
                    "<td>" + item.Quantita  + "</td>" +
                    "<td>" + item.Indirizzo + "</td>" +
                    "<td>" + item.Note      + "</td>"

                if (item.Confermato)
                    tr += "<td> Arrivo stimato per " + item.DataArrivo + "</td>"
                else
                    tr += "<td> In attesa di conferma </td>"

                if (!item.Confermato)
                    tr += "<td> <a href='/Ordine/Edit/" + item.Id + "'>Modifica</a>" +
                          "<span>|</span>" +
                        "<a href='/Ordine/Delete/" + item.Id + "'>Modifica</a> </td>"

                else if (item.evaso)
                    tr += "<td> Ordine evaso </td>"

                else if (admin == 'True')
                    tr += "<td> <a class='btn btn-primary' href='/Ordine/evadiOrdine/" + item.Id + "'>Evadi</a> </td>"

                tr += "</tr>"

                $("#tbody").append(tr);
                console.log(tot)

            })
            console.log(tot)
        },
        error: function (e)
        {
            console.log(e)
        }
    })
}

function getCosto(fk, quant)
{
    let totale = 0
    $.ajax
        ({
            method: 'POST',
            url: "Ordine/getCostoOrdine",
            data:
            {
                FkProdotto: fk,
                Quantita: quant
            },
            success: function (out)
            {
                console.log(out)
                return out
            },
            error: function (e)
            {
                console.log(e, "PORCODIO")
            }
        })
}


getOrdini(a)