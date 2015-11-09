//myApp.controller('groupsController', function ($scope, groups) {
//    groups.success(function (data) {
//        $scope.listGroups = data;
//    });
//});
myApp.controller('groupsController', ['$scope', 'groups', 'uiGridConstants', function ($scope, groups, uiGridConstants)
{
    $scope.text = "Groups:";

    $scope.groupsGrid = {
        showGridFooter: true,
        columnDefs: [
   {
       displayName:"No",
       field: 'NameNumber',
       width: "50",
       cellFilter: 'number',
       sort: {
           direction: uiGridConstants.ASC,
           priority: 1
       }
   },
   {
       field: 'NameLetter',
       width: "50"
   },
   {
       field: "Teacher"
   },
   {
       field: "PupilsAmount"
   }
        ],
        onRegisterApi: function (gridApi) {
            $scope.grid2Api = gridApi;
        }
    };

    groups.success(function (data) {
        $scope.groupsGrid.data = data;
    });

}
]);