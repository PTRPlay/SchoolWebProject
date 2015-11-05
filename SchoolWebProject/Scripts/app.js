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
<<<<<<< HEAD

=======
    .state('teacherInfo', {
        url: '/teacherInfo?id={id}',
        templateUrl: '/Layouts/TeacherInfo.html?id={id}',
        controller: 'teacherInfoController'
    })
>>>>>>> 09695b24ccdf1ef781cf83451963d3806f35b42d
});
