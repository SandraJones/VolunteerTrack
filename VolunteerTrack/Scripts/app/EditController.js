angular.module("Tracker");
//rename to activites controller
app.controller('EditController', function ($scope, $location, $http) {
    //add a function here for updateActivity() when I add it in, it breaks the listing of the table to only show the titles

    $http({
        url: '/api/Activities/',
        method: "GET"
    })
       .then(function (result) {
           $scope.activities = result.data;
       }, function (error) {
           console.log(error);
       });

    $scope.EditActivity = function (ActivityId) {
        $location.path("/EditActivityPage/" + ActivityId)
    }

    $scope.UpdateActivity = function (value) {
        
        $http({
            url: '/api/Activities/',
            method: "PUT"
        })
        .then(function (result) {
            $scope.activities = result.data;
        }, function (error) {
            console.log(error);
        });
    }
});



//filter datetime in html file
//added line 9 with data: $scope.Activity