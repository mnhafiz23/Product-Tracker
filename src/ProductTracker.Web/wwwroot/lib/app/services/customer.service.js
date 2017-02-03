(function () {
    'use strict';

    var service = angular.module('app');
    service.factory('customerService', customerService);

    function customerService($http) {

        function getAllCustomer() {
          
           return $http.get("/api/Customer").then(function (result) {               
                 return result.data;
             });
           
        };

        return {
            getAllCustomer: getAllCustomer
        };
    };

})();