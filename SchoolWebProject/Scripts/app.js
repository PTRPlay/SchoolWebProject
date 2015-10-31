var myApp = angular.module('myApp', ['ngRoute']);

myApp.config(function ($routeProvider) {
    $routeProvider

        .when('/teachers', {
            templateUrl: 'Teachers.html',
            controller: 'teachersController'
        })

        .when('/subjects', {
            templateUrl:'Subjects.html',
            controller: 'subjectsController'
        })

        .when('/scheldule', {
            template: 'Scheldule.html',
            controller: 'shelduleController'
        })
        .when('/news', {
            template: 'News.html',
            controller: 'newsController'
        });
});

myApp.controller('teachersController', function ($scope,$http) {
    
});

myApp.controller('subjectsController', function ($scope) {

    });

myApp.controller('schelduleController', function ($scope) {
    //there will be some stuff
});

myApp.controller('newsController', function ($scope) {
    //there will be some stuff
});