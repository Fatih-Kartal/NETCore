$(document).ready(function () {
    GetAllTokens();
});

function GetAllTokens() {
    $.ajax({
        url: "http://localhost:5000/api/Trade/GetAllTokens",
        type: "GET",
        success: function (response) {
            console.log(data);
        }
    })
}
