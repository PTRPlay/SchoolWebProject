myApp.controller('groupDetailsController', ['$scope', 'groupsService', function ($scope, groupsService) {
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
}]);