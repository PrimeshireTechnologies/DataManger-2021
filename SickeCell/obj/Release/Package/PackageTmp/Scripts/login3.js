(function () {

    var PasswordToggler = function (element, field) {
        this.element = element;
        this.field = field;

        this.toggle();
    };

    PasswordToggler.prototype = {
        toggle: function () {
            var self = this;
            if (self.element !== null) {
                self.element.addEventListener("change", function () {
                    if (self.element.checked) {
                        self.field.setAttribute("type", "text");
                    } else {
                        self.field.setAttribute("type", "password");
                    }
                }, false);
            }            
        }
    };       

    document.addEventListener("DOMContentLoaded", function () {
        var checkbox = document.querySelector("#show-hide4"),
            newpassword = document.querySelector("#newpassword"),
            form = document.querySelector("#loginreset");

        //form.addEventListener("submit", function (e) {
        //    e.preventDefault();
        //}, false);

        var toggler = new PasswordToggler(checkbox, newpassword);
    });

    document.addEventListener("DOMContentLoaded", function () {
        var checkbox = document.querySelector("#show-hide5"),
            newpassword = document.querySelector("#confirmpassword"),
            form = document.querySelector("#loginreset");

        //form.addEventListener("submit", function (e) {
        //    e.preventDefault();
        //}, false);

        var toggler = new PasswordToggler(checkbox, confirmpassword);
    });

})();