﻿myApp.controller('journalController', ['$scope', 'journalService', 'subjects', 'groups', 'uiGridConstants', '$rootScope',function ($scope, journalService, subjects, groups, uiGridConstants, $rootScope) {

    $scope.chosenSubject = null;
    $scope.chosenGroup = null;
    $scope.journalGrid = {
        showGridFooter: true,
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
        if (chosenGroup != null && chosenSubject != null)
            journalService.getPage(chosenSubject, chosenGroup).success(function (data) {
                $scope.journalGrid.columnDefs = [{
                    field: "№ ",
                    cellTemplate: '<div class="ui-grid-cell-contents">{{grid.renderContainers.body.visibleRowCache.indexOf(row)+1}}</div>',
                    width: "50",
                    pinnedLeft: true,
                    enableCellEdit: false,
                    enableFiltering: false,
                },
        {
            name: "Учень",
            field: "name",
            width: "200",
            pinnedLeft: false,
            enableCellEdit: false,
            enableFiltering: false
        }];
                pupilsMarks = [];
                $scope.data = data;
                fillMarks();
                for (var i = 0; i < $scope.data.LessonDetails.length; ++i) {
                    $scope.journalGrid.columnDefs.push({
                        name: parseDate($scope.data.LessonDetails[i].Date),
                        headerCellTemplate: '<div ng-controller="lessondetailController" class="ui-grid-header-cell" ng-click="getLessonDetails(col.field)">{{col.name}}</div>',
                        field: $scope.data.LessonDetails[i].Id.toString(),
                        width: "*",
                        pinnedLeft: false,
                        enableCellEdit: false,
                        enableFiltering: false,
                        enableSorting: false
                    });
                }
                $scope.journalGrid.data = pupilsMarks;
            });
    }

    subjects.success(function (data) {
        $scope.subjectsOptions = data;
    });

    groups.success(function (data) {
        $scope.groupsOptions = data;
    });
}])