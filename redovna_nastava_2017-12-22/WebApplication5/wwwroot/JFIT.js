


    //$("#btn1").click(function () {
    //    $.get("/studenti/index", function(data, status){
    //        $("#ajaxDiv").html(data);
    //    });
    //});

    $("button[ajaks-poziv='da']").click(function () {
        var urlZaPoziv = $(this).attr("ajaks-url");
        var divZaRezultat = $(this).attr("ajaks-rezultat");

        $.get(urlZaPoziv, function (data, status) {
            $("#" + divZaRezultat).html(data);
        });
    });

