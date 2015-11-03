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
        templateUrl: '/Layouts/Subjects.html',
        controller:'subjectsController'
    })
    .state('scheldule', {
        url: '/scheldule',
        templateUrl: '/Layouts/Scheldule.html',
        controller:'schelduleController'
    })
    .state('news', {
        url: '/news',
        templateUrl: '/Layouts/News.html',
        controller: 'newsController'
    })
});
