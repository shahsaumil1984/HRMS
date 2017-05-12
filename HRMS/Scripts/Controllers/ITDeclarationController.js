

// Properties
//----------------------------------------------

// Methods
//----------------------------------------------

// Event Handlers
//----------------------------------------------
$(document).ready(function () {
    _.Initialize(function (status, msg) {
        // Initialization Code Goes Here
    });

    $('#mobileNumber').keydown(function (e) {

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
 
// Form Validation
//----------------------------------------------
_.NewItDeclarationDetailForm = function (formName, hideList, callback) {
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
   
    itDeclarationDetailsForm.SetValue('EmployeeID', $('#hdnEmployeeID').val());
    itDeclarationDetailsForm.SetValue('PanNo', $('#hdnPan').val());

    itDeclarationDetailsForm.SetValue('AddressLine1', $('#hdnAddressLine1').val().trim());
    itDeclarationDetailsForm.SetValue('AddressLine2', $('#hdnAddressLine2').val().trim());
    itDeclarationDetailsForm.SetValue('AddressLine3', $('#hdnAddressLine3').val().trim());
    itDeclarationDetailsForm.SetValue('AddressCity', $('#hdnAddressCity').val().trim());
    itDeclarationDetailsForm.SetValue('AddressState', $('#hdnAddressState').val().trim());
    $('#addressState').val($('#hdnAddressState').val().trim());
    itDeclarationDetailsForm.SetValue('AddressZip', $('#hdnAddressZip').val().trim());
    itDeclarationDetailsForm.SetValue('AddressCountry', $('#hdnAddressCountry').val().trim());

    itDeclarationDetailsForm.SetValue('MobileNumber', $('#hdnMobileNumber').val().trim());
    
}
_.ResetForm = function () {
    $("label").remove(".error");
    $("span").remove(".error");
    itDeclarationDetailsForm.HideForm(true);
}

_.itDeclarationDeleteCallback = function (status, data) {
    if (status) {
        toastr.success('Successfully deleted Tax Computation!');
    }
    else {

        toastr.error('Tax Computation could not be deleted.');
    }
}


_.loadITDeclarationForm = function (formName, id, hideList) {
    var fb = this.FormBindings[formName];
    if (fb) {
        if (fb.detailsWindow) {
            fb.ShowForm(hideList);
        }
        fb.Load(id, function (status, data) {
            $('#itDeclarationYear').val(itDeclarationDetailsForm.model().ItDeclarationYear)
        });
    }
    else {
        alert('Framework: Form Binding [' + formName + '] was not found');
    }
}