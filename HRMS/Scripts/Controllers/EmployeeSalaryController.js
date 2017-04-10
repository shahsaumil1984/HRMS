

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
        $('#employeeidtoedit').val(employeeID);
        salaryService.GetByMonth(employeeID, monthID, function (status, data) {
            if (status) {
                employeeSalaryService.GetById(employeeID, function (status, empdata) {
                    $('#empName').text(empdata.FullName);
                    $('#empCode').text(empdata.EmployeeCode);
                    if (empdata.SalaryAccountNumber != null) {
                        $('#bankAccNo').text(empdata.SalaryAccountNumber);
                    }
                    if (empdata.SalaryAccountBank != null) {
                        $('#bankName').text(empdata.SalaryAccountBank);
                    }
                    data.AccountNumber = empdata.SalaryAccountNumber;
                    data.BankName = empdata.SalaryAccountBank;
                    salaryDetailsForm.model(data);
                    $("#salaryDetailsForm").parent().show();
                    $("#employeeSalaryListView").hide();
                })
            }
        });

    }
    _.HideSalaryForm = function () {
        $("#salaryDetailsForm").parent().hide();
        $("#employeeSalaryListView").show();
    }

    _.SaveSalary = function () {
        var isvalid = salaryDetailsForm.detailsForm.valid();
        if (isvalid) {
            salaryDetailsForm.Save();
            $("#salaryDetailsForm").parent().hide();
            $("#employeeSalaryListView").show();
        }
        else {
            alert('Kindly check if data entered is correct.');
        }
    }
});



//function showHideForm(success, params) {
//    if (success) {
//        $("#salaryDetailsForm").parent().hide();
//        $("#employeeSalaryListView").show();
//    } else {
//        alert("Failed to save salary.")
//    }
//}

_.loadNextEmployee = function (employeeID, monthID) {
    debugger;
    var isvalid = salaryDetailsForm.detailsForm.valid();
    if (isvalid) {
        salaryDetailsForm.Save();
        employeeSalaryService.GetNextEmployeeID(employeeID, function (status, data) {
            if (status) {
                if (data != -1) {
                    _.LoadSalaryForm(data, monthID);
                } else {
                    _.LoadSalaryForm(employeeID, monthID);
                    alert('No next employee.');
                }
            }
        });
    }
    else {
        alert('Kindly check if data entered is correct.');
    }
}

_.loadPrevEmployee = function (employeeID, monthID) {
    var isvalid = salaryDetailsForm.detailsForm.valid();
    if (isvalid) {
        salaryDetailsForm.Save();
        employeeSalaryService.GetPrevEmployeeID(employeeID, function (status, data) {
            if (status) {
                if (data != -1) {
                    _.LoadSalaryForm(data, monthID);
                } else {
                    _.LoadSalaryForm(employeeID, monthID);
                    alert('No previous employee.');

                }
            }
        });
    }
    else {
        alert('Kindly check if data entered is correct.');
    }
}
var approveNextEmployee = function (monthID) {  
    employeeID = $('#employeeidtoedit').val();
    salaryDetailsForm.SetValue('SalaryStatus', 'Approved');
    _.loadNextEmployee(employeeID, monthID);
}

var approvePrevEmployee = function (monthID) {
    employeeID = $('#employeeidtoedit').val();
    salaryDetailsForm.SetValue('SalaryStatus', 'Approved');
    _.loadPrevEmployee(employeeID, monthID);
}

_.UploadCSV = function () {

    //Validations on Uploaded File
    if ($('#fileUpload').val() == '') {
        alert('Please select file to upload');
        return false;
    }

    var file = $("#fileUpload").get(0).files[0];
    if (file.size > 10000000) {
        alert('Please select a file of maximum size upto 10MB');
        return false;
    }

    var fileType = file["type"];
    var ValidImageTypes = ["application/vnd.ms-excel"];
    if ($.inArray(fileType, ValidImageTypes) < 0) {
        alert('Invalid file type');
        return false;
    }
    //End

    var data = new FormData();

    // Add the uploaded CSV content to the form data collection
    data.append("UploadedCSV", file);


    // Make Ajax request with the contentType = false, and procesDate = false
    $.ajax({
        type: "POST",
        url: "/api/Salary/UploadCSV",
        contentType: false,
        processData: false,
        data: data,
        success: function (response) {
            alert("Successfully uploaded CSV");
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.responseText);
        }
    });


    //salaryService.UploadCSV(function (status, data) {
    //    if (status) {
    //        alert('Successfully uploaded CSV');
    //    }
    //    else {
    //        alert('Error occured while uploading CSV. Please try after some time.');
    //    }
    //});
}


// Form Validation
//----------------------------------------------


