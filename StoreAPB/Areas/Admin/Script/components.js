ko.bindingHandlers.appendToSRC = { 
    update: function (element, valueAccessor) {
        var currentHref = $(element).attr('src');
        var valor = valueAccessor().indexOf("undefined")!=-1 ? '' : valueAccessor();
        if (valor != "") {
            if (product.image() == "" || product.image()) {
                var index=currentHref.indexOf("//");
                if (index == -1) {
                    product.image(currentHref);
                    $(element).attr('src', currentHref + '/' + valor);
                }
                else {
                    currentHref = currentHref.substring(0, index+1);                   
                    $(element).attr('src', currentHref + '/' + valor);
                }
            }           
        }          
    }
};

//ko.bindingHandlers.appendToSRC = {
//    init: function (element, valueAccessor) {
//        var currentHref = $(element).attr('src');
//        var valor = valueAccessor();
//        $(element).attr('src', currentHref + '/' + valor);
//    }
//};

ko.bindingHandlers.isElectrial = {
    update: function (element, valueAccessor) {
        var value = ko.utils.unwrapObservable(valueAccessor());
        ko.bindingHandlers.visible.update(element, function () {
            return (value == 'CD Recorder' || value == 'Mixer' || value == 'Radio' || value == 'Tape Recorder' || value == 'TV');
        });
    }
};
ko.bindingHandlers.isMeat = {
    update: function (element, valueAccessor) {
        var value = ko.utils.unwrapObservable(valueAccessor());
        ko.bindingHandlers.visible.update(element, function () {
            return (value == 'Beef' || value == 'Chicken' || value == 'Mutton' || value == 'Pork' || value == 'Veal');
        });
    }
};

ko.bindingHandlers.appendToSRCSearch = {
    init: function (element, valueAccessor) {
        var currentHref = $(element).attr('src');
        var valor = valueAccessor();
        var path = "";
        if (valor.description.search("From") == 0) {
            path = "Meat/" + valor.type + "/" + valor.image;
        }
        else {
            path = "Electrical/" + valor.type + "/" + valor.image;
        }
        $(element).attr('src', currentHref + '/' + path);
    }
};

ko.extenders.subTotal = function (target, multiplier) {
    target.subTotal = ko.observable();

    function calculateTotal(newValue) {
        target.subTotal((newValue * multiplier).toFixed(2));
    };

    calculateTotal(target());

    target.subscribe(calculateTotal);

    return target;
};

ko.observableArray.fn.total = function () {
    return ko.computed(function () {
        var runningTotal = 0;

        for (var i = 0; i < this().length; i++) {
            runningTotal += parseFloat(this()[i].count.subTotal());
        }

        return runningTotal.toFixed(2);
    }, this);
};

ko.observableArray.fn.items = function () {
    return ko.computed(function () {
        var runningItems = 0;

        for (var i = 0; i < this().length; i++) {
            runningItems += isNaN(parseFloat(this()[i].count())) ? 0 : parseFloat(this()[i].count());
        }

        return runningItems;
    }, this);
};
