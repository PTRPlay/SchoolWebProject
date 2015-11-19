myApp.controller('degreeModelService', ['$scope', 'ModalService',  '$http', function ($scope, ModalService, $http) {
    $scope.showDegreeEditPage = function (degree) {
        ModalService.showModal({
            templateUrl: "Layouts/TeacherDegreeTemplate.html",
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
                        $http.post("api/teacherdegree/", result);
                        window.location.reload("/");
                    }
                    else {
                        $http.post("api/teacherdegree/" + result.id, result);
                        window.location.reload("/");
                    }
                }
            });
        });
    };

}]);