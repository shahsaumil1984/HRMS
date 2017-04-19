/*
Copyright 2014 Affirma, LLC and Michael J.C. Brown
http://affirma.com/

Permission is hereby granted, free of charge, to any person obtaining
a copy of this software and associated documentation files (the
"Software"), to deal in the Software without restriction, including
without limitation the rights to use, copy, modify, merge, publish,
distribute, sublicense, and/or sell copies of the Software, and to
permit persons to whom the Software is furnished to do so, subject to
the following conditions:

The above copyright notice and this permission notice shall be
included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

*/

var currentUploadProperty;
var currentUploadElmt;
var currentUploadFormId;
var currentUploadIdField;
var currentUploadNameField;
var currentUploadFileMultiplicity;

var FileDownloadURL = "/Upload/DownloadFile?fileDocumentID=";

function Actions() {
    this.New = 'new';
    this.Load = 'load';
    this.Delete = 'delete';
    this.Save = 'save';
    this.Validate = 'validate';
}
var actions = new Actions();


/*
    Proxy Class creates a default Proxy for interfacing with standard methods expected to be found on the server WebAPI layer for each entity. 
    This class reduces the need to write proxy methods for each entity on the server and allows one class to function across all entities.
    This class is inheritied from by all the concrete Service classes in on the client side.
*/
function Proxy(entityName, entityKey) {

    this.entityName = entityName;
    this.entityKey = entityKey;

    this.rootUrl = '/api/' + entityName + '/';
    this.getModelUrl = '/api/' + entityName + '/GetModel';
    this.getAllUrl = '/api/' + entityName + '/GetAll';
    this.getListUrl = '/api/' + entityName + '/GetList';
    this.getByIdUrl = '/api/' + entityName + '/GetById';
    this.searchUrl = '/api/' + entityName + '/Search';
    this.createUrl = '/api/' + entityName + '/Create';
    this.updateUrl = '/api/' + entityName + '/Update';
    this.deleteUrl = '/api/' + entityName + '/Delete';
}

Proxy.prototype.ReInitialize = function (entityName, entityKey) {

    this.entityName = entityName;
    this.entityKey = entityKey;

    this.rootUrl = '/api/' + entityName + '/';
    this.getModelUrl = '/api/' + entityName + '/GetModel';
    this.getAllUrl = '/api/' + entityName + '/GetAll';
    this.getListUrl = '/api/' + entityName + '/GetList';
    this.getByIdUrl = '/api/' + entityName + '/GetById';
    this.searchUrl = '/api/' + entityName + '/Search';
    this.createUrl = '/api/' + entityName + '/Create';
    this.updateUrl = '/api/' + entityName + '/Update';
    this.deleteUrl = '/api/' + entityName + '/Delete';
}

Proxy.prototype.GetModel = function (callback) {
    $.ajax({
        datatype: 'json',
        type: 'GET',
        success: function (data) { if (callback) { callback(true, data); } },
        error: function (data) { if (callback) { callback(false, data); } },
        url: this.getModelUrl
    });
}


Proxy.prototype.GetAll = function (callback) {
    $.ajax({
        datatype: 'json',
        type: 'GET',
        success: function (data) { if (callback) { callback(true, data); } },
        error: function (data) { if (callback) { callback(false, data); } },
        url: this.getAllUrl
    });
}


Proxy.prototype.GetList = function (pageIndex, pageSize, filter, orderBy, includeChildren, callback, methodName) {
    var getUrl = this.getListUrl;
    if (methodName != null) {
        getUrl = this.rootUrl + methodName + '/';
    }

    $.ajax({
        datatype: 'json',
        type: 'GET',
        success: function (data) { if (callback) { callback(true, data); } },
        error: function (data) { if (callback) { callback(false, data); } },
        url: getUrl + '?pageIndex=' + pageIndex + '&pageSize=' + pageSize + '&filter=' + filter + '&orderBy=' + orderBy + '&includeProperties=' + includeChildren
    });
}

Proxy.prototype.GetById = function (id, callback) {

    var _url = this.getByIdUrl;
    if (id != null)
        _url = _url + '?id=' + id;

    $.ajax({
        datatype: 'json',
        type: 'GET',
        success: function (data) { if (callback) { callback(true, data); } },
        error: function (data) { if (callback) { callback(false, data); } },
        url: _url
    });
}


Proxy.prototype.QueryInternal = function (method, queryType, params, callback) {
    var root = this.rootUrl;
    $.ajax({
        datatype: 'json',
        type: queryType,
        success: function (data) { if (callback) { callback(true, data); } },
        error: function (data) { if (callback) { callback(false, data); } },
        data: params,
        url: root + method
    });
}

Proxy.prototype.Query = function (method, params, callback) {
    this.QueryInternal(method, 'GET', params, callback);
}
Proxy.prototype.QueryByPost = function (method, params, callback) {
    this.QueryInternal(method, 'POST', params, callback);
}

Proxy.prototype.QueryController = function (method, callback) {

    $.ajax({
        datatype: 'json',
        type: 'GET',
        success: function (data) { if (callback) { callback(true, data); } },
        error: function (data) { if (callback) { callback(false, data); } },
        url: entityName + '/' + method
    });
}

Proxy.prototype.Save = function (obj, callback) {
    if (obj[this.entityKey] == null || obj[this.entityKey] == 0) {
        this.Create(obj, function (success, data) { if (callback) { callback(success, data); } });
    }
    else {
        this.Update(obj, function (success, data) { if (callback) { callback(success, data); } });
    }
}

Proxy.prototype.Create = function (obj, callback) {
    $.ajax({
        url: this.createUrl,
        data: JSON.stringify(obj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        success: function (data) { if (callback) { callback(true, data); } },
        error: function (data) { if (callback) { callback(false, $.parseJSON(data.responseText)); } },
        complete: function () { $.unblockUI(); },
        beforeSend: function () { $.blockUI({ message: "Saving data..." }); }
    });
}

Proxy.prototype.Update = function (obj, callback) {
    $.ajax({
        url: this.updateUrl,
        data: JSON.stringify(obj),
        type: "PUT",
        contentType: "application/json;charset=utf-8",
        success: function (data) { if (callback) { callback(true, data); } },
        error: function (data) { if (callback) { callback(false, $.parseJSON(data.responseText)); } }
    });
}

Proxy.prototype.Delete = function (id, callback) {
    $.ajax({
        url: this.deleteUrl + '/' + id,
        type: "DELETE",
        contentType: "application/json;charset=utf-8",
        success: function (data) { if (callback) { callback(true, data); } },
        error: function (data) { if (callback) { callback(false, $.parseJSON(data.responseText)); } }
    });
}

/*--------------------------------------------------------------------------------------
    User Interface Bind Classes -
    Encompass UI Binding to abscure knockout knowledge as well as interactions with ajax.  
    This library also encompasses the viewModel for binding to a form and setting up validation.
----------------------------------------------------------------------------------------*/
function UserInterfaceBinder() {
    this.debugWindow = null;
    this.FormBindings = new Array();
    this.ListBindings = new Array();
    this.Directives = new Array();
}


UserInterfaceBinder.prototype.Log = function (message, showAlert) {
    if (this.debugWindow != null) {
        $(this.debugWindow).prepend(message + '<br/>');
    }
    if (showAlert) {
        alert(message);
    }
}

UserInterfaceBinder.prototype.LogSuccess = function (message, showAlert) {
    message = '<font color="green">' + message + '</font>';
    _.Log(message, showAlert);
}
UserInterfaceBinder.prototype.LogFailure = function (message, showAlert) {
    message = '<font color="red">' + message + '</font>';
    _.Log(message, showAlert);
}
UserInterfaceBinder.prototype.LogInfo = function (message, showAlert) {
    message = '<font color="blue">' + message + '</font>';
    _.Log(message, showAlert);
}

UserInterfaceBinder.prototype.GetErrorMsg = function (data) {
    if (data.Error) {
        return data.Error;
    }
    if (data.responseText) {
        return data.responseText;
    }
    if (data.ExceptionMessage) {
        return data.ExceptionMessage;
    }
    return 'Unknow Error Occurred;';
}
UserInterfaceBinder.prototype.Initialize = function (callback) {
    try {
        var currentBinder = this;

        // Check for Debug Window
        $("[data-debug-window='true']").each(function (key, elmt) {
            currentBinder.debugWindow = elmt;
        });

        _.LogInfo('Initializing UI Bindings...');


        $('[data-element-type=upload]').each(function (i, obj) {
            var uploadElmt = $(obj);
            var uploadFormId = uploadElmt.closest('form[data-ui-binding^="true"]').attr('id');
            var btn1 = document.createElement('button');
            if (uploadElmt.attr('data-upload-path') == '') {
                uiBinder.Log('data-upload-path attribute is required by all upload enabled elements on the page');
            }
            else {
                var datareadonly = uploadElmt.attr('data-readonly');
                var uploadBindingProp = uploadElmt.attr('data-bind-property');
                var datauploadTemplate = uploadElmt.attr('data-upload-template');
                var datauploadField = uploadElmt.attr('data-upload-Idfield');
                if (datauploadField == undefined || datauploadField == null || datauploadField == "") {
                    datauploadField = "Key";
                }
                var datauploadNamefield = uploadElmt.attr('data-upload-Namefield');
                if (datauploadNamefield == undefined || datauploadNamefield == null || datauploadNamefield == "") {
                    datauploadNamefield = "Value";
                }

                if (datauploadTemplate == undefined || datauploadTemplate == null || datauploadTemplate == "") {
                    if (datareadonly) {
                        datauploadTemplate = "<tr><td>[Name]</td></tr>";
                    }
                    else {
                        datauploadTemplate = "<tr><td>[Name]</td><td>[Remove]</td></tr>";
                    }
                }

                var datauploadMultiplefield = uploadElmt.attr('data-upload-multiple');
                if (datauploadMultiplefield == undefined || datauploadMultiplefield == null || datauploadMultiplefield == "") {
                    datauploadMultiplefield = "false";
                }

                if (datauploadMultiplefield == "true" || datauploadMultiplefield == true) {
                    datauploadTemplate = datauploadTemplate.replace("[Name]", "<a href='{{x." + datauploadField + " == 0 ? (\"/" + uploadElmt.attr('data-upload-path') + "/\" + x." + datauploadNamefield + ") : (\"" + FileDownloadURL + "\" + x." + datauploadField + ")}}'>{{x." + datauploadNamefield + "}}</a>");
                    datauploadTemplate = datauploadTemplate.replace("[Remove]", "<a href='#' ng-click='$parent.fb.DeleteUploadFile($index, \"" + uploadBindingProp + "\")'>Remove</a>");

                    uploadElmt.html(datauploadTemplate);
                    uploadElmt.children().first().attr("ng-repeat", "x in model." + uploadBindingProp);
                    var span = $("<span></span>");
                    span.attr('data-readonly', datareadonly);
                    span.attr('data-element-type', "upload");
                    span.attr('data-bind-property', uploadBindingProp);
                    span.attr('data-upload-Idfield', datauploadField);
                    span.attr('data-upload-Namefield', datauploadNamefield);
                    span.attr('data-upload-multiple', datauploadMultiplefield);

                    span.attr('data-upload-path', uploadElmt.attr('data-upload-path'));
                    span.hide();
                    uploadElmt.after(span);
                }
                if (datareadonly != "true") {

                    var removeCallback = 'null';
                    if (uploadElmt.attr('data-remove-callback') != '') {
                        removeCallback = uploadElmt.attr('data-remove-callback')
                    }
                    btn1.className = "btn";
                    btn1.setAttribute('id', obj.id + '_RemoveBtn');
                    btn1.setAttribute('onclick', '_.RemoveFile(\'' + uploadFormId + '\', \'' + uploadBindingProp + '\', \'' + uploadFormId + '\', ' + removeCallback + ')');
                    btn1.innerHTML = 'Remove File';
                    btn1.setAttribute('type', 'button');

                    var btn = document.createElement('button');
                    btn.className = "btn btn-primary btn-sm";
                    btn.setAttribute('id', obj.id + '_uploadBtn');


                    btn.setAttribute('onclick', 'uiBinder.ShowUploadForm(\'' + obj.id + '\', \'' + uploadBindingProp + '\', \'' + uploadFormId + '\', \'' + datauploadField + '\', \'' + datauploadNamefield + '\', \'' + datauploadMultiplefield + '\')');
                    btn.innerHTML = 'Upload File';
                    btn.setAttribute('type', 'button');
                    uploadElmt.after(btn);
                }

            }


        });

        // Loop through all tagged forms
        $("form[data-ui-binding='true']").each(function (key, elmt) {
            _.LogSuccess('Found Form for Binding[' + elmt.id + ']');


            var formName = elmt.name;
            var formElmt = $(elmt);

            // Validate Form Name is specified
            if (formName == null || formName.length == 0) {
                _.LogFailure("Form name attribute must be specified for UI Binding to work properly");
                return;
            }

            // Creating UI Binding from HTML Declarations
            if (!currentBinder.FormBindings[formName]) {
                var serviceName = formElmt.attr('data-service-object');
                var parameterName = formElmt.attr('data-parameter-name');
                currentBinder.InitializeForm(formName, window[serviceName]);

                if (parameterName && parameterName != null) {
                    var id = GetParameterByName(parameterName);
                    var fb = currentBinder.FormBindings[formName];

                    if (id != null) {
                        if (fb.associatedList && fb.associatedList != null) {
                            $('#' + fb.associatedList).parent().hide();
                        }

                        // Load Existing
                        
                        _.LoadForm(formName, id, true ,function (success, data) {
                            
                            if (success) {
                                _.LogSuccess('Successfully Logged Existing Form[' + formName + ']');
                                fb.ShowForm(true);
                                if (callback) { callback(success, data); }
                            }
                            else {
                                _.LogFailure('Failed to Load Existing Data[' + formName + ']:' + _.GetErrorMsg(data));
                                if (callback) { callback(success, data); }
                            }
                        });
                    }
                    else {
                        if (fb.associatedList && fb.associatedList != null) {
                            
                            fb.HideForm(true);
                        }
                    }
                }

            }
        });

        // Loop through all tagged tables
        $("table[data-ui-binding='true']").each(function (key, elmt) {
            _.LogSuccess('Found List for Binding[' + elmt.id + ']');


            var tableName = elmt.id;
            var tableElmt = $(elmt);

            // Validate Form Name is specified
            if (tableName == null || tableName.length == 0) {
                _.LogFailure("Table name attribute must be specified for UI Binding to work properly");
                return;
            }

            // Creating UI Binding from HTML Declarations
            if (!currentBinder.ListBindings[tableName]) {
                var serviceName = tableElmt.attr('data-service-object');
                currentBinder.InitializeList(tableName, window[serviceName]);
            }

        });




        // Initialize Upload Form
        if ($("#ajaxUploadForm").length > 0) {

            $("#ajaxUploadForm").ajaxForm({
                iframe: true,
                dataType: "json",
                beforeSubmit: function () {
                    $("#ajaxUploadForm").block({ message: 'Uploading file...' });
                },
                success: function (result) {
                    try {

                        if (!result.fileName) {
                            alert(result.message);
                        }
                        var fb = uiBinder.GetFormBinding(currentUploadFormId);

                        var jsonString = "{\"" + currentUploadNameField + "\":\"" + result.fileName.split('\\').pop() + "\", \"" + currentUploadIdField + "\": 0 }";
                        var modelSet = fb.model();

                        filenmae = result.fileName.split('\\').pop();

                        if (currentUploadFileMultiplicity == "true" || currentUploadFileMultiplicity == true) {
                            var modelSet = fb.model();
                            var jsonString = "{\"" + currentUploadNameField + "\":\"" + result.fileName.split('\\').pop() + "\", \"" + currentUploadIdField + "\": 0 }";
                            eval("if(modelSet." + currentUploadProperty + "== null) { modelSet." + currentUploadProperty + " = new Array(); } ");
                            eval("modelSet." + currentUploadProperty + ".push({ " + currentUploadNameField + ": \"" + result.fileName.split('\\').pop() + "\", " + currentUploadIdField + ": 0  });");
                            fb.model(modelSet);
                        }
                        else {
                            fb.SetValue(currentUploadProperty, filenmae);
                        }


                        $('#fileUploadPopUp').modal('hide');
                        $("#ajaxUploadForm").unblock();
                        $("#ajaxUploadForm").resetForm();
                        

                        _.LogSuccess(filenmae + ' upload successfully');
                    } catch (err) { _.LogFailure('Error: ' + err); }
                },
                error: function (xhr, textStatus, errorThrown) {
                    _.LogFailure("Upload Failed");
                    $("#ajaxUploadForm").unblock();
                    $("#ajaxUploadForm").resetForm();
                }
            });
        }

        if (callback) { callback(true); }

    }
    catch (err) {
        if (callback) { callback(false, err.message); }
        alert("Failed to Initialize UI Binder - " + err.message);
    }
}

UserInterfaceBinder.prototype.RemoveFile = function (uploadFormId, bindingProperty, formId, callback) {
    _.GetFormBinding(uploadFormId).SetValue(bindingProperty, '');
    if (callback) { callback(true, null); }
}

UserInterfaceBinder.prototype.CreateFormBinding = function (formName) {
    if (!this.FormBindings[formName]) {
        return new FormBinder();
    }
    return null;
}

UserInterfaceBinder.prototype.CreateListBinding = function (listName) {
    if (!this.ListBindings[listName]) {
        return new ListBinder();
    }
    return null;
}

UserInterfaceBinder.prototype.InitializeForm = function (formName, service) {
    try {
        _.LogInfo('Initializing Form [' + formName + ']');
        _.LogInfo('Initializing Service [' + service.entityName + ']');

        var firstLoad = true;

        if (!this.FormBindings[formName]) {
            this.FormBindings[formName] = this.CreateFormBinding(formName);
        }
        else {
            firstLoad = false; // flag to avoid applying Bindings twice
        }

        var fb = this.FormBindings[formName];
        window[formName] = fb;




        fb.id = formName;
        fb.detailsForm = $('#' + fb.id);
        fb.associatedList = fb.detailsForm.attr('data-associated-list');
        fb.parameterName = fb.detailsForm.attr('data-parameter-name');
        fb.childSerfvices = fb.detailsForm.attr('data-child-service');
        // Rig Up Callbacks
        fb.callback = window[fb.detailsForm.attr('data-callback')];
        fb.callbackNew = window[fb.detailsForm.attr('data-new-callback')];
        fb.callbackLoad = window[fb.detailsForm.attr('data-load-callback')];
        fb.callbackSave = window[fb.detailsForm.attr('data-save-callback')];
        fb.callbackPreSave = window[fb.detailsForm.attr('data-pre-save-callback')];
        fb.callbackDelete = window[fb.detailsForm.attr('data-delete-callback')];
        fb.callbackValidate = window[fb.detailsForm.attr('data-validate-callback')];
        fb.callbackValidate = window[fb.detailsForm.attr('data-validate-callback')];

        if (service == null) {
            fb.model(null);
            _.LogFailure('No associated service found for Form [' + formName + ']');
        }
        else {

            // Get Dynamic Lookups
            fb.lookupSettings = new Array();
            fb.detailsForm.find('select[data-dynamic-lookup="true"]').each(function (key, obj) {

                _.LogSuccess('Dynamic Lookup found [' + obj.id + ']');

                var elmt = $(obj);


                fb.lookupSettings[key] = new LookupSetting();
                var ls = fb.lookupSettings[key];

                ls.id = elmt.attr('data-lookup-id');
                ls.service = window[elmt.attr('data-lookup-service')];
                ls.loadByKey = elmt.attr('data-load-by-key');
                ls.includes = elmt.attr('data-includes');


            });


            // Get Error Display

            fb.detailsForm.find('[data-error-display="true"]').each(function (key, obj) {
                fb.errorDisplay = obj;
                _.LogSuccess('Validation Display found for [' + fb.id + ']');
            });

            // Bind Model
            this.FormBindings[formName].service = service;
            if (this.newModel == null) {
                service.GetModel(function (status, data) {

                    try {

                        if (status) {
                            _.LogSuccess('Successfully retrieved model for [' + fb.id + '] from entity [' + fb.service.entityName + ']');

                            
                            uiBinder.BindFormController(formName, data);
                            fb.newModel = _.Clone(data);
                            if (firstLoad) {
                                fb.Callbacks(true, actions.Load, data, null, fb.callbackLoad, { 'id': fb.model()[fb.service.entityKey], 'data': data, 'bindingId': fb.id });
                            }
                        }
                        else {
                            _.LogFailure('Failed to Get Model for [' + fb.id + ']');
                        }
                    }
                    catch (err) {
                        _.LogFailure('Failed to Bind Get Model to Form: [' + fb.id + '] - ' + err.message, true);
                    }
                });
            }
            else {
                uiBinder.BindFormController(formName, _.Clone(fb.newModel));
            }
            if (fb.childSerfvices) {
                var childservices = fb.childSerfvices.split(",");

                for (var i = 0; i < childservices.length; i++) {
                    GetChildDataModel(fb, childservices[i]);
                }
            }
        }

        fb.detailsWindow = fb.detailsForm.closest('div[class^="modal"]');

        _.LogInfo('Associating Validation...');
        var submitAction = fb.detailsForm.attr('data-submit-action');
        if (submitAction && submitAction != null && submitAction.length > 0) {
            eval("fb.validator = fb.detailsForm.validate({ submitHandler: function () { " + submitAction + "(); } });");
        }
        else {
            eval("fb.validator = fb.detailsForm.validate({ submitHandler: function () { uiBinder.GetFormBinding('" + fb.id + "').Save(); } });");
        }

        return fb;
    }
    catch (err) {
        _.LogFailure("Failed to Bind Form:" + formName + " - " + err.message);
    }
}

function GetChildDataModel(fb, childeservice) {
    window[childeservice].GetModel(function (status, data) {
        try {
            if (status) {
                fb.childModels[childeservice] = data;
            }
            else {
                _.LogFailure('Failed to Get Model for service [' + childeservice + ']');
            }
        }
        catch (err) {
            _.LogFailure('Failed to Bind Get Model for service: [' + childeservice + '] - ' + err.message, true);
        }
    });

}
UserInterfaceBinder.prototype.NewForm = function (formName, hideList, callback) {
    
    var fb = this.FormBindings[formName];

    fb.New(function (status, data) {
     
        if (fb.detailsWindow) {
            fb.validator.resetForm();
            fb.ShowForm(hideList);
        }
        var df = fb.detailsWindow.find("[data-default-focus='true']");
        if (df != null && df.length > 0) {
            setTimeout('$("#' + df[0].id + '").focus()', 400);
        }
    });
}

UserInterfaceBinder.prototype.Sort = function (listName, field, direction) {

    uiBinder.Log('Sort ' + listName + ' by ' + field);
    try {
        var lb = this.ListBindings[listName];

        if (direction != null) {
            lb.orderByDirection = direction;
        }
        else if (lb.orderByField != null && lb.orderByField == field) {
            if (lb.orderByDirection == 'ascending') {
                lb.orderByDirection = 'descending';
            }
            else {
                lb.orderByDirection = 'ascending';
            }
        }
        else {
            lb.orderByDirection = 'ascending';
        }
        lb.orderByField = field
        lb.orderBy = field + ' ' + lb.orderByDirection;
        lb.pageIndex = 0;
        this.GetBySearchAndFilter(listName);
    }
    catch (err) {
        alert("Failed to Sort:" + listName + " - " + err.message);
    }
}
UserInterfaceBinder.prototype.SortIndicator = function (lb, listName, field, direction) {

    // Remove Existing
    $('#' + listName).find('a[data-sort-field]').each(function (key, elmt) {
        $(elmt).next().removeClass();
    });

    var sortElement = $('#' + listName).find('a[data-sort-field="' + field + '"]');
    if (sortElement != null) {

        // Insert span if missing
        if (sortElement.next().length == 0 || sortElement.next()[0].localName != 'span') {
            sortElement.after('<span></span>');
        }

        // Insert sort icon
        var icon_dir = 'bottom';
        if (lb.orderByDirection == 'descending') { icon_dir = 'top'; }
        sortElement.next().removeClass().addClass('glyphicon glyphicon-triangle-' + icon_dir + ' sort-icon');
    }
}

UserInterfaceBinder.prototype.Search = function (listName, id, fields, searchTerm) {
    var lb = this.ListBindings[listName];

    lb.pageIndex = 0;
    lb.searchElement = id;
    lb.searchField = fields;
    lb.searchValue = searchTerm;

    if (lb.searchValue.length > 1 || lb.searchValue.length == 0) {
        this.GetBySearchAndFilter(listName);
    }
}


UserInterfaceBinder.prototype.Filter = function (listName, id, field, value) {

    try {
        var lb = this.ListBindings[listName];

        lb.pageIndex = 0;

        var newIndex = lb.filters.length;
        var found = false;
        for (var i = 0; i < lb.filters.length; i++) {
            if (lb.filters[i].Field == field) {
                newIndex = i;
                found = true;
                break;
            }
        }
        if (!found) {
            lb.filters[newIndex] = new ListFilter();
        }
        lb.filters[newIndex].id = id;
        lb.filters[newIndex].Field = field;
        lb.filters[newIndex].Value = value;

        this.GetBySearchAndFilter(listName);
    }
    catch (err) {
        alert("Failed to Filter:" + listName + " - " + err.message);
    }
}

UserInterfaceBinder.prototype.GetBySearchAndFilter = function (listName) {
    try {
        var lb = this.ListBindings[listName]
        var filter = '';

        // Add Search to Condition
        if (lb.searchFields && lb.searchValue && lb.searchValue != '') {

            var searchFields = lb.searchFields.split(",");

            for (i = 0; i < searchFields.length; i++) {

                if (filter.length != 0) {
                    filter += ' or ';
                }

                filter += searchFields[i] + '.Contains("' + lb.searchValue + '") ';
            }
        }
        else {
            lb.searchValue = null;
        }
if(filter != '')
        {
            filter = '( ' + filter + ' )';
        }
        // Add Filters to Condition
        if (lb.filters) {
            var af = this.BuildFilter(lb.filters);
            if (lb.searchValue != null && af != '') {
                filter += ' and ';
            }
            filter += af;
        }

        // Execute Search/Execute Filter, Execute Fields to Search, Execute Grouping...
        lb.service.GetList(lb.pageIndex, lb.pageSize, filter, lb.orderBy, lb.includes, function (status, data) {
            if (status) {
                uiBinder.BindListConroller(listName, data);
                if (lb.callbackLoad)
                    lb.callbackLoad(true, data);
            }
            else {
                uiBinder.Log('Failed to Get List[' + lb.id + ']:' + data.Error, true);
            }
            _.SortIndicator(lb, listName, lb.orderByField, lb.orderByDirection);
        }, lb.getListOverride);

    }
    catch (err) {
        alert("Failed to Bind List:" + listName + " - " + err.message);
    }
}

UserInterfaceBinder.prototype.BuildFilter = function (filters) {

    var filter = '';

    for (var i = 0; i < filters.length; i++) {
        if (filters[i].Value != '') {
            if (filter.length != 0) {
                filter += ' and ';
            }
            filter += filters[i].Field + ' == ' + filters[i].Value;
        }
    }

    return filter;
}

UserInterfaceBinder.prototype.LoadForm = function (formName, id, hideList, callback) {
    
    var fb = this.FormBindings[formName];
    if (fb) {
        if (fb.detailsWindow) {
            fb.ShowForm(hideList);
        }
        fb.Load(id, function (status, data) {
            if (callback != null) {
                callback(status, data);
            }
        });
    }
    else {
        alert('Framework: Form Binding [' + formName + '] was not found');
    }
}


UserInterfaceBinder.prototype.BindNGAttributes = function (id, binder) {

    var Name = id;
    var appText = $("#" + Name).attr("ng-app");
    if (appText == undefined || appText == null || appText == "") {
        $("#" + Name).attr("ng-app", Name + "App");
        $("#" + Name).attr("ng-controller", Name + "Ctrl");
        var app = angular.module(Name + "App", []);

        binder.app = app;
        app.controller(Name + "Ctrl", function ($scope) {
            $scope.rows = [];
        });

        for (var i = 0; i < _.Directives.length; i++) {
            app.directive(_.Directives[i].Name, _.Directives[i].Func)
        }


        angular.bootstrap(document.getElementById(Name), [Name + "App"]);





    }

}

UserInterfaceBinder.prototype.Clone = function (obj) {
    return $.extend(true, {}, obj);
}

UserInterfaceBinder.prototype.InitializeList = function (listName, service) {

    try {

        var firstLoad = true;

        if (!this.ListBindings[listName]) {
            this.ListBindings[listName] = this.CreateListBinding(listName);
        }
        else {
            firstLoad = false;
        }




        var lb = this.ListBindings[listName];
        window[listName] = lb;
        var mastList = $('#' + listName);
        lb.initialLoad = mastList.attr('data-default-initial-load');
        if (lb.initialLoad != 'false') {
            loading(listName, true);
        }
        lb.callbackLoad = window[mastList.attr('data-load-callback')];



        lb.id = listName;

        // Find Search Boxes
        $("input[data-search-list='" + listName + "']").each(function (key, elmt) {

            var list = $(elmt);
            lb.searchFields = list.attr('data-search-fields');
            if (list.attr('data-default-focus') != null) {
                $(elmt).focus();
            }



            elmt.onkeyup = function () {
                globalKeyCount++;

                var me = $(this);
                setTimeout("delayedSearch(" + globalKeyCount + ", '" + me.attr('data-search-list') + "', '" + me.attr('id') + "', '" + me.attr('data-search-fields') + "', '" + me.val() + "')", 400);
            }
        });

        //apply sorting
        $('#' + listName).find("a").each(function (key, elmt) {

            var dataSortField = $(elmt).attr('data-sort-field');

            if (dataSortField) {
                $(elmt).attr('href', "javascript:uiBinder.Sort('" + listName + "', '" + dataSortField + "');");
            }

        });
        var filterIndex = 0;
        // Find Filters
        $("select[data-filter-list='" + listName + "']").each(function (key, elmt) {

            var obj = $(elmt);
            if (!obj.attr('id')) { alert('data-filter-list attribute requires id specified on the element'); }
            lb.filters[filterIndex] = new ListFilter();
            lb.filters[filterIndex].id = obj.attr('id');
            lb.filters[filterIndex].Field = obj.attr('data-filter-field');
            lb.filters[filterIndex].Value = obj.val();

            elmt.onchange = function () {
                var me = $(this);
                uiBinder.Filter(me.attr('data-filter-list'), me.attr('id'), me.attr('data-filter-field'), me.val());
            }
            filterIndex++;
        });

        if (lb.filters) {
            lb.filter = this.BuildFilter(lb.filters);
        }


        if (service == null) {
            lb.rows = null;
        }
        else {
            this.ListBindings[listName].service = service;


            lb.orderBy = mastList.attr('data-default-orderby');

            if (!lb.orderBy) lb.orderBy = null;
            lb.includes = mastList.attr('data-includes');
            if (!lb.includes) lb.includes = null;


            // Set Page Size is Specified
            var pageSize = mastList.attr('data-page-size');
            if (pageSize)
                lb.pageSize = pageSize;

            // Override Methods
            lb.getListOverride = mastList.attr('data-getlist-override');


            lb.detailsForm = mastList.attr('data-details-form');
            if (lb.initialLoad != 'false') {
                service.GetList(lb.pageIndex, lb.pageSize, lb.filter, lb.orderBy, lb.includes, function (status, data) {
                    if (status) {
                        _.LogSuccess('Successfully retrieved Get List for [' + lb.id + ']');
                        uiBinder.BindListConroller(listName, data);
                        if (lb.callbackLoad)
                            lb.callbackLoad(true, data);
                       

                    }
                    else {
                        _.LogFailure('Failed to Get List[' + lb.id + ']:' + _.GetErrorMsg(data), true);
                        lb.callbackLoad(false, data);
                    }
                    _.SortIndicator(lb, listName, lb.orderByField, lb.orderByDirection);
                    loading(listName, false);
                }, lb.getListOverride);
            }
            else {
                loading(listName, false);
            }
        }
    }
    catch (err) {
        alert("Failed to Bind List:" + listName + " - " + err.message);
        loading(listName, false);
    }

}

UserInterfaceBinder.prototype.GetListBinding = function (listName) {
    try {
        return this.ListBindings[listName]
    }
    catch (err) {
        alert("Framework: Failed to Find List Binding:" + listName + " - " + err.message);
    }
}

UserInterfaceBinder.prototype.GetFormBinding = function (formName) {
    try {
        return this.FormBindings[formName]
    }
    catch (err) {
        alert("Failed to Find Form Binding:" + formName + " - " + err.message);
    }
}

UserInterfaceBinder.prototype.ShowUploadForm = function (elementId, bindingProperty, formId, datauploadIdField, datauploadNameField, datauploadMultiplefield) {

    //  Set global variables for tracking upload
    currentUploadElmt = elementId;
    currentUploadProperty = bindingProperty;
    currentUploadFormId = formId;
    currentUploadNameField = datauploadNameField;
    currentUploadIdField = datauploadIdField;
    currentUploadFileMultiplicity = datauploadMultiplefield;
    // Set Value

    $('#fileUploadPopUp').modal({ backdrop: true }).css({
       
    });

    // Show Upload Popup
    $('#fileUploadPopUp').modal('show');
}

UserInterfaceBinder.prototype.BindListConroller = function (listName, data) {
    var lb = this.ListBindings[listName];

    this.BindNGAttributes(listName, lb);
    try {       
        if (data.TotalRows != null) {
            var totalPages = 0;
            lb.TotalRows = data.TotalRows;
            totalPages = parseInt(data.TotalRows / lb.pageSize, 10);

            if (data.TotalRows % lb.pageSize != 0) {
                totalPages = totalPages + 1;
            }
            lb.totalPages = totalPages;
            var startPageText = ((lb.pageIndex * lb.pageSize) + 1);
            var endPageText = (parseInt(data.List.length) + (lb.pageIndex * lb.pageSize));
            var stringText = startPageText + "-" + endPageText + " of " + lb.TotalRows + " ";
            lb.pageText = stringText;




            var appElement = document.querySelector('[ng-app=' + listName + 'App]');
            var $scope = angular.element(appElement).scope();

            $scope.$apply(function () {
                $scope.rows = data.List;
                $scope.TotalRows = lb.TotalRows;
                $scope.totalPages = lb.totalPages;
                $scope.pageText = lb.pageText;
                $scope.pageIndex = lb.pageIndex;
                $scope.pageSize = lb.pageSize;
                $scope.lb = lb;
                $scope.ub = _;
            });
        }
        else {
            var appElement = document.querySelector('[ng-app=' + listName + 'App]');
            var $scope = angular.element(appElement).scope();
            $scope.$apply(function () {
                $scope.rows = data.List;
            });

        }
        uiBinder.Log('Successfully retrieved Get List for [' + lb.id + ']');


    }
    catch (err) {
        uiBinder.Log('Failed to Get List[' + lb.id + ']:' + err, true);
    }
    loading(listName, false);

}

UserInterfaceBinder.prototype.BindFormController = function (formName, data) {
    var fb = this.FormBindings[formName];
    _.BindNGAttributes(formName, fb);
    
    fb.model(data);

    loading(formName, false);
}


/*--------------------------------------------------------------------------------------
    FormBinder Class -
    Declares a class for managing the state of form binding
----------------------------------------------------------------------------------------*/
function FormBinder() {
    this.id;
    this.model;
    this.rawData;
    this.service;
    this.app;

    this.newModel = null;
    this.detailsForm;
    this.detailsWindow;
    this.detailsFormDimmer;
    this.formContainer;
    this.validator;
    this.focusField;
    this.errorDisplay;
    this.associatedList;
    this.parameterName;
    this.callback = null;
    this.callbackLoad = null;
    this.callbackNew = null;
    this.callbakDelete = null;
    this.callbackPreSave = null;
    this.callbackSave = null;
    this.callbackValidate = null;
    this.childSerfvices = null;
    this.childModels = new Array();;
    this.lookups = new Array();
    this.lookupSettings = new Array();

}

FormBinder.prototype.Submit = function () {

    this.detailsForm.submit();
}


FormBinder.prototype.HideForm = function (showList) {
    if (this.detailsWindow) {
        $('#' + this.id).parent().hide();

        if (showList && this.associatedList) {
            $('#' + this.associatedList).parent().show();
        }
    }
}

FormBinder.prototype.ShowForm = function (hideList) {
    if (this.detailsWindow) {
        $('#' + this.id).parent().show();

        if (hideList && this.associatedList) {
            $('#' + this.associatedList).parent().hide();
        }
    }
}

FormBinder.prototype.SaveForm = function () {
    this.Save(null);
}

FormBinder.prototype.Save = function (callback) {
    debugger;
    var fb = this;
    fb.ClearError();

    // Capture Custom Validation
    if (this.callbackValidate && !this.callbackValidate()) {
        return;
    }


    var obj = fb.model();

    // Save Primary Record
    this.service.Save(obj, function (success, data) {
        if (success) {
            fb.HideForm(true);

            // Refresh the Associated Grid
            if (fb.associatedList != null && fb.associatedList != '') {
                uiBinder.GetListBinding(fb.associatedList).RefreshData();
            }

            // Callback
            fb.Callbacks(true, actions.Save, data, callback, fb.callbackSave, { 'id': fb.model()[fb.service.entityKey], 'data': data, 'bindingId': fb.id });
        }
        else {
            if (data.ExceptionMessage) {
                fb.DisplayError(data.ExceptionMessage);
            }
            else if (data.Error) {
                fb.DisplayError(data.Error);
            }

            // Callback
            fb.Callbacks(false, actions.Save, data, callback, fb.callbackSave, { 'id': fb.model()[fb.service.entityKey], 'data': data, 'bindingId': fb.id });
        }
    });

}


FormBinder.prototype.DeleteChild = function (index, collectionName, serviceName, confirmDelete, callback) {

    var fb = this;
    fb.ClearError();
    if (confirmDelete) {
        if (!confirm('Are you sure you want to delete this item?')) {
            return;
        }
    }
    var service = window[serviceName];
    var obj = fb.model()[collectionName][index];
    if (obj[service.entityKey] == 0) {
        fb.model()[collectionName].splice(index, 1);
    }
    else {
        service.Delete(obj[service.entityKey], function (success, data) {
            if (success) {

                var array = fb.model()[collectionName];
                array.splice(index, 1);
                var model = fb.model();
                model[collectionName] = array;
                fb.model(model);
            }
            else {
                alert('Failed to delete item');
            }
        });
    }
}

FormBinder.prototype.New = function (callback) {
    
    var fb = this;
    fb.ClearError();
    if (fb.newModel == null) {
        this.service.GetModel(function (success, data) {
            if (success) {

                // Attempt to bind custom viewModel is not specified on initialization
                if (fb.model() == null) {
                    fb.model(data);

                    if (fb.detailsForm != null) {
                        uiBinder.BindFormController(fb.detailsForm[0].name, data);
                    }
                }

                fb.rawData = data;
                fb.LoadLookups(function (status) {

                    // Update Mapping Values
                    uiBinder.BindFormController(fb.detailsForm[0].name, data);

                    // Callback
                    fb.Callbacks(true, actions.New, null, callback, fb.callbackNew, null);
                });
            }
            else {
                if (data.ExceptionMessage) {
                    fb.DisplayError(data.ExceptionMessage);
                }
                else if (data.Error) {
                    fb.DisplayError(data.Error);
                }

                // Callback
                fb.Callbacks(false, actions.New, null, callback, fb.callbackNew, null);
            }
        });
    }
    else {
        fb.model(_.Clone(fb.newModel));
        fb.Callbacks(true, actions.New, null, callback, fb.callbackNew, null);
    }
}

FormBinder.prototype.Load = function (id, callback) {

    var fb = this;
    fb.ClearError();

    this.service.GetById(id, function (success, data) {
        if (success) {


            // Attempt to bind custom viewModel is not specified on initialization
            if (fb.model() == null) {
                //    


                fb.model(data);

                if (fb.detailsForm != null) {

                    uiBinder.BindFormController(fb.detailsForm[0].name, data);
                }
            }

            fb.rawData = data;  // Load raw data for lookup values

            fb.LoadLookups(function (status) {

                // Update Mapping Values
                uiBinder.BindFormController(fb.detailsForm[0].name, data);

                // Callbacks
                fb.Callbacks(true, actions.Load, data, callback, fb.callbackLoad, { 'id': id, 'data': data, 'bindingId': fb.id });
            });
        }
        else {
            if (data.ExceptionMessage) {
                fb.DisplayError(data.ExceptionMessage);
            }
            else if (data.Error) {
                fb.DisplayError(data.Error);
            }


            // Callbacks
            fb.Callbacks(false, actions.Load, data, callback, fb.callbackLoad, { 'id': id, 'data': data, 'bindingId': fb.id });
        }
    });
}

FormBinder.prototype.Delete = function (id, callback) {
    var fb = this;
    fb.ClearError();

    this.service.Delete(id, function (success, data) {
        if (success) {

            // Callbacks
            fb.Callbacks(true, actions.Delete, data, callback, fb.callbackDelete, { 'id': id, 'data': data, 'bindingId': fb.id });
        }
        else {
            if (data.ExceptionMessage) {
                fb.DisplayError(data.ExceptionMessage);
            }
            else if (data.Error) {
                fb.DisplayError(data.Error);
            }

            // Callbacks
            fb.Callbacks(false, actions.Delete, data, callback, fb.callbackDelete, { 'id': id, 'data': data, 'bindingId': fb.id });
        }
    });
}

FormBinder.prototype.Callbacks = function (status, action, data, paramCallback, specificCallback, params) {

    if (this.callback) { this.callback(status, action, params); }
    if (specificCallback) { specificCallback(status, params); }
    if (paramCallback) { paramCallback(status, data); }
}

FormBinder.prototype.AddChild = function (collectionName, service) {
    var ref = collectionName;
    var fb = this;
    if (fb.childModels[service]) {
        var childModel = _.Clone(fb.childModels[service]);
        var parentobject = this.model();
        parentobject[collectionName].push(childModel);
        // this.model(parentobject);
    }
}

FormBinder.prototype.LoadLookups = function (callback) {

    var fb = this;

    for (var i = 0; i < this.lookupSettings.length; i++) {

        var ls = fb.lookupSettings[i];

        if (fb.rawData != null && fb.rawData[ls.loadByKey] != null) {
            ls.service.GetList(null, null, ls.loadByKey + ' == ' + fb.rawData[ls.loadByKey], null, ls.includes, function (success, data) {
                fb.lookups[ls.id] = data;

                if (callback) { callback(true, data); }
            });
        }
        else {

            ls.service.GetList(null, null, null, null, ls.includes, function (success, data) {
                fb.lookups[ls.id] = data;
                if (callback) { callback(true, data); }
            });

            if (callback) { callback(true, null); }
        }
    }
    if (callback) { callback(true, null); }
}

FormBinder.prototype.RefreshLookup = function (lookupId, overrideId, callback) {
    var fb = this;

    for (var i = 0; i < this.lookupSettings.length; i++) {
        if (fb.lookupSettings[i].id == lookupId) {

            var ls = fb.lookupSettings[i];

            if (fb.rawData != null && fb.model()[ls.loadByKey]() != null && fb.model()[ls.loadByKey]() != '') {

                var val = fb.model()[ls.loadByKey]()
                if (overrideId) {
                    val = overrideId;
                }

                ls.service.GetList(null, null, ls.loadByKey + ' == ' + val, null, ls.includes, function (success, data) {
                    
                    if (!fb.lookups[ls.id]) {
                       
                    }
                    else {
                        fb.lookups[ls.id](data);
                    }
                    if (callback) { callback(true, data); }
                });
            }
        }
    }

}

FormBinder.prototype.DisplayError = function (msg) {
    if (this.errorDisplay) {
        $(this.errorDisplay).html('<div class="errMsg">' + msg + '</div>');
    }
}


FormBinder.prototype.AppendError = function (msg) {
    if (this.errorDisplay) {
        $(this.errorDisplay).append('<div class="errMsg">' + msg + '</div>');
    }
}


FormBinder.prototype.ClearError = function () {
    if (this.errorDisplay) {
        $(this.errorDisplay).html('');
    }
}


FormBinder.prototype.model = function (data) {
    var formName = this.detailsForm[0].name;
    var fb = uiBinder.FormBindings[formName];
    if (data != undefined) {

        var appElement = document.querySelector('[ng-app=' + formName + 'App]');
        var $scope = angular.element(appElement).scope();
        $scope.$apply(function () {
            $scope.model = data;
            $scope.fb = fb;
            $scope.ub = _;
        });
    }
    else {
        var appElement = document.querySelector('[ng-app=' + formName + 'App]');
        var $scope = angular.element(appElement).scope();
        return $scope.model;
    }
}



FormBinder.prototype.DeleteUploadFile = function (index, propertyName) {

    var modelLocal = this.model();
    modelLocal[propertyName].splice(index, 1);
    this.model(modelLocal);
    return false;
}


FormBinder.prototype.SetValue = function (field, value) {
    var data = this.model();
    data[field] = value;
    this.model(data);
}

FormBinder.prototype.GetValue = function (field) {
    var data = this.model();
    return data[field];

}





/*--------------------------------------------------------------------------------------
    ListBinder Class -
    Declares a class for managing the state of binding a list to data
----------------------------------------------------------------------------------------*/
var DEFAULT_PAGE_SIZE = '10';

// Binder for Tables, Dropdowns and Unordered Lists
function ListBinder() {
    this.id;
    this.service;
    this.rows;
    this.app;
    this.TotalRows = 1;
    this.totalPages = 1;
    this.pageIndex = 0;
    this.pageSize = DEFAULT_PAGE_SIZE;
    this.pageText = '';
    this.callbackLoad = null;
    this.detailsForm;
    this.filter = null;
    this.orderBy = null;
    this.orderByField = null;
    this.orderByDirection = 'ascending';
    this.includeProperties;
    this.listElement;
    this.errorDisplay;
    this.searchElement;
    this.searchField;
    this.searchValue;
    this.initialLoad = true;
    this.filters = new Array();
    this.includes = '';
    this.getListOverride = null;
}

function ListFilter() {
    this.id = null;
    this.Field = '';
    this.Value = null;
}

ListBinder.prototype.Delete = function (id, message, callback) {
    var lb = this;

    event.cancelBubble = true;

    if (message != null && message.length > 0) {
        if (!confirm(message)) {
            return;
        }
    }

    this.service.Delete(id, function (success, data) {
        if (success) {
            lb.RefreshData();
            if (callback) { callback(true, data); }
        }
        else {
            if (callback) { callback(false, data); }
        }
    });

}

ListBinder.prototype.PageFirst = function (callback) {
    this.pageIndex = 0;
    this.RefreshData();
}

ListBinder.prototype.PagePrevious = function (callback) {

    if (this.pageIndex > 0) {
        this.pageIndex = this.pageIndex - 1;
        this.RefreshData();
    }
}

ListBinder.prototype.PageNext = function (callback) {

    if (this.pageIndex < this.totalPages - 1) {
        this.pageIndex = this.pageIndex + 1;
        this.RefreshData();
    }
}

ListBinder.prototype.PageLast = function (callback) {
    if (this.pageIndex != this.totalPages - 1) {
        this.pageIndex = this.totalPages - 1;
        this.RefreshData();
    }
}


ListBinder.prototype.RefreshData = function (callback) {
    var lb = this;

    uiBinder.GetBySearchAndFilter(lb.id);
}

//---------------------------------------------
// Lookup Setting 
//---------------------------------------------
function LookupSetting() {
    this.id;
    this.service;
    this.loadByKey;
    this.includes;
    this.getMethod;
    this.callback;
}

//---------------------------------------------
// Child Records 
//---------------------------------------------

//---------------------------------------------
// Default Global UI Binder
//---------------------------------------------
var uiBinder = new UserInterfaceBinder();
var _ = uiBinder;

//---------------------------------------------
// Support Searching only after done typing
//---------------------------------------------
var globalKeyCount = 0;

function delayedSearch(keyCount, searchList, id, searchFields, value) {
    if (keyCount == globalKeyCount) {
        uiBinder.Search(searchList, id, searchFields, value);
    }
}

//---------------------------------------------
// Load Animations
//---------------------------------------------
function loading(elmt_name, show) {

    if (show) {
        if ($('#' + elmt_name + '_loading').length > 0) {
            $('#' + elmt_name + '_loading').show();
        }
        else {
            $('#' + elmt_name).append("<div id='" + elmt_name + "_loading' class='loading_window'><img src='/Images/loading.gif' alt='Loading...'/><br/>Loading...</div>")
        }
    }
    else {
        if ($('#' + elmt_name + '_loading').length > 0) {
            $('#' + elmt_name + '_loading').hide();
        }
    }
}

//---------------------------------------------------------------
//  Affirma Common Javascript and knockout Extension Functions
//---------------------------------------------------------------
Number.prototype.isNumeric = function () {
    var n = this;
    return !isNaN(parseFloat(n)) && isFinite(n);
}

Number.prototype.toCurrency = function () {

    var strValue = this;
    strValue = strValue.toString().replace(/\$|\,/g, '');
    dblValue = parseFloat(strValue);

    blnSign = (dblValue == (dblValue = Math.abs(dblValue)));
    dblValue = Math.floor(dblValue * 100 + 0.50000000001);
    intCents = dblValue % 100;
    strCents = intCents.toString();
    dblValue = Math.floor(dblValue / 100).toString();
    if (intCents < 10)
        strCents = "0" + strCents;
    for (var i = 0; i < Math.floor((dblValue.length - (1 + i)) / 3) ; i++)
        dblValue = dblValue.substring(0, dblValue.length - (4 * i + 3)) + ',' +
		dblValue.substring(dblValue.length - (4 * i + 3));
    return (((blnSign) ? '' : '-') + '$' + dblValue + '.' + strCents);
}
Number.prototype.padLeft = function (base, chr) {
    var len = (String(base || 10).length - String(this).length) + 1;
    return len > 0 ? new Array(len).join(chr || '0') + this : this;
}
String.prototype.parseFloat = function () {
    var obj = this;
    obj = obj.replace(",", "");
    return parseFloat(obj).toFixed(2);
}
Number.prototype.customFormat = function () {
    var obj = this;
    obj = numberWithCommas(obj.toFixed(2));
    return obj;
}
function CancelBubble() {
    var evt = window.event;
    if (evt.stopPropagation) evt.stopPropagation();
    if (evt.cancelBubble != null) evt.cancelBubble = true;
}

var weekday = new Array(7);
weekday[0] = "Mon";
weekday[1] = "Tues";
weekday[2] = "Wed";
weekday[3] = "Thur";
weekday[4] = "Fri";
weekday[5] = "Sat";
weekday[6] = "Sun";

function convertISODate(date) {
    try {
        date = new String(date);
        var d = date.split("T")[0]
        return new Date(d.split("-")[0], d.split("-")[1] - 1, d.split("-")[2]);
    }
    catch (err) {
        return date;
    }
}



function numberWithCommas(x) {
    var parts = x.toString().split(".");
    parts[0] = parts[0].replace(/\B(?=(\d{3})+(?!\d))/g, ",");
    //setColorToRed(x);
    return parts.join(".");
}



function GetParameterByName(name) {
    url = window.location.href;
    url = url.toLowerCase(); // This is just to avoid case sensitiveness  
    name = name.replace(/[\[\]]/g, "\\$&").toLowerCase();// This is just to avoid case sensitiveness for query parameter name
    var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"),
        results = regex.exec(url);
    if (!results) return null;
    if (!results[2]) return '';
    return decodeURIComponent(results[2].replace(/\+/g, " "));
}

_.Directives.push({
    Name: 'datePicker',
    Func: function () {
        return {
            restrict: 'A',

            require: 'ngModel',
            link: function (scope, element, attr, ngModel) {

                ngModel.$formatters.push(function (value) {
                    if (value == "0001-01-01T00:00:00")
                        return "";
                    else if (value == null || value == "")
                        return "";
                    else {
                        value = value.replace("T00:00:00", "")
                        var date = new Date(value);
                        var dformat = [(date.getMonth() + 1).padLeft(),
                        date.getDate().padLeft(),
                        date.getFullYear()].join('/');
                        return dformat;
                    }
                });
                $(element).datepicker();
            }
        }
    }
});
_.Directives.push({
    Name: 'formatNumber',
    Func: function () {
        return {
            restrict: 'A',

            require: 'ngModel',
            link: function (scope, element, attr, ngModel) {


                ngModel.$parsers.push(function (value) {
                    if (value) {
                        value = value.replace(',', '');
                        return value;
                    }
                    else {
                        return null;
                    }
                });



                $(element).change(function () {

                    var val = numberWithCommas(this.value);
                    $(this).val(val);
                });

            }
        }
    }
});

_.Directives.push({
    Name: 'formatMoney',
    Func: function () {
        return {
            restrict: 'A',

            require: 'ngModel',
            link: function (scope, element, attr, ngModel) {


                ngModel.$parsers.push(function (value) {
                    if (value) {
                        value = value.replace(',', '');
                        value = value.replace('$', '');
                        return value;
                    }
                    else {
                        return null;
                    }
                });

                ngModel.$formatters.push(function (value) {

                    if (value && value != "") {
                        var val = '$' + numberWithCommas(value.toFixed(2));

                        return val;
                    }
                    return "";
                });

                $(element).change(function () {
                    var val = '$' + numberWithCommas(parseFloat(this.value.replace(",", "").replace("$", "")).toFixed(2));
                    if (this.value != "") {
                        $(this).val(val);
                    }
                });

            }
        }
    }
});


_.Directives.push({
    Name: 'formatSelectid',
    Func: function () {
        return {
            restrict: 'A',

            require: 'ngModel',
            link: function (scope, element, attr, ngModel) {


                ngModel.$parsers.push(function (value) {

                    if (value) {
                        return parseInt(value);
                    }
                    else {
                        return null;
                    }
                });

                ngModel.$formatters.push(function (value) {

                    if (value) {


                        return value + "";
                    }
                    return "";
                });



            }
        }
    }
});

_.Directives.push({
    Name: 'numericOnly',
    Func: function () {
        return {
            require: 'ngModel',
            link: function (scope, element, attrs, modelCtrl) {

                modelCtrl.$parsers.push(function (inputValue) {
                    var transformedInput = inputValue ? inputValue.replace(/[^\d.-]/g, '') : null;

                    if (transformedInput != inputValue) {
                        modelCtrl.$setViewValue(transformedInput);
                        modelCtrl.$render();
                    }

                    return transformedInput;
                });
            }
        }
    }
});

