angular.module('exceptionOverride', [])
    .factory('$exceptionHandler', ['$injector', function ($injector) {
        return function (exception, cause) {
            console.log(exception);
            var $http = $injector.get('$http');
            $http.post("api/errorlog",
                {
                    exception: exception.message,
                    cause: cause
                });
        };
    }]);