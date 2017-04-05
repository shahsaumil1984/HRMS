

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
                debugger;
                employeeSalaryService.GetById(employeeID, function (status, data) {
                    debugger;
                    $('#empName').text(data.FullName);
                    $('#empCode').text(data.EmployeeCode);
                })
                $("#salaryDetailsForm").parent().show();
                $("#employeeSalaryListView").hide();
            }
        });

    }
    _.HideSalaryForm = function () {
        $("#salaryDetailsForm").parent().hide();
        $("#employeeSalaryListView").show();
    }

});


function showHideForm(success, params) {   
    if (success) {
        $("#salaryDetailsForm").parent().hide();
        $("#employeeSalaryListView").show();
    } else {
        alert("Failed to save salary.")
    }
}

function _.loadNextEmployee(employeeID,monthID) {
    _.LoadSalaryForm(1, 39);
}
//var loadNextEmployee = function (status, data) {
//    debugger;
//    if (status) {
//        salaryService
//        _.LoadSalaryForm(1, 39);
//    }
//    else {
//        alert("Some error occured while saving data!")
//    }

//};

// Form Validation
//----------------------------------------------


