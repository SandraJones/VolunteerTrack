"use strict";
app.controller('UpdateController', function ($scope, $routeParams, $location, $http) {
    //This controller gets the specific Activity that user wants to edit AND
    console.log("UpdateController get activity that user wants to edit");
    $http({
        url: '/api/Activities/'+$routeParams.activityId,
        method: "GET"
    })
    .then(function (response) {
        $scope.Activity = response.data;
    }, function (error) {
    });

    //this part of the controller handles the Submit button click to save user changes.
    $scope.UpdateActivity = function () {
        $http({
            url: '/api/Activities/4',
            method: "PUT",
            data: $scope.Activity
        })
        .then(function (result) {
            //call toast msg
            $scope.Activity = {};
        }, function (error) {
            //poss call an error toast msg
        });
    };
});