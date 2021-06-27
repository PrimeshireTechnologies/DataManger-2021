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
        var checkbox = document.querySelector("#show-hide"),
            pwd = document.querySelector("#pwd"),
            form = document.querySelector("#login");

        //form.addEventListener("submit", function (e) {
        //    e.preventDefault();
        //}, false);

        var toggler = new PasswordToggler(checkbox, pwd);
    });

    document.addEventListener("DOMContentLoaded", function () {
        var checkbox = document.querySelector("#show-hide2"),
            confirmpass = document.querySelector("#confirmpass"),
            form = document.querySelector("#login");

        //form.addEventListener("submit", function (e) {
        //    e.preventDefault();
        //}, false);

        var toggler = new PasswordToggler(checkbox, confirmpass);
    });

    document.addEventListener("DOMContentLoaded", function () {
        var checkbox = document.querySelector("#show-hide3"),
            schid = document.querySelector("#schid"),
            form = document.querySelector("#login");

        //form.addEventListener("submit", function (e) {
        //    e.preventDefault();
        //}, false);

        var toggler = new PasswordToggler(checkbox, schid);
    });
})();