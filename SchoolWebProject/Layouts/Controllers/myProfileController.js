myApp.controller('myProfileController', function ($scope, currentUser, myProfileService, teachersService, pupilsService, parentsService) {
    
    $scope.user = JSON.parse(currentUser);

    $scope.userData;

    $scope.getUserData = function () {
        if ($scope.user.Role == "Admin")
            myProfileService.getUser($scope.user.Id).success(function (data) {
                $scope.userData = data;
            });
        else if ($scope.user.Role == "Teacher")
            teachersService.getTeacherById($scope.user.Id).success(function (data) {
                $scope.userData = data;
            });
        else if ($scope.user.Role == "Pupil")
            pupilsService.getPupilById($scope.user.Id).success(function (data) {
                $scope.userData = data;
            });
        else if ($scope.user.Role == "Parent")
            parentsService.getParentById($scope.user.Id).success(function (data) {
                $scope.userData = data;
            });
    };

    $scope.showTeacherData = function () {
        if ($scope.user.Role == "Teacher")
            return true;
        else return false;
    };

    $scope.showPupilData = function () {
        if ($scope.user.Role == "Pupil")
            return true;
        else return false;
    };

    $scope.showParentData = function () {
        if ($scope.user.Role == "Parent")
            return true;
        else return false;
    };
});