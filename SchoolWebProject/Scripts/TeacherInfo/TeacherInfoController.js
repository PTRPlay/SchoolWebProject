var teacherInfoController = angular.module('teacherInfoController', []);
teacherInfoController.controller('showInfo', ['$scope', function ($scope) {
    $scope.photo = null;
    $scope.firstName = null;
    $scope.middleName = null;
    $scope.lastName = null;
    $scope.category = null;
    $scope.degree = null;
    $scope.subjects = null;
    $scope.ownGroup = null;
    $scope.groups = null;
}]);