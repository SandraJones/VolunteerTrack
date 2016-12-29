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
        console.log("editFunction kicked off by EditController");
        $location.path("/EditActivityPage/" + ActivityId)
    }
    $scope.RemoveActivity = function (ActivityId) {
        console.log("Remove function kicked off in EditController");
        $http({
            url: '/api/Activities/' + ActivityId,
            method: "Delete"
        })
        .then(function (result) {
            console.log(result);
        }, function (error) {

        });
    }
});
