function getOrdini(data)
{
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
                console.log("ciao")
                console.log(item)
                let tr = "<tr>" +
                    "<td>" + item.Quantita  + "</td>" +
                    "<td>" + item.Indirizzo + "</td>" +
                    "<td>" + item.Note      + "</td>"
                if (item.confermato)
                    tr += "<td> Arrivo stimato per " + item.DataArrivo + "</td>"
                if (!item.Confermato)
                    tr += "<a href='/Ordine/Edit/" + item.Id + "'>Modifica</a>" +
                          "<span>|</span>" +
                          "<a href='/Ordine/Delete/" + item.Id + "'>Modifica</a>"
                if (admin == 'False' && item.Confermato && !item.Evaso)
                    tr += "<a class='btn btn-primary' href='/Ordine/evadiOrdine'" + item.Id + "'>Evadi</a>"

                tr += "</tr>"

                $("#tbody").append(tr);
            })
        },
        error: function (e)
        {
            console.log(e)
        }
    })
}

getOrdini()