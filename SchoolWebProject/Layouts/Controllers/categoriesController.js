myApp.controller('categoriesController', function ($scope, categories) {
    categories.success(function (data) {
        $scope.categories = data;
    });
});