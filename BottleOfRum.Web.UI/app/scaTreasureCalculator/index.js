
(function() {
    "use strict";

    var controllerId = "scaTreasureCalculatorIndexCtrl";
    angular.module("app").controller(controllerId, ["common", "scaTreasureCalculatorDataService", scaTreasureCalculatorIndexCtrl]);

    function scaTreasureCalculatorIndexCtrl(common, treasureCalculatorDataService) {

        var vm = this;
        vm.treasureCount = 0;
        vm.numberOfPirates = "";
        
        vm.calcTreasure = function(numberOfPirates) {
            return calculateTreasure(numberOfPirates);
        };

        function calculateTreasure(numberOfPirates) {
            common.spinnerShow();
            return treasureCalculatorDataService.calcTreasure(numberOfPirates).then(function (results) {
                common.spinnerHide();
                return vm.treasureCount = results.data;
            },
            function (results) {
                alert(results.data.Message);
                common.spinnerHide();
            });
        }
    }
})();