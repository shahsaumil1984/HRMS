

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

//var GetStatusById = function (id) {
    
//    employeeStatusHistoryExtendService.GetById(id, function (status, data) {
        
//        var _startDate = new Date(data.StartDate);
//        var _endDate = new Date(data.EndDate);
//        $("#lblStartDate").text((_startDate.getMonth() + 1) + "/" + _startDate.getDate() + "/" + _startDate.getFullYear());
//        $("#lblEndDate").text((_endDate.getMonth() + 1) + "/" + _endDate.getDate() + "/" + _endDate.getFullYear());
        
//        data.StartDate = (_endDate.getMonth() + 1) + "/" + (_endDate.getDate() + 1) + "/" + _endDate.getFullYear();
//        data.EndDate = null;

//        startDate = data.StartDate;
//        employeeStatusHistoryDetailsForm.model(data);

//        $("#em_StartDate").change(function () {
//            if (_endDate > new Date(data.StartDate)) {
//                alert("Please select Start date after End date of Old Status");
//                $("#em_StartDate").val('');
//            }

//        });

//        $("#em_EndDate").change(function () {
//            if (new Date(data.StartDate) > new Date(data.EndDate)) {
//                alert("Please select End date after Start date");
//                $("#em_EndDate").val('');
//            }

//        });
       
//    })
//}