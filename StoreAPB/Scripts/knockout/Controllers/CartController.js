var addToCart = function (product) {
    products.error("");
    var found = false;
    var cart_ = cart.products();
    for (var i = 0; i < cart_.length; i++) {
        if (cart_[i].product.productid == product.productid) {
            found = true;
            count = cart_[i].count() + 1;
            //cart.products.splice(i, 1); //This works too but for me it is not as descriptive as the other one below
            cart.products.remove(cart_[i]);
            cart.products.push({
                count: ko.observable(count).extend({ subTotal: product.price - product.reduce }),
                productid:product.productid,
                product: product
            });
            break;
        }
    }

    if (!found) {
        cart.products.push({
            count: ko.observable(1).extend({ subTotal: product.price - product.reduce }),
            productid: product.productid,
            product: product
        });
    }

    var data = {
        cartid:cart.user(),
        count: 1,
        productid:product.productid
    };
  
    $.ajax({
        url: '/nonrest/productnrest/addtocart/',
        type: 'get',
        dataType: 'json',
        data: data
    })
        .success(successAdd)
        .error(error);
};

var removeFromCart = function (product) {
    products.error("");
    cart.products.remove(product);
   
    var data = {
        cartid:cart.user(),
        productid: product.product.productid
    };

    $.ajax({
        url: '/nonrest/productnrest/delproduct/',
        type: 'get',
        dataType: 'json',
        data:data
    })
        .success(successRemove)
        .error(error);
};

var successRemove = function (data) {
    
}

var successAdd = function (data) {
    //alert(data);
}

var getCart = function () {  
    var data = {
        id: cart.user()      
    };

    $.ajax({
        url: '/nonrest/productnrest/getcart/',
        type: 'get',
        dataType: 'json',
        data: data
    })
        .success(successGet)
        .error(error);
};

var successGet = function (data) {    
    var list_id = ko.observableArray([]);

    for (var i = 0; i < data.length; i++) {
        var productid = data[i].product.productid;        

        var is_there = ko.utils.arrayFirst(list_id(), function (item) {
            return item==productid;
        });
        list_id.push(productid);

        if (is_there==null) {
            var array = ko.utils.arrayFilter(data, function (item) {
                return item.product.productid == productid;
            });


            var count = 0;
            for (var j = 0; j < array.length; j++) {
                count += array[j].count;
            }

            cart.products.push({
                count: ko.observable(count).extend({ subTotal: data[i].product.price - data[i].product.reduce }),
                productid: data[i].product.productid,
                product: data[i].product
            });
        }          
    }

    menu.load(false);
}

var formData = function (form) {
    if (!$(form).valid())        
        return false;
    //form[0].value;  //This has the @Html.AntiForgeryToken()    

    cart.products.remove(function (item) {
        return item.Count == 0;
    });  

    var data = {
        delivery_Address: form[1].value,
        phone_number: form[2].value,
        customer: cart.user(),
        Lines: cart.products()
    };

    $.ajax({
        url: '/nonrest/productnrest/cartorder/',
        type: 'post',
        dataType: 'json',
        data: data
    })
    .success(successOrder)
    .error(error);
};

var successOrder = function (data) {
    if (data==undefined) {
        cart.products.removeAll();
        products.activeView("product");
    }
    else {
        window.location.href = "/Account/Login";       
    }
}