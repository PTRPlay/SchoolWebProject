myApp.controller('ScheduleDirectiveController', ['$scope',function ($scope) {

    $scope.AddEvent = function () {
        $("td").dblclick(function () {
            var OriginalContent = $(this).text();
            $(this).addClass("cellEditing");
            $(this).html("<input type='text' value='" + OriginalContent + "' />");
            $(this).children().first().focus();

            $(this).children().first().keypress(function (e) {
                if (e.which == 13) {
                    var newContent = $(this).val();
                    $(this).parent().text(newContent);
                    $(this).parent().removeClass("cellEditing");
                }
            });

            $(this).children().first().blur(function () {
                $(this).parent().text(OriginalContent);
                $(this).parent().removeClass("cellEditing");
            });
        });
    };

    $scope.InitializeAutocomplate = function () {
        $('#TeacherFilter').autocomplete({
            source: function (request, response) {
                var filter = request.term;
                $.ajax(
                {
                    url: 'api/teacher?filter=' + filter,
                    dataType: "json",
                    success: function (data) {
                        response($.map(data, function (item) {
                            return {
                                label: item.FirstName + " " + item.MiddleName + " " + item.LastName,
                                value: item.FirstName + " " + item.MiddleName + " " + item.LastName
                            }
                        }));
                    }
                });
            }
        });
    }
}])