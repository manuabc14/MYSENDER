// Write your Javascript code.
$(document).ready(function () {

   $('#DtbHistorique').DataTable(
        {
            "processing": true,
            "serverSide": true,
            "ajax": "Home/AjaxHandler",
            "language": { "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/French.json" },
            "columns": [
                { "data": "id" }, //0
                { "data": "smstext" }, //1
                { "data": "dateEnvoi" }, //2
                { "data": "nomContact" }, //3
                { "data": "nomEmetteur" },//4
                { "data": "statutDef" }//5
            ],
            "columnDefs":
            [
                { "targets": [0], "visible": false },
                { "targets": [1], "searchable": false },
                { "targets": [2], "orderable": false, "searchable": false },
                { "targets": [3], "orderable": false, "searchable": false },
                { "targets": [4], "orderable": false, "searchable": false },
                { "targets": [5], "orderable": false, "searchable": false, "visible": false }
            ]
        });


    var table = $('#DtbHistorique').DataTable();

    $('#DtbHistorique tbody').on('click', 'tr', function () {

        var object = table.row(this).data();

        $("input#txtRecept").val(object.nomContact);

        $("textarea#txtMessage").val(object.smstext);
       // console.log(table.row(this).data());

        //gestion de la couleur selon le statut
        switch (object.statutDef) {
            case 1:
                $("#lblDate").text("envoi refusé le " +object.dateEnvoi);
                $("#iconstatut").delay(3000).css("color", "red");
                $("#lblDate").delay(3000).css("color", "red");
                break;
            case 0:
                $("#lblDate").text("envoyé le " + object.dateEnvoi);
                $("#iconstatut").delay(3000).css("color", "green");
                $("#lblDate").delay(3000).css("color", "green");
                break;
            case -1:
                $("#lblDate").text("en attente d'envoi");
                $("#iconstatut").delay(3000).css("color", "gray");
                $("#lblDate").delay(3000).css("color", "gray");
                break;
            default:
                $("#iconstatut").delay(3000).css("color", "black");
                $("#lblDate").delay(3000).css("color", "black");
        }

    });
});

////** focus and focusout on label*/
//$('.input-field #inputnom').focus(
//    function () { $('.input-field #lblnom').addClass('active') }
//);
//$('.input-field #inputnom').focusout(
//    function() {
//        if ($(".input-field #inputnom").val() === "") {
//            $('.input-field #lblnom').removeClass('active');
//        }
//    }
//);


//$('.input-field #inputprenom').focus(
//    function () { $('.input-field #lblprenom').addClass('active') }
//);
//$('.input-field #inputprenom').focusout(
//    function() {
//        if ($(".input-field #inputprenom").val() === "") {
//            $('.input-field #lblprenom').removeClass('active');
//        }
//    }
//);


//$('.input-field #inputtel').focus(
//    function () { $('.input-field #lbltel').addClass('active') }
//);
//$('.input-field #inputtel').focusout(
//    function() {
//        if ($(".input-field #inputtel").val() === "") {
//            $('.input-field #lbltel').removeClass('active');
//        }
//    }
//);


$(function () {
    $('form.material').materialForm();

    $('form').validate({
        errorPlacement: function (error, element) { }
    });

});