myApp.controller('newsAdminController', ['$scope', 'newsService', 'uiGridConstants', function ($scope, newsService, uiGridConstants) {

    $scope.announcmentGrid =
            {
                showGridFooter: true,
                enableFiltering: true,
                columnDefs: [
           {
               field: "№ ",
               cellTemplate: '<div class="ui-grid-cell-contents">{{grid.renderContainers.body.visibleRowCache.indexOf(row)+1}}</div>',
               width: "35",
               enableSorting: false,
               enableFiltering: false,
               enableHiding: false,
               enableColumnMenu: false
           },
           {
               displayName: "Заголовок",
               field: 'Title',
               enableFiltering: true,
               width: "250",
               sortingAlgorithm: function (a, b) {
                   return a.localeCompare(b)
               },
               enableHiding: false,
               enableColumnMenu: false
           },
           {
               name: 'Короткий опис',
               field: 'Message',
               enableFiltering: true,
               enableSorting: false,
               enableHiding: false,
               enableColumnMenu: false
           },

           {
               name: "Дата",
               field: "DataPublished",
               width: "100",
               enableHiding: false,
               enableColumnMenu: false,
               cellFilter: 'date:\'yyyy-MM-dd\''

           },
           {
               name: "Опції",
               field: "Details",
               width: "60",
               cellTemplate: '<div ng-controller="announcementModalService"><a title="Редагувати" href="" ng-click="showAnnouncementEditPage(row.entity)" ><img src="/Layouts/Images/edit.png"></a> ' +
                             '<a title="Видалити" href="" ng-click="showAnnouncementDeletePage(row.entity.Id, row.entity.Title)" ><img src="/Layouts/Images/remove.png"></a></div>',
               enableFiltering: false,
               enableSorting: false,
               enableHiding: false,
               enableColumnMenu: false

           },

                ],
                onRegisterApi: function (gridApi) {
                    $scope.grid2Api = gridApi;
                }
            };

    newsService.getNews().success(function (data) {
        $scope.announcmentGrid.data = data;
    });
}

]);