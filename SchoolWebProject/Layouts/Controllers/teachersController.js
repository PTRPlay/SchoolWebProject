/*myApp.controller('teachersController', ['$scope', 'teachers', function ($scope, teachers) {
    teachers.success(function (data) {
        $scope.teachers = data;
    });
}
]);*/

myApp.controller('teachersController', ['$scope', 'teachers', function ($scope, teachers) {
    $scope.teachersGrid = {
        showGridFooter: true,
        columnDefs: [
   {
       field: 'LastName'
   },
   {
       field: 'FirstName'
   },
   {
       field: "MiddleName"
   },
   {
       field: "CategoryName"
   },
   {
       field: "Profile",
       cellTemplate: '<div><a ng-href="#/teacher/{{row.entity.Id}}" style="width: 70px;">Profile</a></div>',
       width: "80",
       enableFiltering: false,
       enableSorting: false
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
