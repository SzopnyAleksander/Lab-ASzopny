(function (){
    var txtMessage = $('#txtMessage')  
    var btnSend = $('#btnSend') 
    var listMessages = $('#listMessages') 
    var connection = new signalR.HubConnectionBuilder().withUrl('/chat').build();
    var userName = $('#userName').val();

    $(btnSend).click(function () {
        var userMessage = $(txtMessage).val();

        connection.invoke('SendMessage', {
            userName: userName,
            message: userMessage
        }).catch(function (error) {
            alert("Can't send the message.");
            console(error);
        })
        $(txtMessage).val('');
    });

    connection.start().then(function (){
        console.log('Connected to the signalr hub.');
        $(btnSend).removeAttr('disabled');

        connection.invoke('RegisterUser', userName).catch(function (error)
        {
            console.error(error);
            alert("Can't join to the conversation");
        });
    })

    connection.on('ReceiveMessage', function (obj) {
        $(listMessages).prepend('<li>('
            + obj.timeStampString + ') '
            + '<span class="font-weight-bold"> ' + obj.username
            + '</span>: ' +obj.message
            + '</li>')
        
    })

    connection.on('UserJoined', function (userName) {
        $(listMessages).prepend('<li class="font-weight-bold text-success">User ' + userName
            + ' joined to the conversation.</li > ')

    })

}) ();