myApp.controller('categoriesController', function ($scope, categories) {
    categories.success(function (data) {
        $scope.listCategories = data;
    });
});