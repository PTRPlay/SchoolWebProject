myApp.controller('scheduleController', function ($scope,$http,schedule) {
    schedule.success(function (data) {
        $scope.schedule = data;
    })

    $(document).ready(function () {
        $('#teacherFilter').autocomplete({
            source: function(request, response){
                var searchParam  = request.term;

                $.ajax({
                    url: 'api/teacher',
                    dataType: "json",
                    data: searchParam,
                    type: "GET",
                    success: function (data) {
                        response($.map(data, function(item) {
                            for (var i = 0; i < item.length; i++){
                                if (item[i].FirstName.indexOf(searchParam) < 0)
                                    item.splice(i,1);
                            }
                            return {
                                label: item.FirstName,
                                value: item.FirstName
                            };
                        }));
                    }
                });
            },
            maxItemsToShow: 5
        });
    });
});
