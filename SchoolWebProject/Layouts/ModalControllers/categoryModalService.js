myApp.controller('categoryModelService', ['$scope', 'ModalService',  '$http', function ($scope, ModalService, $http) {
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
                        $http.post("api/teachercategory/", result);
                        window.location.reload("/");
                    }
                    else {
                        $http.post("api/teachercategory/" + result.id, result);
                        window.location.reload("/");
                    }
                }
            });
        });
    };

}]);