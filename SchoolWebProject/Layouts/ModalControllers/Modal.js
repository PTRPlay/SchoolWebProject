﻿myApp.controller('ModalShowController', ['$scope', 'ModalService', '$http',function ($scope, ModalService, $http) {
    $scope.showTeachersEditPage = function (user) {
        ModalService.showModal({
            templateUrl: "Layouts/TeacherAddTemplate.html",
            controller: "teacherAddController",
            inputs: {
                title: "Вчитель",
                Teacher: user
            }
        }).then(function (modal) {
            modal.element.modal();
            modal.close.then(function (result) {
                $http.post("api/teacherscategory", result);
            });
        });
    };
}]);
//add here your modal show methods
