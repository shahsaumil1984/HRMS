

// Properties
//----------------------------------------------

// Methods
//----------------------------------------------

// Event Handlers
//----------------------------------------------
$(document).ready(function () {
    _.Initialize(function (status, msg) {

        // Initialization Code Goes Here
         $('#em_StartDate').datepicker();
         $('#em_EndDate').datepicker();
        

    });

});

var GetStatusById = function (id) {
  
    employeeStatusHistoryService.GetById(id, function (status,data) {
        debugger;
        employeeStatusDetailsForm = data;
    })
}