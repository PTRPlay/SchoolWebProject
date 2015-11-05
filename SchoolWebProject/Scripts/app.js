var myApp = angular.module('myApp', ['ui.router', 'angularModalService']);

myApp.config(function ($stateProvider) {
    $stateProvider.state('home', {
        url: '/home',
        templateUrl: '/Layouts/Teachers.html'
    })
    .state('teachers', {
        url:'/teachers',
        templateUrl: '/Layouts/Teachers.html',
        controller: 'teachersController'
    })
    .state('subjects',{
        url: '/subjects',
        templateUrl: '/Layouts/Subjects.html'
    })
    .state('scheldule', {
        url: '/scheldule',
        templateUrl: '/Layouts/Scheldule.html'
    })
    .state('news', {
        url: '/news',
        templateUrl: '/Layouts/News.html'
    })
    .state('login', {
        url: '/login',
        templateUrl: '/Layouts/LogIn.html'
    })

});
