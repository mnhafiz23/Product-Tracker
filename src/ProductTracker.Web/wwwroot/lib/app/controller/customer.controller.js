(function () {
    'use strict';

    angular.module('app').controller('customer', customer);

    function customer($http) {
        var vm = this;

        vm.clients = [];

        $http.get("/api/Customer").then(function (result) {
            vm.clients = result.data;
        },
        function (result) {

        })
    }


})();