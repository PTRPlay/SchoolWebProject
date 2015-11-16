myApp.factory('markService', ['$http', function ($http) {
    //TODO: get pupils function whitch takes a parameters
    return {
        getPage: function (subjectId,groupId ) {
            console.log('From service: ' + groupId, subjectId);
            return $http.get('api/mark/' + subjectId + '/' + groupId)
            .success(function (data) {
                return data.get;
            })
            .error(function (data) {
                return data;
            })
        }
        
    }
}]);