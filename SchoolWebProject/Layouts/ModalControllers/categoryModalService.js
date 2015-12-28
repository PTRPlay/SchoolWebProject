myApp.controller('categoryModelService', ['$scope', 'ModalService',  '$http','$state', '$stateParams', function ($scope, ModalService, $http, $state, $stateParams) {
    $scope.showCategoryEditPage = function (category) {
        ModalService.showModal({
            templateUrl: "Layouts/PartialView/TeacherCategoryTemplate.html",
            controller: "categoryAddController",
            inputs: {
                title: "Category",
                Category: category
            }
        }).then(function (modal) {
            modal.element.modal();
            modal.close.then(function (result) {
                if (result != null) {
                    if (result.id == null) {
                        $http.post("api/teachercategory/", result)
                        .success(function () {
                            $state.go('teachers', { start: $stateParams.start }, { reload: true });
                        });
                    }
                    else {
                        $http.post("api/teachercategory/" + result.id, result)
                        .success(function () {
                            $state.go('teachers', { start: $stateParams.start }, { reload: true });
                        });
                    }
                }
            });
        });
    };

}]);