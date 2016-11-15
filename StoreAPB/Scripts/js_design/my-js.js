$(document).ready(function () { 
    function my_functions() {
        if (window.innerWidth <= 768) {
            mobile();
        }
        else {          
            over_leave();
        }
    }

    function mobile() {
        $(".dropdown").bind("click", function () {       
            $(this).siblings("li").children("ul").removeClass("mobile");
           
            $(this).children("ul").toggleClass("mobile");

            $(".dropdown").removeClass("active");
            $(this).toggleClass("active");
        })

        $(".mobile-menu").slideDown("slow");

        $(".clean-menu").children("li").removeClass("col-sm-10 col-xs-10 col-sm-2 col-xs-2");       

        $(".show-cart img").bind("click", function () {
            $(".cart").toggleClass("cart-show");
        })
    }  

    function over_leave() {
        $(".dropdown-t").bind("mouseover", function () {
            $(this).siblings("ul").fadeIn("slow");
        }).bind("mouseleave", function () {
            $(this).siblings("ul").removeClass("mouse-over");
            $(this).siblings("ul").stop().fadeOut(250)
        })

        $(".menu").bind("mouseover", function () {
            $(this).addClass("mouse-over");
            $(this).stop().fadeIn(250);
        }).bind("mouseleave", function () {
            $(this).removeClass("mouse-over");
            $(this).stop().fadeOut(250);
        })
          
        $(".show-cart img").bind("mouseover", function () {
            $(this).parent().siblings(".cart").toggleClass("shown-cart");
            $(this).parent().siblings(".cart").removeClass("cart");
        })        

        $(".show-cart div").bind("mouseleave", function () {
            $(this).parent().children(".shown-cart").toggleClass("cart");
            $(this).parent().children(".shown-cart").removeClass("shown-cart");
        })

        $(document).on("mouseover", ".enable-mask", function (data) {
            try {
                if ($(event.target).siblings(".mask").context == undefined) {
                    $(arguments[0].target).siblings(".mask").stop().fadeIn(250);//For IE
                }
                else {
                    $(event.target).siblings(".mask").stop().fadeIn(250); //For Chrome
                }
            } catch (e) {
                $(arguments[0].target).siblings(".mask").stop().fadeIn(250);//For Firefox
            }
        });        

        $(document).on("mouseover", ".products", function (data) {
            try {
                if ($(event.target).children(".mask").context == undefined) {
                    $(arguments[0].target).children(".mask").stop().fadeOut(250);//For IE
                }
                else {
                    $(event.target).children(".mask").stop().fadeOut(250); //For Chrome
                }
            } catch (e) {
                $(arguments[0].target).children(".mask").stop().fadeOut(250);//For Firefox
            }
        });       
    }
    my_functions(); 
});