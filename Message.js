﻿/**
 * Kandy.io Call Demo
 * View this tutorial and others at https://developer.kandy.io/tutorials
 */

// Variables for logging in.
var projectAPIKey = "DAKd4c504c893dd4d34884a4bb641c6982b";
var username = "user1@1yalcinsahin1.gmail.com";
var password = "1namvoluptasquia1";

// Setup Kandy to make and receive calls.
kandy.setup({
    // Designate HTML elements to be our stream containers.
    remoteVideoContainer: document.getElementById("remote-container"),
    localVideoContainer: document.getElementById("local-container"),

    // Register listeners to call events.
    listeners: {
        callinitiated: onCallInitiated,
        callincoming: onCallIncoming,
        callestablished: onCallEstablished,
        callended: onCallEnded
    }
});

// Login automatically as the application starts.
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

// Variable to keep track of video display status.
var showVideo = true;

// Get user input and make a call to the callee.
function startCall() {
    var callee = document.getElementById("callee").value;
    document.getElementById("btn-chat").disabled = false;
    // Tell Kandy to make a call to callee.
    kandy.call.makeCall(callee, showVideo);
}

// Variable to keep track of the call.
var callId;

// What to do when a call is initiated.
function onCallInitiated(call, callee) {
    log("Call initiated with " + callee + ". Ringing...");

    // Store the call id, so the caller has access to it.
    callId = call.getId();

    // Handle UI changes. A call is in progress.
    document.getElementById("make-call").disabled = true;
    document.getElementById("end-call").disabled = false;
}

// What to do for an incoming call.
function onCallIncoming(call) {
    log("Incoming call from " + call.callerNumber);

    // Store the call id, so the callee has access to it.
    callId = call.getId();

    // Handle UI changes. A call is incoming.
    document.getElementById("accept-call").disabled = false;
    document.getElementById("decline-call").disabled = false;
}

// Accept an incoming call.
function acceptCall() {
    // Tell Kandy to answer the call.
    kandy.call.answerCall(callId, showVideo);
    // Second parameter is false because we are only doing voice calls, no video.

    log("Call answered.");
    var callee = document.getElementById("callee").value;
    document.getElementById("user").innerHTML += "<td>" + callee + "</td>";
    // Handle UI changes. Call no longer incoming.
    document.getElementById("accept-call").disabled = true;
    document.getElementById("decline-call").disabled = true;
}

// Reject an incoming call.
function declineCall() {
    // Tell Kandy to reject the call.
    kandy.call.rejectCall(callId);

    log("Call rejected.");
    // Handle UI changes. Call no longer incoming.
    document.getElementById("accept-call").disabled = true;
    document.getElementById("decline-call").disabled = true;
}

// What to do when call is established.
function onCallEstablished(call) {
    log("Call established.");

    // Handle UI changes. Call in progress.
    document.getElementById("make-call").disabled = true;
    document.getElementById("mute-call").disabled = false;
    document.getElementById("hold-call").disabled = false;
    document.getElementById("end-call").disabled = false;
}

// End a call.
function endCall() {
    // Tell Kandy to end the call.
    kandy.call.endCall(callId);
}

// Variable to keep track of mute status.
var isMuted = false;

// Mute or unmute the call, depending on current status.
function toggleMute() {
    if (isMuted) {
        kandy.call.unMuteCall(callId);
        log("Unmuting call.");
        isMuted = false;
    } else {
        kandy.call.muteCall(callId);
        log("Muting call.");
        isMuted = true;
    }
}

// Variable to keep track of hold status.
var isHeld = false;

// Hold or unhold the call, depending on current status.
function toggleHold() {
    if (isHeld) {
        kandy.call.unHoldCall(callId);
        log("Unholding call.");
        isHeld = false;
    } else {
        kandy.call.holdCall(callId);
        log("Holding call.");
        isHeld = true;
    }
}

// What to do when a call is ended.
function onCallEnded(call) {
    log("Call ended.");

    // Handle UI changes. No current call.
    document.getElementById("make-call").disabled = false;
    document.getElementById("mute-call").disabled = true;
    document.getElementById("hold-call").disabled = true;
    document.getElementById("end-call").disabled = true;

    // Call no longer active, reset mute and hold statuses.
    isMuted = false;
    isHeld = false;
}

// Show or hide video, depending on current status.
function toggleVideo() {
    if (showVideo) {
        kandy.call.stopCallVideo(callId);
        log("Stopping send of video.");
        showVideo = false;
    } else {
        kandy.call.startCallVideo(callId);
        log("Starting send of video.");
        showVideo = true;
    }
}

