(function () {
    "use strict";

    var serviceId = "scaTreasureCalculatorDataService";
    angular.module("app").service(serviceId, ["$http", treasureCalculatorDataService]);

    function treasureCalculatorDataService($http) {
        var urlBase = "http://pirate.azurewebsites.net/api";

        this.calcTreasure = function (numberOfPirates) {
            return $http.get(urlBase + "/Pirate/" + numberOfPirates);
        };
    }
})();
