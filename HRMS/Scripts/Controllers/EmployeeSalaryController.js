

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

    _.LoadSalaryForm = function (employeeID, monthID) {
        debugger;
        salaryService.GetByMonth(employeeID, monthID, function (status, data) {
            if (status) {
                salaryDetailsForm.model(data);
                $("#salaryDetailsForm").parent().show();
                $("#employeeSalaryListView").hide();
            }
        });       
    }
});

var loadNextEmployee = function (status, data) {
    debugger;
    if (status) {
        _.LoadSalaryForm(1,39);
    }
    else {
        alert("Some error occured while saving data!")
    }

};

// Form Validation
//----------------------------------------------


