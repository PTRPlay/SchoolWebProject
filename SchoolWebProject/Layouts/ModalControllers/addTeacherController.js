myApp.controller("teacherAddController", ['$scope', '$element', 'title', 'close', 'Teacher', function ($scope, $element, title, close, Teacher) {
    $scope.teacher = null;

    if (Teacher != null) {
        $scope.teacher = {
            id: Teacher.id,
            img: Teacher.img,
            firstName: Teacher.firstName,
            middleName: Teacher.middleName,
            lastName: Teacher.lastName,
            phoneNumber: Teacher.phoneNumber,
            degree: Teacher.degree,
            category: Teacher.category,
            workStart: Teacher.workStart,
            subjects: []
        };
    }
    else {
        $scope.teacher = {
            id: null,
            img: null,
            firstName: null,
            middleName: null,
            lastName: null,
            phoneNumber: null,
            degree: null,
            category: null,
            workStart: null,
            subjects: []
        };
    }
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
            id: $scope.teacher.id,
            firstName: $scope.teacher.firstName,
            middleName: $scope.teacher.middleName,
            lastName: $scope.teacher.lastName,
            phoneNumber: $scope.teacher.phoneNumber,
            degree: $scope.teacher.degree,
            category: $scope.teacher.category,
            workStart: $scope.teacher.workStart,
            subjects: $scope.teacher.subjects
        }, 500);
    };

    $scope.cancel = function () {
        $element.modal('hide');

        close({
            id: $scope.teacher.id,
            firstName: $scope.teacher.firstName,
            middleName: $scope.teacher.middleName,
            lastName: $scope.teacher.lastName,
            phoneNumber: $scope.teacher.phoneNumber,
            degree: $scope.teacher.degree,
            category: $scope.teacher.category,
            workStart: $scope.teacher.workStart,
            subjects: $scope.teacher.subjects
        }, 500);
    }
}]);