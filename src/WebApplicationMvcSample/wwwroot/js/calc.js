(function () {

    // Format days in a nice way
    function formatResult(result) {
        return result.toUpperCase();
    }

    var $loader = $("#loader");
    $loader.hide();

    $("form").on("submit", function formSubmit(event) {
        // Prevent default submiy
        event.preventDefault();

        // Get data from form
        var a = $("#a").val();
        var b = $("#b").val();
        var o = $("#o").val();

        // Ask server for calculation
        $loader.show();
        $.getJSON("/api/calculator/", { a: a, b: b, o: o }).then(function renderResult(result) {
            $loader.hide();

            $("#output").text(formatResult(result));
        }, function (error) {
            throw new Error(error.responseJSON.ExceptionMessage);
        });
    });
}());