﻿myApp.factory('journalService', ['$http', function ($http) {
    //TODO: get pupils function whitch takes a parameters
    return {
        getPage: function (groupId, subjectId) {
            console.log('From service: ' + groupId, subjectId);
            return $http.get('api/journal/' + groupId + '/' + subjectId)
            .success(function (data) {
                return data.get;
            })
            .error(function (data) {
                return data;
            })
        }

    }
}]);