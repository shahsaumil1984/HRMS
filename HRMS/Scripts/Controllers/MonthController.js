

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
});

// Form Validation
//----------------------------------------------

//_.GenerateandDownloadCSV()
//{
//    alert('hi');
//}

UserInterfaceBinder.prototype.GenerateandDownloadCSV = function (monthID) {
    
    monthService.GenerateandDownloadCSV('MonthID=' + monthID, function (status, data) {
        if (status) {            
            alert('Successfully generated CSV');            
        }
        else {
            alert('Error occured. Please try after some time');
        }
    });
};
