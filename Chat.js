/**
 * Kandy.io Chat Messages Demo
 * View this tutorial and others at https://developer.kandy.io/tutorials
 */

// Variables for logging in.
var projectAPIKey = "DAKd4c504c893dd4d34884a4bb641c6982b";
var username = "user1@1yalcinsahin1.gmail.com";
var password = "1namvoluptasquia1";

// Setup Kandy to receive messages.
kandy.setup({
    listeners: {
        message: onMessageReceived
    }
});

kandy.login(projectAPIKey, username, password, onLoginSuccess, onLoginFailure);

// What to do on a successful login.
function onLoginSuccess() {
    log("Login was successful.");
}

// What to do on a failed login.
function onLoginFailure() {
    log("Login failed. Make sure you input the user's credentials!");
}

// Utility function for appending messages to the message div.
function log(message) {
    document.getElementById("messages").innerHTML += "<div>" + message + "</div>";
}

// Gathers the user's input and sends a message to the recipient.
function sendMessage() {
    var recipient = document.getElementById("callee").value;
    var message = document.getElementById("btn-input").value;

    kandy.messaging.sendIm(recipient, message, onSendSuccess, onSendFailure);
}

// What to do on a successful send message.
function onSendSuccess(message) {
    // Display the message as outgoing.
    var recipient = message.destination.split("@")[0];
    // Create the message element. Use Lodash to escape the message for security purposes.
    var element = "<div>Outgoing (" + recipient + "): " + escape(message.message.text) + "</div>";
    document.getElementById("messages").innerHTML += element;
}

// What to do on a failed send message.
function onSendFailure() {
    log("Send Message failed.");
}

/**
 * Called when the `message` event is triggered.
 * Receives the message object as a parameter.
 */
function onMessageReceived(message) {
    // Display the message as incoming.
    var sender = message.sender.user_id;
    // Create the message element. Use Lodash to escape the message for security purposes.
    var element = "<div>Incoming (" + sender + "): " + escape(message.message.text) + "</div>"
    document.getElementById("messages").innerHTML += element;
}