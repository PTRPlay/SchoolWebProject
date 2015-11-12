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
       type: 'number',
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
       field: "PupilsAmount",
       type: 'number'
   },
   {
       field: "Details",
       cellTemplate: '<div><button class="btn btn-success btn-sm" style=" width: 70px;" >Details</button></div>',
       width: "80",
       enableFiltering: false,
       enableSorting: false
   },
   {
       field: "Edit",
       cellTemplate: '<div><button class="btn btn-primary btn-sm" style=" width: 70px; " >Edit</button></div>',
       width: "80",
       enableFiltering: false,
       enableSorting: false
   },
   {
       field: "Delete",
       cellTemplate: '<div><button class="btn btn-danger btn-sm" style=" width: 70px;" >Delete</button></div>',
       width: "80",
       enableFiltering: false,
       enableSorting: false
   }
        ],
        onRegisterApi: function (gridApi) {
            $scope.grid2Api = gridApi;
        }
    };

    groups.success(function (data) {
        $scope.groupsGrid.data = data;
    });
    //ng-click="grid.appScope.deleteHandler(row.entity.LastName)"
    //ng-click="grid.appScope.editHandler(row.entity.LastName)"
}
]);