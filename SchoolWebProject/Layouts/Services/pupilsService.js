myApp.factory('pupilsService', ['$http', function ($http) {
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