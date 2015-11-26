myApp.factory('holidaysService', ['$http', function ($http) {
    return{
       getHolidays: function(){
        return $http.get('api/holidays')
        .success(function (data) {
            return data;
        })
        .error (function (data) {
            return data;
        })
      }
    }
}]);


