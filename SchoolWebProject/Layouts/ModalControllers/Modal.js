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
                $http.post("api/teacher", result);
            });
        });
    };

    $scope.showPupilsEditPage = function (user) {
        ModalService.showModal({
            templateUrl: "Layouts/PupilAddTemplate.html",
            controller: "pupilAddController",
            inputs: {
                title: "Учень",
                Pupil: user
            }
        }).then(function (modal) {
            modal.element.modal();
            modal.close.then(function (result) {
                $http.post("api/pupil", result);
            });
        });
    };
}]);