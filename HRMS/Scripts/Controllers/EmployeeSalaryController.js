﻿

// Properties
//----------------------------------------------

// Methods
//----------------------------------------------

// Event Handlers
//----------------------------------------------
var SalaryMonthID = null;

$(document).ready(function () {
    _.Initialize(function (status, msg) {
        // Initialization Code Goes Here     
        showHideActionButtons();
    });

    _.PopulateData = function (employeeID, monthID) {
        var bankName = salaryDetailsForm.model().BankName;
        var accNumber = salaryDetailsForm.model().AccountNumber;
        var salaryID = salaryDetailsForm.model().SalaryID;
        var salmonthid = monthID;
        var createdBy = salaryDetailsForm.model().CreatedBy;
        var createdDate = salaryDetailsForm.model().CreatedDate;
        var fullnFinal = salaryDetailsForm.model().isFullAndFinal;
        var salaryStatus = salaryDetailsForm.model().SalaryStatus;
        var days = salaryDetailsForm.model().Days;
        salaryService.GetByMonth(employeeID, monthID, true, function (status, data) {
            if (status) {
                if (data != null && data.BankName == null) {
                    data.BankName = bankName;
                }
                if (data != null && data.AccountNumber == null) {
                    data.AccountNumber = accNumber;
                }
                data.MonthID = salmonthid;
                data.SalaryID = salaryID;
                data.CreatedBy = createdBy;
                data.CreatedDate = createdDate;
                data.isFullAndFinal = fullnFinal;
                data.Days = days;
                data.SalaryStatus = salaryStatus;

                var arstatus = new Array();
                if (salaryStatus != null && salaryStatus == 2) {
                    arstatus.SalaryStatusName = 'Approved';
                    arstatus.SalaryStatusID = 2;
                }
                else {
                    arstatus.SalaryStatusName = 'Pending';
                    arstatus.SalaryStatusID = 1;
                }
                data.SalaryStatu = arstatus;
                salaryDetailsForm.model(data);
            }
        });
    }
    _.PopulateTDS = function (employeeID, monthID) {
        salaryService.GetTDSbyYear(employeeID, monthID, function (status, data) {
            if (status) {
                salaryDetailsForm.SetValue("TDS", data);
                if (data != null && $('#em_TDS').parent('div').find('.error').length == 2) {
                    $('#em_TDS').parent('div').find('label.error').hide();
                   $('#em_TDS').parent('div').find('.error').removeClass("error");
            }
        }
        });
}

    function showHideActionButtons() {
        var monthNames = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
        var d = new Date();
        var currentDate = d.getDate();
        var currentMonth = monthNames[d.getMonth()];
        var currentYear = d.getFullYear();
        var prevMonth;
        var prevYear;
        if (currentMonth == "January") {
            prevMonth = "December";
            prevYear = parseInt(currentYear) -1;
        }
        else {
            prevMonth = monthNames[d.getMonth() -1];
            prevYear = currentYear;
    }

        var salaryMonth = $('#currentMonth').val().toString().split(',')[0].trim();
        var salaryYear = $('#currentMonth').val().toString().split(',')[1].trim();

        if ((currentMonth == salaryMonth && parseInt(currentYear) == parseInt(salaryYear)) ||
            (currentDate <= 5 && prevMonth == salaryMonth && parseInt(prevYear) == parseInt(salaryYear))) {
            $('#btnSave').css('display', 'inline-block');
            $('#btnApprove').css('display', 'inline-block');
        }
        else {
            $('#btnSave').css('display', 'none');
            $('#btnApprove').css('display', 'none');
    }
}

    _.LoadSalaryForm = function (employeeID, monthID) {
        $('#employeeidtoedit').val(employeeID);
        salaryService.GetByMonth(employeeID, monthID, false, function (status, data) {
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
            SalaryMonthID = null;// whenn called from savecallback
        });

}
    _.HideSalaryForm = function () {
        $("#salaryDetailsForm").parent().hide();
        $("#employeeSalaryListView").show();
}

    _.SaveSalary = function (monthID) {
        var isvalid = salaryDetailsForm.detailsForm.valid();
        if (isvalid) {
            if (salaryDetailsForm.model().SalaryStatu != null && salaryDetailsForm.model().SalaryStatu.SalaryStatusName == "Approved") {
                salaryDetailsForm.model().SalaryStatus = 2;
            }
            else
                salaryDetailsForm.model().SalaryStatus = 1; //Pending
            SalaryMonthID = monthID;

            salaryDetailsForm.model().Days = $('#lbldays').text();
            salaryDetailsForm.Save(saveCallback);
            //$("#salaryDetailsForm").parent().hide();
            //$("#employeeSalaryListView").show();
        }
        else {
            toastr.error('Kindly check if data entered is correct.');
    }
}
});

var approveSalary = function (monthID) {
    var employeeID = $('#employeeidtoedit').val();
    if (salaryDetailsForm.model().SalaryStatu != null) {
        salaryDetailsForm.model().SalaryStatu.SalaryStatusID = 2;
}
    salaryDetailsForm.model().SalaryStatus = 2;
    //salaryDetailsForm.SetValue('SalaryStatu.SalaryStatusID', 2);//Approved
    var isvalid = salaryDetailsForm.detailsForm.valid();
    if (isvalid) {
        SalaryMonthID = monthID;
        salaryDetailsForm.model().Days = $('#lbldays').text();
        salaryDetailsForm.Save(approveCallback);
    }
    else {
        toastr.error('Kindly check if data entered is correct.');
}
}

function saveCallback(status, data) {
    if (status) {
        var employeeID = $('#employeeidtoedit').val();
        _.LoadSalaryForm(employeeID, SalaryMonthID);
        toastr.success('Salary saved successfully!');
}
}

function approveCallback(status, data) {
    if (status) {
        var employeeID = $('#employeeidtoedit').val();
        _.LoadSalaryForm(employeeID, SalaryMonthID);
        toastr.success('Salary saved and approved successfully!');
}
}

_.UploadCSV = function () {

    //Validations on Uploaded File
    if ($('#fileUpload').val() == '') {
        toastr.error('Please select file to upload');
        return false;
}

    var file = $("#fileUpload").get(0).files[0];
    if (file.size > 10000000) {
        toastr.error('Please select a file of maximum size upto 10MB');
        return false;
}

    var fileType = file["type"];
    var ValidImageTypes = ["application/vnd.ms-excel"];
    if ($.inArray(fileType, ValidImageTypes) < 0) {
        toastr.error('Invalid file type');
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
            toastr.success("Successfully uploaded CSV");
            $('#fileUpload').val('');
    },
            error: function (xhr, ajaxOptions, thrownError) {
            toastr.error(xhr.responseText);
            $('#fileUpload').val('');
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
    var r = confirm("Are you sure you want to download pdf file?");
    if (r == true) {
        window.open('~/../../Api/Salary/DownloadPDF?EmpID=' + empID + '&MonthID=' +monthID, '_self', '');
}
};

// Form Validation
//----------------------------------------------

_.SendEmail = function (empID, monthID) {
    var r = confirm("Are you sure you want to send email?");
    if (r == true) {
        salaryService.SendEmail(empID, monthID, function (status, data) {
            if (status) {
                toastr.success("Email sent successfully!");
            }
            else {
                toastr.error("Email could not be sent.")
        }
        })
}
}

_.moveToNextEmployee = function (employeeID, monthID) {
    employeeSalaryService.GetNextEmployeeID(employeeID, function (status, data) {
        if (status) {
            if (data != -1) {
                _.LoadSalaryForm(data, monthID);
            } else {
                _.LoadSalaryForm(employeeID, monthID);
                toastr.info('No next employee.');
        }
    }
    });
}

_.moveToPrevEmployee = function (employeeID, monthID) {
    employeeSalaryService.GetPrevEmployeeID(employeeID, function (status, data) {
        if (status) {
            if (data != -1) {
                _.LoadSalaryForm(data, monthID);
            } else {
                _.LoadSalaryForm(employeeID, monthID);
                toastr.info('No previous employee.');
        }
    }
    });
}
