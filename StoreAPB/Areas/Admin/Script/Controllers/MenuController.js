var getMenu = function () {
        $.ajax({
            url: '/api/product',
            type: 'get',
            dataType: 'json'
        })
           .success(successMenu)
           .error(error);
    };

var successMenu = function (data) {
        menu.electricalType.push.apply(menu.electricalType, data.electrical);
        menu.meatType.push.apply(menu.meatType, data.meat);
    };

var specialElectricalLink = function (data) {
    // alert(data);
    products.activeView("product");
    products.error("");
    $.ajax({
        url: 'nonrest/productnrest/electricalspecial' ,
        type: 'get',
        dataType: 'json'
    })
     .success(successElectricalSpecial)
     .error(error);
};

var successElectricalSpecial = function (data) {
    products.meat.removeAll();
    products.electrical.removeAll();
    products.electrical.push.apply(products.electrical, data);
};

var specialMeatLink = function (data) {
    // alert(data);
    products.activeView("product");
    products.error("");
    $.ajax({
        url: 'nonrest/productnrest/meatspecial' ,
        type: 'get',
        dataType: 'json'
    })
     .success(successMeatSpecial)
     .error(error);
};

var successMeatSpecial = function (data) {
    products.electrical.removeAll();
    products.meat.removeAll();
    products.meat.push.apply(products.meat, data);
};

var electricalLink = function (data) {
    //alert(data);
    products.activeView("product");
    products.error("");
    $.ajax({
        url: 'nonrest/productnrest/electricaltype/' + data,
        type: 'get',
        dataType: 'json'
    })
        .success(successLinkElectrical)
        .error(error);
};

var successLinkElectrical = function (data) {   
    products.meat.removeAll();
    products.electrical.removeAll();
    products.electrical.push.apply(products.electrical, data);
};

var meatLink = function (data) {
    //alert(data);
    products.activeView("product");
    products.error("");
    $.ajax({
        url: 'nonrest/productnrest/meattype/'+data,
        type: 'get',
        dataType: 'json'
    })
          .success(successLinkMeat)
          .error(error);
};

var successLinkMeat = function (data) {
    products.electrical.removeAll();
    products.meat.removeAll();
    products.meat.push.apply(products.meat, data);
};

var error = function (data) {
    products.error(data.status + " " + data.statusText);
};


$(document).ready(function () {       
    ko.applyBindings();
    getMenu();
    getData();
    getCart();
})