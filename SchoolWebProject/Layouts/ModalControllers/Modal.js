myApp.controller('ModalShowController', ['$scope', 'ModalService', '$http', function ($scope, ModalService, $http) {
    $scope.showTeachersEditPage = function (user) {
        ModalService.showModal({
            templateUrl: "Layouts/TeachersAddTemplate.html",
            controller: "teacherAddController",
            inputs: {
                title: "Вчитель",
                Teacher: user
            }
        }).then(function (modal) {
            modal.element.modal();
            modal.close.then(function (result) {
                if (result != null) {
                    var url = "api/teacher/";
                    if (result.id != null)
                     url+= result.id;
                        $http.post(url, result);
                        window.location.reload("/home");

                }
            });
        });
    };

}]);