

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
});

// Form Validation
//----------------------------------------------
_.NewTaxComputationForm = function (formName, hideList, callback) {   
    var fb = this.FormBindings[formName];
    if (fb.detailsWindow) {
        fb.validator.resetForm();
        fb.ShowForm(hideList);
    }
    var df = fb.detailsWindow.find("[data-default-focus='true']");
    if (df != null && df.length > 0) {
        setTimeout('$("#' + df[0].id + '").focus()', 400);
    }
}

_.ResetForm = function () {
    $("label").remove(".error");
    $("span").remove(".error");
    taxComputationDetailsForm.HideForm(true);
}