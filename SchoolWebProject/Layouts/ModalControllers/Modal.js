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

    $scope.showPupilsEditPage = function (user) {
        ModalService.showModal({
            templateUrl: "Layouts/PupilAddTemplate.html",
            controller: "pupilAddController",
            inputs: {
                title: "Учень",
                Pupil: user
            }
        })
        //    .then(function (modal) {
        //    modal.element.modal();
        //    modal.close.then(function (result) {
        //        $http.post("api/pupil", result);
        //    });
        //});
    };

    $scope.showPupilsDeletePrompt = function (user) {
        ModalService.showModal({
            templateUrl: "Layouts/PupilDeleteTemplate.html",
            controller: "pupilsController",
            inputs: {
                title: "Учень",
                Pupil: user
            }
        }).then(function (modal) {
            modal.element.modal();
            modal.close.then(function (result) {
                $http.post("api/pupil", result);
            });
        
        })
    };
}]);