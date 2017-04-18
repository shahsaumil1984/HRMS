

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
    
    $("#em_StartDate").datepicker({
        autoclose: true,
    })
    $("#em_EndDate").datepicker({
        autoclose: true,
    })

});

var closeStatusHistoryPopup = function closeStatusHistoryPopup() {
    $('#StatusDialog').modal('hide');
}