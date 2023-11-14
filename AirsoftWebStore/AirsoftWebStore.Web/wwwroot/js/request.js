"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/requestHub").build();

// Testing if connection is established
connection.start().then(function () {
    console.log("SignalR Connected!");
}).catch(function (err) {
    return console.error(err.toString());
});

connection.on("ReceiveMessage", function (message) {
    /*Display in the TempData with SuccessMessage*/
});

document.getElementById("requestBtn").addEventListener("click", function () {
    connection.invoke("SendMessage", "You have received a Gunsmith request from a user!").catch(function (err) {
        return console.error(err.toString());
    });
});