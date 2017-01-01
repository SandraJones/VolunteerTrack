var app = angular.module("Tracker", ["ngRoute"]);

$("#slideshow > div:gt(0)").hide();

setInterval(function () {
    $('#slideshow > div:first')
      .fadeOut(1000)
      .next()
      .fadeIn(1000)
      .end()
      .appendTo('#slideshow');
}, 15000);


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
            $scope.Activity = {};
        }, function (error) {
            //poss call an error toast msg
            console.log(error);
        });
    };
    //display YTD calculation for NumberHours
    $scope.calculateYTDNumberHours = function () {
        $http({
            url: '/api/Activities/',
            method: "GET"
        })
        .then(function (result) {
            console.log(result);
            var currentYearActivities = $scope.filter(currentUserActivities.date | 2016);
            $scope.currentYearActivities.NumberHours;

        }, function (error) {
            console.log(error);
        });
    };
    //display YTD calculation for Mileage
    $scope.calculateYTDMileage = function () {
        $http({
            url: '/api/Activities/',
            method: "GET"
        })
        .then(function (result) {
            $scope.activities = result.data;
            $scope.activities.data.TotalYTD();

        }, function (error) {
            console.log(error);
        });
    };
    //display YTD calculation for DollarsContributed
    $scope.calculateYTDDollarsContributed = function () {
        $http({
            url: '/api/Activities/',
            method: "GET"
        })
        .then(function (result) {
            $scope.activities = result.data;
            $scope.activities.data.TotalYTD();

        }, function (error) {
            console.log(error);
        });
    };








});//this line is the closing of the app.controller statement;