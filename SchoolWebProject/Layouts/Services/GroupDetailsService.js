myApp.factory('group', ['$http', function ($http)
{
    return $http.get('api/group/{id}')
	.success(function (data)
	{
	    return data.get;
	})
	.error(function (data)
	{
	    return data;
	})

}]);