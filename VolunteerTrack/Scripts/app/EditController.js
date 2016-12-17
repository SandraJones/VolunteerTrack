angular.module("Tracker");

app.controller('EditController', function ($scope, $http) {
    $http({
        url: '/api/Activities/',
        method: "GET"
    })
   .then(function (result) {
       $scope.activities = result.data;
       console.log(result);
   }, function (error) {
       console.log(error);
   });
});

//filter datetime in html file