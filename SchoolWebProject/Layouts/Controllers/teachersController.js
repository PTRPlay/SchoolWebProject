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
       field: 'LastName'
   },
   {
       enableFiltering: false,
       field: 'FirstName'
   },
   {
       enableFiltering:false,
       field: "MiddleName"
   },
   {
       enableFiltering:true,
       field: "Category.Name", filter: {
           //term: '1',
           type: uiGridConstants.filter.SELECT,
           selectOptions: [ { value: '1', label: 'спеціаліст' }, 
                            { value: '2', label: 'спеціаліст першої категорії' }, 
                            { value: '3', label: 'спеціаліст другої категорії'}, 
                            { value: '4', label: 'спеціаліст вищої категорії' } 
           ]
       },
       //cellFilter: 'mapGender', headerCellClass: $scope.highlightFilteredHeader 
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
    })
    $scope.toggleFiltering = function(){
        $scope.gridOptions.enableFiltering = !$scope.gridOptions.enableFiltering;
        $scope.gridApi.core.notifyDataChange( uiGridConstants.dataChange.COLUMN );
    };
}])
    .filter('mapGender', function () {
        var genderHash = {
            1: 'спеціаліст',
            2: 'спеціаліст першої категорії',
            3: 'спеціаліст другої категорії',
            4: 'спеціаліст вищої категорії'
        };
 
        return function(input) {
            if (!input){
                return '';
            } else {
                return genderHash[input];
            }
        };
    
 })
