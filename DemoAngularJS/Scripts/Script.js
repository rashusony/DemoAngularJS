/// <reference path="angular.min.js" />

var myApp = angular.module("myModule", []);

var emp_deatils = [
    { name: 'Stacy', gender: 'female', salary: 60000, DOJ: "02/12/ 1998"},
    { name: 'Florate', gender: 'female', salary: 70000, DOJ: "13/12/1998" },
    { name: 'Jace', gender: 'male', salary: 60900, DOJ: "26/03/2020" },
    { name: 'Mike', gender: 'male', salary: 23000, DOJ: "02/12/1998" }
]

//myApp.filter("Gender", function () {
//    return function (gender) {
//        switch (gender) {
//            case "male":
//                return 1;
//            case "female":
//                return 2;

//        }

//    }
//});

myApp.controller("myController", function ($scope,$http) {

    var employee = {
        firstName: 'Rashmi',
        lastName: 'Bharti',
        gender: 'Female'
    }
    $scope.emp = employee;

    var technology = [{
        name: 'c#',
        like: 0,
        dislike: 0
    },
    {
        name: 'java',
        like: 0,
        dislike: 0
    },

    {
        name: 'Angular',
        like: 0,
        dislike: 0
    },

    {
        name: 'HTML',
        like: 0,
        dislike: 0
    }
    ];

    $scope.tech = technology;

    $scope.countLike = function (tech) {
        tech.like++;
    }

    $scope.countdisike = function (tech) {
        tech.dislike++;
    }

    $scope.emp_deatils = emp_deatils;

    $scope.sortBy = "name";

    var country = [
        {
            name: 'India',
            city: [
                { name: 'Delhi' },
                { name: 'Bangalore'}
            ]
        },
        {
            name: 'USA',
            city: [
                { name: 'Huston' },
                { name: 'New York' }
            ]
        },
        {
            name: 'Europe',
            city: [
                { name: 'Finland' },
                { name: 'Swiden' }
            ]
        }
        
    ];

    $scope.country = country;

    $scope.typeView = "EmployeeTable.html";

    var sucessCallBack = function (response) {
        $scope.employeeDB = response.data;
    }

    var errorCallBack = function (reason) {
        $scope.error = reason.data;
    }

    $http.get('EmployeeWebService.asmx/GetAllEmployee')
        .then(sucessCallBack, errorCallBack); 


});