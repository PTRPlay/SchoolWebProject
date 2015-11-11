myApp.controller("teacherAddController", ['$scope', '$element', 'title', 'close', 'Teacher', '$filter', function ($scope, $element, title, close, Teacher, $filter) {
    $scope.teacher = null;
    $scope.IsFormValid = true;
    if (Teacher != null) {
        var dateParsed = Teacher.WorkStart.split('.');
        $scope.teacher = {
            id: Teacher.Id,
            img: Teacher.Img,
            firstName: Teacher.FirstName,
            middleName: Teacher.MiddleName,
            lastName: Teacher.LastName,
            phoneNumber: Teacher.PhoneNumber,
            degree: Teacher.Degree,
            workStart: new Date(dateParsed[2],dateParsed[1],dateParsed[0]),
            category: Teacher.Category,
            subjects: []
        };
    }
    else {
        var today = new Date();
        $scope.teacher = {
            id: null,
            img: null,
            firstName: null,
            middleName: null,
            lastName: null,
            phoneNumber: null,
            degree: null,
            workStart: new Date(today.getFullYear(), today.getMonth(), today.getDate()),
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
                $scope.teacher.subjects.push(JSON.parse(a.value));
            }
        }
    }
    $scope.close = function () {
        $element.modal('hide');
        close({
            cancelled: false,
            firstName: $scope.teacher.firstName,
            lastName: $scope.teacher.lastName,
            middleName:$scope.teacher.middleName,
            degree: JSON.parse($scope.teacher.degree),
            category: JSON.parse($scope.teacher.category),
            workStart: $scope.teacher.workStart,
            subjects: $scope.teacher.subjects
        }, 500);
    };

    $scope.cancel = function () {
        $element.modal('hide');

        close(null, 500);
    }
}]);