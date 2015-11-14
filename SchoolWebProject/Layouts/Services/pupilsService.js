myApp.factory('pupils', ['$http', function ($http) {
    //TODO: get pupils function whitch takes a parameters
    return{
        getPage: function (page, amount, sorting) {
            console.log('From service: '+ page, amount,sorting);
            return $http.get('api/pupils/'+page+'/'+amount+'/'+sorting)
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