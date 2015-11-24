$(document).ready(function () {
    $('#Filter').autocomplete({
        source: function (request, response) {
            var searchParam = request.term;

            $.ajax({
                data: searchParam,
                url: 'api/teacher/?filter=' + searchParam,
                dataType: "json",
                type: "GET",
                success: function (data) {
                    response($.map(data, function (item) {
                        return {
                            label:item.FirstName+" "+item.MiddleName+" "+item.LastName,
                            value: item.FirstName + " " + item.MiddleName + " " + item.LastName
                        };
                    }));
                }
            });
        },
        maxItemsToShow: 5
    });
});