var app = angular.module("Tracker", ["ngRoute"]);

$("#slideshow > div:gt(0)").hide();

setInterval(function () {
    $('#slideshow > div:first')
      .fadeOut(1000)
      .next()
      .fadeIn(1000)
      .end()
      .appendTo('#slideshow');
}, 20000);


app.config(function ($routeProvider) {
    $routeProvider.
        when('/EditActivityPage/:activityId', {
            templateUrl: '/Partials/UpdateView.html',
            controller: 'UpdateController'
        })
        .when('/', {
            templateUrl: '/partials/ListOfActivities.html',
            controller: 'EditController'
        } );
});


app.controller('ActivitiesController', function ($scope, $http) {
    $scope.saveActivity = function () {
        $http({
            url: '/api/Activities/',
            method: "POST",
            data: $scope.Activity
        })
        .then(function (result) {
            //call toast msg
            //  $scope.Activity = angular.copy(result.data);
            $scope.Activity =  {};
        }, function (error) {
            //poss call an error toast msg
            console.log(error);
        });
    }
});
