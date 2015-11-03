﻿myApp.controller("teacherAddController", ['$scope', '$element', 'title', 'close', '$rootScope', function ($scope, $element, title, close, $rootScope) {
    $scope.teacher = {
        firstName: null,
        lastName: null,
        degree: null
    };
    $scope.close = function () {
        $element.modal('hide');
        close({
            firstName: $scope.teacher.firstName,
            lastName: $scope.teacher.lastName,
            degree: $scope.teacher.degree
        }, 500);
    };

    $scope.cancel = function () {
        $element.modal('hide');
    }
}]);