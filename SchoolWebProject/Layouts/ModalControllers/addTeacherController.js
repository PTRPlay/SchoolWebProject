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
            workStart: Teacher.workStart,
            category: Teacher.category,
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
            workStart: null,
            category: null,
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
            firstName: $scope.teacher.firstName,
            lastName: $scope.teacher.lastName,
            middleName:$scope.teacher.middleName,
            degree: $scope.teacher.degree,
            category: $scope.teacher.category,
            workStart:$scope.teacher.workStart
        }, 500);
    };

    $scope.cancel = function () {
        $element.modal('hide');

        close({
            firstName: $scope.teacher.firstName,
            lastName: $scope.teacher.lastName,
            middleName: $scope.teacher.middleName,
            degree: $scope.teacher.degree,
            category: $scope.teacher.category,
            workStart:$scope.teacher.workStart
        }, 500);
    }
}]);