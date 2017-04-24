/// <reference path="../jquery-1.10.2.min.js" />
/// <reference path="../jquery-1.10.2.min.js" />
// Event Handlers
//----------------------------------------------
$(document).ready(function () {

    _.Initialize(function (status, msg) {

    });

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
        }
        else
        {
            employeeDetailsForm.SetValue("AddressLine1", "");
            employeeDetailsForm.SetValue("AddressLine2", "");
            employeeDetailsForm.SetValue("AddressLine3", "");
            employeeDetailsForm.SetValue("AddressCity", "");
            employeeDetailsForm.SetValue("AddressState", "");
            employeeDetailsForm.SetValue("AddressCountry", "");
            employeeDetailsForm.SetValue("AddressZip", "");
        }
        

            
    })

    $('#phoneno').keydown(function (e) {
	    
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





