myApp.controller('parentInfoController', ['$scope', 'parentsService', 'permissionService', function ($scope, parentsService, permissionService) {
    parentsService.getParent().success(function (data) {
        $scope.getParent = function () {
            var id = document.URL.split("parent/")[1];
            for (var i = 0; i < data.length; i++) {
                if (data[i].Id == id)
                    return data[i];
            }
        }
        $scope.showParents = function () {
            return permissionService.showParents();
        }
    });
}]);