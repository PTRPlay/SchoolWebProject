myApp.controller('parentInfoController', ['$scope', 'parentsService', function ($scope, parentsService) {
    parentsService.getParent().success(function (data) {
        $scope.getParent = function () {
            var id = document.URL.split("parent/")[1];
            for (var i = 0; i < data.length; i++) {
                if (data[i].Id == id)
                    return data[i];
            }
        }
    });
}]);