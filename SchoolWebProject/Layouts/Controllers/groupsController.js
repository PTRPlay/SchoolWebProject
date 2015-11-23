myApp.controller('groupsController', ['$scope', 'groups', 'uiGridConstants', 'GroupModalService',
    function ($scope, groups, uiGridConstants, GroupModalService)
{
    $scope.text = "All Groups:";

    $scope.groupsGrid =
        {
        showGridFooter: true,
        columnDefs: [
   {
       displayName:"No",
       field: 'NameNumber',
       width: "50",
       type: 'number',
       sort:
           {
                direction: uiGridConstants.ASC,
                priority: 1
           }
   },
   {
       field: 'NameLetter',
       width: "50"
   },
   {
       field: "TeacherName",
       sortingAlgorithm: function (a, b)
       {
           return a.localeCompare(b)
       }
   },
   {
       field: "PupilsAmount",
       type: 'number',
       width: "150"
   },
   {
       field: "Details",
       cellTemplate: '<div><a class="btn btn-success btn-sm" ng-href="#/group/{{row.entity.Id}}" style=" width: 70px;" >Details</a></div>',
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
        onRegisterApi: function (gridApi)
        {
            $scope.grid2Api = gridApi;
        }
    };

    $scope.addGroup = function ()
    {
        GroupModalService.showGroupEditPage();
    };

    $scope.editGroup = function (value)
    {
        GroupModalService.showGroupEditPage(value);
    };

    $scope.deleteGroup = function (id, nameNumber, nameLetter)
    {
        var val = { id: id, nameNumber:nameNumber, nameLetter:nameLetter };
        GroupModalService.showGroupDeleteModal(val);
    };

    groups.success(function (data)
    {
        $scope.groupsGrid.data = data;
<<<<<<< HEAD
=======
        //$scope.listGroups = data;
>>>>>>> e17e600b6b6176217a925e7c960a5d4dcca1cf81
    });

    //ng-click="grid.appScope.deleteHandler(row.entity.LastName)"
    //ng-click="grid.appScope.editHandler(row.entity.LastName)"
}

]);