

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

_.EmployeeStatusDeleteCallback = function (status, data)
{
    if (status)
    {
        alert('Successfully deleted status type');
    }
    else{
        
        alert('Cannot delete the status type as it is already in use');
    }
}