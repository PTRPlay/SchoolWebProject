angular.module('exceptionOverride', [])
    .factory('$exceptionHandler', ['$injector', function ($injector) {
        return function (exception, cause) {
            console.log(exception.message);
            var $http = $injector.get('$http');
            $http.post("api/error",
                {
                    exception: exception.message,
                    cause: cause
                });
        };
    }]);