myApp.controller('subjectsController', function ($scope, subjectsService) {
    subjectsService.getSubjects()
        .success(function (data) {
        $scope.listSubjects = data;
    });

    $scope.activeIndex;

    $scope.showTeachers = function (index) {
        $scope.activeIndex = index;
    };

    $scope.isShowing = function (index) {
        return $scope.activeIndex == index;
    };

    $scope.addSubject = function () {
        SubjectModalService.showSubjectEditPage();
    };

    $scope.editSubject = function (value) {
        SubjectModalService.showSubjectEditPage(value);
    };
});