

myApp.controller('journalController', ['$scope', 'markService','subjects','groups', 'uiGridConstants', function ($scope, markService,subjects,groups, uiGridConstants) {
    
   
    $scope.chosenSubject=null;
    $scope.chosenGroup=null;

    $scope.journalGrid = {
        showGridFooter: true,
        enableFiltering: true,
        columnDefs: [
   {
       field: "№ ",
       cellTemplate: '<div class="ui-grid-cell-contents">{{grid.renderContainers.body.visibleRowCache.indexOf(row)+1}}</div>',
       width: "50",
       pinnedLeft: true,
       enableCellEdit: false,
       enableFiltering: false,
   }

        ],
        onRegisterApi: function (gridApi) {
            $scope.gridApi = gridApi;
        }

    };

    $scope.GetJournalPage = function (chosenSubject,chosenGroup)
    {
        if (chosenGroup != null && chosenSubject != null)
            markService.getPage(chosenSubject, chosenGroup).success(function (data) {
                $scope.journalGrid.data = data;
            });
    }

    subjects.success(function (data) {
        $scope.subjectsOptions = data;
    });

    groups.success(function (data) {
        $scope.groupsOptions = data;
    });
}])