myApp.controller('groupDetailsController', ['$scope', 'groups', function ($scope, groups)
{

    groups.success(function (data)
    {
        $scope.getGroup = function ()
        {
            var id = document.URL.split("group/")[1];
            for (var i = 0; i < data.length; i++)
            {
                if (data[i].Id == id)
                {
                    //alert(data[i].ViewPupils[0].FirstName);
                    return data[i];
                }
            }
        }

        $scope.names = ['Ben', 'Nate', 'Austin'];
        //var getPupilsList = [];
        $scope.getPupilsList = function ()
        {
            var id = document.URL.split("group/")[1];
            for (var i = 0; i < data.length; i++)
            {
                if (data[i].Id == id)
                    return data[i].ViewPupils;
            }
        }
    });
}]);