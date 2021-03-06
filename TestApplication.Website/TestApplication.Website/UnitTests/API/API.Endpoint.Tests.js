﻿(function () {
    QUnit.config.testTimeout = 10000;

    var stringformat = QUnit.stringformat;

    module('Web API GET Endpoints respond successfully');

    var apiUrls = [
        '/api/lookups/all',
        '/api/lookups/rooms',
        '/api/lookups/subjects',
        '/api/lookups/lessons',


        '/api/teachers/',
        '/api/teachers/1',
        '/api/pupils/1',
        '/api/pupils',
        '/api/lessons/',
        '/api/lessons/2',
        '/api/rooms',
        '/api/rooms/2',
        '/api/subjects',
        '/api/subjects/2',

        // Find the Attendance with personId==2 && sessionId==1
        //'/api/attendance/?pid=2&sid=1'

    ];


    var apiUrlslen = apiUrls.length;

    // Test only that the Web API responded to the request with 'success'
    var endpointTest = function (url) {
        $.ajax({
            url: url,
            dataType: 'json',
            success: function (result) {
                ok(true, 'GET succeeded for ' + url);
                ok(!!result, 'GET retrieved some data');
                start();
            },
            error: function (result) {
                ok(false,
                    stringformat('GET on \'{0}\' failed with status=\'{1}\': {2}',
                        url, result.status, result.responseText));
                start();
            }
        });
    };

    // Returns an endpointTest function for a given URL
    var endpointTestGenerator = function (url) {
        return function () { endpointTest(url); };
    };

    // Test each endpoint in apiUrls
    for (var i = 0; i < apiUrlslen; i++) {
        var apiUrl = apiUrls[i];
        asyncTest(
            'API can be reached: ' + apiUrl,
            endpointTestGenerator(apiUrl));
    };
})();