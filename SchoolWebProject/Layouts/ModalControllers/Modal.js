myApp.controller('ModalShowController', ['$scope', 'ModalService', '$http', '$rootScope',function ($scope, ModalService, $http, $rootScope) {
    $scope.showTeachersEditPage = function (teacher) {
        teacher = 'some';
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
