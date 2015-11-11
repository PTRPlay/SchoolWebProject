/*myApp.controller('teachersController', ['$scope', 'teachers', function ($scope, teachers) {
    teachers.success(function (data) {
        $scope.teachers = data;
    });
}
]);*/

myApp.controller('teachersController', ['$scope', 'teachers','uiGridConstants', function ($scope, teachers, uiGridConstants) {
    $scope.highlightFilteredHeader = function( row, rowRenderIndex, col, colRenderIndex ) {
        if( col.filters[0].term ){
            return 'header-filtered';
        } else {
            return '';
        }
    };
    $scope.teachersGrid = {
        showGridFooter: true,
        enableFiltering:true,
        columnDefs: [
   {
       enableFiltering: false,
       field: 'LastName',
       displayName:'Призвіще'

   },
   {
       enableFiltering: false,
       field: 'FirstName',
       displayName: 'Ім`я'
   },   
   {
       enableFiltering:false,
       field: "MiddleName",
       displayName:'По-батькові'
   },
   {
       enableFiltering:true,
       field: "Category.Name",
       displayName:'Категорія',
       filter: {
           type: uiGridConstants.filter.SELECT,
           selectOptions: [
                            { value: 'спеціаліст вищої категорії', label: 'спеціаліст вищої категорії' },
                            { value: 'спеціаліст другої категорії', label: 'спеціаліст другої категорії' },
                            { value: 'спеціаліст першої категорії', label: 'спеціаліст першої категорії' }
                          ]
       },
   },
   {
       field: "Profile",
       displayName: 'Профіль',
       cellTemplate: '<div><a ng-href="#/teacher/{{row.entity.Id}}" style="width: 70px;">Profile</a></div>',
       width: "80",
       enableFiltering: false,
       enableSorting: false 
   },
   {
       enableFiltering: true,
       field: "Subjects[0].Name",
       displayName: 'Предмет',

   }

        ],
        onRegisterApi: function (gridApi) {
            $scope.grid2Api = gridApi;
        }
    };

    teachers.success(function (data) {
        $scope.teachersGrid.data = data;
    })
    $scope.toggleFiltering = function(){
        $scope.gridOptions.enableFiltering = !$scope.gridOptions.enableFiltering;
        $scope.gridApi.core.notifyDataChange(uiGridConstants.dataChange.COLUMN);
        
    };
}])