function updateCartProducts() {
    var cartProducts;
    var existingCookieData = $.cookie('CartProducts');
    debugger;
    if (existingCookieData != undefined && existingCookieData != "" && existingCookieData != null) {
        cartProducts = existingCookieData.split('-');
    } else {
        cartProducts = [];
    }
    $("#cartProductsCount").html(cartProducts.length);
};
$(function () {
    updateCartProducts();
}); (jQuery);
