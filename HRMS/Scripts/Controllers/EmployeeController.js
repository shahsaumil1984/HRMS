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


_.CheckEmployeeCode = function (EmpCode) {

    employeeService.CheckEmployeeCode('EmpCode=' + EmpCode, function (status, data) {
        if (status && data) {
            var html = "<label class='error'>The entered Employee Code already exists.</label>";
            $('#empcode').after(html);
        }
    });
}

function Validate() {
    ub.CheckEmployeeCode($('#empcode').val());
}







