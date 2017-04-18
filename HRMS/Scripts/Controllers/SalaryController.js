

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
    salaryService.SendAllEmail(monthID, function (status, data) {
        if (status) {
            alert("Email sent successfully!");
        }
        else {
            alert("Email could not be sent.")
        }
    })
}

// Form Validation
//----------------------------------------------



