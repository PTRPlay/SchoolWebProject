var myApp = angular.module('myApp', ['ui.router', 'angularModalService', 'ngAnimate', 'ngTouch',
    'ui.grid', 'ui.grid.moveColumns', 'ui.grid.pinning', 'ui.grid.edit', 'ui.grid.pagination',
    'ui.grid.cellNav', 'ui.bootstrap', 'naif.base64', 'blockUI', 'exceptionOverride', 'angucomplete-alt']);

myApp.config(function ($stateProvider, $urlRouterProvider) {
    $urlRouterProvider.otherwise('/news');
    $stateProvider.state('home', {
        url: '/home'
    })
    .state('teachers', {
        url: '/teachers',
        templateUrl: '/Layouts/PartialView/Teachers.html',
        controller: 'teachersController'
    })

    .state('subjects', {
        url: '/subjects',
        templateUrl: '/Layouts/PartialView/Subjects.html',
        controller: 'subjectsController'
    })
    .state('groups', {
        url: '/groups',
        templateUrl: '/Layouts/PartialView/Groups.html',
        controller: 'groupsController'
    })
    .state('schedule', {
        url: '/schedule',
        templateUrl: '/Layouts/PartialView/Schedule.html'
    })
    .state('diaryService', {
        url: '/diary',
        templateUrl: '/Layouts/PartialView/Diary.html',
        controller: 'diaryController'
    })
    .state('pupils', {
        url: '/pupils',
        templateUrl: '/Layouts/PartialView/Pupils.html',
        controller: 'pupilsController'
    })
    .state('parents', {
        url: '/parents',
        templateUrl: '/Layouts/PartialView/Parents.html',
        controller: 'parentsController'
    })
    .state('newsService', {
        url: '/news',
        templateUrl: '/Layouts/PartialView/News.html',
        controller: 'newsController'
    })
    .state('newsAdminService', {
        url: '/adminnews',
        templateUrl: '/Layouts/PartialView/NewsAdmin.html',
        controller: 'newsAdminController'
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
    .state('group', {
        url: '/group/{id}',
        templateUrl: '/Layouts/PartialView/GroupDetails.html',
        controller: 'groupDetailsController'
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
    .state('holidays', {
        url: '/holidays',
        templateUrl: '/Layouts/PartialView/Holidays.html',
        controller: 'holidaysController'
    })
     .state('permissionError', {
         url: '/permissionerror',
         templateUrl: '/Layouts/PartialView/PermissionErrorPage.html'
     })
    .state('parent', {
        url: '/parent/{id}',
        templateUrl: '/Layouts/PartialView/ParentInfo.html',
        controller: 'parentInfoController'
    })
})
.config(function (blockUIConfig) {
    blockUIConfig.message = 'Loading...';

    blockUIConfig.delay = 300;
});

