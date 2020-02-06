/// <reference path="angular.min.js" />

var appModuleDemo = angular.module("moduleDemo", [])
    .controller("demoCntrl", function ($scope, $location, $anchorScroll) {
        $scope.scrollTo = function (scrollLocation) {
            $location.hash(scrollLocation);
            $anchorScroll();
        }
    })
    .controller("Another", function ($rootScope, $scope) {
        $rootScope.RedColor = "this is root red color";
        $scope.green = "this is scope green color";
    })