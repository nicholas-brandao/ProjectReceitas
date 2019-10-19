function getData(url, fnRetorno, async, errMessage) {
    $.ajax({
        url: url,
        type: "GET",
        dataType: "json",
        async: async != undefined ? async : false,
        cache: false,
        beforeSend: function () {
            $.blockUI({
                baseZ: 9999999999999,
                message: '<img src="/img/loading.gif" />',
                css: { backgroundColor: 'transparent', border: 'none' }
            });
        },
        success: function (data) {
            if (typeof (fnRetorno) == "function")
                fnRetorno(data);
        },
        complete: function () {
            $.unblockUI();
        }
    });
}
function postData(url, data, fnRetorno, async, errMessage) {
    $.ajax({
        url: url,
        type: "POST",
        dataType: "json",
        contentType: "application/json",
        async: async != undefined ? async : false,
        cache: false,
        data: JSON.stringify(data),
        beforeSend: function () {
            $.blockUI({
                baseZ: 9999999999999,
                message: '<img src="/img/loading.gif" />',
                css: { backgroundColor: 'transparent', border: 'none' }
            });
        },
        success: function (data) {
            if (typeof (fnRetorno) == "function")
                fnRetorno(data);
        },
        complete: function () {
            $.unblockUI();
        },
        error: function (errMessage) {
            console.log(errMessage);
        }
    });
}
function postFormData(url, data, fnRetorno, async, errMessage) {
    $.ajax({
        url: url,
        type: "POST",
        dataType: "json",
        contentType: "application/json",
        async: async != undefined ? async : false,
        cache: false,
        data: data,
        processData: false,
        contentType: false,
        beforeSend: function () {
            $.blockUI({
                baseZ: 9999999999999,
                message: '<img src="/img/loading.gif" />',
                css: { backgroundColor: 'transparent', border: 'none' }
            });
        },
        success: function (data) {
            if (typeof (fnRetorno) == "function")
                fnRetorno(data);
        },
        complete: function () {
            $.unblockUI();
        },
        error: function (errMessage) {
            console.log(errMessage);
        }
    });
}