myApp.controller('pupilsController', ['$scope', 'pupils', 'uiGridConstants', function ($scope, pupils, uiGridConstants) {
    $scope.text = "List of pupils:";
    
    $scope.pupilsGrid = {
        showGridFooter: true,
        enableSorting: true,
        enableFiltering: true,

        columnDefs: [
   {
       field: 'LastName',
       sort: {
           direction: uiGridConstants.ASC,
           priority: 1
       },
   },
   {
       field: 'FirstName',
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
   }
     ],
        onRegisterApi: function (gridApi) {
            $scope.grid1Api = gridApi;
        }
    };
    
    pupils.success(function (data) {
        $scope.pupilsGrid.data = data;
    });
    
}
]);
