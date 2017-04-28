

// Properties
//----------------------------------------------

// Methods
//----------------------------------------------

// Event Handlers
//----------------------------------------------
$(document).ready(function () {
    _.Initialize(function (status, msg) {
    });
});

// Form Validation
//----------------------------------------------
_.NewTaxComputationForm = function (formName, hideList, callback) {

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
        
        if (taxComputationDetailsForm.model().Year == 0) {
            taxComputationDetailsForm.SetValue('Year', null);
        }
        taxComputationDetailsForm.SetValue('EmployeeID', $('#hdnEmployeeID').val());
    });
    //if (fb.detailsWindow) {
    //    fb.validator.resetForm();
    //    fb.ShowForm(hideList);
    //}
    //var df = fb.detailsWindow.find("[data-default-focus='true']");
    //if (df != null && df.length > 0) {
    //    setTimeout('$("#' + df[0].id + '").focus()', 400);
    //}

}

_.ResetForm = function () {
    $("label").remove(".error");
    $("span").remove(".error");
    taxComputationDetailsForm.HideForm(true);
}

_.taxComputationDeleteCallback = function (status, data) {
    if (status) {
        toastr.success('Successfully deleted Tax Computation!');
    }
    else {

        toastr.error('Tax Computation could not be deleted.');
    }
}
