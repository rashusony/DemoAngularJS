/// <reference path="angular.min.js" />

var StudentApp = angular.module("Demo", ["ngRoute"])
    .config(function ($routeProvider) {
        $routeProvider.caseInsensitiveMatch = true;

        $routeProvider
            .when("/Home", {
                templateUrl:"Template/Home.html",
                controller:"homeController"
            })
            .when("/Courses", {
                templateUrl: "Template/Courses.html",
                controller:"coursesController"
            })
            .when("/Students", {
                templateUrl: "Template/Students.html",
                controller: "studentsController"
            })
            .when("/Students/:Id", {
                templateUrl: "Template/StudentDetails.html",
                controller:"studentDetails"
            })
            .when("/StudentsSearch/:name?", {
                templateUrl: "Template/StudentDetailsByName.html",
                controller: "studentByName"
            })
            .when("/AddStudent", {
                templateUrl: "Template/StudentForm.html",
                controller:"studentAdd"
            }

            )
            .otherwise({
                redirectTo:"/Home"
            })
    })
    .controller("homeController", function ($scope) {
        $scope.message = "Home Page";
    })
    .controller("coursesController", function ($scope) {

        $scope.courses = ["C#", "Java", "VB.Net", "JQuery", "AngularJS"];
        $scope.name1 = "vB";
    })
    .controller("studentsController", function ($scope, $http, $location) {

        $scope.getByName = function () {
            if ($scope.name) {
                $location.url("/StudentsSearch/" + $scope.name);
            }
            else {
                $location.url("/Students");
            }

        }
        $scope.addStudent = function(){
            $location.url("/AddStudent");
        }
        $http.get("StudentWebService.asmx/GetAllStudent")
            .then(function (response) {
                $scope.students = response.data;
            })
       

        //$scope.$on("$routeChangeStart", function (event, next, current) {
        //    if (!confirm("Are you sure you want to navigate away from this page?"))
        //    {

        //        event.preventDefault();
        //    }
               
        //})d

       
    })
    .controller("studentDetails", function ($scope, $http, $routeParams) {
        $http({
            url: "StudentWebService.asmx/GetStudent",
            params: { Id: $routeParams.Id },
            method:"get"
        })
          .then(function (response) {
              $scope.student = response.data;
            })
    })
    .controller("studentByName", function ($scope, $http, $routeParams) {
        $http({
            url: "StudentWebService.asmx/GetStudentByName",
            params: { name: $routeParams.name },
            method: "get"
        })
            .then(function (response) {
                $scope.student = response.data;
            })
    })
    .controller("studentAdd", function ($scope, $http, $location) {

        $scope.saveData = function () {
            $http({
                url: "studentWebService.asmx/AddStudent",
                params: { name: $scope.name, gender: $scope.gender, city: $scope.city },
                method: "get"
            })
                .then(function () {
                    $location.url("/Students");
                })
        }
    })