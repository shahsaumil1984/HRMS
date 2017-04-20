

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

_.SendAllEmail = function (monthID) {
    var r = confirm("Are you sure you want to send email to all employees?");
    if (r == true) {
        salaryService.SendAllEmail(monthID, function (status, data) {
            if (status) {
                toastr.success("Email sent successfully!");
            }
            else {
                toastr.error("Email could not be sent.")
            }
        })
    }
}

// Form Validation
//----------------------------------------------



