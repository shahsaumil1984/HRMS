
function MonthService() { } MonthService.prototype = new Proxy('Month', 'MonthID');

MonthService.prototype.GenerateandDownloadCSV = function (params, callback) { this.Query("GetGenerateandDownloadCSV", params, callback); }

var monthService = new MonthService();

