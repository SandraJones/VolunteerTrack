var app = angular.module("Tracker", []);

app.controller('ActivitiesCtrl', function ($scope, $http) {
    $scope.saveActivity = function () {
        $http({
            url: '/api/Activities/',
            method: "POST",
            data: $scope.Activity
        })
        .then(function (result) {
            //call toast msg
            //  $scope.Activity = angular.copy(result.data);
            $scope.Activity =  {};
        }, function (error) {
            //poss call an error toast msg
            console.log(error);
        });
    }
    $scope.editActivity = function () {
        $http({
            url: 'api/Activities/',
            method: "GET",
            data: $scope.editActivity
        })
        .then(function (result) {
        }, function (error) {
            console.log(error);
        });
    }
});