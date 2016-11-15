var cart = {
    products: ko.observableArray([]),
    user: ko.observable()    
};

var cartImportant = {
    total: cart.products.total(),
    amount: cart.products.items()
};