"use strict";
app.controller('UpdateController', function ($scope, $http) {
    //research ng-Route to see if it needs to be in fn above

   
    

    $scope.UpdateActivity = function () {
        $http({
            url: '/api/Activities/',
            method: "PUT",
            data: $scope.Activity
        })
        .then(function (result) {
            console.log(result);
            //call toast msg
            //  $scope.Activity = angular.copy(result.data);
            $scope.Activity = {};
        }, function (error) {
            //poss call an error toast msg
            console.log(error);
        });
  };


});