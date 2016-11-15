var getData = function () {
    $.ajax({
        url: '/nonrest/productnrest/HomePage',
        type: 'get',
        dataType: 'json'
    })
       .success(successData)
       .error(error);
};

var successData = function (data) {
    products.electrical.push.apply(products.electrical, data.electrical);
    products.meat.push.apply(products.meat, data.meat);
};

var search = function () {
    products.activeView("search");
    products.error("");
    var data = $('#movil').val();
    if (data=='') {
        products.error("Please enter a value for your search");
    } else {
        $.ajax({
            url: '/nonrest/productnrest/search/' + data,
            type: 'get',
            dataType: 'json'
        })
      .success(successSearch)
      .error(error);
    }   
};

var successSearch = function (data) {
    products.meat.removeAll();
    products.electrical.removeAll();
    products.search.removeAll();
    products.search.push.apply(products.search, data);
};

var electricalDetails = function (electrical) {
    //alert(product);
    products.selectedelectrical.name(electrical.name_p);
    products.selectedelectrical.brand(electrical.brand);
    products.selectedelectrical.category(electrical.category.name);
    products.selectedelectrical.type(electrical.type);
    products.selectedelectrical.description(electrical.description);
    $('#electricalModal').modal('show');
};

var meatDetails = function (meat) {
    //alert(product);
    products.selectedmeat.name(meat.name_p);
    products.selectedmeat.provider(meat.provider);
    products.selectedmeat.category(meat.category.name);
    products.selectedmeat.type(meat.type);
    products.selectedmeat.description(meat.description);
    $('#meatModal').modal('show');
};

