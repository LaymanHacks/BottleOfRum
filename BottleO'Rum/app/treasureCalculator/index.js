
(function() {
    "use strict";

    var controllerId = "treasureCalculatorIndexCtrl";
    angular.module("app").controller(controllerId, ["common", "treasureCalculatorDataService", treasureCalculatorIndexCtrl]);

    function treasureCalculatorIndexCtrl(common, treasureCalculatorDataService) {

        var vm = this;
        vm.treasureCount = 0;
        vm.numberOfPirates = "";
        
        vm.calcTreasure = function (numberOfPirates) {
            vm.treasureCount = 0;
           return calculateTreasure(numberOfPirates);  
        };

        function calculateTreasure(numberOfPirates) {
            common.spinnerShow();
            return treasureCalculatorDataService.calcTreasure(numberOfPirates).then(function (results) {
                common.spinnerHide();
                return vm.treasureCount = results.data;
            },
            function (results) {
                alert(results.data.message);
                common.spinnerHide();
            });
        }
    }
})();