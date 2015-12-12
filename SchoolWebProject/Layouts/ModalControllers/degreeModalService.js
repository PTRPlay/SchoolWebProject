myApp.controller('degreeModelService', ['$scope', 'ModalService',  '$http', function ($scope, ModalService, $http) {
    $scope.showDegreeEditPage = function (degree) {
        ModalService.showModal({
            templateUrl: "Layouts/PartialView/TeacherDegreeTemplate.html",
            controller: "degreeAddController",
            inputs: {
                title: "Degree",
                Degree: degree
            }
        }).then(function (modal) {
            modal.element.modal();
            modal.close.then(function (result) {
                if (result != null) {
                    if (result.id == null) {
                        $http.post("api/teacherdegree/", result)
                            .success(function () {
                            $state.go('teachers', { start: $stateParams.start }, { reload: true });
                        });
                    }
                    else {
                        $http.post("api/teacherdegree/" + result.id, result)
                            .success(function () {
                            $state.go('teachers', { start: $stateParams.start }, { reload: true });
                        });
                    }
                }
            });
        });
    };

}]);