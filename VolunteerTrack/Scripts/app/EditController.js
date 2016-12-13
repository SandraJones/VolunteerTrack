angular.module("Tracker");

app.controller = ('EditController', function ($scope, $http) {
    $scope.editActivity = function () {
        $http({
            url: '/api/Activities/',
            method: "GET",
            data: $scope.Activities
        })
        .then(function (result) {
        }, function (error) {
            console.log(error);
        });
    };
});