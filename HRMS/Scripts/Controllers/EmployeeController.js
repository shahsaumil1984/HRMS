/// <reference path="../jquery-1.10.2.min.js" />
/// <reference path="../jquery-1.10.2.min.js" />
// Event Handlers
//----------------------------------------------
$(document).ready(function () {

    _.Initialize(function (status, msg) {
        
    });

   
});

function EmployeeNewCallback(status, data) {    
    $("#employeeListView").hide();
    $("#employeeDetailsWindow").show();
}


function GetDesignationDetails(status, data) {
    debugger;    
    alert("Hello");

    
}


//function () {
//    $("#insert").text("");
//    $('#form_add')[0].reset();
//    $("form div").removeClass("error");
//    $("form label").removeClass("error"); 
//    $("form")[0].reset()
//    $('#addPopup').foundation("reveal", "close");