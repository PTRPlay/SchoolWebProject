myApp.controller('subjectsController', ['$scope','subjectsService', 'SubjectModalService', function ($scope, subjectsService, SubjectModalService) {
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
}]);