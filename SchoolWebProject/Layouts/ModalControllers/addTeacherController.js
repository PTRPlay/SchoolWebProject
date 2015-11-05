myApp.controller("teacherAddController", ['$scope', '$element', 'title', 'close','teacherName', function ($scope, $element, title, close, teacherName) {
    $scope.teacher = {
        img: null,
        firstName: teacherName,
        middleName: null,
        lastName: null,
        degree: null,
        workStart: null,
        category: null,
        subjects: []
    };
    $scope.choseSubject = function () {
        $scope.teacher.subjects = [];
        var el = document.getElementsByName("a");
        for (var i = 0; i < el.length; ++i) {
            var a = el[i];
            if (a.checked == true) {
                $scope.teacher.subjects.push(a.value);
            }
        }
    }
    $scope.close = function () {
        $element.modal('hide');
        close({
            firstName: $scope.teacher.firstName,
            lastName: $scope.teacher.lastName,
            degree: $scope.teacher.degree
        }, 600);
    };

    $scope.cancel = function () {
        $element.modal('hide');

        close({
            firstName: $scope.teacher.firstName,
            lastName: $scope.teacher.lastName,
            degree: $scope.teacher.degree
        }, 600);
    }
}]);