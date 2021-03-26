$(document).ready(function () {
    GetAllTokensContinuously();
});
function GetAllTokensContinuously() {
    setInterval(GetAllTokens, 500);
}
function GetAllTokens() {
    $.ajax({
        url: "http://localhost:5000/api/Trade/GetAllTokens",
        type: "GET",
        success: function (response) {
            $("table tbody").empty()
            for (var i = 0; i < response.length; i++) {
                $("table tbody").append(
                    `<tr>
                        <td><span style="color:red">${response[i].first}</span> <span style="color:green">${response[i].second}</span></td >
                        <td><span style="color:blue">${response[i].trades[0].price}</span></td >
                    </tr>
                    `
                )
            }
        }
    })
}
