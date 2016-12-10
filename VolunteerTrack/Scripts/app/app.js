var app = angular.module("Tracker", []);

app.controller("ActivitiesCtrl")


app.controller('ActivitiesCtrl', function ($scope, $http) {
    $scope.getActivities = function () {
        $http({
            url: '/api/VolunteerActivity/',
            method: "GET"
        })
        .then(function (result) {
            $scope.VolunteerActivity = angular.copy(result.data);

        }, function (error) {
            console.log(error);
        });
    }
    getActivities();
});