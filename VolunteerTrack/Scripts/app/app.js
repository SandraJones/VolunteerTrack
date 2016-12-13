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
});