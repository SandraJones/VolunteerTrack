var app = angular.module("Tracker", ["ngRoute"]);


//Home Page Slideshow Code
$("#slideshow > div:gt(0)").hide();

setInterval(function () {
    $('#slideshow > div:first')
      .fadeOut(1000)
      .next()
      .fadeIn(1000)
      .end()
      .appendTo('#slideshow');
}, 13000);

//Angular Routing
app.config(['$routeProvider', function ($routeProvider) {
    $routeProvider.
        when('/EditActivityPage/:activityId', {
            templateUrl: '/Partials/UpdateView.html',
            controller: 'UpdateController'
        })
        .when('/', {
            templateUrl: '/partials/ListOfActivities.html',
            controller: 'EditController'
        } );
}]);

//This controller saves the input from the user for a specific activity.
app.controller('ActivitiesController', ['$scope', '$http', function ($scope, $http) {
    console.log("this is the ActivitiesController POST  kicking off inside of the appjs file");
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
    //GET Calculations from Backend Controller on page load.
    $scope.init = function () {
        console.log("kicked off calcVM function");
        $http({
            url: '/api/SummaryActivities/',  
            method: "GET"     
        })
        .then(function (result) {
            console.log(result, "this is the result of the GET for the calculations in the ActivitiesController");
            $scope.calcVM.totalHours = result.data.totalHours;
            $scope.calcVM.totalMileage = result.data.totalMileage;
            $scope.calcVM.totalDollars = result.data.totalDollars;
            
        }, function (error) {
            console.log(error)
        });

    };  
}]);