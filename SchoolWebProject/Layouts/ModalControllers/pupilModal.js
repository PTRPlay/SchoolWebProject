myApp.controller('ModalShowController', ['$scope', 'ModalService', '$http', function ($scope, ModalService, $http) {
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