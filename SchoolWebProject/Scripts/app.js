var myApp = angular.module('myApp', ['ui.router', 'angularModalService', 'ngAnimate', 'ngTouch', 'ui.grid', 'ui.grid.moveColumns']);

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
    .state('subjects', {
        url: '/subjects',
        templateUrl: '/Layouts/Subjects.html'
    })
    .state('scheldule', {
        url: '/scheldule',
        templateUrl: '/Layouts/Scheldule.html'
    })
    .state('pupils', {
        url: '/pupils',
        templateUrl: '/Layouts/Pupils.html',
        controller: 'pupilsController'
    })
    .state('newsService', {
        url: '/news',
        templateUrl: '/Layouts/News.html',
        controller: 'newsController'
    })
    .state('newsDetailService', {
            url: '/news/{id}',
            templateUrl: '/Layouts/NewsDetail.html',
            controller: 'newsDetailController'
    })
    .state('login', {
        url: '/login',
        templateUrl: '/Layouts/LogIn.html'
    })
    .state('teacher', {
        url: '/teacher/{id}',
        templateUrl: '/Layouts/TeacherInfo.html',
        controller: 'teacherInfoController'
    })
});
