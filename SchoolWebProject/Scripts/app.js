var myApp = angular.module('myApp', ['ui.router', 'angularModalService', 'ngAnimate', 'ngTouch', 'ui.grid', 'ui.grid.moveColumns', 'ui.grid.pinning', 'ui.grid.edit', 'ui.grid.pagination']);

myApp.config(function ($stateProvider) {
    $stateProvider.state('home', {
        url: '/home'
    })
    .state('teachers', {
        url:'/teachers',
        templateUrl: '/Layouts/Teachers.html',
        controller: 'teachersController'
    })

    .state('teachersCategory', {
        url: '/teacherCategory/{Id}',
        templateUrl: '/Layouts/Teachers.html',
        controller: 'teachersByCategory'
    })

    .state('subjects', {
        url: '/subjects',
        templateUrl: '/Layouts/Teachers.html',
        controller:'subjectsController'
    })
        .state('groups', {
            url: '/groups',
            templateUrl: '/Layouts/Groups.html',
            controller:'groupsController'
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
    .state('schoolService', {
            url: '/contacts',
            templateUrl: '/Layouts/Contacts.html',
            controller: 'schoolController'
    })
    .state('teacher', {
        url: '/teacher/{id}',
        templateUrl: '/Layouts/TeacherInfo.html',
        controller: 'teacherInfoController'
    })
    .state('pupil', {
        url: '/pupil/{id}',
        templateUrl: '/Layouts/PupilInfo.html',
        controller: 'pupilInfoController'
    })
	.state('journal', {
        url: '/journal',
        templateUrl: '/Layouts/Journal.html',
        controller: 'journalController'
    })
});
