
$(".idDetalhes").click(function () {

    var id = $(this).attr('id');
    $.ajax({
        type: "Get",
        url: "/Home/BuscarPorId",
        data: {
            'id': id
        },
        success: function (data) {

            $('#modalDetalhes').modal('show');
            $('#idTitulo').text(data.titulo);
            $('#idModoFazer').text(data.modoFazer);

            var ingredientes = data.ingredientes;
            $.each(ingredientes, function (key, value) {

                $('#tbody > tr').append("<td>" + value.nome + "</td><td>" + value.peso + "</td><td>" + value.descricao +
                    " - " + value.quantidade + "</td>");

            });
        }
    });

});


$(".deletarId").click(function () {

    var id = $(this).attr('id');

    console.log(id);
    $.ajax({
        type: "Get",
        url: "/Receita/BuscarPorId",
        data: {
            'id': id
        },
        success: function (data) {

            $('#modalExcluir').modal('show');
            $('#hdIdExcluir').val(data.id);
            $('#txtTitulo2').val(data.titulo);
            console.log(data)
        }
    });

});


$(".btn-close").click(function () {

    $('#modalDetalhes').modal('hide');
});



