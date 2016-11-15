var products = {
    error:ko.observable()
};

var error = function (data) {
    products.error(data.status + " " + data.statusText);
};

$(document).ready(function () {    
    ko.applyBindings();
    getCart();
})