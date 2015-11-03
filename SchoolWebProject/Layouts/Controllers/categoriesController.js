myApp.controller('categoriesController', function ($rootScope, categories) {
    categories.success(function (data) {
        $rootScope.categories = data;
    });
});