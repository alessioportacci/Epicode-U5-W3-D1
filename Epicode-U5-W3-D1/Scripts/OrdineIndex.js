
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

                //1-2-3
                let tr = "<tr>" +
                    "<td>" + item.Quantita  + "</td>" +
                    "<td>" + item.Indirizzo + "</td>" +
                    "<td>" + item.Note      + "</td>"

                //4
                if (item.Confermato)
                    tr += "<td> Arrivo stimato per " + item.DataArrivo + "</td>"
                else
                    tr += "<td> In attesa di conferma </td>"

                //5
                if (!item.Confermato)
                    tr += "<td> <a href='/Ordine/Edit/" + item.Id + "'>Modifica</a>" +
                          "<span>|</span>" +
                        "<a href='/Ordine/Delete/" + item.Id + "'>Elimina</a> </td>"

                else if (item.Evaso)
                    tr += "<td> Ordine evaso </td>"

                else if (admin == 'True')
                    tr += "<td> <a class='btn btn-primary' href='/Ordine/evadiOrdine/" + item.Id + "'>Evadi</a> </td>"

                tr += "</tr>"

                $("#tbody").append(tr);
            })
            $("#totale").text("Totale: " + tot + "€")
            console.log(tot)
        },
        error: function (e)
        {
            console.log(e)
        }
    })
}


getOrdini(a)

$("#cerca").click(function () {
    let data = $("#databox").val()
    getOrdini(a, data)
});
