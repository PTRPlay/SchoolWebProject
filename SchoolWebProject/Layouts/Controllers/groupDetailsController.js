myApp.controller('groupDetailsController', ['$scope', 'groups', function ($scope, groups) {
    groups.success(function (data) {
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