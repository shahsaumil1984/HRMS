

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
    
    window.open('~/../../Api/Month/GetGenerateandDownloadCSV?MonthID=' + monthID, '_blank', '');
};

_.DownloadPDF = function (monthID) {

    window.open('~/../../Api/Month/GenerateandDownloadPDF?MonthID=' + monthID, '_blank', '');
};

_.UploadCSV = function () {

    if($('#fileUpload').val() == '')
    { 
        alert('Please select file to upload');
        return false; 
    } 
    if(document.getElementById('fileUpload').files[0].size > 10000000)
    {
        alert('Please select a file of maximum size upto 10MB');
        return false; 
    }

    var data = new FormData();

    var files = $("#fileUpload").get(0).files;

    // Add the uploaded CSV content to the form data collection
    if (files.length > 0) {
        data.append("UploadedCSV", files[0]);
    }

    // Make Ajax request with the contentType = false, and procesDate = false
    var ajaxRequest = $.ajax({
        type: "POST",
        url: "/api/Month/UploadCSV",
        contentType: false,
        processData: false,
        data: data
    });




    //monthService.UploadCSV('filePath=' + document.getElementById('fileUpload').files[0]., function (status, data) {
    //        if (status && data) {
                
    //        }            
    //    }

    //);    
};


