

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
    
    window.open('~/../../Api/Month/GetGenerateandDownloadCSV?MonthID=' + monthID, '_blank', '');
};

_.DownloadAllPDF = function (monthID) {

    window.open('~/../../Api/Salary/DownloadPDFZip?MonthID=' + monthID, '_blank', '');
};
