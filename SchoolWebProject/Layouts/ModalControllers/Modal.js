myApp.controller('ModalShowController', ['$scope', 'ModalService', function ($scope, ModalService, $http) {
    $scope.showTeachersEditPage = function () {
        ModalService.showModal({
            templateUrl: "Layouts/TeacherAddTEmplate.html",
            controller: "teacherAddController",
            inputs: {
                title: "Вчитель"
            }
        }).then(function (modal) {
            modal.element.modal();
            modal.close.then(function (result) {
                //$http.post("", angular.toJson(result.teacher));
            });
        });
    };
}]);
//add here your modal show methods
