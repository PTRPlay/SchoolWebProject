myApp.controller('pupilsController', ['$scope', 'pupils', 'uiGridConstants', function ($scope, pupils, uiGridConstants) {
    $scope.text = "List of pupils:";
    
    $scope.pupilsGrid = {
        showGridFooter: true,
        enableSorting: true,
        enableFiltering: true,

        columnDefs: [
   {
       name: "numb",
       field: "№ ",
       cellTemplate: '<div class="ui-grid-cell-contents">{{grid.renderContainers.body.visibleRowCache.indexOf(row)+1}}</div>',
       width: 40,
       enableSorting: false,
       enableFiltering: false,
   },
   {
       name: "LastName",
       field: "LastName",
       sort: {
           direction: uiGridConstants.ASC,
           priority: 1
       }
   },
   {
       field: "FirstName",
       enableSorting:false,
       enableFiltering: false
   },
   {
       field: "PhoneNumber",
       enableFiltering: false,
       enableSorting: false,
   },
   {
       field: "Address",
       enableFiltering: false,
       enableSorting: false,
   },
   {
       field: "Email",
       enableFiltering: false,
       enableSorting: false,
   },
   {
       field: "Edit",
       cellTemplate: '<div><button ng-click="grid.appScope.editHandler(row.entity.LastName)">Edit</button></div>',
       enableFiltering: false,
       enableSorting: false
   },
   {
       field: "Delete",
       cellTemplate: '<div><button ng-click="grid.appScope.deleteHandler(row.entity.LastName)">Delete</button></div>',
       enableFiltering: false,
       enableSorting: false
   }
     ],
        onRegisterApi: function (gridApi) {
            $scope.grid1Api = gridApi;
        }
    };
    
    $scope.editHandler = function (value) {
        alert('Editing ' + value + ' !');
    };

    $scope.deleteHandler = function (value) {
        alert('Wanna delete ' + value + ' ?');
    };

    pupils.success(function (data) {
        $scope.pupilsGrid.data = data;
    });
    
}
]);
