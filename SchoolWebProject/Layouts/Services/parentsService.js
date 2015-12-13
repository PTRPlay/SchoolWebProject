myApp.factory("parentsService", ["$http", function ($http) {
    return {
        getPage: function (page, amount, sorting, filtering) {
            if (!filtering)
                return $http.get('api/parents/' + page + '/' + amount + '/' + sorting)
            else
                return $http.get('api/parents/' + page + '/' + amount + '/' + sorting + '/' + filtering)
            .success(function (data) {
                return data.get;
            })
            .error(function (data) {
                return data;
            })
        },
        getParent: function () {
            return $http.get('api/parents/')
            .success(function (data) {
                return data.get;
            })
            .error(function (data) {
                return data;
            })
        }
    }
}])