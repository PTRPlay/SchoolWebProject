myApp.controller('pupilsController', ['$scope', 'pupils', function ($scope, pupils) {
    $scope.text = "List of pupils:";
    
    $scope.pupilsGrid = {
        showGridFooter: true,
        columnDefs: [
   {
       field: 'FirstName'
   },
   {
       field: 'LastName'
   },
   {
       field: "PhoneNumber"
   },
   {
       field: "Address"
   },
   {
       field: "Email"
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
