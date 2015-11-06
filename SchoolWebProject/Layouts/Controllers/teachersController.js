/*myApp.controller('teachersController', ['$scope', 'teachers', function ($scope, teachers) {
    teachers.success(function (data) {
        $scope.teachers = data;
    });
}
]);*/

myApp.controller('teachersController', ['$scope', 'teachers', function ($scope, teachers) {
    $scope.text = "Teachers:";

    $scope.teachersGrid = {
        showGridFooter: true,
        columnDefs: [
   {
       field: 'firstName'
   },
   {
       field: 'lastName'
   },
   {
       field: "phoneNumber"
   },
   {
       field: "category"
   }
        ],
        onRegisterApi: function (gridApi) {
            $scope.grid2Api = gridApi;
        }
    };

    teachers.success(function (data) {
        $scope.teachersGrid.data = data;
    });

}
]);
