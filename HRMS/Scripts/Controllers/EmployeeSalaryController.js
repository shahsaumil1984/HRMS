

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
    var SalaryMonthID = null;
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
        debugger;
        var isvalid = salaryDetailsForm.detailsForm.valid();
        if (isvalid) {
            if (salaryDetailsForm.model().SalaryStatu.SalaryStatusName == "Approved") {
                salaryDetailsForm.model().SalaryStatus = 2;
            }
            else
                salaryDetailsForm.model().SalaryStatu.SalaryStatusName = 1; //Pending
            salaryDetailsForm.Save();
            $("#salaryDetailsForm").parent().hide();
            $("#employeeSalaryListView").show();
        }
        else {
            alert('Kindly check if data entered is correct.');
        }
    }
});

_.loadNextEmployee = function (employeeID, monthID) {
    debugger;
    var isvalid = salaryDetailsForm.detailsForm.valid();
    if (isvalid) {
        SalaryMonthID = monthID;
        if (salaryDetailsForm.model().SalaryStatu.SalaryStatusName == "Approved") {
            salaryDetailsForm.model().SalaryStatus = 2;
        }
        else
            salaryDetailsForm.model().SalaryStatus = 1; //Pending
        salaryDetailsForm.Save(loadNextEmployeeCallback);

    }
    else {
        alert('Kindly check if data entered is correct.');
    }
}

function loadNextEmployeeCallback(successStatus, callBackData) {
    if (successStatus) {
        var employeeID = $('#employeeidtoedit').val();
        employeeSalaryService.GetNextEmployeeID(employeeID, function (status, data) {
            if (status) {
                if (data != -1) {
                    _.LoadSalaryForm(data, SalaryMonthID);
                } else {
                    _.LoadSalaryForm(employeeID, SalaryMonthID);
                    alert('No next employee.');
                }
                SalaryMonthID = null;
            }
        });
    }
}
_.loadPrevEmployee = function (employeeID, monthID) {
    debugger;
    var isvalid = salaryDetailsForm.detailsForm.valid();
    if (isvalid) {
        SalaryMonthID = monthID;
        if (salaryDetailsForm.model().SalaryStatu.SalaryStatusName == "Approved") {
            salaryDetailsForm.model().SalaryStatus = 2;
        }
        else
            salaryDetailsForm.model().SalaryStatus = 1; //Pending
        salaryDetailsForm.Save(loadPrevEmployeeCallback);
    }
    else {
        alert('Kindly check if data entered is correct.');
    }
}

function loadPrevEmployeeCallback(successStatus, callbackData) {
    debugger;
    if (successStatus) {
        var employeeID = $('#employeeidtoedit').val();
        employeeSalaryService.GetPrevEmployeeID(employeeID, function (status, data) {
            if (status) {
                if (data != -1) {
                    _.LoadSalaryForm(data, SalaryMonthID);
                } else {
                    _.LoadSalaryForm(employeeID, SalaryMonthID);
                    alert('No previous employee.');

                }
                SalaryMonthID = null;
            }
        });
    }
}

var approveNextEmployee = function (monthID) {
    debugger;
    var employeeID = $('#employeeidtoedit').val();
    salaryDetailsForm.model().SalaryStatu.SalaryStatusID = 2;
    salaryDetailsForm.model().SalaryStatu.SalaryStatusName = "Approved";
    salaryDetailsForm.model().SalaryStatus = 2;
    // salaryDetailsForm.SetValue('SalaryStatus', 2);//Approved
    _.loadNextEmployee(employeeID, monthID);
}

var approvePrevEmployee = function (monthID) {
    var employeeID = $('#employeeidtoedit').val();
    salaryDetailsForm.model().SalaryStatu.SalaryStatusID = 2;
    salaryDetailsForm.model().SalaryStatu.SalaryStatusName = "Approved";
    salaryDetailsForm.model().SalaryStatus = 2;
    //salaryDetailsForm.SetValue('SalaryStatus', 2);//Approved
    _.loadPrevEmployee(employeeID, monthID);
}

var approveSalary = function (monthID) {
    debugger;
    var employeeID = $('#employeeidtoedit').val();
    salaryDetailsForm.model().SalaryStatu.SalaryStatusID = 2;
    salaryDetailsForm.model().SalaryStatus = 2;
    //salaryDetailsForm.SetValue('SalaryStatu.SalaryStatusID', 2);//Approved
    var isvalid = salaryDetailsForm.detailsForm.valid();
    if (isvalid) {
        SalaryMonthID = monthID;
        salaryDetailsForm.Save(approveCallback);
    }
    else {
        alert('Kindly check if data entered is correct.');
    }
}

function approveCallback(status, data) {
    if (status) {
        var employeeID = $('#employeeidtoedit').val();
        _.LoadSalaryForm(employeeID, SalaryMonthID);
    }
    SalaryMonthID = null;
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

_.DownloadPDF = function (empID, monthID) {

    window.open('~/../../Api/Salary/DownloadPDF?EmpID=' + empID + '&MonthID=' + monthID, '_blank', '');
};

// Form Validation
//----------------------------------------------

_.SendEmail = function (empID, monthID) {
    salaryService.SendEmail(empID, monthID, function (status, data) {
        if (status) {
            alert("Email sent successfully!");
        }
        else {
            alert("Email could not be sent.")
        }
    })
}
