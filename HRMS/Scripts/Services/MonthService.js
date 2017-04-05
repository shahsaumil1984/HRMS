
function MonthService() { } MonthService.prototype = new Proxy('Month', 'MonthID');

MonthService.prototype.UploadCSV = function (params, callback) { this.Query("GetUploadCSV", params, callback); }

var monthService = new MonthService();

