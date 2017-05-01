/// <reference path="../jquery-1.10.2.min.js" />
/// <reference path="../jquery-1.10.2.min.js" />
// Event Handlers
//----------------------------------------------
var dateOfJoining = "";
$(document).ready(function () {

    _.Initialize(function (status, msg) {
        
    });
     
    $("#em_DateOfjoining").datepicker({
        todayBtn: 1,
        autoclose: true,
        clearBtn: true
    }).on('changeDate', function (selected) {
        var minDate = new Date(selected.date.valueOf());
        $('#em_ProbationPeriodEndDate').datepicker('setStartDate', minDate);
    });

    $("#em_ProbationPeriodEndDate").datepicker({
        autoclose: true,
        clearBtn: true
    })
         .on('changeDate', function (selected) {

             if ($("#em_ProbationPeriodEndDate").val() == "") {
                 $("#em_DateOfjoining").val('');
                 $('#em_DateOfjoining').datepicker('setEndDate', null);
             } else {

                 var maxDate = new Date(selected.date.valueOf());
                 $('#em_DateOfjoining').datepicker('setEndDate', maxDate);
             }
         });



    //$("#em_ProbationPeriodEndDate").on("dp.change", function (e) {
    //    debugger;
    //    $("#em_DateOfjoining").data("DatePicker").minDate(e.date);
    //})

    $("#em_sameAsPermenent").change(function () {


        if ($("#em_sameAsPermenent").is(':checked')) {
            var PermanentAddressLine1 = employeeDetailsForm.GetValue("PermanentAddressLine1");
            var PermanentAddressLine2 = employeeDetailsForm.GetValue("PermanentAddressLine2");
            var PermanentAddressLine3 = employeeDetailsForm.GetValue("PermanentAddressLine3");
            var PermanentAddressCity = employeeDetailsForm.GetValue("PermanentAddressCity");
            var PermanentAddressState = employeeDetailsForm.GetValue("PermanentAddressState");
            var PermanentAddressCountry = employeeDetailsForm.GetValue("PermanentAddressCountry");
            var PermanentAddressZip = employeeDetailsForm.GetValue("PermanentAddressZip");

            employeeDetailsForm.SetValue("AddressLine1", PermanentAddressLine1);
            employeeDetailsForm.SetValue("AddressLine2", PermanentAddressLine2);
            employeeDetailsForm.SetValue("AddressLine3", PermanentAddressLine3);
            employeeDetailsForm.SetValue("AddressCity", PermanentAddressCity);
            employeeDetailsForm.SetValue("AddressState", PermanentAddressState);
            employeeDetailsForm.SetValue("AddressCountry", PermanentAddressCountry);
            employeeDetailsForm.SetValue("AddressZip", PermanentAddressZip);

            $('#em_AddressLine1').attr("disabled", "disabled");
            $('#em_AddressLine2').attr("disabled", "disabled");
            $('#em_AddressLine3').attr("disabled", "disabled");
            $('#em_AddressCity').attr("disabled", "disabled");
            $('#em_AddressState').attr("disabled", "disabled");
            $('#em_AddressCountry').attr("disabled", "disabled");
            $('#em_AddressZip').attr("disabled", "disabled");
        }
        else {
            employeeDetailsForm.SetValue("AddressLine1", "");
            employeeDetailsForm.SetValue("AddressLine2", "");
            employeeDetailsForm.SetValue("AddressLine3", "");
            employeeDetailsForm.SetValue("AddressCity", "");
            employeeDetailsForm.SetValue("AddressState", "");
            employeeDetailsForm.SetValue("AddressCountry", "");
            employeeDetailsForm.SetValue("AddressZip", "");

            $("#em_AddressLine1").removeAttr("disabled");
            $("#em_AddressLine2").removeAttr("disabled");
            $("#em_AddressLine3").removeAttr("disabled");
            $("#em_AddressCity").removeAttr("disabled");
            $("#em_AddressState").removeAttr("disabled");
            $("#em_AddressCountry").removeAttr("disabled");
            $("#em_AddressZip").removeAttr("disabled");
        }



    })

    $("#em_PermanentAddressLine1").change(function () {
        if ($("#em_sameAsPermenent").is(':checked')) {
            var PermanentAddressLine1 = employeeDetailsForm.GetValue("PermanentAddressLine1");
            employeeDetailsForm.SetValue("AddressLine1", PermanentAddressLine1);
        }
    });

    $("#em_PermanentAddressLine2").change(function () {
        if ($("#em_sameAsPermenent").is(':checked')) {
            var PermanentAddressLine2 = employeeDetailsForm.GetValue("PermanentAddressLine2");
            employeeDetailsForm.SetValue("AddressLine2", PermanentAddressLine2);
        }
    });

    $("#em_PermanentAddressLine3").change(function () {
        if ($("#em_sameAsPermenent").is(':checked')) {
            var PermanentAddressLine3 = employeeDetailsForm.GetValue("PermanentAddressLine3");
            employeeDetailsForm.SetValue("AddressLine3", PermanentAddressLine3);
        }
    });

    $("#em_PermanentAddressCity").change(function () {
        if ($("#em_sameAsPermenent").is(':checked')) {
            var PermanentAddressCity = employeeDetailsForm.GetValue("PermanentAddressCity");
            employeeDetailsForm.SetValue("AddressCity", PermanentAddressCity);
        }
    });

    $("#em_PermanentAddressState").change(function () {
        if ($("#em_sameAsPermenent").is(':checked')) {
            var PermanentAddressSta = $('#em_PermanentAddressState option:selected').val();
            //var PermanentAddressState = employeeDetailsForm.GetValue("PermanentAddressState");
            employeeDetailsForm.SetValue("AddressState", PermanentAddressSta);
        }
    });

    $("#em_PermanentAddressCountry").change(function () {
        if ($("#em_sameAsPermenent").is(':checked')) {
            var PermanentAddressCountry = employeeDetailsForm.GetValue("PermanentAddressCountry");
            employeeDetailsForm.SetValue("AddressCountry", PermanentAddressCountry);
        }
    });

    $("#em_PermanentAddressZip").change(function () {
        if ($("#em_sameAsPermenent").is(':checked')) {
            var PermanentAddressZip = employeeDetailsForm.GetValue("PermanentAddressZip");
            employeeDetailsForm.SetValue("AddressZip", PermanentAddressZip);
        }
    });

    $('#phoneno,#alternatephone').keydown(function (e) {

        var key = e.charCode || e.keyCode || 0;
        $phone = $(this);
        // Auto-format- do not expose the mask as the user begins to type
        if (key !== 8 && key !== 9) {
            if ($phone.val().length === 3) {
                $phone.val($phone.val() + '-');
            }
            if ($phone.val().length === 5) {
                $phone.val($phone.val() + '');
            }
            if ($phone.val().length === 7) {
                $phone.val($phone.val() + '-');
            }
        }
        return ((key >= 48 && key <= 57) || key == 08 || key == 127 || key != 16)
    })

	.bind('focus click', function () {
	    $phone = $(this);

	    if ($phone.val().length === 0) {

	    }
	    else {
	        var val = $phone.val();
	        $phone.val('').val(val); // Ensure cursor remains at the end
	    }
	})

	.blur(function () {
	    $phone = $(this);

	    if ($phone.val() === '(') {
	        $phone.val('');
	    }
	});


});

function EmployeeNewCallback(status, data) {
    $("#employeeListView").hide();
    $("#employeeDetailsWindow").show();
}

_.ResetForm = function () {
    $("label").remove(".error");
    $("span").remove(".error");
    employeeDetailsForm.HideForm(true);
}

_.CheckEmployeeCode = function (EmpCode) {

    employeeService.CheckEmployeeCode('EmpCode=' + EmpCode, function (status, data) {
        if (status && data) {
            var html = "<label id='EmpCodeError' class='error'>The entered Employee Code already exists.</label>";
            $('#empcode').after(html);
        }
        else if (status && !data) {
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

_.DisableEmployee = function (EmployeeID) {
    var r = confirm("Are you sure you want to disable this employee?");
    if (r == true) {
        employeeService.disableEmployeeByID('EmployeeID=' + EmployeeID, function (status, data) {
            if (status && data) {
                employeeGrid.RefreshData();
                toastr.success("Employee disabled successfully!");
            }
            else if (status && !data) {
                toastr.error("Employee could not be disabled!");
            }
        });
    }
}

_.NewEmployeeForm = function (formName, hideList, callback) {

    employeeService.generateEmployeeCode(null, function (status, data) {
        if (data != "") {
            employeeDetailsForm.SetValue('EmployeeCode', data);
        }
    });

    var fb = this.FormBindings[formName];
    fb.New(function (status, data) {

        if (fb.detailsWindow) {
            fb.validator.resetForm();
            fb.ShowForm(hideList);
        }
        var df = fb.detailsWindow.find("[data-default-focus='true']");
        if (df != null && df.length > 0) {
            setTimeout('$("#' + df[0].id + '").focus()', 400);
        }        
    });

}





