

myApp.controller('journalController', ['$scope', 'journalService', 'subjects', 'groups', 'uiGridConstants', function ($scope, journalService, subjects, groups, uiGridConstants) {


    $scope.chosenSubject = null;
    $scope.chosenGroup = null;

    $scope.columns = [];
    $scope.journalGrid = {
        columnDefs: $scope.columns,
        onRegisterApi: function (gridApi) {
            $scope.gridApi = gridApi;
        }
    };

    function PushColumns(date) {
        for (var i = 0; i < (date.length + 3) ; i++) {
            if (i === 0) {
                $scope.columns.push(
                  {
                      field: "№ ",
                      cellTemplate: '<div class="ui-grid-cell-contents">{{grid.renderContainers.body.visibleRowCache.indexOf(row)+1}}</div>',
                      width: "50",
                      pinnedLeft: true
                  })
            }
            else if (i === 1) {
                $scope.columns.push(
                  {
                      name: "Last Name",
                      field: 'Pupil.LastName',
                      width: 100,
                      pinnedLeft: true,
                      enableCellEdit: false
                  })
            }
            else {
                $scope.columns.push(
                                {
                                    name: " " + date[(i - 2)].slice(0, 10),
                                    field: "$scope.journalGrid.data[date[i].slice(0, 10)]",
                                    width: 100,
                                    enableCellEdit: false
                                })
            }
        }
    }


    var JournalRowObjecr = {};

    function CreateObject(data, date) {
        for (var i = 0; i < data.Pupils.length; i++) {
            JournalRowObjecr[Id] = data.Pupils[i][Id];
            JournalRowObjecr[Name] = data.Pupils[i].LastName;
            for (var d = 0; d < date.length; d++) {
                for (var j = 0; j < data.Mark.length; j++) {
                    if (data.Mark[j].LessonDetail[Date] == date[i]) {
                        JournalRowObjecr[date[d].slice(0, 10)] = Mark[j].Value;
                    }
                }
            }
            $scope.journalGrid.data.push(JournalRowObjecr);

        }
    }





    $scope.GetJournalPage = function (chosenGroup, chosenSubject) {
        if (chosenGroup != null && chosenSubject != null)
            journalService.getPage(chosenGroup, chosenSubject).success(function (data) {
                $scope.date = data.getDate();
                CreateObject(data, $scope.date);
                PushColumns($scope.journalGrid.data);
            });
    }

    Object.prototype.getDate = function () {
        var arr = [];
        for (var i = 0; i < this.LessonDetails.length; i++) {
            arr.push(this.LessonDetails[i].Date);
        }
        return arr;
    }

    subjects.success(function (data) {
        $scope.subjectsOptions = data;
    });

    groups.success(function (data) {
        $scope.groupsOptions = data;
    });
}])