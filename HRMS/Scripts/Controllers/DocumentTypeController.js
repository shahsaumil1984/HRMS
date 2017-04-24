

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

_.documentTypeDeleteCallback = function (status, data)
{
    if (status)
    {
        toastr.success('Successfully deleted document type');
    }
    else{
        
        toastr.error('Cannot delete the document type as it is already in use');
    }
}