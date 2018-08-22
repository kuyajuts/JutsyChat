$(function () {

    $("#usernameModal").modal('show');

    $("#btnSetHandler").click(function () {

        var chatHandle = $("#txtChatHandle").val();
        
        if (chatHandle.length >= 0) {
            var tryToConnect = connectToHub(chatHandle);

            if (tryToConnect == "OK") {
                $("#usernameModal").modal('toggle');
            }
        }

    });



});