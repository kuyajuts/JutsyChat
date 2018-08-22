var jutsyChat = $.connection.chatHub;
var jutsyEstablished = false;


jutsyChat.client.DisplayMessage = function (handler, message, background) {
    var encodedHandlerName = $('<div />').text(handler).html();
    var encodedMessage = $('<div />').text(message).html();
    var encodedChatColor = $('<div />').text(backgroundColor).html();

    $('.thread').prepend('<div class="bubble" style="background-color:"' + encodedChatColor + '"><p>'
        + encodedHandlerName
        + '</strong>:&nbsp;&nbsp;' + encodedMessage + '</p></div>');
}




function connectToHub(handler) {
    $.connection.hub.start().done(function () {
        jutsyEstablished = true;

        jutsyChat.server.join(handler).done(function () {
            jutsyChat.server.getActiveChatmates().done(function (connectedUsers) {
                $.map(connectedUsers, function (user) {
                    $(".connectedUsers").append("<li>" + user.Handle + "</li>");
                });

                jutsyChat.server.Send(handler, " has joined Jutsy.", "#900000");


            });

        });
    });

    return "OK";

}

function Receive(handler, message, backgroundColor) {

    if (jutsyEstablished) {

    }

}