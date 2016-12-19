angular.module("Tracker");

app.controller('EditController', function ($scope, $http) {
    $http({
        url: '/api/Activities/',
        method: "GET"
    })
   .then(function (result) {
       $scope.activities = result.data;
       console.log(result);
   }, function (error) {
       console.log(error);
   });
   $scope.editActivity = function () {
        $http({
            url: '/api/Activities/',
            method: "POST",
            data: $scope.Activity
        })
        .then(function (result) {
            //call toast msg
            //  $scope.Activity = angular.copy(result.data);
            $scope.Activity = {};
        }, function (error) {
            //poss call an error toast msg
            console.log(error);
        });
    }
});
//just added lines 14 through line28 to try to edit an activity
//filter datetime in html file