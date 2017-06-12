

// Properties
//----------------------------------------------

// Methods
//----------------------------------------------

// Event Handlers
//----------------------------------------------
var startDate = null;
$(document).ready(function () {
    _.Initialize(function (status, msg) {
    });

    $("#em_StartDateDetails").datepicker({
        todayBtn: 1,
        autoclose: true,
        clearBtn: true
    }).on('changeDate', function (selected) {
        var minDate = new Date(selected.date.valueOf());
        $('#em_EndDateDetails').datepicker('setStartDate', minDate);
    });

    $("#em_EndDateDetails").datepicker({
        autoclose: true,
        clearBtn: true
    }).on('changeDate', function (selected) {
        if ($("#em_EndDateDetails").val() == "") {
            //$("#em_StartDateDetails").val('');
            $('#em_StartDateDetails').datepicker('setEndDate', null);
        }
        else {
            var maxDate = new Date(selected.date.valueOf());
            $('#em_StartDateDetails').datepicker('setEndDate', maxDate);
        }
    });


    $("#em_StartDate_New").datepicker({
        todayBtn: 1,
        autoclose: true,
        clearBtn: true
    }).on('changeDate', function (selected) {
        var minDate = new Date(selected.date.valueOf());
        $('#em_EndDate_New').datepicker('setStartDate', minDate);
    });

    $("#em_EndDate_New").datepicker({
        autoclose: true,
        clearBtn: true
    }).on('changeDate', function (selected) {
        if ($("#em_EndDate_New").val() == "") {
            $('#em_StartDate_New').datepicker('setEndDate', null);
        }
        else {
            var maxDate = new Date(selected.date.valueOf());
            $('#em_StartDate_New').datepicker('setEndDate', maxDate);
        }
    });
});

var closeStatusHistoryPopup = function closeStatusHistoryPopup() {
    $('#StatusDialog').modal('hide');
}

function loadEmployeeStatusHistoryCallback() {
    alert(1);
}

_.loadFormEmployeeStatusHistory = function (formName, id, hideList) {
    var fb = this.FormBindings[formName];
    if (fb) {
        if (fb.detailsWindow) {
            fb.ShowForm(hideList);
        }
        fb.Load(id, function (status, data) {
            debugger;
            var minDate = employeeStatusHistoryDetailsForm.model().StartDate;
            var newmindate = new Date(minDate);
            $('#em_EndDate').datepicker('setStartDate', newmindate);
        });
    }
    else {
        alert('Framework: Form Binding [' + formName + '] was not found');
    }
}