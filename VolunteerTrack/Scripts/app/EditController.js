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
//here is where I code in current user somehow
//filter datetime in html file