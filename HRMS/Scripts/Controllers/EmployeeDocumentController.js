

// Properties
//----------------------------------------------

// Methods
//----------------------------------------------

// Event Handlers
//----------------------------------------------
$(document).ready(function () {
    var employeeid = GetParameterByName("EmployeeID");

    _.Initialize(function (status, msg) {

        // Initialization Code Goes Here

    });

    $("#btnCloseFileUpload").click(function () {       
        $('#fileUpload').val('');
        $('#DocumentTypeID').val('');
        $('#fileUploadPopUp').modal('hide');
    });
   
});

// Form Validation
//----------------------------------------------

