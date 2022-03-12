$("body").on("click", "button[ajax-poziv='da']", function (event) {
    event.preventDefault();
    var urlZaPoziv = $(this).attr("ajax-url");
    var divZaRezultat = $(this).attr("ajax-rezultat");

    $.get(urlZaPoziv,  function (Data, status) {
        $("#" + divZaRezultat).html(Data);
    });
});

$("body").on("submit", "form[ajax-poziv='da']", function (event) {
    event.preventDefault();
    var UrlZaPoziv = $(this).attr("ajax-url");
    var DivZaRezultat = $(this).attr("ajax-rezultat");
    var Modal = $(this).attr("ajax-modal");
    var form = $(this);

    $.ajax({
        type: "POST",
        url: UrlZaPoziv,
        data: form.serialize(),
        success: function (Data) {
            $("#" + DivZaRezultat).html(Data);

            if (Modal != undefined)
                $("#" + Modal).modal("toggle");

        },
        error: function (req, err) { console.log(req.responseText); }
    });
});

$("body").on("click", "a[ajax-poziv='da']", function (event) {
    event.preventDefault();


    var UrlZaPoziv = $(this).attr("ajax-url");
    var DivZaRezultat = $(this).attr("ajax-rezultat");
    var Modal = $(this).attr('ajax-modal');

    console.log($.ajax({ type: "GET", url: UrlZaPoziv, async: false }).responseText);

    $.get(UrlZaPoziv, function (Data, status) {
        $("#" + DivZaRezultat).html(Data);

        if (Modal != undefined)
            $("#" + Modal).modal("toggle");

    });

});