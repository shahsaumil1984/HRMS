
function DocumentTypeService() { } DocumentTypeService.prototype = new Proxy('DocumentType', 'DocumentTypeID');

// Example Custom Method
DocumentTypeService.prototype.MyCustomMethod = function (params, callback) {

    // Query allows for custom get calls to the server    

    // Query API
    this.Query('MyCustomMethodNameOnThisObject?' + params, callback);

    // Query Controller
    this.QueryController('MyCustomMethodNameOnThisObject?' + params, callback);
}

var documentTypeService = new DocumentTypeService();

