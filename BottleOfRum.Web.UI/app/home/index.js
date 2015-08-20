
(function() {
    "use strict";

    var controllerId = "homeIndexCtrl";
    angular.module("app").controller(controllerId, [homeIndexCtrl]);

    function homeIndexCtrl() {

        var vm = this;
        vm.myInterval = 4000;
        vm.noWrapSlides = false;
        vm.slides = [
            {
                image: "/Content/images/pirate1.jpg"
            },
            {
                image: "/Content/images/pirate2.jpg"
            },
            {
                image: "/Content/images/pirate3.jpg"
            },
            {
                image: "/Content/images/pirate4.jpg"
            },
            {
                image: "/Content/images/pirate5.jpg"
            }
        ];


    }
})();