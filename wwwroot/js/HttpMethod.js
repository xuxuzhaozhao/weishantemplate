var Http = (function ($, storage, self) {
    var _contentType = 'application/json; charset=utf-8',
        _dataType = 'json',
        _key = 'token';

    function getToken() {
        return "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiMSIsImV4cCI6MTU5NDA5MTk1OCwiaXNzIjoid2Vpc2hhbi50ZWNoIiwiYXVkIjoiV2ViQXBpIn0.ua2XetM0L7icXiyiv8d3ZjY6csOioAO-hSdmB69HkVA"

        return storage.getItem(_key);
    }

    function setAuthHeader(xhr) {
        var token = getToken();
        if (!token) return;
        xhr.setRequestHeader('Authorization', 'Bearer ' + token);
    }

    function get(url) {
        var method = 'GET';
        var deferred = $.Deferred();
        ajax({
            deferred: deferred,
            method: method,
            url: url
        });
        return deferred.promise();
    }

    function post(url, payload) {
        var method = 'POST';
        var deferred = $.Deferred();
        var json = JSON.stringify(payload);
        ajax({
            deferred: deferred,
            json: json,
            method: method,
            url: url
        });
        return deferred.promise();
    }

    function patch(url, payload) {
        var method = 'PATCH';
        var deferred = $.Deferred();
        var json = JSON.stringify(payload);
        ajax({
            deferred: deferred,
            json: json,
            method: method,
            url: url
        });
        return deferred.promise();
    }

    function put(url, payload) {
        var method = 'PUT';
        var deferred = $.Deferred();
        var json = JSON.stringify(payload);
        ajax({
            deferred: deferred,
            json: json,
            method: method,
            url: url
        });
        return deferred.promise();
    }

    function del(url) {
        var method = 'DELETE';
        var deferred = $.Deferred();
        ajax({
            deferred: deferred,
            method: method,
            url: url,
        });
        return deferred.promise();
    }

    function ajax(cfg) {
        $.ajax({
            type: cfg.method,
            crossDomain: true,
            url: cfg.url,
            data: cfg.json,
            contentType: _contentType,
            dataType: _dataType,
            beforeSend: setAuthHeader,
            success: function (response) {
                cfg.deferred.resolve(response);
            },
            error: function (xhr, ajaxOptions, thrownError) {
                cfg.deferred.reject(thrownError);
            }
        });
    }

    self.post = post;
    self.patch = patch;
    self.put = put;
    self.get = get;
    self.delete = del;
    return self;
}($, window.localStorage, Http || {}));