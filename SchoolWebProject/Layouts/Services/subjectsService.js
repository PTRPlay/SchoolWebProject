﻿myApp.factory('subjectsService', ['$http', function ($http) {
    return {
        getSubjects: function () {
            return $http.get("api/subjects").success(function (data) {
                return data;
            }).error(function (data) {
                return data;
            })
        },

            getSujectForGroup: function(groupId){
                return $http.get("api/subjects/getSubjectForGroup/" + groupId)
                .success(function(data){
                    return data;
            }).error(function(data){
                return data;
            });
            }
        
}
}]);