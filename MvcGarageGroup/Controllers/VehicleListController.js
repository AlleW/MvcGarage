var myApp = angular.module('AngularGarageGroup', []);

myApp.controller('VehicleListController', ['$http', '$scope', '$filter', function ($http, $scope, $filter) {


    $scope.vehicles = [];
    $http.get("/VehicleList/AngularRead").success(function (result) {

        $scope.vehicles = result;
        console.log($scope.vehicles);

    }).error(function (error) {
        console.log(error);
    });

    $scope.SearchText = "Alle";


    $scope.onButtonClick = function (SearchText) {
        var found = $filter('filter')($scope.vehicles.Vehicle, { LicencePlate: SearchText }, true);
        console.log(found);
        if (found.length) {
            $scope.vehicles = JSON.stringify(found[0]);
        } else {
            $scope.vehicles = 'Not found';
        }
    }

}]);
