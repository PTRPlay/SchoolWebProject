﻿myApp.controller('journalController', ['$scope', 'journalService','permissionService', 'subjectsService', 'groupsService', 'pupilsService', 'lessonDetailService', 'uiGridConstants', '$rootScope', function ($scope, journalService,permissionService, subjectsService, groupsService, pupilsService, uiGridConstants, lessonDetailService, $rootScope) {

    $scope.chosenSubject = false;
    $scope.chosenGroup = false;
    isValidRoleForEditMark = false;
    $scope.isValidRoleForChooseGroupsForJournal = permissionService.isValidRoleForChooseGroupsForJournal();

    $("#group").ready(function () {
        SetGroupInDroupDawnList();
    });

    function SetGroupInDroupDawnList() {
        if ((permissionService.user.Role == "Pupil" || permissionService.user.Role == "Parent")) {
            pupilsService.getPupilById(permissionService.user.Id).success(function (data) {
                $scope.chosenGroup = data.GroupId;
                $scope.GetSubjectByGroupId($scope.chosenGroup);
            });
        }
    }


    $scope.journalGrid = {
        columnDefs: [],
        onRegisterApi: function (gridApi) {
            $scope.gridApi = gridApi;
        }

    };

    var pupilsMarks = [];
    
    var AddPupil = function (Pupil) {
        pupilsMarks.push({
            id: Pupil.Id,
            name: Pupil.LastName + ' ' + Pupil.FirstName
        });
    }


    var fillPupils = function () {
        for (var i = 0; i < $scope.data.Pupils.length; ++i) {
            AddPupil($scope.data.Pupils[i]);
        }
        for (var i = 0; i < pupilsMarks.length; ++i) {
            for (var j = 0; j < $scope.data.LessonDetails.length; ++j) {
                pupilsMarks[i][$scope.data.LessonDetails[j].Id.toString()] = null;
            }
        }
    }

    var getDateByLessonDetailId = function (id) {
        for (var i = 0; i < $scope.data.LessonDetails.length; ++i) {
            if (id == $scope.data.LessonDetails[i].Id) {
                return $scope.data.LessonDetails[i].Date.toString();
            }
        }
        return null;
    }

    var getLessonDetailByDate = function (date) {
        for (var i = 0; i < $scope.data.LessonDetails.length; ++i) {
            if (date == $scope.data.LessonDetail[i].Date) {
                return {
                    date: parseDate($scope.data.LessonDetail[i].Date),
                    theme: $scope.LessonDetail[i].HomeTask,
                    hometask: $scope.LessonDetail[i].Theme
                }
            }
        }
    }

    var fillMarks = function () {
        fillPupils();
        for (var i = 0; i < pupilsMarks.length; ++i) {
            for (var j = 0; j < $scope.data.Marks.length; ++j) {
                if ($scope.data.Marks[j].PupilId == pupilsMarks[i].id) {
                    pupilsMarks[i][$scope.data.Marks[j].LessonDetailId] = $scope.data.Marks[j].Value;
                }
            }
        }
    }

    var parseDate = function (date) {
        var arrdate = date.toString().slice(5, 10).split("-");
        return arrdate[1] + "/" + arrdate[0];
    }

    $scope.GetJournalPage = function (chosenSubject, chosenGroup) {
        if (chosenGroup != false && chosenSubject != false)
            journalService.getPage(chosenSubject, chosenGroup).success(function (data) {
                $scope.journalGrid.columnDefs = [{
                    field: "№ ",
                    cellTemplate: '<div class="ui-grid-cell-contents">{{grid.renderContainers.body.visibleRowCache.indexOf(row)+1}}</div>',
                    width: "50",
                    pinnedLeft: true,
                    enableCellEdit: false,
                    enableFiltering: false,
                    enableHiding: false,
                    enableColumnMenu: false
                },
        {
            name: "Учень",
            field: "name",
            width: "200",
            pinnedLeft: true,
            sortingAlgorithm: function (a, b) {
                return a.localeCompare(b)
            },
            enableCellEdit: false,
            enableFiltering: false,
            enableHiding: false,
            enableColumnMenu: false
        }];
                pupilsMarks = [];
                $scope.data = data;
                if (data.LessonDetails.length>0) {
                    isValidRoleForEditMark = permissionService.isValidRoleForEditMark(data.LessonDetails[0].TeacherId);
                } else isValidRoleForEditMark = (permissionService.user.Role=="Admin");
                fillMarks();
                for (var i = 0; i < $scope.data.LessonDetails.length; ++i) {
                    $scope.journalGrid.columnDefs.push({
                        name: parseDate($scope.data.LessonDetails[i].Date),
                        headerCellTemplate: '<div style=" transform: rotate(270deg);" ng-controller="lessondetailController" class="ui-grid-header-cell" ng-click="getLessonDetails(col.field)">{{col.name}}</div>',
                        field: $scope.data.LessonDetails[i].Id.toString(),
                        pinnedLeft: false,
                        enableCellEdit: isValidRoleForEditMark,
                        enableFiltering: false,
                        width: "60",
                        cellFilter: 'mapGender',
                        enableSorting: false,
                        editableCellTemplate: 'ui-grid/dropdownEditor', width: '*',
                        editDropdownOptionsArray: [
                        { id: 0, value: " " },
                        { id: 1, value: 1 },
                        { id: 2, value: 2 },
                        { id: 3, value: 3 },
                        { id: 4, value: 4 },
                        { id: 5, value: 5 },
                        { id: 6, value: 6 },
                        { id: 7, value: 7 },
                        { id: 8, value: 8 },
                        { id: 9, value: 9 },
                        { id: 10, value: 10 },
                        { id: 11, value: 11 },
                        { id: 12, value: 12 },
                        { id: 13, value: "н" }
                        ]
                    });
                }
                $scope.journalGrid.data = pupilsMarks;
            });
    }

    function GetMarkId(rowEntityName, colDefField)
    {
        var name=rowEntityName.split(" ");
        for (var i = 0; i < $scope.data.Marks.length; i++)
        {
            if ($scope.data.Marks[i].LessonDetailId == colDefField && $scope.data.Marks[i].FirstName == name[1] && $scope.data.Marks[i].LastName == name[0])
            { return $scope.data.Marks[i].Id; }
        }
    }

    $scope.journalGrid.onRegisterApi = function (gridApi) {
        $scope.gridApi = gridApi;
        gridApi.edit.on.afterCellEdit($scope, function (rowEntity, colDef, newValue, oldValue) {
            if (newValue != oldValue) {
                console.log('Mark Date: ' + colDef.field, rowEntity.name);
                var markId = GetMarkId(rowEntity.name, colDef.field);
                journalService.editMark(markId, newValue, rowEntity.id, colDef.field);
            }
        });
    };


   $scope.GetSubjectByGroupId=function(groupId)
   {
       subjectsService.getSujectForGroup(groupId).success(function (data) {
           $scope.parsedSubjectsOptions = data;
       });
    }

    groupsService.getGroups().success(function (data) {
        $scope.groupsOptions = data;
    });

}])

myApp.filter('mapGender', function () {
    var genderHash = {
        0: ' ',
        13: 'н'
    };

    return function (input) {
        if (input == 0 || input == 13) {
            return genderHash[input];
        }
        else return input;
        }
    
});