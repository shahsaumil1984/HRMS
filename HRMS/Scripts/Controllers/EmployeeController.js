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

_.ResetForm = function () {    
    $("label").remove(".error");
    $("span").remove(".error");
    
    FormBinder.HideForm(true);
}

_.CheckEmployeeCode = function (EmpCode) {

    employeeService.CheckEmployeeCode('EmpCode=' + EmpCode, function (status, data) {
        if (status && data) {
            var html = "<label id='EmpCodeError' class='error'>The entered Employee Code already exists.</label>";
            $('#empcode').after(html);
        }
        else if (status && !data)
        {
            $('#EmpCodeError').remove();
        }
    });
}

function Validate() {
    //UserInterfaceBinder.CheckEmployeeCode($('#empcode').val());
    employeeService.CheckEmployeeCode('EmpCode=' + $('#empcode').val(), function (status, data) {
        if (status && data) {
            var html = "<label id='EmpCodeError' class='error'>The entered Employee Code already exists.</label>";
            $('#empcode').after(html);
            return false;
        }
        else if (status && !data) {
            $('#EmpCodeError').remove(); 
            return true;
        }
        else
            return false;
    });
}







