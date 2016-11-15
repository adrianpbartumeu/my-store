var getMeat = function () {
    //loadModal('#myModal');
    product.load(true);
    var data = {
        page: paging.page(),
        pageSize: paging.pageSizes()
    };

    $.ajax({
        url: '/nonrest/products/pagingmeat/',
        type: 'get',
        dataType: 'json',
        data: data
    })
        .success(successGet)
        .error(error);
};

var successGet = function (data) {
    product.meats.removeAll();
    product.meats.push.apply(product.meats, data.results);
    paging.total(data.total)
    //closeModal('#myModal');
    product.load(false);
}

//It's used to get the categoryid
var categoryid = ko.computed(function () {
    try {
        return product.selectedCategory().categoryid;
    } catch (e) {
        return "";
    }    
});

var editClick = function (data) {
    loadModal('#editMeat');
    product.error(false);
    product.file(false);
    loadData(data);
    product.visible(false);
    loadingSelectData(successLoadTypes);
}

var successLoadTypes = function (data) {
    product.type.removeAll();
    product.type.push.apply(product.type, data.type);
    product.selectedType(product.selectedmeat.type());//This is the key
    product.category.removeAll();
    product.category.push.apply(product.category, data.results);

    var matchcategory = ko.utils.arrayFirst(product.category(), function (item) {
        return product.selectedmeat.categoryid() === item.categoryid;
    });  
    product.selectedCategory(matchcategory);    
}

$('#myform')
  .submit(function (e) {
      var myform = $('#myform');
      if (!myform.valid())
          return false;

      if (myform[0][12].files.length != 0) {
          var name = myform[0][12].files[0].name;
          if (myform[0][12].files[0].name.substr(name.length - 4, name.length) == ".jpg") {
              product.selectedmeat.image(myform[0][12].files[0].name);
          }         
      }      
      var data = new FormData(this);
      if (product.visible()) {
          if (myform[0][12].files.length == 0) {
              product.file(true);//If not select a .jpg file
              e.preventDefault();
          }
          else {
              formSubmit(data, e, successCreate);
          }         
      }
      else {
          formSubmit(data, e, successEdit);
      }
  });

var formSubmit = function (data, e, success) {
    $.ajax({
        url: product.visible() ? '/admin/principal/create/' : '/admin/principal/edit/',
        type: product.visible() ? 'post' : 'put',
        data: data,
        processData: false,
        contentType: false
    }).success(success);
    e.preventDefault();
};

var successEdit = function (data) {
    var match = ko.utils.arrayFirst(product.meats(), function (item) {
        return product.selectedmeat.productid() === item.productid;
    });   
    product.meats.remove(match);   

    var newmeat = {
        productid: product.selectedmeat.productid(),
        provider:product.selectedmeat.provider(),
        type: product.selectedType(),
        name_p:product.selectedmeat.name(),
        price: product.selectedmeat.price(),
        reduce:product.selectedmeat.reduce(),
        amount:product.selectedmeat.amount(),
        categoryid: categoryid(),
        category:'',
        image:product.selectedmeat.image()
    };

    var matchcategory = ko.utils.arrayFirst(product.category(), function (item) {
        return product.selectedmeat.categoryid() === item.categoryid;
    });

    newmeat.category = matchcategory;

    product.meats.push(newmeat);
    product.meats.sort(
        function (left, right) { return left.productid > right.productid ? 1 : -1 }
        );
    closeModal('#editMeat');
};

var successCreate = function (data) {
    if (data=="Invalid") {
        product.error(true);
    }
    else {
        closeModal('#editMeat');
    }    
};

var detailClick = function (data) {
    loadModal('#deMeat');
    loadData(data);
    product.button("Ok");
}

var deleteClick = function (data) {
    loadModal('#deMeat');
    loadData(data);
    product.button("Delete");
}

var Action = function () {
    if (product.button()=="Ok") {
        closeModal('#deMeat');
    }
    else {
        var data = {
            productid:product.selectedmeat.productid(),       
            type:product.selectedmeat.type(),     
            image:product.selectedmeat.image(),
        };
        deleteMeat(data);
    }
}

var deleteMeat = function (data) {
    $.ajax({
        url: '/admin/principal/delete/',
        type: 'delete',
        data: data
    })
        .success(successDelete)
        .error(error);
};

var successDelete = function () {
    var match = ko.utils.arrayFirst(product.meats(), function (item) {
        return product.selectedmeat.productid() === item.productid;
    });
    product.meats.remove(match);
    closeModal('#deMeat');
};

var createClick = function () {
    loadModal('#editMeat');
    product.visible(true);
    product.error(false);
    product.file(false);
    loadingSelectData(successTypes);
}

var successTypes = function (data) {
    product.type.removeAll();
    product.type.push.apply(product.type, data.type);   
    product.category.removeAll();
    product.category.push.apply(product.category, data.results);  
}

var loadData = function (data) {
    product.image('');
    product.selectedmeat.productid(data.productid);
    product.selectedmeat.provider(data.provider);
    product.selectedmeat.type(data.type);
    product.selectedmeat.name(data.name_p);
    product.selectedmeat.price(data.price);
    product.selectedmeat.reduce(data.reduce);
    product.selectedmeat.amount(data.amount);
    product.selectedmeat.categoryid(data.categoryid);
    product.selectedmeat.category(data.category.name);
    product.selectedmeat.image(data.image);
};

var loadingSelectData = function (success) {
    $.ajax({
        url: '/nonrest/products/meatModalData/',
        type: 'get',
        dataType: 'json'
    })
          .success(success)
          .error(error);
};

var loadModal = function (idmodal) {
    $(idmodal).modal('show');
}

var closeModal = function (idmodal) {
    $(idmodal).modal('hide');
}

var formDataa = function (form) {
    var myform=$(form);
    if (!myform.valid())
        return false;

    alert("OK");  
};

var error = function (data) {
    products.error(data.status + " " + data.statusText);
};

$(document).ready(function () {   
    ko.applyBindings();
    getMeat();
})

