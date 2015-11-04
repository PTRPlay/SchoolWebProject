myApp.controller("teacherAddController", ['$scope', '$element', 'title', 'close', '$rootScope','teacherName', function ($scope, $element, title, close, $rootScope, teacherName) {
    $scope.teacher = {
        firstName: teacherName,
        middleName: null,
        lastName: null,
        degree: null,
        workStart: null,
        category: null,
        subjects: []
    };
    $scope.close = function () {
        $element.modal('hide');
        close({
            firstName: $scope.teacher.firstName,
            lastName: $scope.teacher.lastName,
            degree: $scope.teacher.degree
        }, 600);
    };

    $scope.cancel = function () {
        $element.modal('hide');

        close({
            firstName: $scope.teacher.firstName,
            lastName: $scope.teacher.lastName,
            degree: $scope.teacher.degree
        }, 600);
    }
}]);