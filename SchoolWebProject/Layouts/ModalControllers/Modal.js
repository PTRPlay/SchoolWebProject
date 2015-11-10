myApp.controller('ModalShowController', ['$scope', 'ModalService', '$http', function ($scope, ModalService, $http) {
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
                if (result != null) {
                    $http.post("api/teacher", result);
                }
            });
        });
    };

}]);