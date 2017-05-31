

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

_.GenerateandDownloadCSV = function (monthID) {   
    var r = confirm("Are you sure you want to generate .csv file for all employees?");
    if (r == true) {
        window.open('~/../../Api/Month/GetGenerateandDownloadCSV?MonthID=' + monthID, '_self', '');
    } 
};

_.DownloadAllPDF = function (monthID) {
    var r = confirm("Are you sure you want to download salary slips for all employees?");
    if (r == true) {
        window.open('~/../../Api/Salary/DownloadPDFZip?MonthID=' + monthID, '_self', '');
    }
};
