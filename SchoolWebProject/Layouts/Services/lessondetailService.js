myApp.factory('lessondetail', ['$http', function ($http) {
    return {
        getLessonDetails: function (id) {
            return $http.get("api/lessonDetail/" + id)
                .success(function (data) {
                    return data
                })
                .error(function (data) {
                    return data
                });
        }
    }
}])