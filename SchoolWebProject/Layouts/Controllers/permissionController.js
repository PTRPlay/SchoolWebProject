myApp.controller('permissionController', ['$scope', '$location', function ($scope, $location) {

    $scope.redirection = '/permissionerror';

    $scope.showAddNews = function () {
        if (window.currentUser.Role == "Admin" || window.currentUser.Role == "Teacher") {
            return true;
        } else {
            return false;
        }
    }

    $scope.showGroups = function () {
        if (window.currentUser.Role == "Pupil" || window.currentUser.Role == "Parent") {
            $location.path($scope.redirection);
        } else {
            return true;
        }
    }

    $scope.showPupils = function () {
        if (window.currentUser.Role == "Pupil" || window.currentUser.Role == "Parent") {
            $location.path($scope.redirection);
        } else {
            return true;
        }
    }

    $scope.showTeachers = function () {
        if (window.currentUser.Role == "Pupil") {
            $location.path($scope.redirection);
        } else {
            return true;
        }
    }

    $scope.showAddEditTeacher = function () {
        if (window.currentUser.Role == "Admin") {
            return true;
        } else {
            return false;
        }
    }

    $scope.showEditSchedule = function () {
        if (window.currentUser.Role == "Admin" || window.currentUser.Role == "Teacher") {
            return true;
        } else {
            return false;
        }
    }

    $scope.FileSchedule = function () {
        if (window.currentUser.Role == "Admin") {
            return true;
        } else {
            return false;
        }
    }
}])