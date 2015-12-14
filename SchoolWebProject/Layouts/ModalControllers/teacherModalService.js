myApp.controller('ModalShowController', ['$scope', 'ModalService', '$http', '$state', '$stateParams', function ($scope, ModalService, $http, $state, $stateParams ) {
    $scope.showTeachersEditPage = function (user) {
        ModalService.showModal({
            templateUrl: "Layouts/PartialView/TeachersAddTemplate.html",
            controller: "teacherAddController",
            inputs: {
                title: "Вчитель",
                Teacher: user
            }
        }).then(function (modal) {
            modal.element.modal();
            modal.close.then(function (result) {
                if (result != null) {
                    if (result.id == null) {
                        $http.post("api/teacher", result)
                                .success(function () {
                                    $state.go('teachers', { start: $stateParams.start }, { reload: true });
                                });
                    }
                    else{
                        $http.post("api/teacher/" + result.id, result)
                                .success(function () {
                                    $state.go('teachers', { start: $stateParams.start }, { reload: true });
                                });
                    }
                }
            });
        });
    };
}]);