myApp.factory('newsService', ['$http', function ($http) {

    return {
        getNews: function () {
            return $http.get("api/announcements").success(function (data) {
                return data;
            }).error(function (data) {
                return data;
            })
        }
    }
}]);