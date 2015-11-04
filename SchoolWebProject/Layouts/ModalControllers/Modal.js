myApp.controller('ModalShowController', ['$scope', 'ModalService', '$http',function ($scope, ModalService, $http) {
    $scope.showTeachersEditPage = function () {
        ModalService.showModal({
            templateUrl: "Layouts/TeacherAddTemplate.html",
            controller: "teacherAddController",
            inputs: {
                title: "Вчитель"
            }
        }).then(function (modal) {
            modal.element.modal();
            modal.close.then(function (result) {

                $.ajax({
                    type: "POST",
                    url: "/api/teacher",
                    dataType: 'JSON',

                    data: result

                });
            });
        })
    };
}]);
//add here your modal show methods
