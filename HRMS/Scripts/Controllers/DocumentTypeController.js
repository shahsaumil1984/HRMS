

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


function documentTypeDeleteCallback(status, data)
{
    if (status)
    {
        alert('Successfully deleted document type');
    }
    else{
        
        alert('Cannot delete the document type as it is already in use');
    }
}