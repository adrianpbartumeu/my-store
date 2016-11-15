var products = {
    electrical: ko.observableArray([]),
    meat: ko.observableArray([]),
    search: ko.observableArray([]),
    activeView: ko.observable("product"),
    error: ko.observable(),
    selectedelectrical: {
        name: ko.observable(),
        brand: ko.observable(),
        category: ko.observable(),
        type: ko.observable(),
        description: ko.observable()
    },

    selectedmeat: {
            name: ko.observable(),
            provider: ko.observable(),
            category: ko.observable(),
            type: ko.observable(),
            description: ko.observable()
        }
};