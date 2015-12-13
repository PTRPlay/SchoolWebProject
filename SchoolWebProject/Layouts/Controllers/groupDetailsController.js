myApp.controller('groupDetailsController', ['$scope', 'groupsService', 'permissionService', function ($scope, groupsService, permissionService) {
    groupsService.getGroups()
        .success(function (data) {
        $scope.getGroup = function () {
            var id = document.URL.split("group/")[1];
            for (var i = 0; i < data.length; i++) {
                if (data[i].Id == id) {
                    return data[i];
                }
            }
        }
        });
    $scope.showGroups = function () {
        return permissionService.showGroups();
    };
}]);