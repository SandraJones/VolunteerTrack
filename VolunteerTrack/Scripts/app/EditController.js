angular.module("Tracker");

app.controller('EditController', function ($scope, $location, $http) {
    //This controller acts upon the click of the nav tab, "MyActivities" to return a list of current user's activities.

    $http({
        url: '/api/Activities/',
        method: "GET"
    })
       .then(function (result) {
           $scope.activities = result.data;
       }, function (error) {
       });

    $scope.EditActivity = function (ActivityId) {

        $location.path("/EditActivityPage/" + ActivityId)
    }
});
