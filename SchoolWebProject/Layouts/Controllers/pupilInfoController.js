myApp.controller('pupilInfoController', ['$scope', 'pupilsService', 'permissionService', function ($scope, pupilsService, permissionService) {
    pupilsService.getPupil().success(function (data) {
        $scope.getPupil = function () {
            var id = document.URL.split("pupil/")[1];
            for (var i = 0; i < data.length; i++) {
                if (data[i].Id == id)
                    return data[i];
            }
        }
    });
    $scope.showPupilInfo = function () {
        return permissionService.showPupils();
    };
}]);
