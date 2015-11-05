myApp.controller('ModalShowController', ['$scope', 'ModalService', '$http',function ($scope, ModalService, $http) {
    $scope.showTeachersEditPage = function (teacher) {
        ModalService.showModal({
            templateUrl: "Layouts/TeacherAddTemplate.html",
            controller: "teacherAddController",
            inputs: {
                title: "Вчитель",
                teacherName: teacher
            }
        }).then(function (modal) {
            modal.element.modal();
            modal.close.then(function (result) {
                $http.post("api/teacherscategory", result);
            });
        });
    };
}]);
//add here your modal show methods
