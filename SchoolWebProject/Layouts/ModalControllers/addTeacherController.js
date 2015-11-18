myApp.controller("teacherAddController", ['$scope', '$element', 'title', 'close', 'Teacher', function ($scope, $element, title, close, Teacher) {
    $scope.teacher = null;
    $scope.IsFormValid = true;
    if (Teacher != null) {
        var dateParsed;
        if (Teacher.WorkStart != null) {
            var dateParsed = Teacher.WorkStart.split('.');
        }
        $scope.teacher = {
            id: Teacher.Id,
            img: Teacher.Img,
            firstName: Teacher.FirstName,
            middleName: Teacher.MiddleName,
            lastName: Teacher.LastName,
            phoneNumber: Teacher.PhoneNumber,
            degree: Teacher.Degree,
            workStart: dateParsed != null ? new Date(dateParsed[2],dateParsed[1],dateParsed[0]) : new Date(),
            category: Teacher.Category,
            subjects: Teacher.Subjects
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
            workStart: new Date(),
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
    $scope.editShowTeacherSubjects = function (subject) {
        if (Teacher != null) {
            for (var i = 0; i < $scope.teacher.subjects.length; ++i) {
                if ($scope.teacher.subjects[i].Name == subject.Name) {
                    return true;
                }
            }
        }
        return false;
    }
    $scope.close = function () {
        $element.modal('hide');
        close({
            id: $scope.teacher.id,
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
