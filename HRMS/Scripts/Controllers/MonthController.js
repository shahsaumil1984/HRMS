

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

_.GenerateandDownloadCSV = function (monthID) {
    
    //monthService.GenerateandDownloadCSV('MonthID=' + monthID, function (status, data) {
    //    if (status) {            
    //        alert('Successfully generated CSV');            
    //    }
    //    else {
    //        alert('Error occured. Please try after some time');
    //    }
    //});
    window.open('http://localhost:45719/api/home?id=12', '_blank', '');
};
