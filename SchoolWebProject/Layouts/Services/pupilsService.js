myApp.factory('pupils', ['$http', function ($http) {
    //TODO: get pupils function whitch takes a parameters
    return{
        getPage: function (page, amount, sorting, filtering) {
            if(!filtering)
                return $http.get('api/pupils/' + page + '/' + amount + '/' + sorting )
            else 
                return $http.get('api/pupils/' + page + '/' + amount + '/' + sorting + '/' + filtering)
            .success(function (data) {
                return data.get;
            })
            .error(function (data) {
                return data;
            })
        },
        getPupil: function () {
            return $http.get('api/pupils/')
            .success(function (data) {
                return data.get;
            })
            .error(function (data) {
                return data;
            })
        }
    }
}]);