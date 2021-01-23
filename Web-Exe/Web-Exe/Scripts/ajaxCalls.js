function ajaxCall(method, api, data, successCB, errorCB) {
    // load - show loading icon
    load = true;
    if (method == "PUT")
        load = false;
    $.ajax({
        type: method,
        url: api,
        data: data,
        cache: false,
        contentType: "application/json",
        dataType: "json",
        success: successCB,
        error: errorCB,
        global: load
    });
}