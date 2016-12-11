var app = angular.module("Tracker", []);

app.controller('ActivitiesCtrl', function ($scope, $http) {
    $scope.saveActivity = function () {
        $http({
            url: '/api/Activities/',
            method: "POST",
            data: $scope.Activity
        })
        .then(function (result) {
         //  $scope.Activity = angular.copy(result.data);

        }, function (error) {
            console.log(error);
        });
       // AddActivity();
    }
});