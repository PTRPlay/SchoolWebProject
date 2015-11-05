myApp.controller('pupilsController', ['$scope', 'pupils', function ($scope, pupils) {
    $scope.tField = "Fuckkk yeah!!!";

    $scope.teachersGrid = {
        showGridFooter: true,
        columnDefs: [
            {
                field: 'name'
            }
        ],
        onRegisterApi: function (gridApi) {
            $scope.grid1Api = gridApi;
        }
    };
    
    teachers.success(function (data) {
        $scope.pupils = data;
    });
}
]);
