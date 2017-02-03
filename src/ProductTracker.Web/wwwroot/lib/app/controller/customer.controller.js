(function () {
    'use strict';

    angular.module('app').controller('customerController', customerController);

    function customerController(customerService, $interval) {
        var vm = this;

        vm.loadingBar = false;
        vm.customers = [];
        vm.displayCustomers = [];
        
        vm.getCustomers = function getCustomerFromService(tableState) {
            vm.loadingBar = true;
            var pagination = tableState.pagination;

            var start = pagination.start || 0;     // This is NOT the page number, but the index of item in the list that you want to use to display the table.
            var number = 2;  // Number of entries showed per page.
            tableState.pagination.numberOfPages = 2;//set the number of pages so the pagination can update

            console.log(tableState);
            customerService.getAllCustomer().then(function (data) {
                vm.customers = data;
                vm.displayCustomers = vm.customers;
                vm.loadingBar = false;
            });
        }
    }


})();