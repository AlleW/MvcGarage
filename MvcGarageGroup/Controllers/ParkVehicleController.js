var myApp = angular.module('AngularGarageGroup', []);

myApp.controller('myController', ['$http', function ($http) {
    var vm = this;
    vm.companies = [];
    $http.get("/ParkVehicle/AngularRead").success(function (result) {

        vm.companies = result;
        console.log(vm.companies);
    }).error(function (error) {
        console.log(error);
    });
}]);
