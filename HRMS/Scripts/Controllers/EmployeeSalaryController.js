

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

//function _.loadNextEmployee(employeeID,monthID) {
//    _.LoadSalaryForm(1, 39);
//}
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
        success: function (response) 
        {
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

    window.open('~/../../Api/Salary/GenerateandDownloadPDF?EmployeeID=' + empID + '&MonthID=' + monthID, '_blank', '');
};

// Form Validation
//----------------------------------------------


