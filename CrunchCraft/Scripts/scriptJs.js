$(document).ready(function () {
    $(".editar-producto").on("click", function () {
        var id = $(this).data("id");
        var product = $(this).data("product");
        //var qty = $(this).data("qty");
        var publicPrice = $(this).data("public-price");

        //console.log("ID: " + id);
        //console.log("Product: " + product);
        //console.log("Qty: " + qty);
        //console.log("Public Price: " + publicPrice);
        $("#exampleModal input[name='Product']").val(product);
        //$("#exampleModal input[name='Qty']").val(qty);
        $("#exampleModal input[name='PublicPrice']").val(publicPrice);

        $("#exampleModal").modal("show");
    });
});
