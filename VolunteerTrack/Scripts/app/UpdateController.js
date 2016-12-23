"use strict";
app.controller('UpdateController', function ($scope, $routeParams, $location, $http) {
    //research ng-Route to see if it needs to be in fn above
   
    $http({
        url: '/api/Activities/'+$routeParams.activityId,
        method: "GET"
    })
    .then(function (response) {
        $scope.Activity = response.data;
    }, function (error) {
        console.log(error);
    });

    $scope.UpdateActivity = function () {
        $http({
            url: '/api/Activities/4',
            method: "PUT",
            data: $scope.Activity
        })
        .then(function (result) {
            console.log(result);
            //call toast msg
            
            $scope.Activity = {};
        }, function (error) {
            //poss call an error toast msg
            console.log(error);
        });
    };

    //$scope.SaveActivity();

});