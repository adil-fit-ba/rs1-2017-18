

function DodajAjaxEvente() {
    $("button[ajax-poziv='da']").click(function (event) {

        var btn = $(this);

        var url = btn.attr("ajax-url");
        var r = btn.attr("ajax-rezultat");

        $.get(url,
            function (rezultat, status) {
                $("#" + r).html(rezultat);
             
            });
    });

   
    $("form[ajax-poziv='da']").submit(function (event) {
        event.preventDefault();

        var forma = $(this);
        var r = forma.attr("ajax-rezultat");
        var url = forma.attr("action");
        $.ajax(
            {
                type: "POST",
                url: url,
                data: forma.serialize(),
                success: function (rezultat) {
                    $("#" + r).html(rezultat);
                
                }
            }

        );
    });
}

$(document).ready(function() {
    DodajAjaxEvente();

});


$(document).ajaxComplete(function () {
    DodajAjaxEvente();

});