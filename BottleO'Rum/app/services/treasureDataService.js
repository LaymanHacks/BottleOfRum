(function () {
    "use strict";

    var serviceId = "treasureCalculatorDataService";
    angular.module("app").service(serviceId, ["$http", treasureCalculatorDataService]);

    function treasureCalculatorDataService($http) {
        var urlBase = "/api/treasure";

        this.calcTreasure = function (numberOfPirates) {
            return $http.get(urlBase + "/calculate/" + numberOfPirates);
        };
    }
})();
