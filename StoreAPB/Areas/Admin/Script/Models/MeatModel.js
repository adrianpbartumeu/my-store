var product = {    
    meats: ko.observableArray([]),
    type: ko.observableArray([]),
    category: ko.observableArray([]),    
    selectedType: ko.observable(),
    selectedCategory: ko.observable(),
    button: ko.observable(),
    visible: ko.observable(false),
    selectedmeat: {
            productid:ko.observable(),            
            provider: ko.observable(),
            type: ko.observable(),            
            name: ko.observable(),
            price: ko.observable(),
            reduce: ko.observable(),
            amount: ko.observable(),
            categoryid: ko.observable(),
            category: ko.observable(),
            image: ko.observable()
    },
    image: ko.observable(),
    error: ko.observable(false),
    file: ko.observable(false),
    load: ko.observable()
};

var paging = {
    page: ko.observable(1),
    total: ko.observable(),
    pageSizes: ko.observable(5),
    maxPages: ko.observable(5),
    directions: ko.observable(true),
    boundary: ko.observable(true),
    pagingText : {
        first: ko.observable('First'),
        last: ko.observable('Last'),
        back: ko.observable('&laquo;'),
        forward: ko.observable('&raquo;')
    }
};


