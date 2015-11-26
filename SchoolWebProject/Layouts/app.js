var myApp = angular.module('myApp', ['ui.router', 'angularModalService', 'ngAnimate', 'ngTouch', 'ui.grid', 'ui.grid.moveColumns', 'ui.grid.pinning', 'ui.grid.edit', 'ui.grid.pagination', 'ui.grid.cellNav', 'ui.bootstrap']);

myApp.config(function ($stateProvider) {
    $stateProvider.state('home', {
        url: '/home'
    })
    .state('teachers', {
        url:'/teachers',
        templateUrl: '/Layouts/PartialView/Teachers.html',
        controller: 'teachersController'
    })

    .state('subjects', {
        url: '/subjects',
        templateUrl: '/Layouts/PartialView/Teachers.html',
        controller:'subjectsController'
    })
    .state('groups', {
        url: '/groups',
        templateUrl: '/Layouts/PartialView/Groups.html',
        controller:'groupsController'
    })
    .state('schedule', {
        url: '/schedule',
        templateUrl: '/Layouts/PartialView/Schedule.html'
    })
    .state('diaryService', {
        url: '/diary/{id}/{date}',
        templateUrl: '/Layouts/PartialView/Diary.html',
        controller: 'diaryController'
     })
    .state('pupils', {
        url: '/pupils',
        templateUrl: '/Layouts/PartialView/Pupils.html',
        controller: 'pupilsController'
    })
    .state('newsService', {
        url: '/news',
        templateUrl: '/Layouts/PartialView/News.html',
        controller: 'newsController'
    })
    .state('schoolService', {
            url: '/contacts',
            templateUrl: '/Layouts/PartialView/Contacts.html',
            controller: 'schoolController'
    })
    .state('teacher', {
        url: '/teacher/{id}',
        templateUrl: '/Layouts/PartialView/TeacherInfo.html',
        controller: 'teacherInfoController'
    })
    .state('pupil', {
        url: '/pupil/{id}',
        templateUrl: '/Layouts/PartialView/PupilInfo.html',
        controller: 'pupilInfoController'
    })
	.state('journal', {
        url: '/journal',
        templateUrl: '/Layouts/PartialView/Journal.html',
        controller: 'journalController'
	})
    .state('myprofile', {
        url: '/myprofile',
        templateUrl: '/Layouts/PartialView/MyProfile.html',
    })
});
