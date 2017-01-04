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
    $scope.calcVM = {};
    $scope.saveActivity = function () {
        $http({
            url: '/api/Activities/',
            method: "POST",
            data: $scope.Activity
        })
        .then(function (result) {
            //call toast msg
            $scope.Activity = {};
        }, function (error) {
            //poss call an error toast msg
            console.log(error);
        });
    };

    $scope.init = function () {
        console.log("kicked off calcVM function");
        $http({
            url: '/api/SummaryActivities/',  
            method: "GET"     
        })
        .then(function (result) {
            console.log(result);
            $scope.calcVM.totalHours = result.data.totalHours;
            $scope.calcVM.totalMileage = result.data.totalMileage;
            $scope.calcVM.totalDollars = result.data.totalDollars;
            
        }, function (error) {
            console.log(error)
        });

    };  
});