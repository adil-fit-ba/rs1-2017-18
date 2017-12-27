


    //$("#btn1").click(function () {
    //    $.get("/studenti/index", function(data, status){
    //        $("#ajaxDiv").html(data);
    //    });
    //});

$("button[ajax-poziv='da']").click(function (event) {
    event.preventDefault();
        var urlZaPoziv = $(this).attr("ajax-url");
        var divZaRezultat = $(this).attr("ajax-rezultat");

        $.get(urlZaPoziv, function (data, status) {
            $("#" + divZaRezultat).html(data);
        });
    });

$("a[ajax-poziv='da']").click(function (event) {
        event.preventDefault(); 
        var urlZaPoziv1 = $(this).attr("ajax-url");
        var urlZaPoziv2 = $(this).attr("href");
        var divZaRezultat = $(this).attr("ajax-rezultat");

        var urlZaPoziv;

    if (typeof urlZaPoziv1 === 'string' || urlZaPoziv1 instanceof String)
            urlZaPoziv = urlZaPoziv1;
        else
            urlZaPoziv = urlZaPoziv2;

        $.get(urlZaPoziv, function (data, status) {
            $("#" + divZaRezultat).html(data);
        });
});

$("form[ajax-poziv='da']").submit(function (event) {
    event.preventDefault();
        var urlZaPoziv1 = $(this).attr("ajax-url");
        var urlZaPoziv2 = $(this).attr("action");
        var divZaRezultat = $(this).attr("ajax-rezultat");

        var urlZaPoziv;
        if (typeof urlZaPoziv1 === 'string' || urlZaPoziv1 instanceof String)
            urlZaPoziv = urlZaPoziv1;
        else
            urlZaPoziv = urlZaPoziv2;

    var form = $(this);

    $.ajax({
        type: "POST",
        url: urlZaPoziv,
        data: form.serialize(),
        success: function (data) {
            $("#" + divZaRezultat).html(data);
        }
    });
 });

