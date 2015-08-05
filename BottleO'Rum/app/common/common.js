(function () {
    "use strict";

    var commonModule = angular.module("common", []);
    commonModule.provider("commonConfig", function () {
        this.config = {
        };

        this.$get = function () {
            return {
                config: this.config
            };
        };
    });

    commonModule.factory("common",
        ["$q", "$rootScope", "$timeout", "commonConfig",  common]);

    function common($q, $rootScope, $timeout, commonConfig) {
      var service = {
            // common angular dependencies
            $broadcast: $broadcast,
            $q: $q,
            $timeout: $timeout,
            // generic
            activateController: activateController,
            spinnerHide:spinnerHide,
            spinnerShow: spinnerShow
            
        };

        return service;

        function spinnerHide() { $("#ajaxLoader").hide(); }
        function spinnerShow() { $("#ajaxLoader").show(); }

        function activateController(promises, controllerId) {
            return $q.all(promises).then(function (eventArgs) {
                var data = { controllerId: controllerId };
                $broadcast(commonConfig.config.controllerActivateSuccessEvent, data);
            });
        }

        function $broadcast() {
            return $rootScope.$broadcast.apply($rootScope, arguments);
        }

      
    }
})();