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
<<<<<<< HEAD
       field: "CategoryName"
=======
       field: "Category"
   },
   {
       field: "Profile",
       cellTemplate: '<div><a ng-href="#/teacher/{{row.entity.Id}}" style="width: 70px;">Profile</a></div>',
       width: "80",
       enableFiltering: false,
       enableSorting: false
>>>>>>> 80611c5717fcf31ee5d254bb047e91b98e1440a5
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
