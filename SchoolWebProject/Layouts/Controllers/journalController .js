

myApp.controller('journalController', ['$scope','$timeout', 'markService', function ($scope,$timeout, markService) {
    $scope.text = "Journal Group";

    $scope.journalGrid = { enableSorting: false };

    var quontutyOfLesson = 23;
    var quontityOfPupil = markService.Count;

    $scope.journalGrid.columnDefs = [
   {
       field: "№ ",
       cellTemplate: '<div class="ui-grid-cell-contents">{{grid.renderContainers.body.visibleRowCache.indexOf(row)+1}}</div>',
       width: "50",
       pinnedLeft: true,
       enableCellEdit: false
   },
    {
        name: "First Name",
        field: 'Pupil.FirstName',
        width: 100,
        pinnedLeft: true,
        enableCellEdit: false
    },
        {
            name: "Last Name",
            field: 'Pupil.LastName',
            width: 200,
            pinnedLeft: true,
            enableSorting: true,
            enableCellEdit: false
        }
    ];

    var mas;

    markService.success(function (data) {
        $scope.journalGrid.data = data;
        mas = data;
    });
     var row = {};
    $timeout(function () {
        for (var colIndex = 0; colIndex < quontutyOfLesson; colIndex++) {
            $scope.journalGrid.columnDefs.push({
                name: '' + mas[0].Date.slice(5, 10) + colIndex,
                width: 100
            });
        }
    });

    $timeout(function () {
        for (var rowIndex = 0; rowIndex < quontityOfPupil; rowIndex++) {
           

            for (var colIndex = 0; colIndex < quontutyOfLesson; colIndex++) {
                row['col' + colIndex] = 'r' + rowIndex + 'c' + colIndex;
            }
            $scope.journalGrid.data.push(row);
        }

    });

}]);