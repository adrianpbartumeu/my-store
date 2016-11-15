var viewCart = function () {
    products.activeView("viewcart");
}

var cssFunction1 = function () {
    return ko.pureComputed(function () {
        if (cartview.step1())
            return "active";
        return "disabled";
    });
};

//Usado pa evitar el evento onclick de los link
var clickHref = function () {

};

var nextStep = function () {
    cartview.step2(true);
    cartview.step1(false);
};

//Cuando el usuario da click en el boton Carro de Compra
var backToCart = function () {
    cartview.step2(false);
    cartview.step1(true);
};
//Activa o no el <li> Carro de Compra usando la clase css active o disabled
var cssFunction1 = function () {
    return ko.pureComputed(function () {
        if (cartview.step1())
            return "active";
        return "disabled";
    });
};
//Activa o no el <li> Tus Datos usando la clase css active o disabled
var cssFunction2 = function () {
    return ko.pureComputed(function () {
        if (cartview.step2())
            return "active";
        return "disabled";
    });
};

$(document).on("keypress", ".justinteger", function (event, data) {
    var keyCode = (event.which ? event.which : event.keyCode);
    // Allow: backspace, tab, escape, enter 
    if ($.inArray(keyCode, [8, 9, 27, 13]) !== -1 ||
        // Allow: Ctrl+A
     (keyCode == 65 && e.ctrlKey === true) ||
        // Allow: Ctrl+C
     (keyCode == 67 && e.ctrlKey === true) ||
        // Allow: Ctrl+X
     (keyCode == 88 && e.ctrlKey === true) ||
        // Allow: home, end, left, right
     (keyCode >= 35 && keyCode <= 39)) {
        // let it happen, don't do anything
        return true;
    }
    // Ensure that it is a number and stop the keypress  if ((e.shiftKey || (e.charCode < 48 || e.charCode > 57)) && (e.charCode < 96 || e.charCode > 105))
    if (keyCode < 48 || keyCode > 57) {
        return false;
    }
    else {
        return true;
    }
});