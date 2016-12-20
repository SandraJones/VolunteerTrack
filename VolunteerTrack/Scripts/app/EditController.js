angular.module("Tracker");

app.controller('EditController', function ($scope, $http) {
    //add a function here for updateActivity()
    $scope.UpdateActivity = function () {
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

    };
});
//filter datetime in html file