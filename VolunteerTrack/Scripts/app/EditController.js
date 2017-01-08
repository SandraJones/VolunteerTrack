angular.module("Tracker");

app.controller('EditController', ['$scope', '$location', '$http', function ($scope, $location, $http) {
    //This controller acts upon the click of the nav tab, "MyActivities" to return a list of current user's activities.
    console.log("This EditController has kicked off!");
    $http({
        url: '/api/Activities/',
        method: "GET"
    })
       .then(function (result) {
           console.log(result, "result of GET request inside the EditController");
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
}]);
